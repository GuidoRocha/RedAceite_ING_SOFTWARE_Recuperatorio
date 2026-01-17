# ?? Sistema de Generación de PDFs de Remitos - RedAceite

## ?? **Índice**
1. [Arquitectura General](#arquitectura-general)
2. [Componentes Implementados](#componentes-implementados)
3. [Flujo de Generación](#flujo-de-generación)
4. [Configuración](#configuración)
5. [Uso desde UI](#uso-desde-ui)
6. [Estructura de Archivos](#estructura-de-archivos)
7. [Logging y Auditoría](#logging-y-auditoría)
8. [Troubleshooting](#troubleshooting)

---

## ??? **Arquitectura General**

```
???????????????????????????????????????????????????????????????
?                    UI LAYER                                 ?
?  FrmGenerarRemito.btnGenerarRemito_Click()                 ?
???????????????????????????????????????????????????????????????
                     ?
                     ?
???????????????????????????????????????????????????????????????
?                  BLL LAYER                                  ?
?  RemitoService.GenerarRemito()                             ?
?    ??? Crear Remito en BD                                  ?
?    ??? Actualizar Inventario                               ?
?    ??? RemitoPdfService.GenerarPdfRemito(idRemito)        ?
?           ??? Validaciones                                 ?
?           ??? Generar nombre archivo                       ?
?           ??? PdfService.GenerarPdfRemito()                ?
?           ??? Calcular hash MD5                            ?
?           ??? RemitoPdfRepository.Guardar()                ?
???????????????????????????????????????????????????????????????
                     ?
        ?????????????????????????????
        ?                           ?
????????????????????    ????????????????????????????
?   DAL LAYER      ?    ?   SERVICES LAYER         ?
?                  ?    ?                          ?
? RemitoPdfRepo    ?    ? PdfService (Facade)      ?
? RemitoRepo       ?    ?  ??? PdfGeneratorHelper  ?
?                  ?    ?       ??? iText7         ?
????????????????????    ????????????????????????????
                                    ?
                                    ?
                        ?????????????????????????
                        ?   FILESYSTEM          ?
                        ?  REMITO.PDF\          ?
                        ?   ?? [PDFs generados] ?
                        ?????????????????????????
```

---

## ?? **Componentes Implementados**

### **1. DOMAIN Layer**

#### **RemitoPDF.cs**
```csharp
namespace DOMAIN
{
    public class RemitoPDF
    {
        public Guid IdRemitoPDF { get; set; }
        public Guid IdRemito { get; set; }
        public string NombreArchivo { get; set; }  // Solo nombre, NO ruta
        public DateTime FechaGeneracion { get; set; }
        public long TamañoBytes { get; set; }
        public string HashMD5 { get; set; }
    }
}
```

**Características:**
- No guarda ruta completa, solo nombre del archivo
- Hash MD5 para verificación de integridad
- Relación 1:1 con Remito

---

### **2. DAL Layer**

#### **IRemitoPdfRepository.cs**
Métodos disponibles:
- `GuardarRegistroPdf(RemitoPDF remitoPdf)`
- `ObtenerPorIdRemito(Guid idRemito)`
- `ObtenerPorNombreArchivo(string nombreArchivo)`
- `ExistePdfParaRemito(Guid idRemito)`
- `ObtenerPorRangoFechas(DateTime inicio, DateTime fin)`
- `ActualizarHashMD5(Guid idRemitoPdf, string nuevoHashMD5)`

#### **RemitoPdfRepository.cs**
- Implementación completa con queries SQL optimizadas
- Manejo de conexiones usando `SqlHelper`
- Mapeo de DataReader a entidades

---

### **3. SERVICES Layer**

#### **ConfigHelper.cs**
```csharp
public static class ConfigHelper
{
    public static string ObtenerRutaPdfRemitos()
    public static string ObtenerRutaLogoRemito()
}
```

#### **DatosRemitoPdfDto.cs**
DTO que encapsula todos los datos necesarios para generar el PDF:
- Información del remito
- Información del transportista
- Información del generador
- Información del residuo
- Información de envío (opcional)

#### **PdfGeneratorHelper.cs**
Responsable de la generación técnica del PDF usando iText7:
- `CrearRemitoPdf(DatosRemitoPdfDto datos, string rutaDestino, string rutaLogo)`
- Métodos privados para cada sección:
  - `AgregarLogo()`
  - `AgregarCabecera()`
  - `AgregarDatosTransportista()`
  - `AgregarDatosGenerador()`
  - `AgregarDatosResiduo()`
  - `AgregarFechaYFirma()`
  - `AgregarTextoLegal()`
  - `AgregarDatosEnvio()` (si requiere)
  - `AgregarPie()`

#### **PdfService.cs** (Facade)
```csharp
public class PdfService
{
    public bool GenerarPdfRemito(DatosRemitoPdfDto datos, string rutaDestino, string rutaLogo)
    public string CalcularHashMD5(string rutaArchivo)
    public long ObtenerTamañoArchivo(string rutaArchivo)
    public bool ExisteArchivo(string rutaArchivo)
    public void EliminarArchivo(string rutaArchivo)
}
```

---

### **4. BLL Layer**

#### **RemitoPdfService.cs**
Orquestador principal de la generación de PDFs:

```csharp
public class RemitoPdfService
{
    public RemitoPDF GenerarPdfRemito(Guid idRemito)
    {
        // 1. Validar remito existe
        // 2. Verificar NO existe PDF ya
        // 3. Mapear datos a DTO
        // 4. Generar nombre archivo único
        // 5. Crear carpeta si no existe
        // 6. Generar PDF
        // 7. Calcular hash MD5
        // 8. Guardar registro en BD
        // 9. Logging completo
    }
}
```

**Formato de nombre de archivo:**
```
{FechaYYYYMMDD}_{NombreGenerador}_{IdRemito8chars}.pdf

Ejemplo:
20250117_MCDONALD_a1b2c3d4.pdf
```

#### **RemitoService.cs** (Modificado)
Integración automática de generación de PDF:

```csharp
public Guid GenerarRemito(...)
{
    // 1. Crear remito
    // 2. Actualizar inventario
    // 3. Generar PDF automáticamente
    //    ??? Si falla: advertencia en logs, NO rollback
}
```

---

## ?? **Flujo de Generación Completo**

### **Paso a Paso:**

```
1. Usuario completa FrmGenerarRemito
   ?
2. Click en "Generar Remito"
   ?
3. RemitoService.GenerarRemito()
   ??? 3a. Crear Remito en BD (tabla Remito)
   ?    ??? Obtener IdRemito = e5f6g7h8-...
   ?
   ??? 3b. Actualizar Inventario
   ?    ??? LOG: "Inventario actualizado automáticamente"
   ?
   ??? 3c. RemitoPdfService.GenerarPdfRemito(e5f6g7h8)
        ?
        ??? LOG: "Iniciando generación de PDF para remito..."
        ?
        ??? Validar remito existe
        ?    ??? Si NO existe: throw Exception
        ?
        ??? Verificar NO existe PDF ya
        ?    ??? Si existe: throw Exception
        ?
        ??? Mapear remito a DatosRemitoPdfDto
        ?    ??? Incluir todos los datos necesarios
        ?
        ??? Generar nombre archivo
        ?    Fecha = 20250117
        ?    Generador = MCDONALD (8 chars)
        ?    IdRemito = a1b2c3d4 (8 chars)
        ?    ? Nombre: 20250117_MCDONALD_a1b2c3d4.pdf
        ?    ??? LOG: "Nombre de archivo generado: ..."
        ?
        ??? Validar carpeta destino existe
        ?    ??? Si NO: crear carpeta
        ?         ??? LOG: "Carpeta creada: ..."
        ?
        ??? PdfService.GenerarPdfRemito()
        ?    ??? PdfGeneratorHelper.CrearRemitoPdf()
        ?         ??? Agregar logo (JPEG)
        ?         ??? Agregar cabecera (título + número)
        ?         ??? Agregar datos transportista
        ?         ??? Agregar datos generador
        ?         ??? Agregar datos residuo
        ?         ??? Agregar fecha y firma
        ?         ??? Agregar texto legal
        ?         ??? Agregar datos envío (si aplica)
        ?         ??? Agregar pie (WhatsApp)
        ?    ??? LOG: "PDF generado exitosamente en: ..."
        ?
        ??? Calcular hash MD5
        ?    ? Hash: a3f5b9c1d7e2f4a6...
        ?    ??? LOG: "Hash MD5 calculado: ..."
        ?
        ??? Obtener tamaño archivo
        ?    ? Tamaño: 245678 bytes (239.92 KB)
        ?    ??? LOG: "Tamaño del archivo: 245678 bytes"
        ?
        ??? RemitoPdfRepository.GuardarRegistroPdf()
             INSERT INTO RemitoPDF (
                 IdRemitoPDF = [nuevo guid],
                 IdRemito = e5f6g7h8,
                 NombreArchivo = "20250117_MCDONALD_a1b2c3d4.pdf",
                 FechaGeneracion = 2025-01-17 10:30:00,
                 TamañoBytes = 245678,
                 HashMD5 = "a3f5b9c1d7e2f4a6..."
             )
             ??? LOG: "Registro PDF guardado en BD"
   ?
4. MessageBox: "Remito generado exitosamente"
5. LOG: "Generación completada exitosamente"
```

---

## ?? **Configuración**

### **App.config (RedAceite_ING_SOFTWARE)**

```xml
<appSettings>
  <!-- Carpeta donde se guardan los PDFs de remitos NOTEBOOK -->
  <add key="RutaPDFRemitos" 
       value="C:\TrabajoDiplomaRecuperatorio\RedAceite_ING_SOFTWARE_Recuperatorio\REMITO.PDF\" />

  <!-- Carpeta donde se guardan los PDFs de remitos PC ESCRITORIO -->
  <!-- <add key="RutaPDFRemitos" value="C:\RedAceite\REMITO.PDF\" /> -->

  <!-- Ruta del logo para los remitos NOTEBOOK -->
  <add key="RutaLogoRemito" 
       value="C:\TrabajoDiplomaRecuperatorio\RedAceite_ING_SOFTWARE_Recuperatorio\REMITO.PDF\Recursos\LogoRemito.jpeg" />

  <!-- Ruta del logo para los remitos PC ESCRITORIO -->
  <!-- <add key="RutaLogoRemito" value="C:\RedAceite\REMITO.PDF\Recursos\LogoRemito.jpeg" /> -->
</appSettings>
```

### **Estructura de Carpetas Requerida:**

```
C:\TrabajoDiplomaRecuperatorio\RedAceite_ING_SOFTWARE_Recuperatorio\
??? REMITO.PDF\
    ??? Recursos\
    ?   ??? LogoRemito.jpeg    ? Logo de RedAceite (REQUERIDO)
    ??? [PDFs generados aquí]
```

---

## ?? **Uso desde UI**

### **Automático (al crear remito):**

```csharp
// En FrmGenerarRemito.btnGenerarRemito_Click()
Guid idRemito = _remitoService.GenerarRemito(...);

// Automáticamente:
// 1. Se crea el remito
// 2. Se actualiza el inventario
// 3. Se genera el PDF
// 4. Se guarda el registro en RemitoPDF
// 5. Todo queda en logs
```

### **Manual (si fuera necesario):**

```csharp
var remitoPdfService = new RemitoPdfService();
var remitoPdf = remitoPdfService.GenerarPdfRemito(idRemito);

MessageBox.Show($"PDF generado: {remitoPdf.NombreArchivo}");
```

---

## ?? **Estructura de Archivos Generados**

### **Tabla RemitoPDF (SQL Server):**

| Columna | Tipo | Descripción |
|---------|------|-------------|
| IdRemitoPDF | UNIQUEIDENTIFIER | PK, ID único del registro |
| IdRemito | UNIQUEIDENTIFIER | FK a Remito, único |
| NombreArchivo | NVARCHAR(255) | Solo nombre, NO ruta |
| FechaGeneracion | DATETIME | Timestamp de creación |
| TamañoBytes | BIGINT | Tamaño en bytes |
| HashMD5 | NVARCHAR(32) | Hash para integridad |

### **Filesystem:**

```
REMITO.PDF\
??? 20250117_MCDONALD_a1b2c3d4.pdf
??? 20250117_BURGERKI_b2c3d4e5.pdf
??? 20250118_SUBWAY_c3d4e5f6.pdf
??? ...
```

---

## ?? **Logging y Auditoría**

### **Niveles de Log Utilizados:**

| Nivel | Uso | Ejemplo |
|-------|-----|---------|
| **Info** | Eventos importantes | "Remito generado exitosamente" |
| **Verbose** | Detalles técnicos | "Hash MD5 calculado: xyz..." |
| **Warning** | Advertencias no críticas | "Logo no encontrado" |
| **Error** | Errores capturados | "Error al generar PDF" |

### **Logs Generados (Ejemplo Real):**

```
[2025-01-17 10:30:15] [INFO] RemitoService: Creando remito para McDonalds
[2025-01-17 10:30:15] [INFO] Inventario actualizado automáticamente para remito e5f6g7h8
[2025-01-17 10:30:15] [INFO] [RemitoPdfService] Iniciando generación de PDF para remito e5f6g7h8
[2025-01-17 10:30:15] [VERBOSE] [RemitoPdfService] Remito encontrado: McDonalds
[2025-01-17 10:30:15] [VERBOSE] [RemitoPdfService] Datos del remito mapeados. Número: 20250117-A1B2C
[2025-01-17 10:30:15] [INFO] [RemitoPdfService] Nombre de archivo generado: 20250117_MCDONALD_a1b2c3d4.pdf
[2025-01-17 10:30:16] [INFO] [RemitoPdfService] PDF generado exitosamente en: C:\...\REMITO.PDF\20250117_MCDONALD_a1b2c3d4.pdf
[2025-01-17 10:30:16] [VERBOSE] [RemitoPdfService] Hash MD5 calculado: a3f5b9c1d7e2f4a6...
[2025-01-17 10:30:16] [VERBOSE] [RemitoPdfService] Tamaño del archivo: 245678 bytes (239.92 KB)
[2025-01-17 10:30:16] [INFO] [RemitoPdfService] Registro PDF guardado en BD. ID: f6g7h8i9...
[2025-01-17 10:30:16] [INFO] [RemitoPdfService] Generación de PDF completada exitosamente
[2025-01-17 10:30:16] [INFO] PDF generado exitosamente para remito e5f6g7h8. Archivo: 20250117_MCDONALD_a1b2c3d4.pdf
```

---

## ?? **Troubleshooting**

### **Error: "Logo no encontrado"**

**Síntoma:** Advertencia en logs
```
[WARNING] Logo no encontrado en: C:\...\LogoRemito.jpeg
```

**Solución:**
1. Verificar que existe: `C:\...\REMITO.PDF\Recursos\LogoRemito.jpeg`
2. Si no existe, colocar el archivo en esa ubicación
3. El PDF se genera igual, pero sin logo

---

### **Error: "La configuración 'RutaPDFRemitos' no está definida"**

**Síntoma:** Exception al iniciar `RemitoPdfService`

**Solución:**
1. Abrir `App.config`
2. Verificar que existe:
```xml
<add key="RutaPDFRemitos" value="C:\...\REMITO.PDF\" />
```
3. Verificar que la ruta termina con `\`

---

### **Error: "Ya existe un PDF para el remito"**

**Síntoma:** Exception al generar PDF

**Causa:** Ya se generó un PDF para ese remito

**Solución:**
- Cada remito solo puede tener un PDF
- Si necesitas regenerar, primero eliminar el registro de `RemitoPDF`

---

### **Advertencia: "Remito creado pero error al generar PDF"**

**Síntoma:** Remito creado, pero PDF falla

**Causa:** Error en generación de PDF (iText, permisos, etc.)

**Comportamiento:**
- ? Remito se crea correctamente
- ? Inventario se actualiza
- ? PDF no se genera
- ?? Warning en logs

**Solución:**
1. Revisar logs para ver error específico
2. Verificar permisos de carpeta `REMITO.PDF\`
3. Regenerar PDF manualmente:
```csharp
var remitoPdfService = new RemitoPdfService();
remitoPdfService.GenerarPdfRemito(idRemito);
```

---

## ?? **Ventajas de esta Implementación**

### **? Arquitectura Limpia**
- Separación clara de responsabilidades
- iText7 solo en SERVICES/Helpers
- BLL sin dependencias técnicas

### **? Portabilidad**
- Solo nombre de archivo en BD, NO ruta
- Fácil cambiar ubicación de PDFs
- Backups simples

### **? Integridad**
- Hash MD5 verifica archivo no modificado
- Constraint UNIQUE: un remito = un PDF
- ON DELETE CASCADE automático

### **? Auditoría Completa**
- Todo registrado en logs
- Rastreabilidad total
- Debugging fácil

### **? Resiliente**
- Si falla PDF: remito sigue creándose
- Carpetas se crean automáticamente
- Validaciones robustas

---

## ?? **Próximos Pasos (Futuro)**

1. **Descarga de PDFs desde UI**
   - Botón en formulario de remitos
   - Abrir PDF con visor predeterminado

2. **Regeneración de PDFs**
   - Si se pierde el archivo físico
   - Si se modifican datos del remito

3. **Envío por Email**
   - Adjuntar PDF automáticamente
   - Enviar a proveedor

4. **Impresión Directa**
   - Imprimir sin abrir visor
   - Configurar impresora predeterminada

---

## ?? **Soporte**

Para consultas sobre esta implementación:
- Revisar logs en tabla de bitácora
- Verificar configuración en `App.config`
- Comprobar permisos de carpetas

---

**Documento generado:** 2025-01-17  
**Versión del sistema:** 1.0.0  
**Framework:** .NET Framework 4.7.2  
**Librería PDF:** iText7 v8.0.2
