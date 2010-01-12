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
        private EmpleadoController _controller;

        public AgregarEmpleadoPresenter(IAgregarEmpleado vista)
        {
            _vista = vista;
            _controller = new EmpleadoController();
        }

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
                empleado.FechaNacimiento = DateTime.Parse(_vista.FechaNacEmpleado.Text);
                empleado.SueldoBase = float.Parse(_vista.SueldoEmpleado.Text);
                //empleado = _controller
            }
            catch(WebException e)
            {
                //Aqui se maneja la excepcion en caso de que de error la seccion Web
            }
        }
        #endregion

        #region Comando
        public Core.LogicaNegocio.Entidades.Empleado Ingresar(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            Core.LogicaNegocio.Comandos.ComandoEmpleado.Ingresar ingresar; //objeto del comando Ingresar.

            //fábrica que instancia el comando Ingresar.
            ingresar = Core.LogicaNegocio.Fabricas.FabricaComandosEmpleado.CrearComandoIngresarId(entidad);

            //try
            //{    
            //ejecuta el comando.
            return ingresar.Ejecutar();
        }
        #endregion
    }
}
