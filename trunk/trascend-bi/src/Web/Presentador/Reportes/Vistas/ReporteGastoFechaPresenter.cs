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
    public class ReporteGastoFechaPresenter
    {

        #region Propiedades
        private IReporteGastoFecha _vista;

        private IList<Core.LogicaNegocio.Entidades.Gasto> Gastos;
        #endregion

        #region Constructor

        public ReporteGastoFechaPresenter(IReporteGastoFecha vista)
        {
            _vista = vista;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que se ejecuta al presionar el boton Aceptar
        /// En el cual se realiza el llamado al Comando Consultar
        /// </summary>
        /// <param name="FechaIni">Fecha Inicio</param>
        /// <param name="FechaFin">Fecha Fin</param>
        public void ConsultarGastoFecha(DateTime FechaIni, DateTime FechaFin)
        {
            try
            {

                FechaIni = Convert.ToDateTime(_vista.FechaInicio.Text);

                FechaFin = Convert.ToDateTime(_vista.FechaFin.Text);

                Gastos = Consultar(FechaIni, FechaFin);

                try
                {
                    if (Gastos != null)
                    {
                        _vista.ObtenerValorDataSource.DataSource = Gastos;
                        LimpiarRegistros();
                    }

                }
                catch (WebException e)
                {
                    //Mensaje al usuario
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }

        }

        /// <summary>
        /// Metodo que Limpia los registros Fecha Inicio y Fecha Fin de la Interfaz
        /// </summary>
        public void LimpiarRegistros()
        {
            _vista.FechaInicio.Text = "";

            _vista.FechaFin.Text = "";
        }
        #endregion

        #region Comando Consultar
        /// <summary>
        /// Creacion del Comando Consultar el Cual retornara una lista con todos
        /// los gastos que se encuentran entre las fechas de inicio y fin respectivamente
        /// </summary>
        /// <param name="FechaIni">Fecha Inicio</param>
        /// <param name="FechaFin">Fecha Fin</param>
        /// <returns></returns>
        public IList<Core.LogicaNegocio.Entidades.Gasto> Consultar(DateTime FechaIni, DateTime FechaFin)
        {
            Core.LogicaNegocio.Comandos.ComandoReporte.ConsultarGastoFecha busqueda;

            busqueda = FabricaComandosReporte.CrearComandoConsultarFecha(FechaIni, FechaFin);

            Gastos = busqueda.Ejecutar();

            return Gastos;
        }
        #endregion

    }
}
