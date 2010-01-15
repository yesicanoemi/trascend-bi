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
    public class ModificarEmpleadoPresenter
    {
        #region Propiedades
        private IModificarEmpleado _vista;
        private string campoVacio = "";
        #endregion
        #region Constructor
        public ModificarEmpleadoPresenter(IModificarEmpleado vista)
        {
            _vista = vista;
        }
        #endregion

        #region Manejo de Eventos
        public void ModificarEmpleado()
        {
            int resultado = 0;
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
                Modificar(empleado);
                LimpiarRegistros();
            }
            catch (WebException e)
            {
                //Aqui se maneja la excepcion en caso de que de error la seccion Web
            }
        }
        public void ConsultarEmpleado()
        {
            Core.LogicaNegocio.Entidades.Empleado empleado = new Core.LogicaNegocio.Entidades.Empleado();
            try
            {
                empleado.Cedula = Int32.Parse(_vista.CedulaEmpleado.Text);
                ConsultarEmpleado(empleado);
            }
            catch (WebException e)
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

        public void LlenarRegistros(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            _vista.NombreEmpleado.Text = empleado.Nombre;
            _vista.SueldoEmpleado.Text =empleado.SueldoBase.ToString();
            _vista.DireccionEmpleado.Text = "";
            _vista.CuentaEmpleado.Text = empleado.Cuenta.ToString();
            _vista.CedulaEmpleado.Text = empleado.Cedula.ToString();
            _vista.ApellidoEmpleado.Text = empleado.Apellido;
            _vista.FechaEgresoEmpleado.Text = empleado.FechaEgreso.ToShortDateString();
            _vista.FechaIngresoEmpleado.Text = empleado.FechaIngreso.ToShortDateString();
            _vista.FechaNacEmpleado.Text = empleado.FechaNacimiento.ToShortDateString();
        }
        #endregion

        #region Comando
        public void Modificar(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            Core.LogicaNegocio.Comandos.ComandoEmpleado.Modificar modificar; //objeto del comando Ingresar.

            //fábrica que instancia el comando Ingresar.
            modificar = Core.LogicaNegocio.Fabricas.FabricaComandosEmpleado.CrearComandoModificar(empleado);

            //try
            //{    
            //ejecuta el comando.
            modificar.Ejecutar();
        }
        public void ConsultarEmpleado(Core.LogicaNegocio.Entidades.Empleado empleado)
        {/*
            Core.LogicaNegocio.Comandos.ComandoEmpleado.Consultar consultar; //objeto del comando Ingresar.

            //fábrica que instancia el comando Ingresar.
            consultar = Core.LogicaNegocio.Fabricas.FabricaComandosEmpleado.CrearComandoConsultar(empleado);

            //try
            //{    
            //ejecuta el comando.
            modificar.Ejecutar();*/
        }
        #endregion
    }
}
