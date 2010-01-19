using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Propuesta.Contrato;
using Core.LogicaNegocio.Entidades;
using System.Net;
using System.Collections;
using System.Resources;
using System.Threading;
using System.Globalization;
using System.Configuration;

namespace Presentador.Propuesta.Vistas
{
    public class AgregarPropuestaPresenter
    {
        #region Propiedades
        private IAgregarPropuesta _vista;
        private IAgregarPropuesta _vista2;
        private IList<Core.LogicaNegocio.Entidades.Persona> Persona;
        #endregion

        #region Constructor

        public AgregarPropuestaPresenter(IAgregarPropuesta vista)
        {
            _vista = vista;
            _vista2 = vista;

        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que se encarga de Invocar al comando Ingresar para asi poder ingresar 
        /// la entidad de tipo propuesta
        /// </summary>
        public void AgregarPropuesta()
        {
            Core.LogicaNegocio.Entidades.Propuesta propuesta = new Core.LogicaNegocio.Entidades.Propuesta();

            try
            {
                propuesta.Titulo = _vista.Titulo.Text;

                propuesta.Version = _vista.Version.Text;

                propuesta.FechaFirma = Convert.ToDateTime(_vista.FechaFirma.Text);

                propuesta.NombreReceptor = _vista.NombreReceptor.Text;

                propuesta.ApellidoReceptor = _vista.ApellidoReceptor.Text;

                propuesta.CargoReceptor = _vista.CargoReceptor.Text;

                propuesta.FechaInicio = Convert.ToDateTime(_vista.FechaInicio.Text);

                propuesta.FechaFin = Convert.ToDateTime(_vista.FechaFin.Text);

                propuesta.MontoTotal = float.Parse(_vista.MontoTotal.Text);

                propuesta.NombreEquipo1 = _vista.NombreEquipo1.Text;

                propuesta.ApellidoEquipo1 = _vista.ApellidoEquipo1.Text;

                propuesta.Rol1 = _vista.RolEquipo1.Text;

                propuesta.NombreEquipo2 = _vista.NombreEquipo2.Text;

                propuesta.ApellidoEquipo2 = _vista.ApellidoEquipo2.Text;

                propuesta.Rol2 = _vista.RolEquipo2.Text;

                propuesta.NombreEquipo3 = _vista.NombreEquipo3.Text;

                propuesta.ApellidoEquipo3 = _vista.ApellidoEquipo3.Text;

                propuesta.Rol3 = _vista.RolEquipo3.Text;

                propuesta.TotalHoras = int.Parse(_vista.TotalHoras.Text);

                propuesta = Agregar(propuesta);

                LimpiarRegistros();
            }
            catch (Exception e)
            {
                //Mensaje a usuario
            }
        }

        /// <summary>
        /// Metodo que se encarga de Invocar al Comando Consultar Empleados y luego proceder
        /// a ser cargados en el grid view
        /// </summary>
        public void ConsultarEmpleados()
        {

            Persona = ConsultEmp();

            try
            {
                if (Persona != null)
                {
                    _vista2.ObtenerValorDataSource.DataSource = Persona;
                    // LimpiarRegistros();
                }

            }
            catch (WebException e)
            {
                //Mensaje al usuario
            }
        }

        /// <summary>
        /// Metodo que se encarga de limpiar todos los campos de la Interfaz Agregar Propuesta
        /// </summary>
        public void LimpiarRegistros()
        {
            _vista.Titulo.Text = "";

            _vista.Version.Text = "";

            _vista.FechaFirma.Text = "";

            _vista.FechaInicio.Text = "";

            _vista.FechaFin.Text = "";

            _vista.MontoTotal.Text = "";

            _vista.CargoReceptor.Text = "";

            _vista.ApellidoReceptor.Text = "";

            _vista.NombreReceptor.Text = "";

            _vista.NombreEquipo1.Text = "";

            _vista.NombreEquipo2.Text = "";

            _vista.NombreEquipo3.Text = "";

            _vista.ApellidoEquipo1.Text = "";

            _vista.ApellidoEquipo2.Text = "";

            _vista.ApellidoEquipo3.Text = "";

            _vista.RolEquipo1.Text = "";

            _vista.RolEquipo2.Text = "";

            _vista.RolEquipo3.Text = "";

            _vista.TotalHoras.Text = "";
        }

        #endregion

        #region Comando Agregar
        /// <summary>
        /// Comando que se encarga de Crear el Comando Ingresar Propuesta
        /// </summary>
        /// <param name="propuesta">Entidad de tipo Propuesta</param>
        /// <returns></returns>

        public Core.LogicaNegocio.Entidades.Propuesta Agregar(Core.LogicaNegocio.Entidades.Propuesta propuesta)
        {
            Core.LogicaNegocio.Comandos.ComandoPropuesta.Ingresar ingresar;

            ingresar = Core.LogicaNegocio.Fabricas.FabricaComandosPropuesta.CrearComandoIngresar(propuesta);

            return ingresar.Ejecutar();



        }
        #endregion

        #region Comando Consultar Empleados
        /// <summary>
        /// Creamos la fabrica y el comando para la consulta de los empleados
        /// </summary>
        /// <returns>Retorna una lista de Empleados</returns>

        public IList<Core.LogicaNegocio.Entidades.Persona> ConsultEmp()
        {
            Core.LogicaNegocio.Comandos.ComandoEmpleado.ConsultarE buscar;
            buscar = Core.LogicaNegocio.Fabricas.FabricaComandosEmpleado.CrearComandoConsultarE(Persona);
            Persona = buscar.Ejecutar();
            return Persona;
        }

        #endregion


    }
}
