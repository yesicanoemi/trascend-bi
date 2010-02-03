using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Presentador.Empleado.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Fabricas;
using System.Web.UI.WebControls;
using Core.LogicaNegocio.Comandos;

namespace Presentador.Empleado.Vistas
{
    public class EliminarEmpleadoPresenter
    {
        private IEliminarEmpleado _vista;
        private IList<Core.LogicaNegocio.Entidades.Empleado> empleado;
        private IList<string> cargo;
        private string campoVacio = " ";
        Core.LogicaNegocio.Entidades.Empleado emp;

        #region Constructor
        public EliminarEmpleadoPresenter(IEliminarEmpleado vista)
        {
            _vista = vista;
        }
        #endregion

        #region Metodos


        /// <summary>
        /// Metodo que ejecuta la accion de Selección de tipo de Consulta
        /// </summary>
        public void BotonSeleccionTipo()
        {
            #region SolicitudServicios

            if (_vista.opcion.SelectedIndex == 0) // Seleccion Cedula
            {

            }

            if (_vista.opcion.SelectedIndex == 1)// Seleccion Nombre
            {

            }

            if (_vista.opcion.SelectedIndex == 2)// Seleccion Cargo
            {
                cargo = BuscarCargos();
                for (int i = 0; i < cargo.Count; i++)
                {
                    _vista.drowListaCargo.Items.Add(cargo.ElementAt(i));
                }
                _vista.drowListaCargo.DataBind();
            }

            #endregion
        }

        /// <summary>
        /// Metodo que ejcuta la Accion de realizar la consulta por parámetro indicado
        /// y presenta la propuesta seleccionada
        /// </summary>
        public void BotonAccionEliminar()
        {
            #region Atributos de la Pagina
            #region Activar Campos

            #endregion
            #region Desactivar Campos
            _vista.opcion.Visible = true;
            _vista.drowListaCargo.Visible = false;
            #endregion

            #endregion

            #region Solicitud Servicio
            emp = new Core.LogicaNegocio.Entidades.Empleado();

            if (_vista.opcion.SelectedIndex == 0)//cedula
            {
                emp.Cedula = Int32.Parse(_vista.ParametroCedula.Text);
                Core.LogicaNegocio.Entidades.Empleado empleado = BuscarPorCedula(emp);
                IList<Core.LogicaNegocio.Entidades.Empleado> listado = new List<Core.LogicaNegocio.Entidades.Empleado>();
                listado.Add(empleado);

                try
                {
                    if (listado != null)
                    {
                        _vista.GetOCConsultarEmp.DataSource = listado;
                    }
                }
                catch (WebException e)
                {

                }
            }
            if (_vista.opcion.SelectedIndex == 1)//nombre
            {
                emp.Nombre = _vista.TextBoxParametro.Text;
                IList<Core.LogicaNegocio.Entidades.Empleado> listado = BuscarPorNombre(emp);
                try
                {
                    if (listado != null)
                    {
                        _vista.GetOCConsultarEmp.DataSource = listado;
                    }
                }
                catch (WebException e)
                {

                }
            }
            if (_vista.opcion.SelectedIndex == 2)//cargo
            {
                emp.Cargo = _vista.drowListaCargo.SelectedItem.Text;
                IList<Core.LogicaNegocio.Entidades.Empleado> listado = BuscarPorCargo(emp);
                try
                {
                    if (listado != null)
                    {
                        _vista.GetOCConsultarEmp.DataSource = listado;
                    }
                }
                catch (WebException e)
                {

                }
            }
            #endregion
        }
        private void LimpiarFormulario()
        {
            _vista.TextBoxParametro.Text = campoVacio;

        }
        public void ChangedSearch()
        {
            LimpiarFormulario();

            if (_vista.opcion.SelectedValue == "1")
            {
                _vista.drowListaCargo.Visible = false;
                _vista.opcion.Visible = true;
                _vista.TextBoxParametro.Visible = false;
                _vista.ParametroCedula.Visible = true;
                _vista.Aceptar.Visible = true;
                _vista.GetOCConsultarEmp.DataSource = "";
                _vista.ParametroCedula.Text = "";
                _vista.TextBoxParametro.Text = "";


            }

            if (_vista.opcion.SelectedValue == "2")
            {
                _vista.drowListaCargo.Visible = false;
                _vista.opcion.Visible = true;
                _vista.TextBoxParametro.Visible = true;
                _vista.Aceptar.Visible = true;
                _vista.ParametroCedula.Visible = false;
                _vista.GetOCConsultarEmp.DataSource = "";
                _vista.ParametroCedula.Text = "";
                _vista.TextBoxParametro.Text = "";


            }

            if (_vista.opcion.SelectedValue == "3")
            {
                _vista.drowListaCargo.Visible = true;
                _vista.opcion.Visible = true;
                _vista.TextBoxParametro.Visible = false;
                _vista.Aceptar.Visible = true;
                _vista.ParametroCedula.Visible = false;
                _vista.GetOCConsultarEmp.DataSource = "";
                _vista.ParametroCedula.Text = "";
                _vista.TextBoxParametro.Text = "";

            }
        }


        public void uxObjectConsultaUsuariosSelecting(int codigoEmpleado)
        {
            Core.LogicaNegocio.Entidades.Empleado emp = new Core.LogicaNegocio.Entidades.Empleado();
            //emp.Nombre = nombre;
            emp.Id = codigoEmpleado;
            int result = EliminarEmpleado(emp);

            //lanzar un ventana de confirmacion si result es 1 o una de error si result es 0

        }
  
        /// <summary>
        /// Metodo que busca las propuestas
        /// </summary>
        /// <returns>devuelve objeto de tipo lista de propuestas</returns>
        public IList<Core.LogicaNegocio.Entidades.Empleado> BuscarPorNombre(Core.LogicaNegocio.Entidades.Empleado entidad)
        {
            IList<Core.LogicaNegocio.Entidades.Empleado> empleado1 = null;

            Core.LogicaNegocio.Comandos.ComandoEmpleado.ELiminarConsultarPorNombre consultar;

            consultar = FabricaComandosEmpleado.CrearComandoEliminarConsultarPorNombre(entidad);

            empleado1 = consultar.Ejecutar();

            return empleado1;

        }

        public Core.LogicaNegocio.Entidades.Empleado BuscarPorCedula(Core.LogicaNegocio.Entidades.Empleado entidad)
        {

            Core.LogicaNegocio.Entidades.Empleado empleado1 = new Core.LogicaNegocio.Entidades.Empleado();

            Core.LogicaNegocio.Comandos.ComandoEmpleado.EliminarConsultarPorCI consultar;

            consultar = FabricaComandosEmpleado.CrearComandoEliminarConsultarPorCI(entidad);
            
            empleado1 = consultar.Ejecutar();

            return empleado1;
        }

        public IList<string> BuscarCargos()
        {
            Core.LogicaNegocio.Comandos.ComandoEmpleado.ConsultarCargo consultar;

            consultar = FabricaComandosEmpleado.CrearComandoConsultarCargo(cargo);

            cargo = consultar.Ejecutar();

            return cargo;
        }

        public IList<Core.LogicaNegocio.Entidades.Empleado> BuscarPorCargo(Core.LogicaNegocio.Entidades.Empleado entidad)
        {
            IList<Core.LogicaNegocio.Entidades.Empleado> empleado1 = null;

            Core.LogicaNegocio.Comandos.ComandoEmpleado.EliminarConsultarPorCargo consultar;

            consultar = FabricaComandosEmpleado.CrearComandoEliminarConsultarPorCargo(entidad);

            empleado1 = consultar.Ejecutar();

            return empleado1;

        }

        public int EliminarEmpleado(Core.LogicaNegocio.Entidades.Empleado entidad)
        {

            int resultado = 0;

            Core.LogicaNegocio.Comandos.ComandoEmpleado.EliminarEmpleado eliminar;

            eliminar = FabricaComandosEmpleado.CrearComandoEliminarEmpleado(entidad);

            resultado = eliminar.Ejecutar();

            return resultado;

        }
        public void BotonAccionConsulta()
        {
            // _vista.opcion.Visible = false;
            // _vista.SeleccionCargo.Visible = false;                       

            #region Solicitud Servicio

            emp = new Core.LogicaNegocio.Entidades.Empleado();

            #region buscar por cedula

            if (_vista.opcion.SelectedValue == "1")//cedula
            {
                emp.Cedula = Int32.Parse(_vista.ParametroCedula.Text);

                Core.LogicaNegocio.Entidades.Empleado empleado = BuscarPorCedula(emp);

                IList<Core.LogicaNegocio.Entidades.Empleado> listado = new List<Core.LogicaNegocio.Entidades.Empleado>();

                listado.Add(empleado);

                try
                {
                    if (listado != null)
                    {
                        _vista.GetOCConsultarEmp.DataSource = listado;
                    }
                }
                catch (WebException e)
                {

                }
            }
            #endregion
            #endregion
        }
        public void ConsultarCargos()
        {
            IList<Core.LogicaNegocio.Entidades.Entidad> cargos = null;
            IList<Core.LogicaNegocio.Entidades.Cargo> cargo = new List<Core.LogicaNegocio.Entidades.Cargo>();
            try
            {
                DropDownList e = new DropDownList();
                Core.AccesoDatos.SqlServer.DAOCargoSQLServer conex = new Core.AccesoDatos.SqlServer.DAOCargoSQLServer();
                cargos = conex.ConsultarCargos();
                for (int i = 0; i < cargos.Count; i++)
                {
                    cargo.Add((Core.LogicaNegocio.Entidades.Cargo)cargos[i]);
                }
                _vista.drowListaCargo.Items.Clear();
                _vista.drowListaCargo.Items.Add("--");
                _vista.drowListaCargo.Items[0].Value = "0";
                _vista.drowListaCargo.DataSource = cargo;
                _vista.drowListaCargo.DataTextField = "Nombre";
                _vista.drowListaCargo.DataValueField = "Id";
                _vista.drowListaCargo.DataBind();
            }
            catch (WebException e)
            {
                // _vista.Pintar("0002", "Error consultando cargos", "Error 0002", e.ToString());
                // _vista.DialogoVisible = true;//Aqui se maneja la excepcion en caso de que de error la seccion Web
            }
            catch (Exception e)
            {
                //_vista.Pintar("0002", "Error consultando cargos", "Error 0002", e.ToString());
                //_vista.DialogoVisible = true;//Aqui se maneja la excepcion en caso de que de error la seccion Web
            }
        }
    }
}
#endregion