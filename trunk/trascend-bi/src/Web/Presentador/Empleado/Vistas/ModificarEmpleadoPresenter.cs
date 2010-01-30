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
using Core.LogicaNegocio.Fabricas;

namespace Presentador.Empleado.Vistas
{
    public class ModificarEmpleadoPresenter
    {
        #region Propiedades
        private IModificarEmpleado _vista;
        private string campoVacio = "";
        private IList<string> cargo;
        private IList<Core.LogicaNegocio.Entidades.Empleado> empleado;
        Core.LogicaNegocio.Entidades.Empleado emp;
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
                empleado.Id = Int32.Parse(_vista.Id);
                empleado.Nombre = _vista.NombreEmpleado.Text;
                empleado.Apellido = _vista.ApellidoEmpleado.Text;
                empleado.Cedula = Int32.Parse(_vista.CedulaEmpleado.Text);
                empleado.Cuenta = _vista.CuentaEmpleado.Text;
                empleado.Estado = "Activo";
                empleado.FechaIngreso = DateTime.Now;
                empleado.FechaNacimiento = DateTime.Now;
                empleado.SueldoBase = float.Parse(_vista.SueldoEmpleado.Text);
                empleado.Cargo = _vista.ComboCargos.SelectedValue.ToString();
                empleado.Direccion = new Core.LogicaNegocio.Entidades.Direccion();
                empleado.Direccion.Avenida = _vista.AvenidaEmpleado.Text;
                empleado.Direccion.Calle = _vista.CalleEmpleado.Text;
                empleado.Direccion.Ciudad = _vista.CiudadEmpleado.Text;
                empleado.Direccion.Edif_Casa = _vista.EdificioEmpleado.Text;
                empleado.Direccion.Piso_apto = _vista.PisoEmpleado.Text;
                empleado.Direccion.Urbanizacion = _vista.UrbanizacionEmpleado.Text;
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
            #region Solicitud Servicio
            emp = new Core.LogicaNegocio.Entidades.Empleado();

            if (Int32.Parse(_vista.ComboBusqueda.SelectedValue) == 1)//cedula
            {
                emp.Cedula = Int32.Parse(_vista.CedulaEmpleadoBus.Text);
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
            if (Int32.Parse(_vista.ComboBusqueda.SelectedValue) == 2)//nombre
            {
                emp.Nombre = _vista.NombreEmpleadoBus.Text;
                IList<Core.LogicaNegocio.Entidades.Empleado> listado = BuscarPorNombre(emp);
                try
                {
                    if (listado != null)
                    {
                        _vista.GetOCConsultarEmp.DataSource = listado;
                        CambiarVista(4);
                    }
                }
                catch (WebException e)
                {

                }
            }
            if (Int32.Parse(_vista.ComboBusqueda.SelectedValue) == 3)//cargo
            {
                emp.Cargo = _vista.SeleccionCargo.SelectedItem.Text;
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
        public void Consultar()
        {
            emp = new Core.LogicaNegocio.Entidades.Empleado();
            emp.Id = Int32.Parse(_vista.GridViewConsultarEmpleado.SelectedValue.ToString());
            ConsultarEmpleadoId(emp);
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
            _vista.FechaNacEmpleado.Text = DateTime.Now.ToString();
        }
        public void LlenarRegistros(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            _vista.Id = empleado.Id.ToString();
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
            _vista.FechaNacEmpleado.Text = empleado.FechaNacimiento.ToShortDateString();
        }
        public void LlenarComboCargos()
        {
            cargo = BuscarCargos();
            for (int i = 0; i < cargo.Count; i++)
            {
                _vista.SeleccionCargo.Items.Add(cargo.ElementAt(i));
            }
            _vista.SeleccionCargo.DataBind();
        }
        #endregion

        #region Comando
        public void Modificar(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            try
            {
                Core.LogicaNegocio.Comandos.ComandoEmpleado.Modificar modificar; //objeto del comando Ingresar.

                //fábrica que instancia el comando Ingresar.
                modificar = Core.LogicaNegocio.Fabricas.FabricaComandosEmpleado.CrearComandoModificar(empleado);

                //try
                //{    
                //ejecuta el comando.
                modificar.Ejecutar();
            }
            catch (Exception e)
            {
                _vista.Pintar("0004", "Error Modificando al Empleado", "Especificacion del Error", e.ToString());
                _vista.DialogoVisible = true;//Aqui se maneja la excepcion en caso de que de error la seccion Web
            }
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

        public IList<Core.LogicaNegocio.Entidades.Empleado> BuscarPorCargo(Core.LogicaNegocio.Entidades.Empleado entidad)
        {
            IList<Core.LogicaNegocio.Entidades.Empleado> empleado1 = null;

            Core.LogicaNegocio.Comandos.ComandoEmpleado.ConsultarPorCargo consultar;

            consultar = FabricaComandosEmpleado.CrearComandoConsultarPorCargo(entidad);

            empleado1 = consultar.Ejecutar();

            return empleado1;

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
        public void ConsultarEmpleadoId(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            try
            {
                Core.LogicaNegocio.Comandos.ComandoEmpleado.ConsultarEmpleado consultar;

                consultar = FabricaComandosEmpleado.CrearComandoConsultarEmpleado(empleado);

                empleado = consultar.Ejecutar();

                LlenarRegistros(empleado);

                CambiarVista(5);
            }
            catch (Exception e)
            {
                _vista.Pintar("0003", "Error Consultando Empleado", "Especificacion del Error", e.ToString());
                _vista.DialogoVisible = true;//Aqui se maneja la excepcion en caso de que de error la seccion Web
            }
        }
        #endregion
    }
}
