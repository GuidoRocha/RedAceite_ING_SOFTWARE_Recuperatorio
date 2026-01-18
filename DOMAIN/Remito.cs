using System;

namespace DOMAIN
{
    /// <summary>
    /// Representa un remito de entrega de residuos (aceite o grasa)
    /// generado en el sistema según la Resolución SPA n°063/96.
    /// </summary>
    public class Remito
    {
        /// <summary>
        /// Identificador único del remito.
        /// </summary>
        public Guid IdRemito { get; set; }

        /// <summary>
        /// Nombre del transportista responsable de la recolección.
        /// </summary>
        public string NombreTransportista { get; set; }

        /// <summary>
        /// Domicilio del transportista.
        /// </summary>
        public string DomicilioTransportista { get; set; }

        /// <summary>
        /// Nombre del generador del residuo.
        /// </summary>
        public string NombreGenerador { get; set; }

        /// <summary>
        /// Domicilio de la planta donde se genera el residuo.
        /// </summary>
        public string DomicilioPlanta { get; set; }

        /// <summary>
        /// Tipo de residuo (Aceite o Grasa).
        /// </summary>
        public string TipoResiduo { get; set; }

        /// <summary>
        /// Cantidad del residuo recolectado (en litros o kilogramos).
        /// </summary>
        public decimal Cantidad { get; set; }

        /// <summary>
        /// Estado físico del residuo (Líquido o Sólido).
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// CUIT del generador del residuo.
        /// </summary>
        public string Cuit { get; set; }

        /// <summary>
        /// Nombre de fantasía de la empresa generadora.
        /// </summary>
        public string NombreFantasia { get; set; }

        /// <summary>
        /// Dirección del establecimiento generador.
        /// </summary>
        public string Direccion { get; set; }

        /// <summary>
        /// Fecha y hora de creación del remito.
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Estado del remito (Activo, Anulado, etc.).
        /// </summary>
        public string EstadoRemito { get; set; }

        /// <summary>
        /// Dígito Verificador (hash MD5) calculado sobre los campos críticos del remito
        /// para garantizar la integridad de los datos.
        /// </summary>
        public string DigitoVerificador { get; set; }

        /// <summary>
        /// Constructor por defecto que inicializa el ID del remito con un nuevo Guid
        /// y establece la fecha de creación al momento actual.
        /// </summary>
        public Remito()
        {
            IdRemito = Guid.NewGuid();
            FechaCreacion = DateTime.Now;
            EstadoRemito = "Activo"; // Por defecto, el remito está activo
        }

        /// <summary>
        /// Constructor que permite inicializar el remito con un ID específico.
        /// </summary>
        /// <param name="idRemito">ID del remito.</param>
        public Remito(Guid idRemito)
        {
            this.IdRemito = idRemito;
            FechaCreacion = DateTime.Now;
            EstadoRemito = "Activo";
        }
    }
}
