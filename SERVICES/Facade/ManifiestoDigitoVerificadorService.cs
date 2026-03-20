using DOMAIN;
using System;
using System.Globalization;
using System.Text;

namespace SERVICES.Facade
{
    /// <summary>
    /// Servicio para calcular y verificar el Digito Verificador (hash de integridad)
    /// de los manifiestos, garantizando que los datos criticos no hayan sido alterados.
    /// Sigue el mismo patron que RemitoDigitoVerificadorService.
    /// </summary>
    public static class ManifiestoDigitoVerificadorService
    {
        /// <summary>
        /// Construye el payload deterministico para calcular el Digito Verificador.
        /// Utiliza un formato fijo con separadores y cultura invariante para decimales.
        /// </summary>
        /// <param name="manifiesto">El manifiesto del cual se construira el payload.</param>
        /// <returns>String con el payload completo en formato deterministico.</returns>
        public static string BuildPayload(Manifiesto manifiesto)
        {
            if (manifiesto == null)
            {
                throw new ArgumentNullException(nameof(manifiesto), "El manifiesto no puede ser nulo.");
            }

            // Formatear el monto total con cultura invariante y 2 decimales
            string montoFormateado = manifiesto.MontoTotal.ToString("0.00", CultureInfo.InvariantCulture);

            // Construir payload con formato fijo:
            // DVM1|IdManifiesto|NumeroManifiesto|FechaManifiesto|NombreTransportista|
            // DomicilioTransportista|CantidadTotalRemitos|MontoTotal|Estado

            StringBuilder sb = new StringBuilder();
            sb.Append("DVM1");  // Prefijo de version del algoritmo para Manifiestos
            sb.Append("|");
            sb.Append(manifiesto.IdManifiesto.ToString());
            sb.Append("|");
            sb.Append(manifiesto.NumeroManifiesto ?? string.Empty);
            sb.Append("|");
            sb.Append(manifiesto.FechaManifiesto.ToString("yyyy-MM-dd"));
            sb.Append("|");
            sb.Append(manifiesto.NombreTransportista ?? string.Empty);
            sb.Append("|");
            sb.Append(manifiesto.DomicilioTransportista ?? string.Empty);
            sb.Append("|");
            sb.Append(manifiesto.CantidadTotalRemitos.ToString());
            sb.Append("|");
            sb.Append(montoFormateado);
            sb.Append("|");
            sb.Append(manifiesto.Estado ?? string.Empty);

            return sb.ToString();
        }

        /// <summary>
        /// Calcula el Digito Verificador (hash MD5) del manifiesto.
        /// </summary>
        /// <param name="manifiesto">El manifiesto del cual se calculara el DV.</param>
        /// <returns>Hash MD5 del payload en formato hexadecimal (32 caracteres).</returns>
        public static string Calcular(Manifiesto manifiesto)
        {
            if (manifiesto == null)
            {
                throw new ArgumentNullException(nameof(manifiesto), "El manifiesto no puede ser nulo.");
            }

            string payload = BuildPayload(manifiesto);
            string hash = CryptographyService.HashMd5(payload);

            return hash;
        }

        /// <summary>
        /// Verifica si el Digito Verificador del manifiesto es valido.
        /// Compara el DV almacenado con el DV recalculado a partir de los datos actuales.
        /// </summary>
        /// <param name="manifiesto">El manifiesto a verificar.</param>
        /// <returns>
        /// True si el DV coincide (datos integros),
        /// False si no coincide (datos alterados) o si el DV esta vacio.
        /// </returns>
        public static bool Verificar(Manifiesto manifiesto)
        {
            if (manifiesto == null)
            {
                throw new ArgumentNullException(nameof(manifiesto), "El manifiesto no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(manifiesto.DigitoVerificador))
            {
                return false;
            }

            string dvCalculado = Calcular(manifiesto);

            return string.Equals(dvCalculado, manifiesto.DigitoVerificador, StringComparison.OrdinalIgnoreCase);
        }
    }
}
