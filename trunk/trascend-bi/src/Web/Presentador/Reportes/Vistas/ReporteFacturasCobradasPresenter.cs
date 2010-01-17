using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Reportes.Contrato;
using Core.LogicaNegocio.Comandos.ComandoReporte;

namespace Presentador.Reportes.Vistas
{
    public class ReporteFacturasCobradasPresenter 
    {
        private IReporteFacturasPorCobrar _vista;

        public ReporteFacturasCobradasPresenter(IReporteFacturasPorCobrar laVista)
        {
            _vista = laVista;
        }

        public void CargarGrid()
        {

            _vista.Grid.DataSource = null;
            _vista.Grid.DataBind();

            Core.LogicaNegocio.Comandos.ComandoReporte.ConsultarFacturasPorEstado ComandoConsultarFacturas;

            ComandoConsultarFacturas = Core.LogicaNegocio.Fabricas.FabricaComandosReporte.CrearComandoConsultarFacturasPorEstado
                                                                (Convert.ToDateTime(_vista.FechaInicio.Text),
                                                                Convert.ToDateTime(_vista.FechaFin.Text),
                                                                true);

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

        public string FormatearFechaParaMostrar(DateTime fecha)
        {
            return fecha.ToShortDateString();
        }
    }
}
