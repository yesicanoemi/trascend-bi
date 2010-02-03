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
using Core.LogicaNegocio.Excepciones.Empleados.LogicaNegocio;
using System.Globalization;
using System.Data;
using System.Web;
using System.Configuration;
using Presentador.Base;
using Presentador.Cliente.Vistas;
using Presentador.Cliente.Contrato;
using Core.LogicaNegocio.Comandos;
using Core.LogicaNegocio.Excepciones.Cliente.LogicaNegocio;

namespace Presentador.Empleado.Vistas
{
    public class AgregarEmpleadoPresenter: PresentadorBase
    {
        private IAgregarEmpleado _vista;
        private string campoVacio = "";
        //private EmpleadoController _controller;
        #region Constructor
        public AgregarEmpleadoPresenter(IAgregarEmpleado vista)
        {
            _vista = vista;
            //_controller = new EmpleadoController();
        }
        #endregion
        #region Manejo de Eventos
        public void IngresarEmpleado()
        {
            Core.LogicaNegocio.Entidades.Empleado empleado = new Core.LogicaNegocio.Entidades.Empleado();

            int comprobar;

            try
            {

                empleado.Nombre = _vista.NombreEmpleado.Text;

                empleado.Apellido = _vista.ApellidoEmpleado.Text;

                empleado.Cedula = Int32.Parse(_vista.CedulaEmpleado.Text);                

                comprobar = comprobarCedula(empleado.Cedula);

                if (comprobar == 0)
                    throw new Core.LogicaNegocio.Excepciones.Empleados.LogicaNegocio.AgregarEmpleadoLNException();

                empleado.Cuenta = _vista.CuentaEmpleado.Text;

                empleado.Cargo = _vista.ComboCargos.SelectedValue.ToString();

                empleado.Estado = 1;

                empleado.FechaNacimiento = DateTime.Parse(_vista.FechaNacEmpleado.Text);

                empleado.Direccion = new Core.LogicaNegocio.Entidades.Direccion();

                empleado.Direccion.Avenida = _vista.AvenidaEmpleado.Text;

                empleado.Direccion.Calle = _vista.CalleEmpleado.Text;

                empleado.Direccion.Ciudad = _vista.CiudadEmpleado.Text;

                empleado.Direccion.Edif_Casa = _vista.EdificioEmpleado.Text;

                empleado.Direccion.Piso_apto = _vista.PisoEmpleado.Text;

                empleado.Direccion.Urbanizacion = _vista.UrbanizacionEmpleado.Text;

                empleado.SueldoBase = float.Parse(_vista.SueldoEmpleado.Text);

                Ingresar(empleado);



            }
            catch (AgregarEmpleadoLNException e)
            {
                _vista.Mensaje("Error la cedula de identida ya existe");
            }
            catch (WebException e)
            {
                _vista.Mensaje(e.Message);

                //_vista.Pintar("0001", "Error Ingresando Empleado" , "Especificacion del Error", e.ToString());
                //_vista.DialogoVisible = true;//Aqui se maneja la excepcion en caso de que de error la seccion Web
            }
            catch (Exception e)
            {
                _vista.Mensaje(e.Message);

                //_vista.Pintar("0001", "Error Ingresando Empleado", "Especificacion del Error", e.ToString());
                //_vista.DialogoVisible = true;//Aqui se maneja la excepcion en caso de que de error la seccion Web
            }

            //_vista.PintarInformacion(ManagerRecursos.GetString("ClienteOperacionExitosa"), "confirmacion");
            //_vista.InformacionVisible = true;

            LimpiarRegistros();
            //DesactivarCampos();
            //_vista.InsertarOtro.Visible = true;
            //_vista.Agregar.Visible = false;
        }
        public void ConsultarCargos()
        {
            IList<Core.LogicaNegocio.Entidades.Entidad> cargos = null;
            IList<Core.LogicaNegocio.Entidades.Cargo> cargo = new List<Core.LogicaNegocio.Entidades.Cargo>();
            try
            {
                DropDownList e = new DropDownList();
                //esto lo modifico Iann Yanes para que corriera con el nuevo paton de diseño de DAO
            
                FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

                IDAOCargo bd = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOCargo();

                cargos = bd.ConsultarCargos();
                //*******************************
                for (int i = 0; i < cargos.Count; i++)
                {
                    cargo.Add((Core.LogicaNegocio.Entidades.Cargo)cargos[i]);
                }
                
                _vista.ComboCargos.Items.Clear();
                _vista.ComboCargos.Items.Add("--");
                _vista.ComboCargos.Items[0].Value = "0";
                _vista.ComboCargos.DataSource = cargo;
                _vista.ComboCargos.DataTextField = "Nombre";
                _vista.ComboCargos.DataValueField = "Id";
                _vista.ComboCargos.DataBind();
            }
            catch (WebException e)
            {
                _vista.Pintar("0002", "Error consultando cargos", "Error 0002", e.ToString());
                _vista.DialogoVisible = true;//Aqui se maneja la excepcion en caso de que de error la seccion Web
            }
            catch (Exception e)
            {
                _vista.Pintar("0002", "Error consultando cargos", "Error 0002", e.ToString());
                _vista.DialogoVisible = true;//Aqui se maneja la excepcion en caso de que de error la seccion Web
            }
        }
        public void ConsultarSueldos()
        {
            try
            {
                Core.LogicaNegocio.Entidades.Cargo cargo = new Core.LogicaNegocio.Entidades.Cargo();
                cargo.Nombre = _vista.ComboCargos.SelectedItem.Text;
                FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

                IDAOCargo bd = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOCargo();

                cargo = (Core.LogicaNegocio.Entidades.Cargo)bd.ConsultarCargo(cargo);
                _vista.RangoSueldo = "Rango de Sueldo: " + cargo.SueldoMinimo.ToString() + " - " + cargo.SueldoMaximo.ToString();
                _vista.RangoVisible = true;
                _vista.SueldoEmpleado.Text = cargo.SueldoMinimo.ToString();
                _vista.SueldoEmpleado.Enabled = false;
            }
            catch (WebException e)
            {
            }
            catch (Exception e)
            {
            }
        }
        public void LimpiarRegistros()
        {
            _vista.NombreEmpleado.Text = campoVacio;
            _vista.SueldoEmpleado.Text = campoVacio;
            _vista.AvenidaEmpleado.Text = campoVacio;
            _vista.CalleEmpleado.Text = campoVacio;
            _vista.CiudadEmpleado.Text = campoVacio;
            _vista.EdificioEmpleado.Text = campoVacio;
            _vista.PisoEmpleado.Text = campoVacio;
            _vista.UrbanizacionEmpleado.Text = campoVacio;
            _vista.CuentaEmpleado.Text = campoVacio;
            _vista.CedulaEmpleado.Text = campoVacio;
            _vista.ApellidoEmpleado.Text = campoVacio;
            _vista.FechaNacEmpleado.Text = campoVacio;
            
        }
        

        #endregion

        #region Comando
        public void Ingresar(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            Core.LogicaNegocio.Entidades.Empleado _empleado;

            try
            {
                Core.LogicaNegocio.Comandos.ComandoEmpleado.Ingresar ingresar; //objeto del comando Ingresar.

                //fábrica que instancia el comando Ingresar.
                ingresar = Core.LogicaNegocio.Fabricas.FabricaComandosEmpleado.CrearComandoIngresar(empleado);

                //try
                //{    
                //ejecuta el comando.
                _empleado = ingresar.Ejecutar();
                /*if ((_empleado.Id != -1) ||(_empleado.Id == -2))
                {
                    //_vista.MensajeError.Text = "El empleado se agrego con exito";
                    //_vista.MensajeError.Visible = true;
                }                
                
               LimpiarRegistros();*/

                _vista.Mensaje("El empleado se agrego con exito");
            }
            catch (WebException e)
            {
                //LimpiarRegistros();
                _vista.Mensaje(e.Message);

                //_vista.Pintar(ManagerRecursos.GetString("codigoErrorWeb"),
                //ManagerRecursos.GetString("mensajeErrorWeb"), e.Source, e.Message + "\n " + e.StackTrace);
                //_vista.DialogoVisible = true;

            }
            catch (AgregarEmpleadoLNException e)
            {

                _vista.Mensaje(e.Message);
                //_vista.Pintar(ManagerRecursos.GetString("codigoErrorIngresar"),
                //ManagerRecursos.GetString("mensajeErrorIngresar"), e.Source, e.Message + "\n " + e.StackTrace);
                //_vista.DialogoVisible = true;

            }           
            catch (Exception e)
            {
                _vista.Mensaje(e.Message);
                //_vista.Pintar(ManagerRecursos.GetString("codigoErrorGeneral"),
                //  ManagerRecursos.GetString("mensajeErrorGeneral"), e.Source, e.Message + "\n " + e.StackTrace);
                //_vista.DialogoVisible = true;

            }
            LimpiarRegistros();
            
        }

        private int comprobarCedula(int ced)
        {
            int cedulaL=0;

            try
            {
                Core.LogicaNegocio.Comandos.ComandoEmpleado.ConsultarCedula consultarCedula; //objeto del comando Ingresar.

                //fábrica que instancia el comando Ingresar.

                consultarCedula = Core.LogicaNegocio.Fabricas.FabricaComandosEmpleado.CrearComandoConsultarCedula(ced);


                cedulaL = consultarCedula.Ejecutar();
                                
            }
            catch (WebException e)
            {
                //LimpiarRegistros();
                _vista.Mensaje(e.Message);

                //_vista.Pintar(ManagerRecursos.GetString("codigoErrorWeb"),
                //ManagerRecursos.GetString("mensajeErrorWeb"), e.Source, e.Message + "\n " + e.StackTrace);
                //_vista.DialogoVisible = true;

            }
            catch (AgregarEmpleadoLNException e)
            {

                _vista.Mensaje(e.Message);
                //_vista.Pintar(ManagerRecursos.GetString("codigoErrorIngresar"),
                //ManagerRecursos.GetString("mensajeErrorIngresar"), e.Source, e.Message + "\n " + e.StackTrace);
                //_vista.DialogoVisible = true;

            }           
            catch (Exception e)
            {
                _vista.Mensaje(e.Message);
                //_vista.Pintar(ManagerRecursos.GetString("codigoErrorGeneral"),
                //  ManagerRecursos.GetString("mensajeErrorGeneral"), e.Source, e.Message + "\n " + e.StackTrace);
                //_vista.DialogoVisible = true;

            }
            return cedulaL;
        }
        
        #endregion
      
    }
}
