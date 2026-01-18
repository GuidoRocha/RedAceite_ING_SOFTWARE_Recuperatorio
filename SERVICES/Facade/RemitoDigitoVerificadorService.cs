using DOMAIN;
using System;
using System.Globalization;
using System.Text;

namespace SERVICES.Facade
{
    /// <summary>
    /// Servicio para calcular y verificar el Dígito Verificador (hash de integridad)
    /// de los remitos, garantizando que los datos críticos no hayan sido alterados.
    /// </summary>
    public static class RemitoDigitoVerificadorService
    {
        /// <summary>
        /// Construye el payload determinístico para calcular el Dígito Verificador.
        /// Utiliza un formato fijo con separadores y cultura invariante para decimales.
        /// </summary>
        /// <param name="remito">El remito del cual se construirá el payload.</param>
        /// <returns>String con el payload completo en formato determinístico.</returns>
        public static string BuildPayload(Remito remito)
        {
            if (remito == null)
            {
                throw new ArgumentNullException(nameof(remito), "El remito no puede ser nulo.");
            }

            // Formatear la cantidad con cultura invariante y 2 decimales
            // (coincide con DECIMAL(18,2) de la DB)
            string cantidadFormateada = remito.Cantidad.ToString("0.00", CultureInfo.InvariantCulture);

            // Construir payload con formato fijo:
            // DV1|IdRemito|NombreTransportista|DomicilioTransportista|NombreGenerador|
            // DomicilioPlanta|TipoResiduo|Cantidad|Estado|Cuit|NombreFantasia|
            // Direccion|EstadoRemito

            StringBuilder sb = new StringBuilder();
            sb.Append("DV1");  // Prefijo de versión del algoritmo
            sb.Append("|");
            sb.Append(remito.IdRemito.ToString());
            sb.Append("|");
            sb.Append(remito.NombreTransportista ?? string.Empty);
            sb.Append("|");
            sb.Append(remito.DomicilioTransportista ?? string.Empty);
            sb.Append("|");
            sb.Append(remito.NombreGenerador ?? string.Empty);
            sb.Append("|");
            sb.Append(remito.DomicilioPlanta ?? string.Empty);
            sb.Append("|");
            sb.Append(remito.TipoResiduo ?? string.Empty);
            sb.Append("|");
            sb.Append(cantidadFormateada);
            sb.Append("|");
            sb.Append(remito.Estado ?? string.Empty);
            sb.Append("|");
            sb.Append(remito.Cuit ?? string.Empty);
            sb.Append("|");
            sb.Append(remito.NombreFantasia ?? string.Empty);
            sb.Append("|");
            sb.Append(remito.Direccion ?? string.Empty);
            sb.Append("|");
            sb.Append(remito.EstadoRemito ?? string.Empty);

            return sb.ToString();
        }

        /// <summary>
        /// Calcula el Dígito Verificador (hash MD5) del remito.
        /// Utiliza el servicio de criptografía existente.
        /// </summary>
        /// <param name="remito">El remito del cual se calculará el DV.</param>
        /// <returns>Hash MD5 del payload en formato hexadecimal (32 caracteres).</returns>
        public static string Calcular(Remito remito)
        {
            if (remito == null)
            {
                throw new ArgumentNullException(nameof(remito), "El remito no puede ser nulo.");
            }

            string payload = BuildPayload(remito);
            string hash = CryptographyService.HashMd5(payload);

            return hash;
        }

        /// <summary>
        /// Verifica si el Dígito Verificador del remito es válido.
        /// Compara el DV almacenado con el DV recalculado a partir de los datos actuales.
        /// </summary>
        /// <param name="remito">El remito a verificar.</param>
        /// <returns>
        /// True si el DV coincide (datos íntegros), 
        /// False si no coincide (datos alterados) o si el DV está vacío.
        /// </returns>
        public static bool Verificar(Remito remito)
        {
            if (remito == null)
            {
                throw new ArgumentNullException(nameof(remito), "El remito no puede ser nulo.");
            }

            // Si no tiene DV asignado, retornar false
            if (string.IsNullOrWhiteSpace(remito.DigitoVerificador))
            {
                return false;
            }

            // Recalcular el DV actual
            string dvCalculado = Calcular(remito);

            // Comparar con el DV almacenado
            return string.Equals(dvCalculado, remito.DigitoVerificador, StringComparison.OrdinalIgnoreCase);
        }
    }
}
