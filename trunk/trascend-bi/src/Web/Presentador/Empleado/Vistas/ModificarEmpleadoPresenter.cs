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
                empleado.Cuenta = _vista.CuentaEmpleado.Text;
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
                empleado.Cedula = Int32.Parse(_vista.CedulaEmpleadoBus.Text);
                empleado.Nombre = _vista.NombreEmpleadoBus.Text;
                ConsultarEmpleado(empleado);
            }
            catch (WebException e)
            {
            }
        }
        public void CambiarVista(int index)
        {
            _vista.MultiViewEmpleado.ActiveViewIndex = index;
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
            _vista.FechaEgresoEmpleado.Text = DateTime.Now.ToString();
            _vista.FechaIngresoEmpleado.Text = DateTime.Now.ToString();
            _vista.FechaNacEmpleado.Text = DateTime.Now.ToString();
        }

        public void LlenarRegistros(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            _vista.NombreEmpleado.Text = empleado.Nombre;
            _vista.SueldoEmpleado.Text =empleado.SueldoBase.ToString();
            _vista.AvenidaEmpleado.Text = empleado.Direccion.Avenida;
            _vista.CalleEmpleado.Text = empleado.Direccion.Calle;
            _vista.CiudadEmpleado.Text = empleado.Direccion.Ciudad;
            _vista.EdificioEmpleado.Text = empleado.Direccion.Edif_Casa;
            _vista.PisoEmpleado.Text = empleado.Direccion.Piso_apto;
            _vista.UrbanizacionEmpleado.Text = empleado.Direccion.Urbanizacion;
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
        public void ConsultarEmpleado(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            Core.LogicaNegocio.Comandos.ComandoEmpleado.ConsultarEmpleado consultar; //objeto del comando Ingresar.

            //fábrica que instancia el comando Ingresar.
            consultar = Core.LogicaNegocio.Fabricas.FabricaComandosEmpleado.CrearComandoConsultarEmpleado(empleado);

            //try
            //{    
            //ejecuta el comando.
            LlenarRegistros(consultar.Ejecutar());
            CambiarVista(1);
        }
        #endregion
    }
}
