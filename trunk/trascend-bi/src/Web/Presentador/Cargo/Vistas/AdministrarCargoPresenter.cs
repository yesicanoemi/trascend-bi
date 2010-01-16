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
        public AdministrarCargoPresenter(IAdministrarCargo laVista)
        {
            _vista = laVista;
            if(_vista.NombreCargo.Items.Count < 1)
                LlenarDDLCargos();

        }
        #endregion

        #region Metodos
        private void LlenarDDLCargos()
        {
            Core.AccesoDatos.SqlServer.CargoSQLServer bd = new Core.AccesoDatos.SqlServer.CargoSQLServer();
            DataSet cargos = bd.ConsultarCargosDS();

            _vista.NombreCargo.DataSource = cargos.Tables[0];
            _vista.NombreCargo.DataTextField = cargos.Tables[0].Columns["Nombre"].ColumnName.ToString();
            _vista.NombreCargo.DataValueField = cargos.Tables[0].Columns["IdCargo"].ColumnName.ToString();
            _vista.NombreCargo.DataBind();
        }

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
        }

        public bool EliminarCargo()
        {
            
            Core.LogicaNegocio.Comandos.ComandoCargo.Eliminar ComandoEliminar;

            ComandoEliminar = Core.LogicaNegocio.Fabricas.FabricaComandoCargo.CrearComandoEliminar( 
                                                        int.Parse(_vista.NombreCargo.SelectedValue) );

            if (ComandoEliminar.Ejecutar())
            {
                LimpiarFormulario();
                return true;
            }
            else
                return false;  
        }

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
                return true;
            }
            else
                return false;

        }

        private void LimpiarFormulario()
        {
            _vista.DescripcionCargo.Text = campoVacio;
            _vista.SueldoMinimo.Text = campoVacio;
            _vista.SueldoMaximo.Text = campoVacio;
            _vista.VigenciaSueldo.Text = campoVacio;
            _vista.LabelError.Text = campoVacio;
            _vista.LabelError.Visible = false;
        }
        #endregion
    }
}
