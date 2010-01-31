using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Propuesta.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;
using Core.AccesoDatos.Fabricas;
using System.Net;
using System.Collections;
using System.Resources;
using System.Threading;
using System.Globalization;
using System.Configuration;
using Core.LogicaNegocio.Fabricas;
using Presentador.Reportes.Contrato;

namespace Presentador.Propuesta.Vistas
{
    public class AgregarPropuestaPresenter
    {
        #region Propiedades
        private IAgregarPropuesta _vista;
        private IAgregarPropuesta _vista2;
        private IList<Core.LogicaNegocio.Entidades.Persona> Persona;
        private IList<string[]> lista;
        private IList<string[]> lista2;
        private IList<string> cargo;

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



                propuesta.Rol1 = _vista.RolEquipo1.Text;


                propuesta.TotalHoras = int.Parse(_vista.TotalHoras.Text);

                // propuesta.Equipo = _vista.TrabajoEquipo.SelectedItem;

                //string[] nombre = propuesta.Equipo.Split(' ');

                lista2 = SeleccionEquipo(lista);

                propuesta = Agregar(propuesta, lista2);

                _vista.LabelExitoA.Text = "La propuesta se agrego con exito";
                _vista.LabelExitoA.Visible = true;

                LimpiarRegistros();
            }
            catch (Exception e)
            {
                _vista.Mensaje(e.Message);
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

                    // _vista2.ObtenerValorDataSource.DataSource = Persona;
                    //    LimpiarRegistros();
                    //_vista2.TrabajoEquipo.DataSource. = Persona;
                    //      _vista2.TrabajoEquipo.DataBind();
                    int i;
                    for (i = 0; i < Persona.Count; i++)
                    {
                        _vista.TrabajoEquipo.Items.Add(Persona.ElementAt(i).Nombre + " " + Persona.ElementAt(i).Apellido);

                    }
                    _vista.TrabajoEquipo.DataBind();
                }

            }
            catch (WebException e)
            {
                _vista.Mensaje(e.Message);
            }
        }

        public IList<string[]> SeleccionEquipo(IList<string[]> lista)
        {
            string seleccion;
            string[] nombre;
            String s = "Selected items:<br>";
            lista = new List<string[]>();

            for (int i = 0; i < _vista.TrabajoEquipo.Items.Count; i++)
            {
                if (_vista.TrabajoEquipo.Items[i].Selected)
                {
                    seleccion = _vista.TrabajoEquipo.Items[i].Text;
                    nombre = seleccion.Split(' ');
                    lista.Add(nombre);
                    // List the selected items
                    //  s = s + Check1.Items[i].Text;
                    // s = s + "<br>";
                }

            }

            return lista;

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

            _vista.NombreReceptor.Text = "";

            _vista.ApellidoReceptor.Text = "";

            _vista.RolEquipo1.Text = "";

            _vista.TotalHoras.Text = "";
        }

        public void ConsultarCargos()
        {
            Core.LogicaNegocio.Entidades.Cargo EntidadCargo = new Core.LogicaNegocio.Entidades.Cargo();

            Core.LogicaNegocio.Comandos.ComandoPropuesta.ConsultarCargoPropuesta consultar;

            consultar = Core.LogicaNegocio.Fabricas.FabricaComandosPropuesta.CrearComandoConsultarCargo(EntidadCargo);

            IList<Entidad> Cargos = consultar.Ejecutar();

            /*
            Core.AccesoDatos.SqlServer.CargoSQLServer bd = new Core.AccesoDatos.SqlServer.CargoSQLServer();
            IList<Entidad> Cargos = bd.ConsultarCargos();
            */

            List<Core.LogicaNegocio.Entidades.Cargo> ListaCargos = new List<Core.LogicaNegocio.Entidades.Cargo>();

            for (int i = 0; i < Cargos.Count; i++)
            {
                ListaCargos.Add((Core.LogicaNegocio.Entidades.Cargo)Cargos.ElementAt(i));
            }

            _vista.CargoReceptor.DataSource = ListaCargos;
            _vista.CargoReceptor.DataTextField = "Nombre";
            _vista.CargoReceptor.DataBind();

        }

        #endregion

        #region Comando Agregar
        /// <summary>
        /// Comando que se encarga de Crear el Comando Ingresar Propuesta
        /// </summary>
        /// <param name="propuesta">Entidad de tipo Propuesta</param>
        /// <returns></returns>

        public Core.LogicaNegocio.Entidades.Propuesta Agregar(Core.LogicaNegocio.Entidades.Propuesta propuesta, IList<string[]> equipo)
        {
            Core.LogicaNegocio.Comandos.ComandoPropuesta.Ingresar ingresar;

            ingresar = Core.LogicaNegocio.Fabricas.FabricaComandosPropuesta.CrearComandoIngresar(propuesta, equipo);

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
