using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Empleado.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Fabricas;
using Core.LogicaNegocio.Comandos;
using System.Net;
using System.Web.UI.WebControls;
namespace Presentador.Empleado.Vistas
{
    public class AgregarEmpleadoPresenter
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
            try
            {

                empleado.Nombre = _vista.NombreEmpleado.Text;
                empleado.Apellido = _vista.ApellidoEmpleado.Text;
                empleado.Cedula = Int32.Parse(_vista.CedulaEmpleado.Text);
                empleado.Cuenta = _vista.CuentaEmpleado.Text;
                empleado.Estado = "Activo";
                empleado.FechaIngreso = DateTime.Parse(_vista.FechaIngresoEmpleado.Text);
                empleado.FechaEgreso = DateTime.Parse(_vista.FechaEgresoEmpleado.Text);
                empleado.FechaNacimiento = DateTime.Parse(_vista.FechaNacEmpleado.Text);
                empleado.SueldoBase = float.Parse(_vista.SueldoEmpleado.Text);
                Ingresar(empleado);
                LimpiarRegistros();
            }
            catch (WebException e)
            {
                _vista.Pintar("0001", "Error Ingresando Empleado" , "Especificacion del Error", e.ToString());
                _vista.DialogoVisible = true;//Aqui se maneja la excepcion en caso de que de error la seccion Web
            }
            catch (Exception e)
            {
                _vista.Pintar("0001", "Error Ingresando Empleado", "Especificacion del Error", e.ToString());
                _vista.DialogoVisible = true;//Aqui se maneja la excepcion en caso de que de error la seccion Web
            }
        }
        public void ConsultarCargos()
        {
            IList<Core.LogicaNegocio.Entidades.Entidad> cargos = null;
            IList<Core.LogicaNegocio.Entidades.Cargo> cargo = new List<Core.LogicaNegocio.Entidades.Cargo>();
            try
            {
                DropDownList e = new DropDownList();
                Core.AccesoDatos.SqlServer.CargoSQLServer conex = new Core.AccesoDatos.SqlServer.CargoSQLServer();
                cargos = conex.ConsultarCargos();
                for (int i = 0; i < cargos.Count; i++)
                {
                    cargo.Add((Core.LogicaNegocio.Entidades.Cargo) cargos[i]);            
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
                _vista.Pintar("0001", e.ToString(), "Yop", "lol");
                _vista.DialogoVisible = true;//Aqui se maneja la excepcion en caso de que de error la seccion Web
            }
            catch (Exception e)
            {
                _vista.Pintar("0001", e.ToString(), "Yop", "lol");
                _vista.DialogoVisible = true;//Aqui se maneja la excepcion en caso de que de error la seccion Web
            }
        }
        public void ConsultarSueldos()
        {
            try
            {
                Core.LogicaNegocio.Entidades.Cargo cargo = new Core.LogicaNegocio.Entidades.Cargo();
                cargo.Nombre = _vista.ComboCargos.SelectedItem.Text;
                Core.AccesoDatos.SqlServer.CargoSQLServer conex = new Core.AccesoDatos.SqlServer.CargoSQLServer();
                cargo = (Core.LogicaNegocio.Entidades.Cargo)conex.ConsultarCargo(cargo);
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
            _vista.DireccionEmpleado.Text = campoVacio;
            _vista.CuentaEmpleado.Text = campoVacio;
            _vista.CedulaEmpleado.Text = campoVacio;
            _vista.ApellidoEmpleado.Text = campoVacio;
            _vista.FechaEgresoEmpleado.Text = DateTime.Now.ToString();
            _vista.FechaIngresoEmpleado.Text = DateTime.Now.ToString();
            _vista.FechaNacEmpleado.Text = DateTime.Now.ToString();
        }
        #endregion

        #region Comando
        public void Ingresar(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            Core.LogicaNegocio.Comandos.ComandoEmpleado.Ingresar ingresar; //objeto del comando Ingresar.

            //fábrica que instancia el comando Ingresar.
            ingresar = Core.LogicaNegocio.Fabricas.FabricaComandosEmpleado.CrearComandoIngresar(empleado);

            //try
            //{    
            //ejecuta el comando.
            ingresar.Ejecutar();
        }
        #endregion
      
    }
}
