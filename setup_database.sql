-- Script de configuración rápida para Sistema de Ventas
-- Base de datos: prestamos_db

USE master;
GO

-- Crear base de datos si no existe
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'prestamos_db')
BEGIN
    CREATE DATABASE prestamos_db;
    PRINT 'Base de datos "prestamos_db" creada exitosamente.';
END
ELSE
BEGIN
    PRINT 'Base de datos "prestamos_db" ya existe.';
END
GO

USE prestamos_db;
GO

-- Tabla de usuarios
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usuario]') AND type in (N'U'))
BEGIN
    CREATE TABLE usuario (
        id INT PRIMARY KEY IDENTITY(1,1),
        nombre VARCHAR(100) NOT NULL,
        apellido VARCHAR(100) NOT NULL,
        correo VARCHAR(150) NOT NULL,
        contraseña VARCHAR(100) NOT NULL,
        rol INT NOT NULL, -- 1=Admin, 2=Vendedor, 3=Usuario
        fecha_registro DATETIME DEFAULT GETDATE(),
        Usuario VARCHAR(50) NOT NULL UNIQUE
    );
    PRINT 'Tabla "usuario" creada exitosamente.';
END
GO

-- Tabla de clientes
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[clientes]') AND type in (N'U'))
BEGIN
    CREATE TABLE clientes (
        IDCliente INT PRIMARY KEY IDENTITY(1,1),
        Razon VARCHAR(200),
        Nombre VARCHAR(200) NOT NULL,
        Cedula VARCHAR(20) NOT NULL UNIQUE,
        Direccion VARCHAR(300),
        Ciudad VARCHAR(100),
        Tel VARCHAR(20),
        Email VARCHAR(150),
        LimitCredit DECIMAL(18,2) DEFAULT 0,
        Observacion VARCHAR(500),
        FechaEntrada DATETIME DEFAULT GETDATE(),
        CondicionCliente VARCHAR(50),
        Estado BIT DEFAULT 1
    );
    PRINT 'Tabla "clientes" creada exitosamente.';
END
GO

-- Tabla de marca
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[marca]') AND type in (N'U'))
BEGIN
    CREATE TABLE marca (
        id INT PRIMARY KEY IDENTITY(1,1),
        nombre VARCHAR(100) NOT NULL UNIQUE,
        descripcion VARCHAR(300)
    );
    PRINT 'Tabla "marca" creada exitosamente.';
END
GO

-- Tabla de linea
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[linea]') AND type in (N'U'))
BEGIN
    CREATE TABLE linea (
        id INT PRIMARY KEY IDENTITY(1,1),
        nombre VARCHAR(100) NOT NULL UNIQUE,
        descripcion VARCHAR(300)
    );
    PRINT 'Tabla "linea" creada exitosamente.';
END
GO

-- Tabla de unidad
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[unidad]') AND type in (N'U'))
BEGIN
    CREATE TABLE unidad (
        id INT PRIMARY KEY IDENTITY(1,1),
        nombre VARCHAR(100) NOT NULL UNIQUE,
        descripcion VARCHAR(300)
    );
    PRINT 'Tabla "unidad" creada exitosamente.';
END
GO

-- Tabla de proveedor
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proveedor]') AND type in (N'U'))
BEGIN
    CREATE TABLE proveedor (
        id INT PRIMARY KEY IDENTITY(1,1),
        nombre VARCHAR(200) NOT NULL,
        contacto VARCHAR(100),
        telefono VARCHAR(20),
        email VARCHAR(150),
        direccion VARCHAR(300),
        ciudad VARCHAR(100)
    );
    PRINT 'Tabla "proveedor" creada exitosamente.';
END
GO

-- Tabla de articulo
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[articulo]') AND type in (N'U'))
BEGIN
    CREATE TABLE articulo (
        id INT PRIMARY KEY IDENTITY(1,1),
        nombre VARCHAR(200) NOT NULL,
        referencia VARCHAR(100) NOT NULL UNIQUE,
        marca_id INT,
        proveedor_id INT,
        linea_id INT,
        unidad_id INT,
        precio DECIMAL(18,2) NOT NULL,
        costo DECIMAL(18,2) NOT NULL,
        existencia INT DEFAULT 0,
        itebis DECIMAL(5,2) DEFAULT 0, -- Porcentaje de impuesto
        descripcion VARCHAR(500),
        observacion VARCHAR(500),
        fecha_registro DATETIME DEFAULT GETDATE(),
        usuario VARCHAR(50),
        FOREIGN KEY (marca_id) REFERENCES marca(id),
        FOREIGN KEY (proveedor_id) REFERENCES proveedor(id),
        FOREIGN KEY (linea_id) REFERENCES linea(id),
        FOREIGN KEY (unidad_id) REFERENCES unidad(id)
    );
    PRINT 'Tabla "articulo" creada exitosamente.';
END
GO

-- Tabla de vendedor
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[vendedor]') AND type in (N'U'))
BEGIN
    CREATE TABLE vendedor (
        id INT PRIMARY KEY IDENTITY(1,1),
        nombre VARCHAR(100) NOT NULL,
        apellido VARCHAR(100) NOT NULL,
        cedula VARCHAR(20) NOT NULL UNIQUE,
        telefono VARCHAR(20),
        email VARCHAR(150),
        direccion VARCHAR(300),
        fecha_ingreso DATETIME DEFAULT GETDATE(),
        comision DECIMAL(5,2) DEFAULT 0,
        estado BIT DEFAULT 1
    );
    PRINT 'Tabla "vendedor" creada exitosamente.';
END
GO

-- Tabla de facturador
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[facturador]') AND type in (N'U'))
BEGIN
    CREATE TABLE facturador (
        id INT PRIMARY KEY IDENTITY(1,1),
        nombre VARCHAR(100) NOT NULL,
        rnc VARCHAR(20),
        telefono VARCHAR(20),
        direccion VARCHAR(300),
        estado BIT DEFAULT 1
    );
    PRINT 'Tabla "facturador" creada exitosamente.';
END
GO

-- ============================================
-- INSERTAR DATOS DE PRUEBA
-- ============================================

-- Usuario Administrador para pruebas
IF NOT EXISTS (SELECT * FROM usuario WHERE Usuario = 'admin')
BEGIN
    INSERT INTO usuario (nombre, apellido, correo, contraseña, rol, Usuario)
    VALUES ('Antony', 'Monge López', 'antony.mongelopez@ucr.ac.cr', 'Admin2025!', 1, 'admin');
    PRINT 'Usuario admin creado.';
END
GO

-- Usuario vendedor para pruebas
IF NOT EXISTS (SELECT * FROM usuario WHERE Usuario = 'vendedor1')
BEGIN
    INSERT INTO usuario (nombre, apellido, correo, contraseña, rol, Usuario)
    VALUES ('María', 'González', 'maria.gonzalez@empresa.com', 'Vendedor123', 2, 'vendedor1');
    PRINT 'Usuario vendedor1 creado.';
END
GO

-- Usuario regular para pruebas
IF NOT EXISTS (SELECT * FROM usuario WHERE Usuario = 'usuario1')
BEGIN
    INSERT INTO usuario (nombre, apellido, correo, contraseña, rol, Usuario)
    VALUES ('Carlos', 'Ramírez', 'carlos.ramirez@empresa.com', 'Usuario123', 3, 'usuario1');
    PRINT 'Usuario usuario1 creado.';
END
GO

-- Marcas
IF NOT EXISTS (SELECT * FROM marca WHERE nombre = 'Samsung')
BEGIN
    INSERT INTO marca (nombre, descripcion) VALUES 
    ('Samsung', 'Productos electrónicos Samsung'),
    ('LG', 'Productos electrónicos LG'),
    ('Sony', 'Productos electrónicos Sony'),
    ('HP', 'Computadoras y periféricos HP'),
    ('Dell', 'Computadoras y equipos Dell');
    PRINT 'Marcas insertadas.';
END
GO

-- Líneas de productos
IF NOT EXISTS (SELECT * FROM linea WHERE nombre = 'Electrónica')
BEGIN
    INSERT INTO linea (nombre, descripcion) VALUES 
    ('Electrónica', 'Productos electrónicos en general'),
    ('Computación', 'Equipos de cómputo y periféricos'),
    ('Hogar', 'Electrodomésticos para el hogar'),
    ('Oficina', 'Suministros de oficina'),
    ('Audio y Video', 'Equipos de audio y video');
    PRINT 'Líneas insertadas.';
END
GO

-- Unidades de medida
IF NOT EXISTS (SELECT * FROM unidad WHERE nombre = 'Unidad')
BEGIN
    INSERT INTO unidad (nombre, descripcion) VALUES 
    ('Unidad', 'Unidad individual'),
    ('Caja', 'Caja de producto'),
    ('Paquete', 'Paquete de producto'),
    ('Docena', '12 unidades'),
    ('Kilogramo', 'Medida en kilogramos');
    PRINT 'Unidades insertadas.';
END
GO

-- Proveedores
IF NOT EXISTS (SELECT * FROM proveedor WHERE nombre = 'TechWorld S.A.')
BEGIN
    INSERT INTO proveedor (nombre, contacto, telefono, email, direccion, ciudad) VALUES 
    ('TechWorld S.A.', 'Juan Pérez', '506-2234-5678', 'ventas@techworld.com', 'Av. Central 123', 'San José'),
    ('ElectroMax', 'Ana Soto', '506-2245-6789', 'info@electromax.com', 'Calle 5, Local 45', 'Heredia'),
    ('Distribuidora Nacional', 'Roberto Mora', '506-2256-7890', 'contacto@disnacional.cr', 'Zona Franca, Edificio 7', 'Alajuela'),
    ('ImportCorp', 'Laura Jiménez', '506-2267-8901', 'ventas@importcorp.com', 'Plaza Central 200', 'Cartago');
    PRINT 'Proveedores insertados.';
END
GO

-- Artículos de prueba
IF NOT EXISTS (SELECT * FROM articulo WHERE referencia = 'SAM-TV55-001')
BEGIN
    INSERT INTO articulo (nombre, referencia, marca_id, proveedor_id, linea_id, unidad_id, precio, costo, existencia, itebis, descripcion, observacion, usuario) VALUES 
    ('Smart TV Samsung 55"', 'SAM-TV55-001', 1, 1, 1, 1, 450000.00, 320000.00, 15, 13.00, 'Televisor inteligente 55 pulgadas 4K', 'Modelo 2024', 'admin'),
    ('Laptop HP Pavilion 15', 'HP-LAP15-002', 4, 1, 2, 1, 650000.00, 480000.00, 8, 13.00, 'Laptop HP 15.6", Intel i5, 8GB RAM, 512GB SSD', 'Nueva generación', 'admin'),
    ('Monitor LG 27"', 'LG-MON27-003', 2, 2, 2, 1, 180000.00, 130000.00, 20, 13.00, 'Monitor LG 27 pulgadas Full HD IPS', 'Ideal para diseño', 'admin'),
    ('Mouse Inalámbrico Sony', 'SON-MOU-004', 3, 3, 2, 1, 8500.00, 5200.00, 50, 13.00, 'Mouse inalámbrico ergonómico', 'Incluye pilas', 'admin'),
    ('Teclado Mecánico Dell', 'DEL-TEC-005', 5, 1, 2, 1, 35000.00, 22000.00, 30, 13.00, 'Teclado mecánico retroiluminado RGB', 'Switch azul', 'admin'),
    ('Auriculares Sony WH-1000', 'SON-AUR-006', 3, 4, 5, 1, 120000.00, 85000.00, 12, 13.00, 'Auriculares inalámbricos con cancelación de ruido', 'Bluetooth 5.0', 'admin'),
    ('Impresora HP LaserJet', 'HP-IMP-007', 4, 2, 4, 1, 220000.00, 160000.00, 10, 13.00, 'Impresora láser monocromática', 'Wifi incluido', 'admin');
    PRINT 'Artículos insertados.';
END
GO

-- Clientes
IF NOT EXISTS (SELECT * FROM clientes WHERE Cedula = '1-1234-5678')
BEGIN
    INSERT INTO clientes (Razon, Nombre, Cedula, Direccion, Ciudad, Tel, Email, LimitCredit, Observacion, CondicionCliente, Estado) VALUES 
    ('Empresa XYZ S.A.', 'Juan Carlos Méndez', '1-1234-5678', 'Av. Principal 456', 'San José', '506-8888-1234', 'jmendez@empresaxyz.com', 5000000.00, 'Cliente preferencial', 'Contado', 1),
    ('Comercial ABC', 'Ana Patricia Rojas', '2-2345-6789', 'Calle 10, Local 15', 'Heredia', '506-8888-2345', 'arojas@comercialabc.com', 3000000.00, 'Buen historial', 'Crédito 30 días', 1),
    ('TiendaTech CR', 'Roberto Solís', '3-3456-7890', 'Centro Comercial Plaza', 'Alajuela', '506-8888-3456', 'rsolis@tiendatech.cr', 2000000.00, 'Cliente nuevo', 'Contado', 1),
    ('Supermercado El Ahorro', 'Laura Vargas', '4-4567-8901', 'Zona Norte, Local 200', 'Cartago', '506-8888-4567', 'lvargas@elahorro.com', 8000000.00, 'Cliente mayorista', 'Crédito 60 días', 1),
    ('Consultores Digitales', 'Mario Castro', '5-5678-9012', 'Edificio Empresarial 301', 'San José', '506-8888-5678', 'mcastro@consultores.com', 1500000.00, 'Compras mensuales', 'Crédito 15 días', 1);
    PRINT 'Clientes insertados.';
END
GO

-- Vendedores
IF NOT EXISTS (SELECT * FROM vendedor WHERE cedula = '1-0987-6543')
BEGIN
    INSERT INTO vendedor (nombre, apellido, cedula, telefono, email, direccion, comision, estado) VALUES 
    ('Luis', 'Fernández', '1-0987-6543', '506-7777-1111', 'lfernandez@empresa.com', 'San Pedro, Montes de Oca', 5.00, 1),
    ('Carmen', 'López', '2-0987-6544', '506-7777-2222', 'clopez@empresa.com', 'Escazú Centro', 4.50, 1),
    ('Diego', 'Mora', '3-0987-6545', '506-7777-3333', 'dmora@empresa.com', 'Curridabat Norte', 5.50, 1);
    PRINT 'Vendedores insertados.';
END
GO

-- Facturadores
IF NOT EXISTS (SELECT * FROM facturador WHERE rnc = '123456789')
BEGIN
    INSERT INTO facturador (nombre, rnc, telefono, direccion, estado) VALUES 
    ('Facturador Principal', '123456789', '506-2200-0000', 'Oficina Central, San José', 1),
    ('Facturador Sucursal Heredia', '987654321', '506-2200-1111', 'Sucursal Heredia, Local 5', 1);
    PRINT 'Facturadores insertados.';
END
GO

PRINT '';
PRINT '========================================';
PRINT 'BASE DE DATOS CONFIGURADA EXITOSAMENTE';
PRINT '========================================';
PRINT '';
PRINT 'CREDENCIALES DE ACCESO:';
PRINT '-----------------------';
PRINT 'Usuario Admin:';
PRINT '  Usuario: admin';
PRINT '  Contraseña: Admin2025!';
PRINT '  Correo: antony.mongelopez@ucr.ac.cr';
PRINT '';
PRINT 'Usuario Vendedor:';
PRINT '  Usuario: vendedor1';
PRINT '  Contraseña: Vendedor123';
PRINT '';
PRINT 'Usuario Regular:';
PRINT '  Usuario: usuario1';
PRINT '  Contraseña: Usuario123';
PRINT '';
PRINT '========================================';
GO
