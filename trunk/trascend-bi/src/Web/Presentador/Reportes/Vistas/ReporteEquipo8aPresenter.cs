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
    //Facturas Emitidas Anuales
    public class ReporteEquipo8aPresenter
    {


        IReporteEquipo8a _vista;
        #region Constructor
        public ReporteEquipo8aPresenter(IReporteEquipo8a vista)
        {
            _vista = vista;
        }
        #endregion

        public void BuscarFactura()
        {
            Core.LogicaNegocio.Entidades.Factura factura = new Core.LogicaNegocio.Entidades.Factura();

            IList<Core.LogicaNegocio.Entidades.Factura> facturasEmitidas = FacturasEmitidas(factura);

            try
            {
                if (facturasEmitidas != null)
                {
                    _vista.GetObjectContainerReporte8a.DataSource = facturasEmitidas;
                    _vista.LabelContador.Text =  _vista.LabelContador.Text + facturasEmitidas.Count.ToString();
                    _vista.LabelContador.Visible = true; 
                    

                }
            }

            catch (WebException e)
            {
                //Mensaje de error al usuario
            }
        }

        #region Comando

        /// <summary>
        /// Método para el comando FacturasEmitidasAnuales
        /// </summary>
        /// <param name="entidad">Entidad Factura</param>
        /// 
      
        public IList<Core.LogicaNegocio.Entidades.Factura>
                                        FacturasEmitidas(Core.LogicaNegocio.Entidades.Factura entidad)
        {
            IList<Core.LogicaNegocio.Entidades.Factura> facturaRetorno = null;

            entidad.Fechapago = Convert.ToDateTime("01/01/"+_vista.Anios.SelectedItem.Text);

            Core.LogicaNegocio.Comandos.ComandoReporte.FacturasEmitidasAnuales comandoFacturasEmitidas;

            comandoFacturasEmitidas = FabricaComandosReporte.CrearComandoFacturasEmitidasAnuales(entidad);

            facturaRetorno = comandoFacturasEmitidas.Ejecutar();

            return facturaRetorno;
        }

        #endregion
    }
}
