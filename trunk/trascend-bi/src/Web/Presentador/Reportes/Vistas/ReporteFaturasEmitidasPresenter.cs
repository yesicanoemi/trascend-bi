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
    public class ReporteFaturasEmitidasPresenter
    {
        private IReporteFacturasEmitidas _vista;

        #region Constructor

        public ReporteFaturasEmitidasPresenter(IReporteFacturasEmitidas vista)
        {
            _vista = vista;

        }

        #endregion

        #region Metodos

        public void OnBotonBuscar()
        {
            Core.LogicaNegocio.Entidades.Factura factura = new Core.LogicaNegocio.Entidades.Factura();

            //factura.Fechaingreso = ConvertirToFecha(_vista.FechaInicio.Text);

            factura.Fechaingreso = Convert.ToDateTime(_vista.FechaInicio.Text);

            factura.Fechapago = Convert.ToDateTime(_vista.FechaFin.Text);

            IList<Core.LogicaNegocio.Entidades.Factura> listadoF = FacturasEmitidas(factura);

            if (listadoF != null)
            {
               _vista.GetObjectContainerReporteFactura3b.DataSource = listadoF;

            }

            else
            {
                //Mensaje de error al usuario
            }
        }

        public IList<Core.LogicaNegocio.Entidades.Factura> 
                                        FacturasEmitidas(Core.LogicaNegocio.Entidades.Factura entidad)
        
        {
            IList<Core.LogicaNegocio.Entidades.Factura> factura1 = null;

            Core.LogicaNegocio.Comandos.ComandoReporte.FacturasEmitidas comando;

            comando = FabricaComandosReporte.CrearComandoFacturasEmitidas (entidad);

           factura1 = comando.Ejecutar();

            return factura1;
        }



        #endregion
    }
}
