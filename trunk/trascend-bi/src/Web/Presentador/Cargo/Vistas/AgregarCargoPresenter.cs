using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Cargo.Contrato;
using Core.LogicaNegocio;
using Core.LogicaNegocio.Excepciones;
using System.Net;


namespace Presentador.Cargo.Vistas
{
    public class AgregarCargoPresenter
    {
        #region Atributos
        private const string campoVacio = "";
        private IAgregarCargo _vista;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="laVista">La vista de la interfaz</param>
        public AgregarCargoPresenter(IAgregarCargo laVista)
        {
            _vista = laVista;
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Metodo para ingresar cargo nuevo
        /// </summary>
        /// <returns>true si fue correcto y false si hubo error</returns>
        public void IngresarCargo()
        {

            if (ValidarCampos())
            {

                try
                {
                    Core.LogicaNegocio.Entidades.Cargo cargo = new Core.LogicaNegocio.Entidades.Cargo();

                    cargo.Nombre = _vista.NombreCargo.Text;
                    cargo.Descripcion = _vista.DescripcionCargo.Text;
                    cargo.SueldoMinimo = float.Parse(_vista.SueldoMinimo.Text);
                    cargo.SueldoMaximo = float.Parse(_vista.SueldoMaximo.Text);
                    cargo.Vigencia = DateTime.Parse(_vista.VigenciaSueldo.Text);

                    Core.LogicaNegocio.Comandos.ComandoCargo.Ingresar ComandoIngresar;

                    ComandoIngresar = Core.LogicaNegocio.Fabricas.FabricaComandoCargo.CrearComandoIngresar(cargo);
                    ComandoIngresar.Ejecutar();
                    LimpiarFormulario();

                    _vista.Mensaje("Se agrego el cargo con exito =)");
                }
                catch(FormatException e)
                {
                    _vista.Mensaje("Error en el formato de campos");
                }
                catch(IngresarException e)
                {
                    _vista.Mensaje(e.Message);
                }
                catch(Exception e)
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
        /// Metodo para limpiar los elementos de la interfaz
        /// </summary>
        private void LimpiarFormulario()
        {
            _vista.NombreCargo.Text = campoVacio;
            _vista.DescripcionCargo.Text = campoVacio;
            _vista.SueldoMinimo.Text = campoVacio;
            _vista.SueldoMaximo.Text = campoVacio;
            _vista.VigenciaSueldo.Text = campoVacio;
            _vista.LabelError.Text = campoVacio;
            _vista.LabelError.Visible = false;
        }

        /// <summary>
        /// Metodo para validar que ningun campo sea vacio
        /// </summary>
        /// <returns>(true) si los campos estan correctos
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
