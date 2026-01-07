# Sistema de Gestión de Proveedores - RedAceite

## Descripción General

Este módulo implementa el sistema completo de gestión de proveedores para RedAceite, siguiendo los mismos patrones de diseño utilizados en la gestión de usuarios.

## Patrones de Diseño Implementados

### 1. **Facade Pattern** (Patrón Fachada)
- **Clase**: `ProveedorService`
- **Ubicación**: `SERVICES/Facade/ProveedorService.cs`
- **Propósito**: Proporciona una interfaz simplificada para todas las operaciones de proveedores
- **Métodos principales**:
  - `CrearProveedor()` - Alta de proveedor
  - `ModificarProveedor()` - Modificación de proveedor
  - `DeshabilitarProveedor()` - Baja lógica de proveedor
  - `ObtenerProveedoresActivos()` - Listar proveedores activos
  - `FiltrarProveedores()` - Filtrar por CUIT, razón social o región

### 2. **Repository Pattern** (Patrón Repositorio)
- **Interfaz**: `IProveedorDAL`
- **Implementación**: `ProveedorRepository`
- **Ubicación**: `SERVICES/DAL/`
- **Propósito**: Abstrae el acceso a datos y permite cambiar el motor de BD sin afectar la lógica

### 3. **Factory Pattern** (Patrón Fábrica)
- **Clase**: `DALFactory`
- **Ubicación**: `SERVICES/DAL/FactoryServices/DALFactory.cs`
- **Propósito**: Crea instancias de repositorios según la configuración
- **Nuevo**: Se agregó `ProveedorRepository` al factory

### 4. **Singleton Pattern** (Patrón Singleton)
- **Implementado en**: `DALFactory.ProveedorRepository`
- **Propósito**: Garantiza una única instancia del repositorio en toda la aplicación

## Estructura de Capas

```
???????????????????????????????????????????
?   CAPA DE PRESENTACIÓN (UI)             ?
?   - FrmGestionProveedores               ?
?   - FrmAltaProveedor                    ?
?   - FrmModificarProveedor               ?
???????????????????????????????????????????
                  ?
???????????????????????????????????????????
?   CAPA DE FACHADA (Facade)              ?
?   - ProveedorService                    ?
???????????????????????????????????????????
                  ?
???????????????????????????????????????????
?   CAPA DE LÓGICA (Logic)                ?
?   - ProveedorLogic                      ?
?   - Validaciones de negocio             ?
???????????????????????????????????????????
                  ?
???????????????????????????????????????????
?   CAPA DE ACCESO A DATOS (DAL)          ?
?   - IProveedorDAL (Contrato)            ?
?   - ProveedorRepository (Implementación)?
?   - DALFactory                          ?
???????????????????????????????????????????
                  ?
???????????????????????????????????????????
?   BASE DE DATOS                         ?
?   - RedAceiteProveedores                ?
?   - Tabla: Proveedor                    ?
???????????????????????????????????????????
```

## Archivos Creados/Modificados

### Nuevos Archivos

#### Capa de Dominio
- `SERVICES/Dominio/Proveedor.cs` - Entidad del proveedor

#### Capa DAL (Data Access Layer)
- `SERVICES/DAL/Contratos/IProveedorDAL.cs` - Interfaz del repositorio
- `SERVICES/DAL/Implementaciones/SQL/ProveedorRepository.cs` - Implementación del repositorio

#### Capa de Lógica
- `SERVICES/Logic/ProveedorLogic.cs` - Lógica de negocio

#### Capa de Fachada
- `SERVICES/Facade/ProveedorService.cs` - Servicio de fachada

#### Capa de Presentación (UI)
- `RedAceite_ING_SOFTWARE/Forms/FrmGestionProveedores.cs` - Formulario principal de gestión
- `RedAceite_ING_SOFTWARE/Forms/FrmGestionProveedores.Designer.cs`
- `RedAceite_ING_SOFTWARE/Forms/FrmAltaProveedor.cs` - Formulario de alta
- `RedAceite_ING_SOFTWARE/Forms/FrmAltaProveedor.Designer.cs`
- `RedAceite_ING_SOFTWARE/Forms/FrmModificarProveedor.cs` - Formulario de modificación
- `RedAceite_ING_SOFTWARE/Forms/FrmModificarProveedor.Designer.cs`

### Archivos Modificados

- `SERVICES/DAL/FactoryServices/DALFactory.cs` - Agregado ProveedorRepository
- `SERVICES/DAL/Implementaciones/SQL/Helpers/SqlHelper.cs` - Agregada cadena de conexión de proveedores
- `RedAceite_ING_SOFTWARE/App.config` - Agregada configuración de conexión

## Configuración de la Base de Datos

### 1. Crear la Base de Datos

Ejecuta el siguiente script SQL en tu servidor SQL Server:

```sql
-- Crear la base de datos
CREATE DATABASE RedAceiteProveedores;
GO

USE RedAceiteProveedores;
GO

-- Crear la tabla de Proveedores
CREATE TABLE Proveedor (
    IdProveedor UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    IdSimple INT IDENTITY(1,1) NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    CUIT NVARCHAR(11) NOT NULL UNIQUE,
    DNI NVARCHAR(10) NULL UNIQUE,
    Direccion NVARCHAR(200) NULL,
    Telefono NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL,
    RazonSocial NVARCHAR(150) NULL,
    Region NVARCHAR(50) NULL,
    Activo BIT NOT NULL DEFAULT 1,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    FechaModificacion DATETIME NULL
);
GO

-- Crear índices
CREATE INDEX IX_Proveedor_CUIT ON Proveedor(CUIT);
CREATE INDEX IX_Proveedor_DNI ON Proveedor(DNI) WHERE DNI IS NOT NULL;
CREATE INDEX IX_Proveedor_RazonSocial ON Proveedor(RazonSocial);
CREATE INDEX IX_Proveedor_Region ON Proveedor(Region);
CREATE INDEX IX_Proveedor_Activo ON Proveedor(Activo);
GO

-- Datos de ejemplo (opcional)
INSERT INTO Proveedor (Nombre, CUIT, DNI, Direccion, Telefono, Email, RazonSocial, Region, Activo)
VALUES 
    ('Juan Pérez', '20123456789', '12345678', 'Av. Corrientes 1234, CABA', '011-4567-8900', 'juan.perez@email.com', 'Pérez S.A.', 'CABA', 1),
    ('María González', '27987654321', '98765432', 'Av. Santa Fe 5678, CABA', '011-4321-0987', 'maria.gonzalez@email.com', 'González SRL', 'CABA', 1),
    ('Carlos Rodríguez', '30456789123', '45678912', 'Av. Libertador 9101, Zona Norte', '011-5555-1234', 'carlos.rodriguez@email.com', 'Rodríguez Hnos.', 'Zona Norte', 1);
GO
```

### 2. Configurar la Cadena de Conexión

En el archivo `App.config` de la capa UI (`RedAceite_ING_SOFTWARE`), ya se agregó la cadena de conexión. 

**DEBES MODIFICAR** la cadena de conexión con tu servidor:

```xml
<!-- Cambia "GuidoPC" por el nombre de tu servidor SQL Server -->
<add name="Proveedores_conexiones" 
     connectionString="Data Source=TU_SERVIDOR;Initial Catalog=RedAceiteProveedores;Integrated Security=True;TrustServerCertificate=True"
     providerName="System.Data.SqlClient" />
```

Ejemplos de nombres de servidor:
- `localhost` - Si SQL Server está en la misma máquina
- `.\SQLEXPRESS` - Si usas SQL Server Express en tu máquina
- `NOMBRE_PC\SQLEXPRESS` - Si usas SQL Server Express en una PC específica

## Casos de Uso Implementados

### REQ.PROVEEDOR.001 – Alta de Proveedor
**Formulario**: `FrmAltaProveedor`

**Campos obligatorios**:
- Nombre del proveedor
- CUIT

**Campos opcionales**:
- DNI
- Dirección
- Teléfono
- Email
- Razón social
- Región

**Validaciones**:
- ? Verificación de CUIT/DNI duplicado
- ? Formato de CUIT (11 dígitos)
- ? Formato de Email válido
- ? Campos obligatorios completados

### REQ.PROVEEDOR.002 – Deshabilitar Proveedor
**Formulario**: `FrmGestionProveedores` (botón Deshabilitar)

**Proceso**:
1. Seleccionar proveedor de la lista
2. Click en "Deshabilitar Proveedor"
3. Confirmar acción
4. El proveedor cambia su estado a Inactivo
5. No aparece en listados activos

### REQ.PROVEEDOR.003 – Modificación de Proveedor
**Formulario**: `FrmModificarProveedor`

**Campos modificables**:
- Nombre
- Dirección
- Teléfono
- Email
- Razón social
- Región

**Campos NO modificables** (según requisitos):
- CUIT
- DNI

**Validaciones**:
- ? CUIT y DNI no se pueden modificar
- ? Formato de Email válido
- ? Nombre obligatorio

### REQ.PROVEEDOR.004 – Listar Proveedores
**Formulario**: `FrmGestionProveedores`

**Funcionalidades**:
- ? Listar todos los proveedores activos
- ? Filtrar por CUIT
- ? Filtrar por Razón Social
- ? Filtrar por Región
- ? Mostrar ID simple (no GUID)
- ? Ordenar por ID

## Cómo Usar el Sistema

### 1. Abrir Gestión de Proveedores

Desde tu menú principal, agregar un botón que abra:

```csharp
var frmGestionProveedores = new FrmGestionProveedores();
frmGestionProveedores.ShowDialog();
```

### 2. Agregar un Proveedor

1. Click en "+ Agregar Proveedor"
2. Completar nombre y CUIT (obligatorios)
3. Completar datos adicionales (opcionales)
4. Click en "Guardar"

### 3. Modificar un Proveedor

1. Seleccionar proveedor de la lista
2. Click en "Modificar Proveedor"
3. Editar los campos permitidos
4. Click en "Guardar"

### 4. Deshabilitar un Proveedor

1. Seleccionar proveedor de la lista
2. Click en "Deshabilitar Proveedor"
3. Confirmar la acción

### 5. Filtrar Proveedores

1. Ingresar texto en los campos de filtro
2. Click en "Filtrar"
3. Para limpiar filtros, click en "Limpiar"

## Características de Seguridad

- ? **Soft Delete**: Los proveedores no se eliminan físicamente, solo se deshabilitan
- ? **Validación de duplicados**: No se permite CUIT o DNI duplicado
- ? **Auditoría**: Se registra fecha de creación y modificación
- ? **Logging**: Todas las operaciones se registran en el log del sistema
- ? **Integridad**: CUIT y DNI únicos en la base de datos

## Notas Importantes

1. **ID Simple vs GUID**:
   - Internamente se usa GUID para mantener unicidad global
   - Al usuario se muestra un ID simple autoincremental
   - Esto evita mostrar GUIDs largos en la interfaz

2. **CUIT y DNI**:
   - No se pueden modificar una vez registrados
   - Esto previene duplicados y mantiene integridad de datos

3. **Estado del Proveedor**:
   - Activo (1): El proveedor aparece en los listados
   - Inactivo (0): El proveedor no aparece pero los datos se conservan

4. **Logging**:
   - Se registra cada operación de alta, modificación y baja
   - Los logs se almacenan usando el `LoggerService` existente

## Troubleshooting

### Error: "No se puede conectar a la base de datos"
**Solución**: Verificar la cadena de conexión en `App.config`

### Error: "El proveedor ya existe"
**Solución**: Verificar que no haya un proveedor con el mismo CUIT o DNI

### Error: "No se puede modificar CUIT o DNI"
**Solución**: Esto es por diseño. CUIT y DNI no son modificables después del alta

### El ID Simple no comienza en 1
**Solución**: Normal si ya se eliminaron registros. El IDENTITY continúa contando

## Próximas Mejoras Sugeridas

- [ ] Exportar listado de proveedores a Excel/PDF
- [ ] Importar proveedores desde archivo CSV
- [ ] Historial de modificaciones de proveedor
- [ ] Integración con sistema de compras
- [ ] Dashboard con estadísticas de proveedores por región
- [ ] Validación de CUIT contra AFIP
- [ ] Sistema de calificación de proveedores
