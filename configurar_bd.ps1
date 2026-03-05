# Script para configurar la base de datos automáticamente
# Sistema de Ventas - Setup Rápido

Write-Host "========================================" -ForegroundColor Cyan
Write-Host " CONFIGURACIÓN BASE DE DATOS" -ForegroundColor Cyan
Write-Host " Sistema de Ventas" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Buscar el archivo SQL
$sqlFile = Join-Path $PSScriptRoot "setup_database.sql"

if (-not (Test-Path $sqlFile)) {
    Write-Host "❌ ERROR: No se encuentra el archivo setup_database.sql" -ForegroundColor Red
    Write-Host "   Ubicación esperada: $sqlFile" -ForegroundColor Yellow
    pause
    exit 1
}

Write-Host "✓ Archivo SQL encontrado" -ForegroundColor Green
Write-Host ""

# Intentar detectar la instancia de SQL Server
Write-Host "🔍 Buscando instancias de SQL Server..." -ForegroundColor Yellow

$instances = @(".", ".\SQLEXPRESS", "localhost", "localhost\SQLEXPRESS", "(localdb)\MSSQLLocalDB")
$serverFound = $null

foreach ($instance in $instances) {
    Write-Host "   Probando: $instance" -ForegroundColor Gray
    try {
        $connectionString = "Server=$instance;Database=master;Integrated Security=true;Connection Timeout=3;"
        $connection = New-Object System.Data.SqlClient.SqlConnection($connectionString)
        $connection.Open()
        $connection.Close()
        $serverFound = $instance
        Write-Host "   ✓ Conectado a: $instance" -ForegroundColor Green
        break
    }
    catch {
        Write-Host "   ✗ No disponible: $instance" -ForegroundColor DarkGray
    }
}

if ($null -eq $serverFound) {
    Write-Host ""
    Write-Host "❌ No se pudo conectar a SQL Server" -ForegroundColor Red
    Write-Host ""
    Write-Host "Opciones:" -ForegroundColor Yellow
    Write-Host "1. Asegúrate de que SQL Server esté instalado e iniciado"
    Write-Host "2. Verifica que el servicio 'SQL Server' esté corriendo"
    Write-Host "3. Ejecuta manualmente el archivo setup_database.sql desde SSMS"
    Write-Host ""
    pause
    exit 1
}

Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Servidor SQL encontrado: $serverFound" -ForegroundColor Green
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "Presiona ENTER para ejecutar el script SQL..." -ForegroundColor Yellow
Read-Host

try {
    # Ejecutar el script SQL
    Write-Host "⚙️  Ejecutando script SQL..." -ForegroundColor Yellow
    
    $sqlcmd = Get-Command sqlcmd -ErrorAction SilentlyContinue
    
    if ($sqlcmd) {
        # Usar sqlcmd si está disponible
        & sqlcmd -S $serverFound -E -i $sqlFile
        $exitCode = $LASTEXITCODE
        
        if ($exitCode -eq 0) {
            Write-Host ""
            Write-Host "✓ Base de datos configurada exitosamente!" -ForegroundColor Green
        }
        else {
            Write-Host ""
            Write-Host "⚠️  El script se ejecutó pero hubo advertencias (código: $exitCode)" -ForegroundColor Yellow
        }
    }
    else {
        # Usar .NET si sqlcmd no está disponible
        Write-Host "   Usando método alternativo (sqlcmd no encontrado)..." -ForegroundColor Gray
        
        $connectionString = "Server=$serverFound;Database=master;Integrated Security=true;"
        $connection = New-Object System.Data.SqlClient.SqlConnection($connectionString)
        $connection.Open()
        
        $sqlContent = Get-Content $sqlFile -Raw
        $batches = $sqlContent -split '\bGO\b'
        
        foreach ($batch in $batches) {
            if ($batch.Trim() -ne "") {
                $command = $connection.CreateCommand()
                $command.CommandText = $batch
                $command.CommandTimeout = 300
                $command.ExecuteNonQuery() | Out-Null
            }
        }
        
        $connection.Close()
        Write-Host ""
        Write-Host "✓ Base de datos configurada exitosamente!" -ForegroundColor Green
    }
    
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Cyan
    Write-Host " CREDENCIALES DE ACCESO" -ForegroundColor Cyan
    Write-Host "========================================" -ForegroundColor Cyan
    Write-Host ""
    Write-Host "Usuario Admin:" -ForegroundColor White
    Write-Host "  Usuario: admin" -ForegroundColor Green
    Write-Host "  Contraseña: Admin2025!" -ForegroundColor Green
    Write-Host "  Correo: antony.mongelopez@ucr.ac.cr" -ForegroundColor Green
    Write-Host ""
    Write-Host "Usuario Vendedor:" -ForegroundColor White
    Write-Host "  Usuario: vendedor1" -ForegroundColor Yellow
    Write-Host "  Contraseña: Vendedor123" -ForegroundColor Yellow
    Write-Host ""
    Write-Host "Usuario Regular:" -ForegroundColor White
    Write-Host "  Usuario: usuario1" -ForegroundColor Yellow
    Write-Host "  Contraseña: Usuario123" -ForegroundColor Yellow
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Cyan
    Write-Host ""
    Write-Host "✓ Consulta el archivo CREDENCIALES.txt para más información" -ForegroundColor Green
    Write-Host ""
}
catch {
    Write-Host ""
    Write-Host "❌ ERROR al ejecutar el script SQL:" -ForegroundColor Red
    Write-Host $_.Exception.Message -ForegroundColor Red
    Write-Host ""
    Write-Host "Intenta ejecutar manualmente:" -ForegroundColor Yellow
    Write-Host "1. Abre SQL Server Management Studio" -ForegroundColor White
    Write-Host "2. Conecta a: $serverFound" -ForegroundColor White
    Write-Host "3. Abre el archivo: setup_database.sql" -ForegroundColor White
    Write-Host "4. Ejecuta el script (F5)" -ForegroundColor White
    Write-Host ""
}

Write-Host "Presiona ENTER para salir..." -ForegroundColor Gray
Read-Host
