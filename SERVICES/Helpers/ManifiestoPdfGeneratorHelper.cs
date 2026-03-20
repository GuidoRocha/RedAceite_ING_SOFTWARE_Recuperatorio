using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using SERVICES.DTO;
using SERVICES.Facade;
using System;
using System.IO;

namespace SERVICES.Helpers
{
    /// <summary>
    /// Helper para generar archivos PDF de manifiestos diarios utilizando iText7.
    /// Sigue el mismo patron que PdfGeneratorHelper pero con contenido de manifiesto.
    /// </summary>
    public class ManifiestoPdfGeneratorHelper
    {
        /// <summary>
        /// Crea un archivo PDF de manifiesto con los datos proporcionados.
        /// </summary>
        /// <param name="datos">Datos del manifiesto a incluir en el PDF.</param>
        /// <param name="rutaDestino">Ruta completa donde se guardara el archivo PDF.</param>
        /// <param name="rutaLogo">Ruta completa del archivo de logo a incluir.</param>
        public void CrearManifiestoPdf(DatosManifiestoPdfDto datos, string rutaDestino, string rutaLogo)
        {
            PdfWriter writer = null;
            PdfDocument pdf = null;
            Document document = null;

            try
            {
                LoggerService.WriteLog("[ManifiestoPdfHelper] === INICIO CREACION PDF MANIFIESTO ===",
                    System.Diagnostics.TraceLevel.Info);

                writer = new PdfWriter(rutaDestino);
                pdf = new PdfDocument(writer);
                document = new Document(pdf, PageSize.A4);
                document.SetMargins(30, 30, 30, 30);

                // Agregar contenido al documento
                AgregarLogo(document, rutaLogo);
                AgregarCabecera(document, datos);
                AgregarDatosTransportista(document, datos);
                AgregarTablaDetalles(document, datos);
                AgregarResumenTotales(document, datos);
                AgregarFechaYFirma(document, datos);
                AgregarPie(document);

                LoggerService.WriteLog("[ManifiestoPdfHelper] Contenido agregado exitosamente",
                    System.Diagnostics.TraceLevel.Info);
            }
            catch (Exception ex)
            {
                LoggerService.WriteLog($"[ManifiestoPdfHelper] ERROR al crear PDF: {ex.Message}",
                    System.Diagnostics.TraceLevel.Error);
                LoggerService.WriteException(ex);
                throw new Exception($"Error al generar el PDF del manifiesto: {ex.Message}", ex);
            }
            finally
            {
                try { if (document != null) document.Close(); } catch { }
                try { if (pdf != null) pdf.Close(); } catch { }
                try { if (writer != null) writer.Close(); } catch { }

                LoggerService.WriteLog("[ManifiestoPdfHelper] === FIN CREACION PDF MANIFIESTO ===",
                    System.Diagnostics.TraceLevel.Info);
            }
        }

        /// <summary>
        /// Agrega el logo de RedAceite.
        /// </summary>
        private void AgregarLogo(Document document, string rutaLogo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(rutaLogo) || !File.Exists(rutaLogo))
                {
                    LoggerService.WriteLog("[ManifiestoPdfHelper] Logo no encontrado. Continuando sin logo.",
                        System.Diagnostics.TraceLevel.Warning);
                    return;
                }

                ImageData imageData = ImageDataFactory.Create(rutaLogo);
                Image logo = new Image(imageData);
                logo.ScaleToFit(150, 80);
                logo.SetHorizontalAlignment(HorizontalAlignment.LEFT);
                document.Add(logo);
            }
            catch (Exception ex)
            {
                LoggerService.WriteLog($"[ManifiestoPdfHelper] Error al agregar logo: {ex.Message}",
                    System.Diagnostics.TraceLevel.Warning);
            }
        }

        /// <summary>
        /// Agrega la cabecera del manifiesto con titulo, numero y fecha.
        /// </summary>
        private void AgregarCabecera(Document document, DatosManifiestoPdfDto datos)
        {
            // Titulo principal
            Paragraph titulo1 = new Paragraph("REDACEITE")
                .SetFontSize(20)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontColor(new DeviceRgb(0, 128, 0));

            Paragraph titulo2 = new Paragraph("SERVICIOS ECOLOGICOS")
                .SetFontSize(14)
                .SetTextAlignment(TextAlignment.CENTER);

            document.Add(titulo1);
            document.Add(titulo2);

            // Numero de manifiesto
            Paragraph numero = new Paragraph($"MANIFIESTO {datos.NumeroManifiesto}")
                .SetFontSize(12)
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD));

            document.Add(numero);

            // Subtitulo con fecha
            Paragraph subtitulo = new Paragraph($"MANIFIESTO DIARIO DE RECOLECCION - {datos.FechaManifiesto:dd/MM/yyyy}")
                .SetFontSize(10)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetBackgroundColor(new DeviceRgb(200, 200, 200))
                .SetPadding(5);

            document.Add(subtitulo);
            document.Add(new Paragraph("\n"));
        }

        /// <summary>
        /// Agrega los datos del transportista.
        /// </summary>
        private void AgregarDatosTransportista(Document document, DatosManifiestoPdfDto datos)
        {
            Table tabla = new Table(2).UseAllAvailableWidth();
            tabla.SetBorder(new SolidBorder(1));

            tabla.AddCell(CrearCeldaEtiqueta("Nombre del Transportista:"));
            tabla.AddCell(CrearCeldaDato(datos.NombreTransportista));

            tabla.AddCell(CrearCeldaEtiqueta("Domicilio:"));
            tabla.AddCell(CrearCeldaDato(datos.DomicilioTransportista));

            tabla.AddCell(CrearCeldaEtiqueta("Telefono:"));
            tabla.AddCell(CrearCeldaDato(datos.TelefonoTransportista));

            document.Add(tabla);
            document.Add(new Paragraph("\n"));
        }

        /// <summary>
        /// Agrega la tabla de detalles con todos los remitos del dia.
        /// Columnas: #, Generador, Tipo Residuo, Cantidad, Precio Unit., Subtotal
        /// </summary>
        private void AgregarTablaDetalles(Document document, DatosManifiestoPdfDto datos)
        {
            Paragraph tituloDetalle = new Paragraph("DETALLE DE REMITOS")
                .SetFontSize(11)
                .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD))
                .SetTextAlignment(TextAlignment.LEFT);

            document.Add(tituloDetalle);

            // Tabla con 6 columnas: #, Generador, Tipo, Cantidad, Precio, Subtotal
            float[] anchos = new float[] { 30f, 180f, 70f, 70f, 80f, 80f };
            Table tabla = new Table(anchos).UseAllAvailableWidth();
            tabla.SetBorder(new SolidBorder(1));

            // Cabecera de la tabla
            tabla.AddHeaderCell(CrearCeldaCabecera("#"));
            tabla.AddHeaderCell(CrearCeldaCabecera("Generador"));
            tabla.AddHeaderCell(CrearCeldaCabecera("Tipo Residuo"));
            tabla.AddHeaderCell(CrearCeldaCabecera("Cantidad"));
            tabla.AddHeaderCell(CrearCeldaCabecera("Precio Unit."));
            tabla.AddHeaderCell(CrearCeldaCabecera("Subtotal"));

            // Filas de detalle
            if (datos.Detalles != null)
            {
                foreach (var detalle in datos.Detalles)
                {
                    string unidad = detalle.TipoResiduo == "Aceite" ? "L" : "Kg";

                    tabla.AddCell(CrearCeldaDato(detalle.Orden.ToString()));
                    tabla.AddCell(CrearCeldaDato(detalle.NombreGenerador));
                    tabla.AddCell(CrearCeldaDato(detalle.TipoResiduo));
                    tabla.AddCell(CrearCeldaDato($"{detalle.Cantidad:N2} {unidad}"));
                    tabla.AddCell(CrearCeldaDato($"${detalle.PrecioUnitario:N2}"));
                    tabla.AddCell(CrearCeldaDato($"${detalle.Subtotal:N2}"));
                }
            }

            document.Add(tabla);
            document.Add(new Paragraph("\n"));
        }

        /// <summary>
        /// Agrega el resumen de totales al final.
        /// </summary>
        private void AgregarResumenTotales(Document document, DatosManifiestoPdfDto datos)
        {
            Table tabla = new Table(2).UseAllAvailableWidth();
            tabla.SetBorder(new SolidBorder(1));

            tabla.AddCell(CrearCeldaEtiqueta("Total de Remitos:"));
            tabla.AddCell(CrearCeldaDato(datos.CantidadTotalRemitos.ToString()));

            tabla.AddCell(CrearCeldaEtiquetaDestacada("MONTO TOTAL A PAGAR:"));
            tabla.AddCell(CrearCeldaDatoDestacado($"${datos.MontoTotal:N2}"));

            document.Add(tabla);
            document.Add(new Paragraph("\n"));
        }

        /// <summary>
        /// Agrega fecha y espacio para firma.
        /// </summary>
        private void AgregarFechaYFirma(Document document, DatosManifiestoPdfDto datos)
        {
            Table tabla = new Table(2).UseAllAvailableWidth();
            tabla.SetBorder(Border.NO_BORDER);

            Paragraph fecha = new Paragraph($"Fecha: {datos.FechaManifiesto:dd/MM/yyyy}")
                .SetFontSize(10);

            Cell celdaFecha = new Cell()
                .Add(fecha)
                .SetBorder(Border.NO_BORDER)
                .SetTextAlignment(TextAlignment.LEFT);

            Paragraph firma = new Paragraph("\n\n_______________________________\nFirma")
                .SetFontSize(10)
                .SetTextAlignment(TextAlignment.CENTER);

            Cell celdaFirma = new Cell()
                .Add(firma)
                .SetBorder(Border.NO_BORDER)
                .SetTextAlignment(TextAlignment.RIGHT);

            tabla.AddCell(celdaFecha);
            tabla.AddCell(celdaFirma);

            document.Add(tabla);
        }

        /// <summary>
        /// Agrega el pie de pagina.
        /// </summary>
        private void AgregarPie(Document document)
        {
            document.Add(new Paragraph("\n"));

            Paragraph contacto = new Paragraph("(011)114-4917473 | Info@redaceite.com.ar")
                .SetFontSize(10)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontColor(new DeviceRgb(100, 100, 100));

            document.Add(contacto);
        }

        #region Helpers de celdas

        private Cell CrearCeldaEtiqueta(string texto)
        {
            return new Cell()
                .Add(new Paragraph(texto).SetFontSize(9))
                .SetBackgroundColor(new DeviceRgb(240, 240, 240))
                .SetPadding(5);
        }

        private Cell CrearCeldaDato(string texto)
        {
            return new Cell()
                .Add(new Paragraph(texto ?? "").SetFontSize(9))
                .SetPadding(5);
        }

        private Cell CrearCeldaCabecera(string texto)
        {
            return new Cell()
                .Add(new Paragraph(texto).SetFontSize(9).SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)))
                .SetBackgroundColor(new DeviceRgb(0, 128, 0))
                .SetFontColor(ColorConstants.WHITE)
                .SetPadding(5)
                .SetTextAlignment(TextAlignment.CENTER);
        }

        private Cell CrearCeldaEtiquetaDestacada(string texto)
        {
            return new Cell()
                .Add(new Paragraph(texto).SetFontSize(11).SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)))
                .SetBackgroundColor(new DeviceRgb(220, 220, 220))
                .SetPadding(8);
        }

        private Cell CrearCeldaDatoDestacado(string texto)
        {
            return new Cell()
                .Add(new Paragraph(texto ?? "").SetFontSize(11).SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)))
                .SetBackgroundColor(new DeviceRgb(220, 255, 220))
                .SetPadding(8);
        }

        #endregion
    }
}
