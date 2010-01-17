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

        public static ConsultaRol CrearComandoConsultarRol(IList<string> entidad)
        {
            return new ConsultaRol(entidad);
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

        public static ConsultarFacturasPorEstado CrearComandoConsultarFacturasPorEstado(DateTime FechaInicio, DateTime FechaFin, bool tipo)
        {
            return new ConsultarFacturasPorEstado(FechaInicio,FechaFin,tipo);
        }

        #endregion

    }
}
