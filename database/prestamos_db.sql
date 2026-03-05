-- Crear la base de datos
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'prestamos_db')
BEGIN
    CREATE DATABASE prestamos_db;
    USE prestamos_db;
END

-- Estructura de tabla para la tabla `agentes`
CREATE TABLE agentes (
    id INT PRIMARY KEY,
    nombre_age VARCHAR(30) NULL,
    telefono_age INT NULL,
    cedula_age INT NULL,
    zona_zon_age VARCHAR(25) NULL,
    provincia_age VARCHAR(20) NULL,
    created_at DATETIME NULL,
    updated_at DATETIME NULL
);

-- Estructura de tabla para la tabla `clientes`
CREATE TABLE clientes (
    id INT PRIMARY KEY,
    nombre_cli VARCHAR(30) NOT NULL,
    zona_zon_cli VARCHAR(20) NOT NULL,
    telefono_cli INT NOT NULL,
    cedula_cli INT NOT NULL,
    representante_cli VARCHAR(30) NOT NULL,
    provincia_cli VARCHAR(20) NOT NULL,
    localidad_cli VARCHAR(20) NOT NULL,
    cobrador_cob_cli VARCHAR(20) NOT NULL,
    agente_age_cli VARCHAR(20) NOT NULL,
    balance_cli INT NOT NULL,
    trabajo_cli VARCHAR(30) NOT NULL,
    direccion_cli VARCHAR(40) NOT NULL,
    created_at DATETIME NULL,
    updated_at DATETIME NULL
);

-- Estructura de tabla para la tabla `cobradores`
CREATE TABLE cobradores (
    id INT PRIMARY KEY,
    nombre_cob VARCHAR(20) NULL,
    direccion_cob VARCHAR(30) NULL,
    tels_cob INT NULL,
    cedula_cob INT NULL,
    zona_zon_cob VARCHAR(25) NULL,
    provincia_cob VARCHAR(20) NULL,
    localidad_cob VARCHAR(20) NULL,
    created_at DATETIME NULL,
    updated_at DATETIME NULL
);

-- Estructura de tabla para la tabla `direcciones`
CREATE TABLE direcciones (
    id INT PRIMARY KEY,
    id_cli_dir INT NOT NULL,
    descripcion_dir VARCHAR(40) NOT NULL,
    created_at DATETIME NULL,
    updated_at DATETIME NULL
);

-- Estructura de tabla para la tabla `ingresos_mae`
CREATE TABLE ingresos_mae (
    id INT PRIMARY KEY,
    prestamo_id_ing INT NULL,
    nombre_cli_ing VARCHAR(20) NULL,
    balance_ing DECIMAL(12,2) NULL,
    capital_pre_ing DECIMAL(12,2) NULL,
    interes_pre_ing DECIMAL(12,2) NULL,
    mora_ing DECIMAL(12,2) NULL,
    dia_gracia_ing DECIMAL(20) NULL,
    descuento_ing DECIMAL(12,2) NULL,
    monto_ing DECIMAL(20) NULL,
    concepto_ing VARCHAR(50) NULL,
    estado_ing INT NULL,
    fecha_ing VARCHAR(20) NULL,
    created_at DATETIME NULL,
    updated_at DATETIME NULL
);

-- Estructura de tabla para la tabla `ingreso_i_c_s`
CREATE TABLE ingreso_i_c_s (
    id INT PRIMARY KEY,
    prestamo_id_ingi INT NULL,
    balance_ingi DECIMAL(12,2) NULL,
    forma_pago_ingi VARCHAR(15) NULL,
    g_legales_ingi DECIMAL(12,2) NULL,
    mora_ingi DECIMAL(12,2) NULL,
    dia_gracia_ingi INT NULL,
    monto_ingi DECIMAL(12,2) NULL,
    concepto_ingi VARCHAR(50) NULL,
    estado_ingi INT NULL,
    fecha_ingi VARCHAR(10) NULL,
    created_at DATETIME NULL,
    updated_at DATETIME NULL
);

-- Estructura de tabla para la tabla `prestamos`
CREATE TABLE prestamos (
    id INT PRIMARY KEY,
    cod_cli_pre VARCHAR(15) NULL,
    cedula_cli_pre VARCHAR(15) NULL,
    cobrador_cob_pre VARCHAR(15) NULL,
    agente_age_pre VARCHAR(15) NULL,
    garante_pre VARCHAR(25) NULL,
    zona_zon_pre VARCHAR(25) NULL,
    detalle_pre VARCHAR(25) NULL,
    printer_pre VARCHAR(25) NULL,
    fiador_pre VARCHAR(25) NULL,
    direccion_fia_pre VARCHAR(25) NULL,
    tels_fia_pre VARCHAR(15) NULL,
    moneda_pre VARCHAR(255) NULL,
    fecha_pre VARCHAR(255) NULL,
    tipo_pre VARCHAR(255) NULL,
    cuotas_pagada_pre VARCHAR(255) NULL,
    gastos_ley_pre VARCHAR(255) NULL,
    balance_pre VARCHAR(255) NULL,
    monto_pre VARCHAR(255) NULL,
    interes_pre VARCHAR(255) NULL,
    cuotas_pre VARCHAR(255) NULL,
    dia_pre VARCHAR(255) NULL,
    dias_cuota_pre VARCHAR(255) NULL,
    estado_pre VARCHAR(255) NULL,
    created_at DATETIME NULL,
    updated_at DATETIME NULL
);

-- Estructura de tabla para la tabla `users`
CREATE TABLE users (
    id INT PRIMARY KEY,
    name VARCHAR(25) NOT NULL,
    email VARCHAR(25) NOT NULL,
    tipo_cli_use VARCHAR(25) NULL,
    printer_use VARCHAR(25) NULL,
    estafea_user VARCHAR(25) NULL,
    email_verified_at DATETIME NULL,
    password VARCHAR(25) NOT NULL,
    remember_token VARCHAR(100) NULL,
    created_at DATETIME NULL,
    updated_at DATETIME NULL
);

-- Estructura de tabla para la tabla `zonas`
CREATE TABLE zonas (
    id INT PRIMARY KEY,
    id_cli_zon VARCHAR(25) NOT NULL,
    nombre_zon VARCHAR(25) NULL,
    created_at DATETIME NULL,
    updated_at DATETIME NULL
);
