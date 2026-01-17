-- =============================================
-- Script de Creación de Base de Datos: RedAceiteInventario
-- Descripción: Sistema de inventario de residuos (Aceite y Grasa)
-- Autor: Sistema RedAceite
-- Fecha: 2025
-- =============================================

-- Crear la base de datos
CREATE DATABASE RedAceiteInventario;
GO

USE RedAceiteInventario;
GO

-- =============================================
-- Tabla: Inventario
-- Descripción: Almacena el stock consolidado de residuos por tipo y estado
-- =============================================
CREATE TABLE Inventario (
    IdInventario UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    TipoResiduo NVARCHAR(50) NOT NULL,           -- 'Aceite' o 'Grasa'
    CantidadDisponible DECIMAL(18, 2) NOT NULL DEFAULT 0,
    Estado NVARCHAR(50) NOT NULL,                -- 'Líquido' o 'Sólido'
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    FechaActualizacion DATETIME NOT NULL DEFAULT GETDATE(),
    EstadoInventario NVARCHAR(20) NOT NULL DEFAULT 'Activo', -- 'Activo', 'Inactivo'
    
    -- Restricciones
    CONSTRAINT CHK_TipoResiduo CHECK (TipoResiduo IN ('Aceite', 'Grasa')),
    CONSTRAINT CHK_Estado CHECK (Estado IN ('Líquido', 'Sólido')),
    CONSTRAINT CHK_CantidadDisponible CHECK (CantidadDisponible >= 0),
    CONSTRAINT CHK_EstadoInventario CHECK (EstadoInventario IN ('Activo', 'Inactivo'))
);
GO

-- =============================================
-- Tabla: MovimientoInventario
-- Descripción: Registra todos los movimientos (entrada/salida) del inventario
--              Sirve como auditoría y para análisis de métricas
-- =============================================
CREATE TABLE MovimientoInventario (
    IdMovimiento UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    IdInventario UNIQUEIDENTIFIER NOT NULL,
    IdRemito UNIQUEIDENTIFIER NULL,              -- Referencia al remito si es entrada
    TipoMovimiento NVARCHAR(20) NOT NULL,        -- 'Entrada', 'Salida', 'Ajuste'
    Cantidad DECIMAL(18, 2) NOT NULL,
    CantidadAnterior DECIMAL(18, 2) NOT NULL,    -- Stock antes del movimiento
    CantidadNueva DECIMAL(18, 2) NOT NULL,       -- Stock después del movimiento
    Observaciones NVARCHAR(500) NULL,
    FechaMovimiento DATETIME NOT NULL DEFAULT GETDATE(),
    UsuarioId UNIQUEIDENTIFIER NULL,             -- Usuario que realizó el movimiento
    
    -- Clave foránea
    CONSTRAINT FK_MovimientoInventario_Inventario 
        FOREIGN KEY (IdInventario) REFERENCES Inventario(IdInventario),
    
    -- Restricciones
    CONSTRAINT CHK_TipoMovimiento 
        CHECK (TipoMovimiento IN ('Entrada', 'Salida', 'Ajuste')),
    CONSTRAINT CHK_Cantidad CHECK (Cantidad > 0)
);
GO

-- =============================================
-- Índices para optimizar consultas
-- =============================================

-- Índices en tabla Inventario
CREATE INDEX IX_Inventario_TipoResiduo ON Inventario(TipoResiduo);
CREATE INDEX IX_Inventario_Estado ON Inventario(Estado);
CREATE INDEX IX_Inventario_EstadoInventario ON Inventario(EstadoInventario);

-- Índices en tabla MovimientoInventario
CREATE INDEX IX_MovimientoInventario_IdInventario ON MovimientoInventario(IdInventario);
CREATE INDEX IX_MovimientoInventario_FechaMovimiento ON MovimientoInventario(FechaMovimiento);
CREATE INDEX IX_MovimientoInventario_TipoMovimiento ON MovimientoInventario(TipoMovimiento);
CREATE INDEX IX_MovimientoInventario_IdRemito ON MovimientoInventario(IdRemito);
GO

-- =============================================
-- Datos iniciales (Seed Data)
-- =============================================

-- Inicializar inventario para cada combinación tipo/estado
-- Esto crea los registros base del sistema
INSERT INTO Inventario (IdInventario, TipoResiduo, CantidadDisponible, Estado, FechaCreacion, FechaActualizacion, EstadoInventario)
VALUES 
    (NEWID(), 'Aceite', 0, 'Líquido', GETDATE(), GETDATE(), 'Activo'),
    (NEWID(), 'Grasa', 0, 'Sólido', GETDATE(), GETDATE(), 'Activo');
GO

-- =============================================
-- Vista: vw_InventarioConMovimientos
-- Descripción: Vista consolidada para reportes
-- =============================================
CREATE VIEW vw_InventarioConMovimientos AS
SELECT 
    i.IdInventario,
    i.TipoResiduo,
    i.Estado,
    i.CantidadDisponible,
    COUNT(m.IdMovimiento) AS TotalMovimientos,
    SUM(CASE WHEN m.TipoMovimiento = 'Entrada' THEN m.Cantidad ELSE 0 END) AS TotalEntradas,
    SUM(CASE WHEN m.TipoMovimiento = 'Salida' THEN m.Cantidad ELSE 0 END) AS TotalSalidas,
    MAX(m.FechaMovimiento) AS UltimoMovimiento
FROM 
    Inventario i
LEFT JOIN 
    MovimientoInventario m ON i.IdInventario = m.IdInventario
WHERE 
    i.EstadoInventario = 'Activo'
GROUP BY 
    i.IdInventario, i.TipoResiduo, i.Estado, i.CantidadDisponible;
GO

-- =============================================
-- Stored Procedure: sp_ObtenerEstadisticasInventario
-- Descripción: Obtiene estadísticas consolidadas del inventario
-- =============================================
CREATE PROCEDURE sp_ObtenerEstadisticasInventario
    @FechaInicio DATETIME = NULL,
    @FechaFin DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Si no se proporcionan fechas, usar el último mes
    IF @FechaInicio IS NULL
        SET @FechaInicio = DATEADD(MONTH, -1, GETDATE());
    
    IF @FechaFin IS NULL
        SET @FechaFin = GETDATE();
    
    SELECT 
        i.TipoResiduo,
        i.Estado,
        i.CantidadDisponible AS StockActual,
        ISNULL(SUM(CASE WHEN m.TipoMovimiento = 'Entrada' 
                        AND m.FechaMovimiento BETWEEN @FechaInicio AND @FechaFin 
                        THEN m.Cantidad ELSE 0 END), 0) AS TotalEntradas,
        ISNULL(SUM(CASE WHEN m.TipoMovimiento = 'Salida' 
                        AND m.FechaMovimiento BETWEEN @FechaInicio AND @FechaFin 
                        THEN m.Cantidad ELSE 0 END), 0) AS TotalSalidas,
        ISNULL(COUNT(CASE WHEN m.FechaMovimiento BETWEEN @FechaInicio AND @FechaFin 
                          THEN m.IdMovimiento END), 0) AS CantidadMovimientos
    FROM 
        Inventario i
    LEFT JOIN 
        MovimientoInventario m ON i.IdInventario = m.IdInventario
    WHERE 
        i.EstadoInventario = 'Activo'
    GROUP BY 
        i.TipoResiduo, i.Estado, i.CantidadDisponible;
END;
GO

-- =============================================
-- Mensaje de confirmación
-- =============================================
PRINT '? Base de datos RedAceiteInventario creada exitosamente';
PRINT '? Tablas Inventario y MovimientoInventario creadas';
PRINT '? Índices creados para optimización';
PRINT '? Datos iniciales insertados';
PRINT '? Vista y Stored Procedure creados';
GO
