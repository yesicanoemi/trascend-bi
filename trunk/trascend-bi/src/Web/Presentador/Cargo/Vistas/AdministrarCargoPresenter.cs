using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Cargo.Contrato;
using Core.LogicaNegocio.Entidades;
using System.Data;

namespace Presentador.Cargo.Vistas
{
    public class AdministrarCargoPresenter
    {
        #region Propiedades
        private const string campoVacio = "";
        private IAdministrarCargo _vista;
        private Core.LogicaNegocio.Entidades.Cargo cargoRetorno;
        //private CargoController _controlador;
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="laVista">Vista de la interfaz</param>
        public AdministrarCargoPresenter(IAdministrarCargo laVista)
        {
            _vista = laVista;
            DesactivarCampos();
            if(_vista.NombreCargo.Items.Count < 1)
                LlenarDDLCargos();
            
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo para cargar los elementos del dropDownList de los nombres de los cargos
        /// </summary>
        private void LlenarDDLCargos()
        {
            Core.AccesoDatos.SqlServer.CargoSQLServer bd = new Core.AccesoDatos.SqlServer.CargoSQLServer();
            IList<Entidad> ListaEntidadesCargos = bd.ConsultarCargos();

            List<Core.LogicaNegocio.Entidades.Cargo> ListaCargos = new List<Core.LogicaNegocio.Entidades.Cargo>();

            for (int i = 0; i < ListaEntidadesCargos.Count; i++ )
            {
                ListaCargos.Add((Core.LogicaNegocio.Entidades.Cargo)ListaEntidadesCargos.ElementAt(i));
            }

                _vista.NombreCargo.DataSource = ListaCargos;
                _vista.NombreCargo.DataTextField = "Nombre";
                _vista.NombreCargo.DataValueField = "Id";
                _vista.NombreCargo.DataBind();               
        }

        /// <summary>
        /// Metodo para realizar la consulta del cargo
        /// </summary>
        public void ConsultarCargo()
        {
            LimpiarFormulario();

            Core.LogicaNegocio.Entidades.Cargo cargo = new Core.LogicaNegocio.Entidades.Cargo();
            cargo.Nombre = _vista.NombreCargo.SelectedItem.ToString();

            Core.LogicaNegocio.Comandos.ComandoCargo.Consultar ComandoConsultar;

            ComandoConsultar = Core.LogicaNegocio.Fabricas.FabricaComandoCargo.CrearComandoConsultar( cargo );

            Core.LogicaNegocio.Entidades.Cargo cargoRetorno = ComandoConsultar.Ejecutar();

            //_vista.NombreCargo.Text = cargoRetorno.Nombre;
            _vista.DescripcionCargo.Text = cargoRetorno.Descripcion;
            _vista.SueldoMinimo.Text = cargoRetorno.SueldoMinimo.ToString();
            _vista.SueldoMaximo.Text = cargoRetorno.SueldoMaximo.ToString();
            _vista.VigenciaSueldo.Text = cargoRetorno.Vigencia.ToShortDateString().ToString();

            ActivarCampos();
        }

        /// <summary>
        /// Metodo del boton para eliminar el cargo
        /// </summary>
        /// <returns>True para correcto y false si hubo error</returns>
        public bool EliminarCargo()
        {
            
            Core.LogicaNegocio.Comandos.ComandoCargo.Eliminar ComandoEliminar;

            ComandoEliminar = Core.LogicaNegocio.Fabricas.FabricaComandoCargo.CrearComandoEliminar( 
                                                        int.Parse(_vista.NombreCargo.SelectedValue) );

            if (ComandoEliminar.Ejecutar())
            {
                LimpiarFormulario();
                LlenarDDLCargos();
                return true;
            }
            else
                return false;  
        }

        /// <summary>
        /// Metodo para la modificacion del cargo buscado
        /// </summary>
        /// <returns>True si no hubo errores y false si hubo error</returns>
        public bool ModificarCargo()
        {

            Core.LogicaNegocio.Entidades.Cargo cargo = new Core.LogicaNegocio.Entidades.Cargo();

            cargo.Id = int.Parse(_vista.NombreCargo.SelectedValue);
            cargo.Nombre = _vista.NombreCargo.SelectedItem.Text;
            cargo.Descripcion = _vista.DescripcionCargo.Text;
            cargo.SueldoMinimo = float.Parse(_vista.SueldoMinimo.Text);
            cargo.SueldoMaximo = float.Parse(_vista.SueldoMaximo.Text);
            cargo.Vigencia = DateTime.Parse(_vista.VigenciaSueldo.Text);

            Core.LogicaNegocio.Comandos.ComandoCargo.Modificar ComandoModificar;

            ComandoModificar = Core.LogicaNegocio.Fabricas.FabricaComandoCargo.CrearComandoModificar( cargo );

            if(ComandoModificar.Ejecutar())
            {
                LimpiarFormulario();
                int i = _vista.NombreCargo.SelectedIndex;
                LlenarDDLCargos();
                _vista.NombreCargo.SelectedIndex = i;
                return true;
            }
            else
                return false;

        }

        /// <summary>
        /// Metodo para limpiar los elementos de la pagina
        /// </summary>
        private void LimpiarFormulario()
        {
            _vista.DescripcionCargo.Text = campoVacio;
            _vista.SueldoMinimo.Text = campoVacio;
            _vista.SueldoMaximo.Text = campoVacio;
            _vista.VigenciaSueldo.Text = campoVacio;
            _vista.LabelError.Text = campoVacio;
            _vista.LabelError.Visible = false;
        }

        /// <summary>
        /// Metodo que abilita los campos en la interfaz
        /// </summary>
        private void ActivarCampos()
        {
            _vista.DescripcionCargo.Enabled = true;
            _vista.SueldoMinimo.Enabled = true;
            _vista.SueldoMaximo.Enabled = true;
            _vista.VigenciaSueldo.Enabled = true;
        }

        /// <summary>
        /// Metodo que desactiva los campos en la interfaz
        /// </summary>
        private void DesactivarCampos()
        {
            _vista.DescripcionCargo.Enabled = false;
            _vista.SueldoMinimo.Enabled = false;
            _vista.SueldoMaximo.Enabled = false;
            _vista.VigenciaSueldo.Enabled = false;
        }
        #endregion
    }
}
