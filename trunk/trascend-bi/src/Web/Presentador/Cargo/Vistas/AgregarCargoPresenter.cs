using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Cargo.Contrato;
using Core.LogicaNegocio;
using System.Text.RegularExpressions;


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
        public bool IngresarCargo()
        {
            if (ValidarCampos())
            {
                Core.LogicaNegocio.Entidades.Cargo cargo = new Core.LogicaNegocio.Entidades.Cargo();

                cargo.Nombre = _vista.NombreCargo.Text;
                cargo.Descripcion = _vista.DescripcionCargo.Text;
                cargo.SueldoMinimo = float.Parse(_vista.SueldoMinimo.Text);
                cargo.SueldoMaximo = float.Parse(_vista.SueldoMaximo.Text);
                cargo.Vigencia = DateTime.Parse(_vista.VigenciaSueldo.Text);

                Core.LogicaNegocio.Comandos.ComandoCargo.Ingresar ComandoIngresar;

                ComandoIngresar = Core.LogicaNegocio.Fabricas.FabricaComandoCargo.CrearComandoIngresar(cargo);

                if (ComandoIngresar.Ejecutar())
                {
                    LimpiarFormulario();
                    return true;
                }
                else
                    return false;
            }
            else
            {
                _vista.LabelError.Text = "Debe rellenar todos los campos";
                return false;
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
