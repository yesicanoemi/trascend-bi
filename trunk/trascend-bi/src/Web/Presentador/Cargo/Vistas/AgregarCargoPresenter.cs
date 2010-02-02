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
                    
                    _vista.Mensaje("El cargo se ingreso satisfactoriamente");
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
                _vista.Mensaje("Debe rellenar todos los campos y la fecha de Vigencia no puede ser menor a la fecha actual");
            }
        }

        /// <summary>
        /// Metodo para carga el cargo introducido en el gridview
        /// </summary>
        public void CargarVistaCargo()
        {
            try
            {
                Core.LogicaNegocio.Entidades.Cargo cargo = new Core.LogicaNegocio.Entidades.Cargo();
                cargo.Nombre = _vista.NombreCargo.Text;

                Core.LogicaNegocio.Comandos.ComandoCargo.Consultar ComandoConsultar;

                ComandoConsultar =
                    Core.LogicaNegocio.Fabricas.FabricaComandoCargo.CrearComandoConsultar(cargo);

                Core.LogicaNegocio.Entidades.Cargo cargoRetorno = ComandoConsultar.Ejecutar();

                List<Core.LogicaNegocio.Entidades.Cargo> listaCargo = new List<Core.LogicaNegocio.Entidades.Cargo>();

                listaCargo.Add(cargoRetorno);

                _vista.VistaCargo.DataSource = listaCargo;
                _vista.VistaCargo.DataBind();

                LimpiarFormulario();
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
        /// Metodo para limpiar los elementos de la interfaz
        /// </summary>
        private void LimpiarFormulario()
        {
            _vista.NombreCargo.Text = campoVacio;
            _vista.DescripcionCargo.Text = campoVacio;
            _vista.SueldoMinimo.Text = campoVacio;
            _vista.SueldoMaximo.Text = campoVacio;
            _vista.VigenciaSueldo.Text = campoVacio;
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

            if (_vista.VigenciaSueldo.Text == "" && DateTime.Parse(_vista.VigenciaSueldo.Text) >= DateTime.Now)
                b = false;

            return b;
        }

        /// <summary>
        /// Metodo para transformar una fecha en ToShortDate 
        /// </summary>
        /// <param name="fecha">fecha que se quiere transformar</param>
        /// <returns>ToShortDate de una vez en string</returns>
        public string FormatearFechaParaMostrar(DateTime fecha)
        {
            return fecha.ToShortDateString();
        }
        /// <summary>
        /// Se valida que el monto minimo no sea negativo
        /// </summary>
        public void ValidarMontoMinimo()
        {
            float montoMinimo = float.Parse(_vista.SueldoMinimo.Text);
            if (montoMinimo < 0.00)
            {
                _vista.LabelError.Text = "El sueldo minimo no puede ser menor que 0";
                _vista.LabelError.Visible = true;
            }
        }
        public void FechaActual()
        {
            _vista.VigenciaSueldo.Text = DateTime.Now.ToShortDateString();
        }
        /// <summary>
        /// Se valida que el monto maximo no sea negativo y que sea menor que el monto minimo
        /// </summary>
        public void ValidarMontoMaximo()
        {
            try
            {
                float montoMinimo = float.Parse(_vista.SueldoMinimo.Text);
                float montoMaximo = float.Parse(_vista.SueldoMaximo.Text);
                if (montoMaximo > 0.00)
                {
                    if (montoMaximo < montoMinimo)
                    {
                        _vista.LabelError.Text = "El sueldo maximo no puede ser menor que 0 y menor que el sueldo minimo";
                        _vista.LabelError.Visible = true;
                    }
                    else
                    {
                        _vista.LabelError.Visible = false;
                        _vista.LabelError.Text = "";
                    }
                }
                else
                {
                    _vista.LabelError.Text = "El sueldo maximo no puede ser menor que 0.00";
                    _vista.LabelError.Visible = true;
                }
            }
            catch (Exception e)
            {
                _vista.Mensaje(e.ToString());
            }
        }
        #endregion
    }
}
