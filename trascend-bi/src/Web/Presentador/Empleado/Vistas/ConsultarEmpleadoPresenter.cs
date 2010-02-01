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
    public class ConsultarEmpleadoPresenter
    {
        private IConsultarEmpleado _vista;
        private IList<Core.LogicaNegocio.Entidades.Empleado> empleado;
        private IList<string> cargo;
        private string campoVacio = " ";
        Core.LogicaNegocio.Entidades.Empleado emp;

        #region Constructor
        public ConsultarEmpleadoPresenter(IConsultarEmpleado vista)
        {
            _vista = vista;
        }
        #endregion

        #region Metodos

                    public void CambiarVista(int index)
                    {
                        _vista.MultiViewConsultar.ActiveViewIndex = index;
                    }

                    private void CargarDatos(Core.LogicaNegocio.Entidades.Empleado empleado)
                    {
                        _vista.LabelNombre.Text = empleado.Nombre;
                        _vista.LabelApellido.Text = empleado.Apellido;
                        _vista.LabelCI.Text = empleado.Cedula.ToString();
                        _vista.LabelNumCuenta.Text = empleado.Cuenta;
                        _vista.LabelFechaNac.Text = empleado.FechaNacimiento.ToShortDateString();
                        _vista.LabelEstado.Text = empleado.Estado.ToString();
                        _vista.LabelDirAve.Text = empleado.Direccion.Avenida;
                        _vista.LabelDirUrb.Text = empleado.Direccion.Urbanizacion;
                        _vista.LabelDirEdifCasa.Text = empleado.Direccion.Edif_Casa;
                        _vista.LabelDirPisoApto.Text = empleado.Direccion.Piso_apto;
                        _vista.LabelDirCiudad.Text = empleado.Direccion.Ciudad;
                        _vista.LabelCargo.Text = empleado.Cargo;
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
                        #endregion

                        #region buscar por cargo
                        if (_vista.opcion.SelectedValue == "3")//cargo
                        {
                            Core.LogicaNegocio.Entidades.Empleado empleado1 = new Core.LogicaNegocio.Entidades.Empleado();

                            //empleado1.Cargo = _vista.SeleccionCargo.SelectedItem.Text;

                            //Core.LogicaNegocio.Entidades.Cargo cargo = BuscarCargosNuevo(cargo1);

                            //////////////////////////////////////////


                            
                            //emp.Cargo = _vista.SeleccionCargo.SelectedItem.Text;//vamos a ver no estoy muy seguro
                            
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

                    public void uxObjectConsultaUsuariosSelecting(string nombre)
                    {
                        Core.LogicaNegocio.Entidades.Empleado emp = new Core.LogicaNegocio.Entidades.Empleado();
                        emp.Nombre = nombre;

                        IList<Core.LogicaNegocio.Entidades.Empleado> listado = BuscarPorNombre(emp);
                        emp = null;
                        emp = listado[0];
                        CargarDatos(emp);
                        CambiarVista(1);
                    }
                          
                    public IList<Core.LogicaNegocio.Entidades.Empleado> BuscarPorNombre(Core.LogicaNegocio.Entidades.Empleado entidad)
                    {
                        IList<Core.LogicaNegocio.Entidades.Empleado> empleado1 = null;

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

                    #endregion

  



        #endregion
    }
}
