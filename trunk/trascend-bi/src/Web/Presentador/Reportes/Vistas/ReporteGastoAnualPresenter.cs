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
    public class ReporteGastoAnualPresenter
    {
        private IReporteGastoAnual _vista;

        #region Constructor

        public ReporteGastoAnualPresenter(IReporteGastoAnual vista)
        {
            _vista = vista;

        }

        #endregion

        #region Metodos

        public void OnBotonBuscar()
        {
            Core.LogicaNegocio.Entidades.Gasto gasto = new Core.LogicaNegocio.Entidades.Gasto();

            string anio;//Año seleccionado como criterio de busqueda

            anio = _vista.AnioGasto.Text;

            IList<Core.LogicaNegocio.Entidades.Gasto> listaGastos = GastosAnuales(anio, gasto);

            float totalGastos = TotalGastos(anio, gasto);

            //int totalGastosInt = (int)totalGastos;

            String totalGastosS = totalGastos.ToString();

            if (listaGastos != null)
            {
                _vista.GetObjectContainerReporteGastos3a.DataSource = listaGastos;

                _vista.TotalGastos.Text = totalGastosS;
                
            }

            else
            {
                //Mensaje de error al usuario
            }
        }

        public IList<Core.LogicaNegocio.Entidades.Gasto>
                                        GastosAnuales(string anio, Core.LogicaNegocio.Entidades.Gasto entidad)
        {
            IList<Core.LogicaNegocio.Entidades.Gasto> gasto1 = null;

            Core.LogicaNegocio.Comandos.ComandoReporte.ConsultarGastoAnual comando;

            comando = FabricaComandosReporte.CrearComandoGastosAnuales(entidad);

            gasto1 = comando.Ejecutar(anio);

            return gasto1;
        }


        public float TotalGastos(string anio, Core.LogicaNegocio.Entidades.Gasto entidad)
        {
            float gasto1 = 0;

            Core.LogicaNegocio.Comandos.ComandoReporte.ConsultarGastoTotal comando;

            comando = FabricaComandosReporte.CrearComandoGastoTotal(entidad);

            gasto1 = comando.Ejecutar(anio);

            return gasto1;
        }



        #endregion
    }
}