using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Propuesta.Contrato;
using Core.LogicaNegocio.Entidades;


namespace Presentador.Propuesta.Vistas
{
    public class AgregarPropuestaPresenter
    {
        private IAgregarPropuesta _vista;

        #region Constructor

        public AgregarPropuestaPresenter(IAgregarPropuesta vista)
        {
            _vista = vista;

        }
        #endregion

        #region Metodos

        public void AgregarPropuesta()
        {
            Core.LogicaNegocio.Entidades.Propuesta propuesta = new Core.LogicaNegocio.Entidades.Propuesta();


            propuesta.Titulo = _vista.Titulo.Text;

            propuesta.Version = _vista.Version.Text;

            propuesta.FechaFirma = Convert.ToDateTime(_vista.FechaFirma.Text);

            propuesta.FechaInicio = Convert.ToDateTime(_vista.FechaInicio.Text);

            propuesta.FechaFin = Convert.ToDateTime(_vista.FechaFin.Text);

            propuesta.MontoTotal = float.Parse(_vista.MontoTotal.Text);

            propuesta = Agregar(propuesta);

            LimpiarRegistros();
        }


        #endregion

        public Core.LogicaNegocio.Entidades.Propuesta Agregar(Core.LogicaNegocio.Entidades.Propuesta propuesta)
        {
            Core.LogicaNegocio.Comandos.ComandoPropuesta.Ingresar ingresar;

            ingresar = Core.LogicaNegocio.Fabricas.FabricaComandosPropuesta.CrearComandoIngresar(propuesta);

            return ingresar.Ejecutar();



        }

        public void LimpiarRegistros()
        {
            _vista.Titulo.Text = "";

            _vista.Version.Text = "";

            _vista.FechaFirma.Text = "";

            _vista.FechaInicio.Text = "";

            _vista.FechaFin.Text = "";

            _vista.MontoTotal.Text = "";
        }
    }
}
