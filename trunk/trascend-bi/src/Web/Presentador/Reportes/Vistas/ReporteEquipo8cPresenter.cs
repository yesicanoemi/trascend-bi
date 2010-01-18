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
    //Facturas Por Cobrar Anuales
    public class ReporteEquipo8cPresenter
    {
        private IReporteEquipo8c _vista;
        #region Constructor
        public ReporteEquipo8cPresenter(IReporteEquipo8c vista)
        {
            _vista = vista;
        }

        #endregion

        public void onBotonBuscar()
        {
            Core.LogicaNegocio.Entidades.Factura factura = new Core.LogicaNegocio.Entidades.Factura();

            IList<Core.LogicaNegocio.Entidades.Factura> facturasPorCobrar = FacturasPorCobrar(factura);

            try
            {
                if (facturasPorCobrar != null)
                {
                    _vista.GetObjectContainerReporte8c.DataSource = facturasPorCobrar;


                }
            }

            catch (WebException e)
            {
                //Mensaje de error al usuario
            }
        }

        #region Comando

        /// <summary>
        /// Método para el comando FacturasPorCobrarAnuales
        /// </summary>
        /// <param name="entidad">Entidad Factura</param>
        /// 

        public IList<Core.LogicaNegocio.Entidades.Factura>
                                        FacturasPorCobrar(Core.LogicaNegocio.Entidades.Factura entidad)
        {
            IList<Core.LogicaNegocio.Entidades.Factura> facturaRetorno = null;

            entidad.Fechapago = Convert.ToDateTime("01/01/" + _vista.Anios.SelectedItem.Text);

            Core.LogicaNegocio.Comandos.ComandoReporte.FacturasPorCobrarAnuales comandoFacturasPorCobrar;

            comandoFacturasPorCobrar = FabricaComandosReporte.CrearComandoFacturasPorCobrarAnuales(entidad);

            facturaRetorno = comandoFacturasPorCobrar.Ejecutar();

            return facturaRetorno;
        }

        #endregion
    }
}
