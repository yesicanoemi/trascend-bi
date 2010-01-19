using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Cargo.Contrato;
using Core.LogicaNegocio.Entidades;
using System.Data;
using Core.LogicaNegocio.Excepciones;

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
            if (_vista.NombreCargo.Items.Count < 1)
                LlenarDDLCargos();

        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo para cargar los elementos del dropDownList de los nombres de los cargos
        /// </summary>
        public void LlenarDDLCargos()
        {
            try
            {
                Core.AccesoDatos.SqlServer.CargoSQLServer bd = new Core.AccesoDatos.SqlServer.CargoSQLServer();
                IList<Entidad> ListaEntidadesCargos = bd.ConsultarCargos();

                List<Core.LogicaNegocio.Entidades.Cargo> ListaCargos = new List<Core.LogicaNegocio.Entidades.Cargo>();

                for (int i = 0; i < ListaEntidadesCargos.Count; i++)
                {
                    ListaCargos.Add((Core.LogicaNegocio.Entidades.Cargo)ListaEntidadesCargos.ElementAt(i));
                }

                _vista.NombreCargo.DataSource = ListaCargos;
                _vista.NombreCargo.DataTextField = "Nombre";
                _vista.NombreCargo.DataValueField = "Id";
                _vista.NombreCargo.DataBind();
            }
            catch (FormatException e)
            {
                _vista.Mensaje("Error en el formato de campos");
            }
            catch (ConsultarException e)
            {
                _vista.Mensaje(e.Message);
            }
            catch(Exception e)
            {
                _vista.Mensaje(e.Message);
            }

        }

        /// <summary>
        /// Metodo para realizar la consulta del cargo
        /// </summary>
        public void ConsultarCargo()
        {
            LimpiarFormulario();

            try
            {

                Core.LogicaNegocio.Entidades.Cargo cargo = new Core.LogicaNegocio.Entidades.Cargo();
                cargo.Nombre = _vista.NombreCargo.SelectedItem.ToString();

                Core.LogicaNegocio.Comandos.ComandoCargo.Consultar ComandoConsultar;

                ComandoConsultar = Core.LogicaNegocio.Fabricas.FabricaComandoCargo.CrearComandoConsultar(cargo);

                Core.LogicaNegocio.Entidades.Cargo cargoRetorno = ComandoConsultar.Ejecutar();

                //_vista.NombreCargo.Text = cargoRetorno.Nombre;
                _vista.DescripcionCargo.Text = cargoRetorno.Descripcion;
                _vista.SueldoMinimo.Text = cargoRetorno.SueldoMinimo.ToString();
                _vista.SueldoMaximo.Text = cargoRetorno.SueldoMaximo.ToString();
                _vista.VigenciaSueldo.Text = cargoRetorno.Vigencia.ToShortDateString().ToString();

                ActivarCampos();
            }
            catch (FormatException e)
            {
                _vista.Mensaje("Error en el formato de campos");
            }
            catch (ConsultarException e)
            {
                _vista.Mensaje(e.Message);
            }
            catch (Exception e)
            {
                _vista.Mensaje(e.Message);
            }

        }

        /// <summary>
        /// Metodo del boton para eliminar el cargo
        /// </summary>
        /// <returns>True para correcto y false si hubo error</returns>
        public void EliminarCargo()
        {
            try
            {

                Core.LogicaNegocio.Comandos.ComandoCargo.Eliminar ComandoEliminar;

                ComandoEliminar = Core.LogicaNegocio.Fabricas.FabricaComandoCargo.CrearComandoEliminar(
                                                            int.Parse(_vista.NombreCargo.SelectedValue));



                    LimpiarFormulario();
                    LlenarDDLCargos();
                    DesactivarCampos();

            }
            catch (FormatException e)
            {
                _vista.Mensaje("Error en el formato de campos");
            }
            catch (EliminarException e)
            {
                _vista.Mensaje(e.Message);
            }
            catch(Exception e)
            {
                _vista.Mensaje(e.Message);
            }

        }

        /// <summary>
        /// Metodo para la modificacion del cargo buscado
        /// </summary>
        /// <returns>True si no hubo errores y false si hubo error</returns>
        public void ModificarCargo()
        {
            if (ValidarCampos())
            {
                try
                {

                    Core.LogicaNegocio.Entidades.Cargo cargo = new Core.LogicaNegocio.Entidades.Cargo();

                    cargo.Id = int.Parse(_vista.NombreCargo.SelectedValue);
                    cargo.Nombre = _vista.NombreCargo.SelectedItem.Text;
                    cargo.Descripcion = _vista.DescripcionCargo.Text;
                    cargo.SueldoMinimo = float.Parse(_vista.SueldoMinimo.Text);
                    cargo.SueldoMaximo = float.Parse(_vista.SueldoMaximo.Text);
                    cargo.Vigencia = DateTime.Parse(_vista.VigenciaSueldo.Text);

                    Core.LogicaNegocio.Comandos.ComandoCargo.Modificar ComandoModificar;

                    ComandoModificar = Core.LogicaNegocio.Fabricas.FabricaComandoCargo.CrearComandoModificar(cargo);

                    
                        LimpiarFormulario();
                        int i = _vista.NombreCargo.SelectedIndex;
                        LlenarDDLCargos();
                        _vista.NombreCargo.SelectedIndex = i;
                        DesactivarCampos();

                }
                catch (FormatException e)
                {
                    _vista.Mensaje("Error en el formato de campos");
                }
                catch (ModificarException e)
                {
                    _vista.Mensaje(e.Message);
                }
                catch (Exception e)
                {
                    _vista.Mensaje(e.Message);
                }
            }
            else
            {
                _vista.Mensaje("Debe rellenar todos los campos");
            }

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

        /// <summary>
        /// Metodo que valida que ningun campo sea vacio
        /// </summary>
        /// <returns>(true) si los campos son validos;
        /// (false) si algun campo es vacio</returns>
        private bool ValidarCampos()
        {
            bool b = true;

            if (_vista.DescripcionCargo.Text == "")
                b = false;

            if (_vista.SueldoMinimo.Text == "")
                b = false;

            if (_vista.SueldoMaximo.Text == "")
                b = false;

            if (_vista.VigenciaSueldo.Text == "")
                b = false;

            return b;
        }
        #endregion
    }
}
