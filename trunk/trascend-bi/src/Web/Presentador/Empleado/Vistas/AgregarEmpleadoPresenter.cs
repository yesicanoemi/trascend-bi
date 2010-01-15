using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Empleado.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Fabricas;
using Core.LogicaNegocio.Comandos;
using System.Net;
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
                empleado.Cuenta = Int32.Parse(_vista.CuentaEmpleado.Text);
                empleado.Estado = "Activo";
                empleado.FechaIngreso = DateTime.Now;
                empleado.FechaNacimiento = DateTime.Now;
                empleado.SueldoBase = float.Parse(_vista.SueldoEmpleado.Text);
                Ingresar(empleado);
                LimpiarRegistros();
            }
            catch (WebException e)
            {
                _vista.Pintar("0001","Hola","Yop","lol");
                _vista.DialogoVisible = true;//Aqui se maneja la excepcion en caso de que de error la seccion Web
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
