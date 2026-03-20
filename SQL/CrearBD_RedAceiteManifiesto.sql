-- =============================================
-- SCRIPTS DE CREACION - BASE DE DATOS DE PRECIOS
-- Base: RedAceitePrecio
-- =============================================

IF DB_ID('RedAceitePrecio') IS NULL
BEGIN
    CREATE DATABASE RedAceitePrecio;
END
GO
USE RedAceitePrecio;
GO
-- =========================================================
-- Tabla: PrecioResiduo
-- =========================================================
IF OBJECT_ID('dbo.PrecioResiduo', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.PrecioResiduo
    (
        IdPrecio UNIQUEIDENTIFIER NOT NULL
            CONSTRAINT PK_PrecioResiduo PRIMARY KEY
            CONSTRAINT DF_PrecioResiduo_IdPrecio DEFAULT NEWID(),
        TipoResiduo NVARCHAR(50) NOT NULL,
        PrecioUnitario DECIMAL(18,2) NOT NULL,
        FechaVigencia DATETIME NOT NULL
            CONSTRAINT DF_PrecioResiduo_FechaVigencia DEFAULT GETDATE(),
        Activo BIT NOT NULL
            CONSTRAINT DF_PrecioResiduo_Activo DEFAULT (1),
        CONSTRAINT CK_PrecioResiduo_TipoResiduo
            CHECK (TipoResiduo IN (N'Aceite', N'Grasa')),
        CONSTRAINT CK_PrecioResiduo_PrecioUnitario
            CHECK (PrecioUnitario >= 0)
    );
END
GO
-- =========================================================
-- Indice unico filtrado:
-- Solo puede haber 1 registro activo por TipoResiduo
-- =========================================================
IF NOT EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE name = 'UX_PrecioResiduo_TipoResiduo_Activo'
      AND object_id = OBJECT_ID('dbo.PrecioResiduo')
)
BEGIN
    CREATE UNIQUE INDEX UX_PrecioResiduo_TipoResiduo_Activo
        ON dbo.PrecioResiduo(TipoResiduo)
        WHERE Activo = 1;
END
GO


-- =============================================
-- SCRIPTS DE CREACION - BASE DE DATOS DE MANIFIESTOS
-- Base: RedAceiteManifiestos
-- =============================================

IF DB_ID('RedAceiteManifiestos') IS NULL
BEGIN
    CREATE DATABASE RedAceiteManifiestos;
END
GO
USE RedAceiteManifiestos;
GO
-- =========================================================
-- Tabla: Manifiesto
-- =========================================================
IF OBJECT_ID('dbo.Manifiesto', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Manifiesto
    (
        IdManifiesto UNIQUEIDENTIFIER NOT NULL
            CONSTRAINT PK_Manifiesto PRIMARY KEY
            CONSTRAINT DF_Manifiesto_IdManifiesto DEFAULT NEWID(),
        NumeroManifiesto NVARCHAR(20) NOT NULL,
        FechaManifiesto DATE NOT NULL,
        NombreTransportista NVARCHAR(100) NOT NULL,
        DomicilioTransportista NVARCHAR(200) NOT NULL,
        CantidadTotalRemitos INT NOT NULL
            CONSTRAINT DF_Manifiesto_CantidadTotalRemitos DEFAULT (0),
        MontoTotal DECIMAL(18,2) NOT NULL
            CONSTRAINT DF_Manifiesto_MontoTotal DEFAULT (0),
        Estado NVARCHAR(20) NOT NULL
            CONSTRAINT DF_Manifiesto_Estado DEFAULT (N'Generado'),
        Observaciones NVARCHAR(500) NULL,
        FechaCreacion DATETIME NOT NULL
            CONSTRAINT DF_Manifiesto_FechaCreacion DEFAULT (GETDATE()),
        DigitoVerificador NVARCHAR(100) NULL,
        CONSTRAINT UQ_Manifiesto_NumeroManifiesto UNIQUE (NumeroManifiesto),
        CONSTRAINT CK_Manifiesto_Estado
            CHECK (Estado IN (N'Generado', N'Anulado')),
        CONSTRAINT CK_Manifiesto_CantidadTotalRemitos
            CHECK (CantidadTotalRemitos >= 0),
        CONSTRAINT CK_Manifiesto_MontoTotal
            CHECK (MontoTotal >= 0),
        CONSTRAINT CK_Manifiesto_NumeroFormato
            CHECK (NumeroManifiesto LIKE N'MAN-[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9]')
    );
END
GO
-- =========================================================
-- Tabla: ManifiestoDetalle
-- =========================================================
IF OBJECT_ID('dbo.ManifiestoDetalle', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.ManifiestoDetalle
    (
        IdDetalle UNIQUEIDENTIFIER NOT NULL
            CONSTRAINT PK_ManifiestoDetalle PRIMARY KEY
            CONSTRAINT DF_ManifiestoDetalle_IdDetalle DEFAULT NEWID(),
        IdManifiesto UNIQUEIDENTIFIER NOT NULL,
        IdRemito UNIQUEIDENTIFIER NOT NULL,
        NombreGenerador NVARCHAR(100) NOT NULL,
        TipoResiduo NVARCHAR(50) NOT NULL,
        Cantidad DECIMAL(18,2) NOT NULL,
        PrecioUnitario DECIMAL(18,2) NOT NULL,
        Subtotal AS CAST(Cantidad * PrecioUnitario AS DECIMAL(18,2)) PERSISTED,
        Orden INT NOT NULL,
        CONSTRAINT FK_ManifiestoDetalle_Manifiesto
            FOREIGN KEY (IdManifiesto)
            REFERENCES dbo.Manifiesto(IdManifiesto),
        CONSTRAINT CK_ManifiestoDetalle_TipoResiduo
            CHECK (TipoResiduo IN (N'Aceite', N'Grasa')),
        CONSTRAINT CK_ManifiestoDetalle_Cantidad
            CHECK (Cantidad > 0),
        CONSTRAINT CK_ManifiestoDetalle_PrecioUnitario
            CHECK (PrecioUnitario >= 0),
        CONSTRAINT CK_ManifiestoDetalle_Orden
            CHECK (Orden > 0),
        CONSTRAINT UQ_ManifiestoDetalle_Orden
            UNIQUE (IdManifiesto, Orden),
        CONSTRAINT UQ_ManifiestoDetalle_IdRemito
            UNIQUE (IdManifiesto, IdRemito)
    );
END
GO
-- =========================================================
-- Indices
-- =========================================================
IF NOT EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE name = 'IX_ManifiestoDetalle_IdManifiesto'
      AND object_id = OBJECT_ID('dbo.ManifiestoDetalle')
)
BEGIN
    CREATE INDEX IX_ManifiestoDetalle_IdManifiesto
        ON dbo.ManifiestoDetalle(IdManifiesto);
END
GO
IF NOT EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE name = 'IX_ManifiestoDetalle_IdRemito'
      AND object_id = OBJECT_ID('dbo.ManifiestoDetalle')
)
BEGIN
    CREATE INDEX IX_ManifiestoDetalle_IdRemito
        ON dbo.ManifiestoDetalle(IdRemito);
END
GO
