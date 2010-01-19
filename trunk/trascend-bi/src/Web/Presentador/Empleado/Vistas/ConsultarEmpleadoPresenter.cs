using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Empleado.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Fabricas;

namespace Presentador.Empleado.Vistas
{
    public class ConsultarEmpleadoPresenter
    {
        private IConsultarEmpleado _vista;
        private IList<Core.LogicaNegocio.Entidades.Empleado> empleado;

        #region Constructor
        public ConsultarEmpleadoPresenter(IConsultarEmpleado vista)
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
            #region AtributosDeLaPagina

            if (_vista.opcion.SelectedIndex == 1)
            {

                _vista.opcion.Visible = false;
                _vista.SeleccionOpcion.Visible = true;

            }
            #endregion

            #region SolicitudServicios

            if (_vista.opcion.SelectedIndex == 0) // Seleccion Cedula
            {
                

            }

            if (_vista.opcion.SelectedIndex == 1)// Seleccion Nombre
            {
                int i = 0;
                empleado = BuscarPorNombre();
                for (i = 0; i < empleado.Count; i++)
                {
                    _vista.SeleccionOpcion.Items.Add(empleado.ElementAt(i).Nombre);

                }
                _vista.SeleccionOpcion.DataBind();
            }

            if (_vista.opcion.SelectedIndex == 2)// Seleccion Cargo
            {

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
            _vista.SeleccionOpcion.Visible = false;
            #endregion

            #endregion

            #region Solicitud Servicio

            int i = 0;
            empleado = BuscarPorNombre();
            for (i = 0; i < empleado.Count; i++)
            {
                if (empleado.ElementAt(i).Nombre.Equals(_vista.SeleccionOpcion.SelectedItem.Text))
                {
                    // Se Llenan Los Campos
                    _vista.LabelCI.Text = empleado.ElementAt(i).Cedula.ToString();
                    _vista.LabelNombre.Text = empleado.ElementAt(i).Nombre;
                    _vista.LabeApellido.Text = empleado.ElementAt(i).Apellido;
                    _vista.LabeNumCuenta.Text = empleado.ElementAt(i).Cuenta.ToString();
                    _vista.LabeFechaNac.Text = empleado.ElementAt(i).FechaNacimiento.ToShortDateString();
                    //_vista.LabelDireccion.Text = empleado.ElementAt(i).Direccion;
                    _vista.LabelCargo.Text = empleado.ElementAt(i).Cargo;
                    _vista.LabelEstado.Text = empleado.ElementAt(i).Estado;
                    
                }
            }

            #endregion
        }

        /// <summary>
        /// Metodo que busca las propuestas
        /// </summary>
        /// <returns>devuelve objeto de tipo lista de propuestas</returns>
        public IList<Core.LogicaNegocio.Entidades.Empleado> BuscarPorNombre()
        {

            Core.LogicaNegocio.Comandos.ComandoEmpleado.Consultar consultar;

            consultar = FabricaComandosEmpleado.CrearComandoConsultar(empleado);

            empleado = consultar.Ejecutar();

            return empleado;

        }
        #endregion
    }
}
