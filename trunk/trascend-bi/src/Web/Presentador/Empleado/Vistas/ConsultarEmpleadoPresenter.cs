using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Presentador.Empleado.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Fabricas;

namespace Presentador.Empleado.Vistas
{
    public class ConsultarEmpleadoPresenter
    {
        private IConsultarEmpleado _vista;
        private IList<Core.LogicaNegocio.Entidades.Empleado> empleado;
        private IList<string> cargo;
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
            _vista.LabelEstado.Text = empleado.Estado;
            _vista.LabelDireccion.Text = empleado.Direccion.Avenida;
            _vista.LabelCargo.Text = empleado.Cargo;
        }
        /// <summary>
        /// Metodo que ejecuta la accion de Selección de tipo de Consulta
        /// </summary>
        public void BotonSeleccionTipo()
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
        }

        /// <summary>
        /// Metodo que ejcuta la Accion de realizar la consulta por parámetro indicado
        /// y presenta la propuesta seleccionada
        /// </summary>
        public void BotonAccionConsulta()
        {
            #region Atributos de la Pagina
            #region Activar Campos

            #endregion
            #region Desactivar Campos
            _vista.opcion.Visible = false;
            _vista.SeleccionCargo.Visible = false;
            #endregion

            #endregion

            #region Solicitud Servicio
            emp = new Core.LogicaNegocio.Entidades.Empleado();

            if (_vista.opcion.SelectedIndex == 0)//cedula
            {
                emp.Cedula = Int32.Parse(_vista.TextBoxParametro.Text);
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
            if (_vista.opcion.SelectedIndex == 1)//nombre
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
            if (_vista.opcion.SelectedIndex == 2)//cargo
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

        /// <summary>
        /// Metodo que busca las propuestas
        /// </summary>
        /// <returns>devuelve objeto de tipo lista de propuestas</returns>
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

        #endregion
    }
}
