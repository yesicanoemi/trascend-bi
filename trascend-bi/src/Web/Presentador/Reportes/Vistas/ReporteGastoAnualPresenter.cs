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
        #region Propiedades
        private IReporteGastoAnual _vista;

        private const String campoVacio = "";
        #endregion

        #region Constructor
        public ReporteGastoAnualPresenter()
        { }

        public ReporteGastoAnualPresenter(IReporteGastoAnual vista)
        {
            _vista = vista;

        }

        #endregion

        #region Metodos

        public void OnBotonBuscar()
        {
            _vista.Aviso.Visible = false;

            Core.LogicaNegocio.Entidades.Gasto gasto = new Core.LogicaNegocio.Entidades.Gasto();

            string anio;//Año seleccionado como criterio de busqueda

            anio = _vista.AnioGasto.Text;

            IList<Core.LogicaNegocio.Entidades.Gasto> listaGastos = GastosAnuales(anio, gasto);

            float totalGastos = TotalGastos(anio, gasto);

            //int totalGastosInt = (int)totalGastos;

            String totalGastosS = totalGastos.ToString();

            if (listaGastos.Count != 0)
            {
                _vista.TotalGastos.Visible = true;

                _vista.TotalGastosLabel.Visible = true;

                _vista.GetObjectContainerReporteGastos3a.DataSource = listaGastos;

                _vista.TotalGastos.Text = totalGastosS;

            }

            else
            {
                _vista.Mensaje("No existen gastos registrados correspondientes a ese parametro");
                _vista.GetObjectContainerReporteGastos3a.DataSource = campoVacio;
                _vista.TotalGastos.Visible = false;
                _vista.TotalGastosLabel.Visible = false;
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
        
        /// <summary>
        /// Método para el comando Consultar IdPermiso
        /// </summary>
        /// <param name="entidad">Entidad permiso</param>
        /// 

        public Core.LogicaNegocio.Entidades.Permiso ConsultarIdPermiso()
        {
            Core.LogicaNegocio.Entidades.Permiso permiso1 = null;

            Core.LogicaNegocio.Entidades.Permiso permiso2 = new Permiso();
            try
            {


                permiso2.Permisos = "Gastos Anuales";

                Core.LogicaNegocio.Comandos.ComandoUsuario.ConsultarIdPermiso comando;

                comando = FabricaComandosUsuario.CrearComandoConsultarIdPermiso(permiso2);

                permiso1 = comando.Ejecutar();
            }

            catch (Exception e)
            {

                /*_vista.PintarInformacion
                    (ManagerRecursos.GetString("mensajeErrorConsultarPermiso"), "mensajes");

                _vista.InformacionVisible = true;*/
            }

            return permiso1;
        }


        #endregion
    }
}