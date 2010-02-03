using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Empleado.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;
using Core.AccesoDatos.Fabricas;
using System.Net;
using System.Web.UI.WebControls;
using Core.LogicaNegocio.Fabricas;
using Core.LogicaNegocio.Comandos;
using Core.LogicaNegocio.Comandos.ComandoEmpleado;



namespace Presentador.Empleado.Vistas
{
    public class ModificarEmpleadoPresenter
    {

        private IModificarEmpleado _vista;
        private IList<Core.LogicaNegocio.Entidades.Empleado> empleado;
        private IList<string> cargo;
        private string campoVacio = " ";
        Core.LogicaNegocio.Entidades.Empleado emp;

        #region Constructor

        public ModificarEmpleadoPresenter(IModificarEmpleado vista)
        {
            _vista = vista;
        }
        #endregion

        #region Metodos

        public void CambiarVista(int index)
        {
            _vista.MultiViewConsultar.ActiveViewIndex = index;
        }

        public void ModificarEmpleado()
        {
            Core.LogicaNegocio.Entidades.Empleado empleado = new Core.LogicaNegocio.Entidades.Empleado();
            try
            {

                empleado.Nombre = _vista.TextBoxNombre.Text;
                empleado.Apellido = _vista.TextBoxApellido.Text;
                empleado.Estado = Int32.Parse(_vista.SeleccionEstado.SelectedValue);
                empleado.Cuenta = _vista.TextBoxNumCuenta.Text;
                empleado.Cedula = Int32.Parse(_vista.TextBoxCI.Text);
                empleado.Cargo = _vista.TextBoxCargo.SelectedValue.ToString();
                empleado.FechaNacimiento = DateTime.Parse(_vista.TextBoxFechaNac.Text);
                empleado.Direccion = new Core.LogicaNegocio.Entidades.Direccion();
                empleado.Direccion.Avenida = _vista.TextBoxDirAve.Text;
                empleado.Direccion.Calle = _vista.TextBoxDirCalle.Text;
                empleado.Direccion.Ciudad = _vista.TextBoxDirCiudad.Text;
                empleado.Direccion.Edif_Casa = _vista.TextBoxDirEdifCasa.Text;
                empleado.Direccion.Piso_apto = _vista.TextBoxDirPisoApto.Text;
                empleado.Direccion.Urbanizacion = _vista.TextBoxDirUrb.Text;
                empleado.SueldoBase = float.Parse(_vista.TextBoxSueldoBase.Text);
                ModificarEmpleadoLogica(empleado);

            }
            catch (WebException e)
            {
                // _vista.Pintar("0001", "Error Modificando Empleado", "Especificacion del Error", e.ToString());
                // _vista.DialogoVisible = true;//Aqui se maneja la excepcion en caso de que de error la seccion Web
            }
            catch (Exception e)
            {
                //_vista.Pintar("0001", "Error Modificando Empleado", "Especificacion del Error", e.ToString());
                //_vista.DialogoVisible = true;//Aqui se maneja la excepcion en caso de que de error la seccion Web
            }
        }

        public void ModificarEmpleadoLogica(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            Core.LogicaNegocio.Entidades.Empleado _empleado;

            try
            {
                Core.LogicaNegocio.Comandos.ComandoEmpleado.Modificar modificar; //objeto del comando Ingresar.

                //fábrica que instancia el comando Ingresar.
                modificar = Core.LogicaNegocio.Fabricas.FabricaComandosEmpleado.CrearComandoModificar(empleado);

                //try
                //{    
                //ejecuta el comando.
                modificar.Ejecutar();
                /*if (_empleado.Id == -1)
                {
                    _vista.MensajeError.Text = "Operacion Fallida: No se pudo ingresar el empleado";
                    _vista.MensajeError.Visible = true;
                }
                else if (_empleado.Id == -2)
                {
                    _vista.MensajeError.Text = "Operacion Fallida: No se pudo ingresaro el empleado";
                    _vista.MensajeError.Visible = true;
                }
                else
                {
                    _vista.MensajeError.Text = "El empleado se agrego con exito";
                    _vista.MensajeError.Visible = true;
                }

                LimpiarRegistros();
                */

            }
            catch (Exception e)
            {
                /* _vista.Pintar("0001", "Error Ingresando Empleado", "Especificacion del Error", e.ToString());
                 _vista.DialogoVisible = true;//Aqui se maneja la excepcion en caso de que de error la seccion Web */
            }
        }



        private void CargarDatos(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            _vista.TextBoxNombre.Text = empleado.Nombre;

            _vista.TextBoxApellido.Text = empleado.Apellido;

            _vista.TextBoxCI.Text = empleado.Cedula.ToString();

            _vista.TextBoxCI.Enabled = false;

            _vista.TextBoxNumCuenta.Text = empleado.Cuenta;

            _vista.TextBoxSueldoBase.Text = empleado.SueldoBase.ToString();

            _vista.TextBoxFechaNac.Text = empleado.FechaNacimiento.ToShortDateString();

            //_vista.TextBoxEstado.Text = empleado.EstadoEmpleado.Nombre.ToString();//   .Estado.ToString();

            _vista.TextBoxDirAve.Text = empleado.Direccion.Avenida;

            _vista.TextBoxDirCalle.Text = empleado.Direccion.Calle;

            _vista.TextBoxDirUrb.Text = empleado.Direccion.Urbanizacion;

            _vista.TextBoxDirEdifCasa.Text = empleado.Direccion.Edif_Casa;

            _vista.TextBoxDirPisoApto.Text = empleado.Direccion.Piso_apto;

            _vista.TextBoxDirCiudad.Text = empleado.Direccion.Ciudad;


            _vista.TextBoxCargo.SelectedIndex = empleado.CargoEmpleado.Id;

            _vista.SeleccionEstado.SelectedIndex = empleado.EstadoEmpleado.IdEstadoEmpleado;
        }





        /*public void BotonSeleccionTipo()
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
                    _vista.SeleccionCargo.Items.Add(cargo.ElementAt(i));
                }
                _vista.SeleccionCargo.DataBind();
            }

            #endregion
        }*/


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

            #region buscar por nombre
            if (_vista.opcion.SelectedValue == "2")//nombre
            {
                emp.Nombre = _vista.TextBoxParametro.Text;

                List<Core.LogicaNegocio.Entidades.Empleado> listado = BuscarPorNombre(emp);

                try
                {
                    if (listado.Count > 0)
                    {
                        _vista.GetOCConsultarEmp.DataSource = listado;
                    }
                }
                catch (WebException e)
                {

                }
            }
            #endregion

            #region buscar por cargo
            if (_vista.opcion.SelectedValue == "3")//cargo
            {
                Core.LogicaNegocio.Entidades.Empleado empleado1 =
                    new Core.LogicaNegocio.Entidades.Empleado();

                Core.LogicaNegocio.Entidades.Cargo cargoEmpleado =
                    new Core.LogicaNegocio.Entidades.Cargo();

                cargoEmpleado.Id = _vista.drowListaCargo.SelectedIndex + 1;

                empleado1.CargoEmpleado = cargoEmpleado;

                IList<Core.LogicaNegocio.Entidades.Empleado> listado = BuscarPorCargo(empleado1);

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

        public void uxObjectConsultaUsuariosSelecting(int codigoEmpleado)//string nombre
        {
            Core.LogicaNegocio.Entidades.Empleado emp = new Core.LogicaNegocio.Entidades.Empleado();
            //emp.Nombre = nombre;
            emp.Id = codigoEmpleado;

            Core.LogicaNegocio.Entidades.Empleado listado = BuscarEmpleadoCodigo(emp);//BuscarPorNombre(emp);

            emp = null;

            emp = listado;

            CargarDatos(emp);

            CambiarVista(1);
        }

        public List<Core.LogicaNegocio.Entidades.Empleado> BuscarPorNombre(Core.LogicaNegocio.Entidades.Empleado entidad)
        {
            List<Core.LogicaNegocio.Entidades.Empleado> empleado1 = null;

            Core.LogicaNegocio.Comandos.ComandoEmpleado.ConsultarPorNombre consultar;

            consultar = FabricaComandosEmpleado.CrearComandoConsultarPorNombre(entidad);

            empleado1 = consultar.Ejecutar();

            return empleado1;

        }

        public Core.LogicaNegocio.Entidades.Empleado BuscarPorCedula(Core.LogicaNegocio.Entidades.Empleado entidad)
        {

            Core.LogicaNegocio.Entidades.Empleado empleado1 = new Core.LogicaNegocio.Entidades.Empleado();

            Core.LogicaNegocio.Comandos.ComandoEmpleado.ConsultarPorCI consultar;

            consultar = FabricaComandosEmpleado.CrearComandoConsultarPorCI(entidad);

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

        public IList<Core.LogicaNegocio.Entidades.Empleado> BuscarPorCargo
            (Core.LogicaNegocio.Entidades.Empleado entidad)
        {
            IList<Core.LogicaNegocio.Entidades.Empleado> empleado1 = null;

            Core.LogicaNegocio.Comandos.ComandoEmpleado.ConsultarPorCargo consultar;

            consultar = FabricaComandosEmpleado.CrearComandoConsultarPorCargo(entidad);

            empleado1 = consultar.Ejecutar();

            return empleado1;

        }

        public Core.LogicaNegocio.Entidades.Cargo BuscarCargosNuevo
            (Core.LogicaNegocio.Entidades.Cargo entidad)
        {
            Core.LogicaNegocio.Entidades.Cargo cargo = null;

            Core.LogicaNegocio.Comandos.ComandoEmpleado.ConsultarCargoNuevo consultar;

            consultar = FabricaComandosEmpleado.CrearComandoConsultarCargoNuevo(entidad);

            cargo = consultar.Ejecutar();

            return cargo;

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

        private void LimpiarFormulario()
        {
            _vista.TextBoxParametro.Text = campoVacio;

        }


        /*Descripcion: Consultar los diferentes cargos que existente en la tabla Cargos
         *Ingresa en la interfax (drowListaCargo) todos los elemnetos de los formularios
         *agregar y modificar
         */
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


                _vista.TextBoxCargo.Items.Clear();
                _vista.TextBoxCargo.Items.Clear();
                _vista.TextBoxCargo.Items.Add("--");
                _vista.TextBoxCargo.Items[0].Value = "0";
                _vista.TextBoxCargo.DataSource = cargo;
                _vista.TextBoxCargo.DataTextField = "Nombre";
                _vista.TextBoxCargo.DataValueField = "Id";
                _vista.TextBoxCargo.DataBind();


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


        /*Descripcion: Consultar los diferentes estados de los usuarios(Activos, Inactivo, etc) 
         * que existente en la tabla Cargos
         *Ingresa en la interfax (drowListaCargo) todos los elemnetos de los formularios
         *agregar y modificar
         */

        public void ConsultarEstados()
        {
            // IList<Core.LogicaNegocio.Entidades.Entidad> estados = null;
            IList<Core.LogicaNegocio.Entidades.EstadoEmpleado> estados = new List<Core.LogicaNegocio.Entidades.EstadoEmpleado>();
            Core.LogicaNegocio.Entidades.EstadoEmpleado estado = new EstadoEmpleado();
            try
            {
                DropDownList e = new DropDownList();

                //Core.AccesoDatos.SqlServer.DAOCargoSQLServer conex = new Core.AccesoDatos.SqlServer.DAOCargoSQLServer();

                Core.LogicaNegocio.Comandos.ComandoEmpleado.ConsultarEstadoEmpleado consultarestadoempleado; //objeto del comando Ingresar.

                //fábrica que instancia el comando Ingresar.
                consultarestadoempleado = Core.LogicaNegocio.Fabricas.FabricaComandosEmpleado.CrearComandoConsultarEstados();
                estados = consultarestadoempleado.Ejecutar();

                /* for (int i = 0; i < estados.Count; i++)
                 {
                     estado.Add((Core.LogicaNegocio.Entidades.EstadoEmpleado)estados[i]);
                 }
                 */

                _vista.SeleccionEstado.Items.Clear();
                _vista.SeleccionEstado.Items.Add("--");
                _vista.SeleccionEstado.Items[0].Value = "0";
                _vista.SeleccionEstado.DataSource = estados;
                _vista.SeleccionEstado.DataTextField = "Nombre";
                _vista.SeleccionEstado.DataValueField = "IdEstadoEmpleado";
                _vista.SeleccionEstado.DataBind();
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

        private Core.LogicaNegocio.Entidades.Empleado BuscarEmpleadoCodigo(Core.LogicaNegocio.Entidades.Empleado entidad)
        {
            Core.LogicaNegocio.Entidades.Empleado empleado1 = null;

            Core.LogicaNegocio.Comandos.ComandoEmpleado.ConsultarPorCodigo consultar;//nuevo

            consultar = FabricaComandosEmpleado.CrearConsultarPorCodigo(entidad);

            empleado1 = consultar.Ejecutar();

            return empleado1;

        }

            #endregion





        public void RedirectModificar()
        {
            Core.LogicaNegocio.Entidades.Empleado empleado1 =
                   new Core.LogicaNegocio.Entidades.Empleado();


            empleado1.Nombre = " ";

            List<Core.LogicaNegocio.Entidades.Empleado> listado = BuscarPorNombre(empleado1);

            try
            {
                if (listado.Count > 0)
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
}
