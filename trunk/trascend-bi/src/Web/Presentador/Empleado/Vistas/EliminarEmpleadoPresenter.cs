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
    public class EliminarEmpleadoPresenter
    {
        private IEliminarEmpleado _vista;
        private IList<Core.LogicaNegocio.Entidades.Empleado> empleado;
        private IList<string> cargo;
        Core.LogicaNegocio.Entidades.Empleado emp;

        #region Constructor
        public EliminarEmpleadoPresenter(IEliminarEmpleado vista)
        {
            _vista = vista;
        }
        #endregion

        #region Metodos

        
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
        public void BotonAccionEliminar()
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

        public void uxObjectConsultaUsuariosSelecting(string cedula)
        {
            Core.LogicaNegocio.Entidades.Empleado emp = new Core.LogicaNegocio.Entidades.Empleado();
            emp.Cedula = Int32.Parse(cedula);

            int result = EliminarEmpleado(emp);

            //lanzar un ventana de confirmacion si result es 1 o una de error si result es 0

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

        public int EliminarEmpleado(Core.LogicaNegocio.Entidades.Empleado entidad)
        {

            int resultado = 0;

            Core.LogicaNegocio.Comandos.ComandoEmpleado.EliminarEmpleado eliminar;
            
            eliminar = FabricaComandosEmpleado.CrearComandoEliminarEmpleado(entidad);
            
            resultado = eliminar.Ejecutar();
            
            return resultado;

        }
        #endregion
    }
}
