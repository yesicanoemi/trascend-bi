using System;
using System.Collections.Generic;
using System.Text;
using Core.LogicaNegocio.Comandos.ComandoReporte;
using Core.LogicaNegocio.Entidades;


namespace Core.LogicaNegocio.Fabricas
{
    public class FabricaComandosReporte
    {
        #region Metodos

        /// <summary>
        /// Metodo que fabrica el comando 'FacturasEmitidas' de la entidad Usuario
        /// </summary>
        /// <param name="entidad">Entidad Factura con los datos</param>
        /// <returns>Comando FacturasEmitidas de la entidad Factura</returns>
        
        public static FacturasEmitidas CrearComandoFacturasEmitidas(Factura entidad)
        {
            return new FacturasEmitidas(entidad);
        }

        public static ConsultarGastoFecha CrearComandoConsultarFecha(DateTime fechaini, DateTime fechafin)
        {
            return new ConsultarGastoFecha(fechaini, fechafin);
        }

        public static ConsultaRol CrearComandoConsultarRol(DateTime FechaI, DateTime FechaF)
        {
            return new ConsultaRol(FechaI,FechaF);
        }
        public static FacturasEmitidasAnuales CrearComandoFacturasEmitidasAnuales(Factura entidad)
        {
            return new FacturasEmitidasAnuales(entidad);
        }

        public static FacturasCobradasAnuales CrearComandoFacturasCobradasAnuales(Factura entidad)
        {
            return new FacturasCobradasAnuales(entidad);
        }

        public static FacturasPorCobrarAnuales CrearComandoFacturasPorCobrarAnuales(Factura entidad)
        {
            return new FacturasPorCobrarAnuales(entidad);
        }

        public static ConsultaHora SumaHoraRol(string rol)
        {
            return new ConsultaHora(rol);
        }

        public static ConsultarGastoAnual CrearComandoGastosAnuales(Gasto entidad)
        {
            return new ConsultarGastoAnual(entidad);
        }

        public static ConsultarGastoTotal CrearComandoGastoTotal(Gasto entidad)
        {
            return new ConsultarGastoTotal(entidad);
        }

        public static ConsultaCargo CrearComandoConsultarCargo(IList<string> entidad)
        {
            return new ConsultaCargo(entidad);
        }

        /// <summary>
        /// Comando utilizado para crear una lista de entidades de tipo factura parametrizada por un
        /// un rango de fecha y el tipo de factura
        /// </summary>
        /// <param name="FechaInicio">Fecha inicial(DateTime)</param>
        /// <param name="FechaFin">Fecha final(DateTime)</param>
        /// <param name="tipo">Puede ser "cobrada" o "por cobrar"</param>
        /// <returns>Devuelve la lista segun el criterio</returns>
        public static ConsultarFacturasPorEstado CrearComandoConsultarFacturasPorEstado(DateTime FechaInicio, DateTime FechaFin, bool tipo)
        {
            return new ConsultarFacturasPorEstado(FechaInicio,FechaFin,tipo);
        }

        public static ConsultarEmpleadoCargoAnual CrearConsultarEmpleadoCargoAnual(string cargo)
        {
            return new ConsultarEmpleadoCargoAnual(cargo);
        }

        #endregion

    }
}
