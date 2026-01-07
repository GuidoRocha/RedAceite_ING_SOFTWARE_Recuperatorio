# ? CHECKLIST DE IMPLEMENTACIÓN - Sistema de Proveedores

## ?? Antes de Empezar

- [ ] Tengo SQL Server instalado y funcionando
- [ ] Tengo acceso a SQL Server Management Studio
- [ ] El proyecto RedAceite_ING_SOFTWARE compila correctamente
- [ ] He leído el archivo INICIO_RAPIDO_PROVEEDORES.md

---

## ??? Base de Datos

### Creación de Base de Datos
- [ ] Base de datos `RedAceiteProveedores` creada
- [ ] Tabla `Proveedor` creada con todos los campos
- [ ] Los 5 índices están creados:
  - [ ] IX_Proveedor_CUIT
  - [ ] IX_Proveedor_DNI
  - [ ] IX_Proveedor_RazonSocial
  - [ ] IX_Proveedor_Region
  - [ ] IX_Proveedor_Activo
- [ ] Datos de prueba insertados (opcional)
- [ ] Puedo hacer SELECT * FROM Proveedor sin errores

### Verificación Rápida (ejecutar en SQL)
```sql
USE RedAceiteProveedores;
SELECT COUNT(*) AS 'Total Proveedores' FROM Proveedor;
-- Debería retornar 0 o más (dependiendo si insertaste datos de prueba)
```

---

## ?? Configuración

### App.config
- [ ] Archivo `RedAceite_ING_SOFTWARE\App.config` abierto
- [ ] Encontré la sección `<connectionStrings>`
- [ ] Encontré la línea `Proveedores_conexiones`
- [ ] Modifiqué `Data Source=` con MI servidor
- [ ] Guardé el archivo App.config

### Mi cadena de conexión dice:
```
Data Source=[MI_SERVIDOR];Initial Catalog=RedAceiteProveedores;Integrated Security=True;TrustServerCertificate=True
```
**Reemplazar [MI_SERVIDOR] con tu servidor real**

### Probar Conexión
- [ ] Compilé el proyecto sin errores
- [ ] No hay errores en SERVICES
- [ ] No hay errores en RedAceite_ING_SOFTWARE
- [ ] (Ignorar errores en BLL - son preexistentes)

---

## ?? Interfaz de Usuario

### Agregar al Menú Principal
- [ ] Agregué un botón/ítem de menú para "Gestión de Proveedores"
- [ ] El código del evento Click incluye:
```csharp
var frm = new FrmGestionProveedores();
frm.ShowDialog();
```
- [ ] Compilé y ejecuté la aplicación
- [ ] Puedo abrir el formulario de Gestión de Proveedores

---

## ?? Pruebas Básicas

### Test 1: Ver Lista Vacía
- [ ] Abrí FrmGestionProveedores
- [ ] Veo el DataGridView vacío (si no hay datos)
- [ ] Veo los botones: Agregar, Modificar, Deshabilitar
- [ ] Veo los filtros: CUIT, Razón Social, Región

### Test 2: Agregar Proveedor
- [ ] Click en "Agregar Proveedor"
- [ ] Se abre FrmAltaProveedor
- [ ] Completé Nombre y CUIT
- [ ] Click en "Guardar"
- [ ] Veo mensaje "Proveedor agregado exitosamente"
- [ ] El nuevo proveedor aparece en la lista

### Test 3: Validaciones
- [ ] Intenté agregar proveedor sin nombre ? Muestra error ?
- [ ] Intenté agregar proveedor sin CUIT ? Muestra error ?
- [ ] Intenté agregar CUIT duplicado ? Muestra error ?
- [ ] Intenté ingresar email inválido ? Muestra error ?

### Test 4: Modificar Proveedor
- [ ] Seleccioné un proveedor de la lista
- [ ] Click en "Modificar Proveedor"
- [ ] Se abre FrmModificarProveedor con datos cargados
- [ ] CUIT y DNI están deshabilitados (grises) ?
- [ ] Puedo modificar Nombre, Dirección, etc.
- [ ] Click en "Guardar"
- [ ] Veo mensaje "Proveedor modificado exitosamente"
- [ ] Los cambios se reflejan en la lista

### Test 5: Deshabilitar Proveedor
- [ ] Seleccioné un proveedor de la lista
- [ ] Click en "Deshabilitar Proveedor"
- [ ] Aparece confirmación
- [ ] Click en "Sí"
- [ ] Veo mensaje "Proveedor deshabilitado exitosamente"
- [ ] El proveedor desaparece de la lista

### Test 6: Filtros
- [ ] Ingresé texto en filtro CUIT
- [ ] Click en "Filtrar"
- [ ] Solo veo proveedores que coinciden
- [ ] Click en "Limpiar"
- [ ] Veo todos los proveedores otra vez

---

## ?? Verificación en Base de Datos

### Después de Agregar un Proveedor
```sql
USE RedAceiteProveedores;
SELECT TOP 1 * FROM Proveedor ORDER BY FechaCreacion DESC;
-- Debería ver el proveedor recién creado
```

- [ ] Ejecuté la consulta
- [ ] Veo el proveedor que agregué
- [ ] El campo `Activo` es 1 (true)
- [ ] `FechaCreacion` tiene la fecha/hora actual
- [ ] `IdSimple` es un número secuencial

### Después de Deshabilitar un Proveedor
```sql
USE RedAceiteProveedores;
SELECT * FROM Proveedor WHERE Activo = 0;
-- Debería ver proveedores deshabilitados
```

- [ ] Ejecuté la consulta
- [ ] Veo el proveedor que deshabilitté
- [ ] El campo `Activo` es 0 (false)
- [ ] `FechaModificacion` tiene fecha/hora de cuando lo deshabilitté

---

## ?? Verificación de Logs

### Si tienes sistema de logs configurado
- [ ] Abrí la base de datos de logs
- [ ] Busqué "Proveedor creado"
- [ ] Busqué "Proveedor modificado"
- [ ] Busqué "Proveedor deshabilitado"
- [ ] Todos los eventos están registrados

---

## ?? Verificación de Archivos

### Archivos del Proyecto - Capa SERVICES
- [ ] `SERVICES\Dominio\Proveedor.cs` existe
- [ ] `SERVICES\DAL\Contratos\IProveedorDAL.cs` existe
- [ ] `SERVICES\DAL\Implementaciones\SQL\ProveedorRepository.cs` existe
- [ ] `SERVICES\Logic\ProveedorLogic.cs` existe
- [ ] `SERVICES\Facade\ProveedorService.cs` existe

### Archivos del Proyecto - Capa UI
- [ ] `RedAceite_ING_SOFTWARE\Forms\FrmGestionProveedores.cs` existe
- [ ] `RedAceite_ING_SOFTWARE\Forms\FrmGestionProveedores.Designer.cs` existe
- [ ] `RedAceite_ING_SOFTWARE\Forms\FrmAltaProveedor.cs` existe
- [ ] `RedAceite_ING_SOFTWARE\Forms\FrmAltaProveedor.Designer.cs` existe
- [ ] `RedAceite_ING_SOFTWARE\Forms\FrmModificarProveedor.cs` existe
- [ ] `RedAceite_ING_SOFTWARE\Forms\FrmModificarProveedor.Designer.cs` existe

### Archivos Modificados
- [ ] `SERVICES\DAL\FactoryServices\DALFactory.cs` tiene ProveedorRepository
- [ ] `SERVICES\DAL\Implementaciones\SQL\Helpers\SqlHelper.cs` tiene conStringProveedores
- [ ] `RedAceite_ING_SOFTWARE\App.config` tiene Proveedores_conexiones

### Documentación
- [ ] `README_PROVEEDORES.md` existe y está completo
- [ ] `RESUMEN_IMPLEMENTACION_PROVEEDORES.md` existe
- [ ] `INICIO_RAPIDO_PROVEEDORES.md` existe
- [ ] Este archivo `CHECKLIST_PROVEEDORES.md` existe

---

## ?? Funcionalidades Verificadas

### Requisitos del Sistema
- [ ] ? REQ.PROVEEDOR.001 – Alta de Proveedor FUNCIONA
- [ ] ? REQ.PROVEEDOR.002 – Deshabilitar Proveedor FUNCIONA
- [ ] ? REQ.PROVEEDOR.003 – Modificación de Proveedor FUNCIONA
- [ ] ? REQ.PROVEEDOR.004 – Listar Proveedores FUNCIONA

### Validaciones
- [ ] ? No permite CUIT duplicado
- [ ] ? No permite DNI duplicado
- [ ] ? Valida formato de CUIT (11 dígitos)
- [ ] ? Valida formato de Email
- [ ] ? No permite modificar CUIT después del alta
- [ ] ? No permite modificar DNI después del alta
- [ ] ? Campos obligatorios validados

### Filtros
- [ ] ? Filtro por CUIT funciona
- [ ] ? Filtro por Razón Social funciona
- [ ] ? Filtro por Región funciona
- [ ] ? Botón "Limpiar" limpia todos los filtros
- [ ] ? Puedo combinar múltiples filtros

---

## ?? Listo para Producción

### Últimas Verificaciones
- [ ] El sistema funciona en mi máquina de desarrollo
- [ ] He probado todas las funcionalidades
- [ ] No hay errores en tiempo de ejecución
- [ ] Los datos se guardan correctamente en BD
- [ ] Los logs se registran correctamente
- [ ] La interfaz es clara y fácil de usar
- [ ] He leído toda la documentación

### Documentación Entregada
- [ ] Script SQL para crear la base de datos
- [ ] Documentación completa en README_PROVEEDORES.md
- [ ] Guía de inicio rápido
- [ ] Este checklist
- [ ] Resumen de implementación

---

## ? FIRMA DE APROBACIÓN

**Fecha de Verificación**: _______________

**Verificado por**: _______________

**Estado**: 
- [ ] ? TODO FUNCIONA - Sistema aprobado para uso
- [ ] ?? PENDIENTE - Ver notas abajo
- [ ] ? NO FUNCIONA - Ver problemas abajo

**Notas/Problemas encontrados**:
```
_____________________________________________________________
_____________________________________________________________
_____________________________________________________________
```

---

## ?? Soporte

Si algo no funciona, verifica:

1. **Base de datos existe y está accesible**
   - Intenta conectarte con SQL Server Management Studio
   
2. **Cadena de conexión es correcta**
   - Verifica el nombre del servidor en App.config
   
3. **El proyecto compila sin errores**
   - Reconstruye la solución (Rebuild Solution)
   
4. **Revisa los documentos de ayuda**
   - INICIO_RAPIDO_PROVEEDORES.md
   - README_PROVEEDORES.md (sección Troubleshooting)

---

## ?? ¡Felicitaciones!

Si todos los checkboxes están marcados, el sistema está **100% funcional** y listo para usar.

**¡Disfruta tu nuevo sistema de gestión de proveedores!** ??
