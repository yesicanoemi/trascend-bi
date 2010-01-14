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
                resultado = Modificar(empleado);
                //LimpiarRegistros();
            }
            catch (WebException e)
            {
                //Aqui se maneja la excepcion en caso de que de error la seccion Web
            }
        }
        #endregion

        #region Comando
        public int Modificar(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            Core.LogicaNegocio.Comandos.ComandoEmpleado.Modificar modificar; //objeto del comando Ingresar.

            //fábrica que instancia el comando Ingresar.
            modificar = Core.LogicaNegocio.Fabricas.FabricaComandosEmpleado.CrearComandoModificar(empleado);

            //try
            //{    
            //ejecuta el comando.
            return modificar.Ejecutar();
        }
        #endregion
    }
}
