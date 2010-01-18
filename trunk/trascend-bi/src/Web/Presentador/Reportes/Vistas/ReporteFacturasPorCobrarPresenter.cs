using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Reportes.Contrato;
using Core.LogicaNegocio.Comandos.ComandoReporte;

namespace Presentador.Reportes.Vistas
{
    public class ReporteFacturasPorCobrarPresenter
    {
        private IReporteFacturasPorCobrar _vista;

        #region Constructor

        public ReporteFacturasPorCobrarPresenter(IReporteFacturasPorCobrar laVista)
        {
            _vista = laVista;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo para cargar el GridView
        /// </summary>
        public void CargarGrid()
        {

            _vista.Grid.DataSource = null;
            _vista.Grid.DataBind();

            Core.LogicaNegocio.Comandos.ComandoReporte.ConsultarFacturasPorEstado ComandoConsultarFacturas;

            ComandoConsultarFacturas = Core.LogicaNegocio.Fabricas.FabricaComandosReporte.CrearComandoConsultarFacturasPorEstado
                                                                (Convert.ToDateTime(_vista.FechaInicio.Text),
                                                                Convert.ToDateTime(_vista.FechaFin.Text),
                                                                false);

            IList<Core.LogicaNegocio.Entidades.Factura> lista = ComandoConsultarFacturas.Ejecutar();



            /*        Core.AccesoDatos.SqlServer.FacturaSQLServer bd = new Core.AccesoDatos.SqlServer.FacturaSQLServer();

                    IList<Core.LogicaNegocio.Entidades.Factura> lista = bd.ConsultarFacturasxEstado(Convert.ToDateTime(_vista.FechaInicio.Text), 
                                                                        Convert.ToDateTime(_vista.FechaFin.Text), 
                                                                        false); */

            if (lista != null)
            {
                _vista.Grid.DataSource = lista;
                _vista.Grid.DataBind();
            }
        }


        /// <summary>
        /// Metodo para transformar una fecha en ToShortDate 
        /// </summary>
        /// <param name="fecha">fecha que se quiere transformar</param>
        /// <returns>ToShortDate de una vez en string</returns>
        public string FormatearFechaParaMostrar(DateTime fecha)
        {
            return fecha.ToShortDateString();
        }

        #endregion
    }
}
