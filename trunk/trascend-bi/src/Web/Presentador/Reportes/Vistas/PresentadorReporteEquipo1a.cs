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
using Presentador.Base;
using System.Resources;
using Core.LogicaNegocio.Excepciones;

namespace Presentador.Reportes.Vistas
{
    public class PresentadorReporteEquipo1a : PresentadorBase
    {
        #region Propiedades

        private IReporteEquipo1a _vista;

        Core.LogicaNegocio.Entidades.Empleado _empleado = new Core.LogicaNegocio.Entidades.Empleado();

        #endregion 

        #region Constructor

        public PresentadorReporteEquipo1a()
        { 
        
        }

        public PresentadorReporteEquipo1a(IReporteEquipo1a vista)
        {
            _vista = vista;
        }

        #endregion 

        #region Métodos

        /// <summary>
        /// Acción del Botón Aceptar
        /// </summary>
        
        public void OnBotonAceptar()
        {
            Core.LogicaNegocio.Entidades.Empleado empleado = new Core.LogicaNegocio.Entidades.Empleado();

            IList<Core.LogicaNegocio.Entidades.Empleado> listadoE = new
                                                List<Core.LogicaNegocio.Entidades.Empleado>();

            IList<Core.LogicaNegocio.Entidades.Empleado> listadoImprime = new
                                                List<Core.LogicaNegocio.Entidades.Empleado>();

            try
            {
                //Si la consulta es por CI

                if (_vista.RadioButton.Text == "Cedula")
                {
                    _empleado.Cedula = Int32.Parse(_vista.TextBoxBusqueda.Text);

                    Core.LogicaNegocio.Entidades.Empleado empleado1 = BuscarPorCedula(_empleado);

                    if (empleado1 != null)
                    {
                        _empleado = ReporteAnualPorPaquetesEmpleadoId(empleado1);

                        listadoImprime.Add(_empleado);

                        _vista.GridViewReportePaquete1a.Visible = true;
                        
                        _vista.GridViewReportePaquete1a.DataSource = listadoImprime;
                                                        
                    }
                    else
                    {
                        _vista.PintarInformacion(ManagerRecursos.GetString
                                                ("MensajeConsulta"), "mensajes");
                        _vista.InformacionVisible = true;

                    }
                }
                
                //Si la consulta es por nombre

                if (_vista.RadioButton.Text == "Nombre")
                {
                    _empleado.Nombre = _vista.TextBoxBusqueda.Text;

                    listadoE = BuscarPorNombre(_empleado);

                    _vista.GridViewReportePaquete1a.Visible = true;

                    _vista.GetOCConsultarEmp.DataSource = listadoE;

                    /*
                    if (listadoE.Count > 0)
                    {

                        _vista.GridViewReportePaquete1a.DataSource = listadoE;

                        _vista.GridViewReportePaquete1a.DataBind();

                    }*/
                                        
                }
                 
                    /*
                else
                {
                    _vista.PintarInformacion(ManagerRecursos.GetString
                                            ("MensajeConsulta"), "mensajes");
                    _vista.InformacionVisible = true;

                }*/
            }
            catch (WebException e)
            {
                _vista.PintarInformacion
                    (ManagerRecursos.GetString("mensajeErrorWeb"),"mensajes");
                _vista.InformacionVisible = true;

            }
            catch (ConsultarException e)
            {
                _vista.PintarInformacion
                   (ManagerRecursos.GetString("mensajeErrorConsultar"), "mensajes");
                _vista.InformacionVisible = true;

            }
            catch (Exception e)
            {
                _vista.PintarInformacion
                   (ManagerRecursos.GetString("mensajeErrorGeneral"), "mensajes");
                _vista.InformacionVisible = true;
            }
        }

        public void uxObjectConsultaUsuariosSelecting(int codigoEmpleado)//string nombre
        {

        }

        #endregion 

        #region Comandos

        /// <summary>
        /// Método para buscar el empleado por CI
        /// </summary>
        /// <param name="entidad">Empleado con parámetro de consulta</param>
        /// <returns>Empleado que cumpla con el parámetro</returns>
        
        public Core.LogicaNegocio.Entidades.Empleado BuscarPorCedula
                                                        (Core.LogicaNegocio.Entidades.Empleado entidad)
        {
            Core.LogicaNegocio.Entidades.Empleado empleado1 = new Core.LogicaNegocio.Entidades.Empleado();

            Core.LogicaNegocio.Comandos.ComandoEmpleado.ConsultarPorCI consultar;

            consultar = FabricaComandosEmpleado.CrearComandoConsultarPorCI(entidad);
                        
            empleado1 = consultar.Ejecutar();

            return empleado1;
        }

        /// <summary>
        /// Método para buscar el empleado por nombre
        /// </summary>
        /// <param name="entidad">Empleado con el parámetro de consulta</param>
        /// <returns>Lista de empleados que cumpla con el criterio de búsqueda</returns>
        
        public List<Core.LogicaNegocio.Entidades.Empleado> BuscarPorNombre
                                                        (Core.LogicaNegocio.Entidades.Empleado entidad)
        {
            List<Core.LogicaNegocio.Entidades.Empleado> empleado1 = null;

            Core.LogicaNegocio.Comandos.ComandoEmpleado.ConsultarPorNombre consultar;

            consultar = FabricaComandosEmpleado.CrearComandoConsultarPorNombre(entidad);

            empleado1 = consultar.Ejecutar();

            return empleado1;

        }

        /// <summary>
        /// Método para buscar los datos del reporte
        /// </summary>
        /// <param name="entidad">Id del empleado</param>
        /// <returns>Reporte para el empleado</returns>

        public Core.LogicaNegocio.Entidades.Empleado ReporteAnualPorPaquetesEmpleadoId
                                                        (Core.LogicaNegocio.Entidades.Empleado entidad)
        {
            Core.LogicaNegocio.Entidades.Empleado empleado1 = null;

            Core.LogicaNegocio.Comandos.ComandoReporte.ReporteAnualPorPaquetesEmpleadoId consultar;

            consultar = FabricaComandosReporte.CrearComandoReporteAnualPorPaquetesEmpleadoId(entidad);

            empleado1 = consultar.Ejecutar();

            return empleado1;

        }

        #endregion

    }
}
