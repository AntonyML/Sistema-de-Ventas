# 🚀 Inicio Rápido - Sistema de Ventas

## 📋 Archivos de Configuración

- **setup_database.sql** - Script SQL para crear la base de datos y tablas con datos de prueba
- **CREDENCIALES.txt** - Información completa de usuarios y configuración
- **configurar_bd.ps1** - Script PowerShell para configuración automática
- **project.json** - Configuración de conexión a la base de datos

## ⚡ Configuración Rápida (2 opciones)

### Opción 1: Automática con PowerShell (Recomendada)

1. Haz clic derecho en `configurar_bd.ps1`
2. Selecciona "Ejecutar con PowerShell"
3. Sigue las instrucciones en pantalla
4. ¡Listo! Ya puedes usar la aplicación

### Opción 2: Manual con SSMS

1. Abre **SQL Server Management Studio (SSMS)**
2. Conecta a tu servidor local (normalmente `.` o `.\SQLEXPRESS`)
3. Abre el archivo `setup_database.sql`
4. Presiona **F5** para ejecutar
5. Verifica los mensajes de éxito en la ventana de resultados

## 🔐 Credenciales de Acceso

### Usuario Administrador (Recomendado para pruebas)
```
Usuario: admin
Contraseña: Admin2025!
Correo: antony.mongelopez@ucr.ac.cr
```

### Usuario Vendedor
```
Usuario: vendedor1
Contraseña: Vendedor123
```

### Usuario Regular
```
Usuario: usuario1
Contraseña: Usuario123
```

## ✅ ¿Qué incluye el script?

El script `setup_database.sql` crea automáticamente:

- ✓ Base de datos `prestamos_db`
- ✓ Todas las tablas necesarias
- ✓ 3 usuarios de prueba (admin, vendedor, usuario)
- ✓ 5 marcas (Samsung, LG, Sony, HP, Dell)
- ✓ 5 líneas de productos
- ✓ 5 unidades de medida
- ✓ 4 proveedores
- ✓ 7 artículos con inventario
- ✓ 5 clientes
- ✓ 3 vendedores
- ✓ 2 facturadores

## 🎯 Primeros Pasos

1. **Configurar la base de datos** (usar una de las 2 opciones arriba)
2. **Ejecutar la aplicación**: `bin\Debug\sistema de ventas.exe`
3. **Iniciar sesión** con las credenciales de admin
4. **Explorar el sistema** con datos de prueba ya cargados

## 🔧 Solución de Problemas

### "No se puede conectar a SQL Server"
- Verifica que SQL Server esté instalado y corriendo
- Abre "Servicios" de Windows y busca "SQL Server"
- Asegúrate que el servicio esté "Iniciado"

### "Base de datos no existe"
- Ejecuta el script `setup_database.sql` primero
- O usa el script PowerShell `configurar_bd.ps1`

### "Credenciales incorrectas"
- Las contraseñas son **sensibles a mayúsculas/minúsculas**
- Verifica que estés usando exactamente: `Admin2025!` (no admin2025!)

### "Cambiar servidor de base de datos"
Edita `project.json` y cambia el servidor:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=TU_SERVIDOR;Database=prestamos_db;Integrated Security=true;"
  }
}
```

Ejemplos de servidores:
- Local por defecto: `.`
- SQL Express: `.\SQLEXPRESS`
- LocalDB: `(localdb)\MSSQLLocalDB`
- Remoto: `192.168.1.100`

## 📚 Estructura de Datos

### Roles de Usuario
- **1** = Administrador (acceso completo)
- **2** = Vendedor (ventas y consultas)
- **3** = Usuario regular (acceso limitado)

### Datos de Prueba Incluidos

**Artículos de ejemplo:**
- Smart TV Samsung 55" - ₡450,000
- Laptop HP Pavilion 15 - ₡650,000
- Monitor LG 27" - ₡180,000
- Mouse Inalámbrico Sony - ₡8,500
- Teclado Mecánico Dell - ₡35,000
- Auriculares Sony WH-1000 - ₡120,000
- Impresora HP LaserJet - ₡220,000

**Clientes de ejemplo:**
- Empresa XYZ S.A.
- Comercial ABC
- TiendaTech CR
- Supermercado El Ahorro
- Consultores Digitales

## 📞 Contacto

**Desarrollador:** Antony Monge López  
**Email:** antony.mongelopez@ucr.ac.cr  
**Fecha:** Mayo 2025

---

## 🎉 ¡Todo Listo!

Ahora puedes:
1. ✓ Iniciar sesión con cualquier usuario
2. ✓ Consultar artículos en inventario
3. ✓ Gestionar clientes
4. ✓ Procesar ventas
5. ✓ Administrar el sistema

**¡Disfruta explorando el Sistema de Ventas!** 🚀
