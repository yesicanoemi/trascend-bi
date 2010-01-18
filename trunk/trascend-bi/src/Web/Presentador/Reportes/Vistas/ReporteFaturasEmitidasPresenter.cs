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
using System.Data;


namespace Presentador.Reportes.Vistas
{
    public class ReporteFaturasEmitidasPresenter
    {
        #region Propiedades

        private IReporteFacturasEmitidas _vista;

        #endregion

        #region Constructor

        public ReporteFaturasEmitidasPresenter(IReporteFacturasEmitidas vista)
        {
            _vista = vista;

        }

        #endregion

        #region Métodos

        /// <summary>
        /// Acción del Botón Buscar (por rango de fechas)
        /// </summary>

        public void OnBotonBuscar()
        {
            Core.LogicaNegocio.Entidades.Factura factura = new Core.LogicaNegocio.Entidades.Factura();

            factura.Fechaingreso = Convert.ToDateTime(_vista.FechaInicio.Text);

            factura.Fechapago = Convert.ToDateTime(_vista.FechaFin.Text);

            IList<Core.LogicaNegocio.Entidades.Factura> listadoF = FacturasEmitidas(factura);

            _vista.GridViewReporteFactura3b.DataSource = null;

            _vista.GridViewReporteFactura3b.DataBind();

            try
            {
                if (listadoF != null)
                {

                    _vista.GridViewReporteFactura3b.DataSource = listadoF;
                    
                    _vista.GridViewReporteFactura3b.DataBind();
                  
                }
            }

            catch (WebException e)
            {
                //Mensaje de error al usuario
            }
        }

        #endregion

        #region Comando

        /// <summary>
        /// Método para el comando FacturasEmitidas
        /// </summary>
        /// <param name="entidad">Entidad Factura</param>
        /// <returns>Lista de Facturas que cumplan con el criterio de búsqueda</returns>
        
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
