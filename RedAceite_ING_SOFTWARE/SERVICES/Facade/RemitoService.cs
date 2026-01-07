using SERVICES.Dominio;
using SERVICES.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Facade
{
    /// <summary>
    /// Servicio de fachada (patrón Facade) para operaciones relacionadas con remitos.
    /// Proporciona una interfaz simplificada para la gestión de remitos.
    /// </summary>
    public static class RemitoService
    {
        private static RemitoLogic _remitoLogic = new RemitoLogic();

        /// <summary>
        /// Genera un nuevo remito en el sistema.
        /// </summary>
        /// <param name="nombreGenerador">Nombre del generador del residuo.</param>
        /// <param name="domicilioPlanta">Domicilio de la planta donde se genera el residuo.</param>
        /// <param name="tipoResiduo">Tipo de residuo (Aceite o Grasa).</param>
        /// <param name="cantidad">Cantidad del residuo recolectado.</param>
        /// <param name="estado">Estado físico del residuo (Líquido o Sólido).</param>
        /// <param name="cuit">CUIT del generador del residuo.</param>
        /// <param name="nombreFantasia">Nombre de fantasía de la empresa generadora.</param>
        /// <param name="direccion">Dirección del establecimiento generador.</param>
        /// <returns>El ID del remito generado.</returns>
        public static Guid GenerarRemito(
            string nombreGenerador,
            string domicilioPlanta,
            string tipoResiduo,
            decimal cantidad,
            string estado,
            string cuit,
            string nombreFantasia,
            string direccion)
        {
            // Crear el objeto remito con los datos proporcionados
            var remito = new Remito
            {
                NombreGenerador = nombreGenerador,
                DomicilioPlanta = domicilioPlanta,
                TipoResiduo = tipoResiduo,
                Cantidad = cantidad,
                Estado = estado,
                Cuit = cuit,
                NombreFantasia = nombreFantasia,
                Direccion = direccion,
                // Los datos del transportista se establecen por defecto en la lógica de negocio
                NombreTransportista = "Hugo Rocha",
                DomicilioTransportista = "Mendoza 3149 San Andres Prov. de Bs.As."
            };

            // Crear el remito usando la lógica de negocio
            _remitoLogic.CrearRemito(remito);

            return remito.IdRemito;
        }

        /// <summary>
        /// Obtiene un remito por su identificador único.
        /// </summary>
        /// <param name="idRemito">El ID del remito.</param>
        /// <returns>El remito correspondiente, si existe.</returns>
        public static Remito ObtenerRemitoPorId(Guid idRemito)
        {
            return _remitoLogic.ObtenerRemitoPorId(idRemito);
        }

        /// <summary>
        /// Obtiene todos los remitos registrados en el sistema.
        /// </summary>
        /// <returns>Una lista de todos los remitos.</returns>
        public static List<Remito> ObtenerTodosLosRemitos()
        {
            return _remitoLogic.ObtenerTodosLosRemitos();
        }

        /// <summary>
        /// Obtiene los remitos filtrados por CUIT del generador.
        /// </summary>
        /// <param name="cuit">El CUIT del generador.</param>
        /// <returns>Una lista de remitos asociados al CUIT especificado.</returns>
        public static List<Remito> ObtenerRemitosPorCuit(string cuit)
        {
            return _remitoLogic.ObtenerRemitosPorCuit(cuit);
        }

        /// <summary>
        /// Obtiene los remitos creados en un rango de fechas.
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del rango.</param>
        /// <param name="fechaFin">Fecha de fin del rango.</param>
        /// <returns>Una lista de remitos dentro del rango de fechas.</returns>
        public static List<Remito> ObtenerRemitosPorFechaRango(DateTime fechaInicio, DateTime fechaFin)
        {
            return _remitoLogic.ObtenerRemitosPorFechaRango(fechaInicio, fechaFin);
        }

        /// <summary>
        /// Anula un remito existente.
        /// </summary>
        /// <param name="idRemito">El ID del remito a anular.</param>
        public static void AnularRemito(Guid idRemito)
        {
            _remitoLogic.AnularRemito(idRemito);
        }

        /// <summary>
        /// Actualiza un remito existente.
        /// </summary>
        /// <param name="remito">El remito con los datos actualizados.</param>
        public static void ActualizarRemito(Remito remito)
        {
            _remitoLogic.ActualizarRemito(remito);
        }
    }
}
