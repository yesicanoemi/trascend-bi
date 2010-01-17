using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Reportes.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Fabricas;
using Core.LogicaNegocio.Comandos.ComandoReporte;
using System.Net;
using System.Collections;
using System.Resources;
using System.Threading;
using System.Globalization;
using System.Configuration;


namespace Presentador.Reportes.Vistas
{
    //Facturas Cobradas Anuales
    public class ReporteEquipo8bPresenter
    {
        IReporteEquipo8b _vista;
        #region Constructor
        public ReporteEquipo8bPresenter(IReporteEquipo8b vista)
        {
            _vista = vista;
        }
        #endregion

        public void onBotonBuscar()
        {
            Core.LogicaNegocio.Entidades.Factura factura = new Core.LogicaNegocio.Entidades.Factura();

            IList<Core.LogicaNegocio.Entidades.Factura> facturasCobradas = FacturasCobradas(factura);

            try
            {
                if (facturasCobradas != null)
                {
                    _vista.GetObjectContainerReporte8b.DataSource = facturasCobradas;


                }
            }

            catch (WebException e)
            {
                //Mensaje de error al usuario
            }
        }

        #region Comando

        /// <summary>
        /// Método para el comando FacturasCobradasAnuales
        /// </summary>
        /// <param name="entidad">Entidad Factura</param>
        /// 

        public IList<Core.LogicaNegocio.Entidades.Factura>
                                        FacturasCobradas(Core.LogicaNegocio.Entidades.Factura entidad)
        {
            IList<Core.LogicaNegocio.Entidades.Factura> facturaRetorno = null;

            Core.LogicaNegocio.Comandos.ComandoReporte.FacturasCobradasAnuales comandoFacturasCobradas;

            comandoFacturasCobradas = FabricaComandosReporte.CrearComandoFacturasCobradasAnuales(entidad);

            facturaRetorno = comandoFacturasCobradas.Ejecutar();

            return facturaRetorno;
        }

        #endregion
    }
}
