using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Fabricas;
using Core.LogicaNegocio.Comandos;
using System.Net;
using Presentador.Gasto.Contrato;
using Presentador.Propuesta.Vistas;


namespace Presentador.Gasto.Vistas
{
    public class IngresarGastoPresenter
    {
        private IIngresarGasto _vista;
        private ConsultarPropuestaPresentador _presentadorPropuesta;
        private IList<Core.LogicaNegocio.Entidades.Propuesta> propuestas;
        private int id_version = 0;


        #region Constructor
        public IngresarGastoPresenter(IIngresarGasto vista)
        {
            _vista = vista;
        }
        #endregion

        #region Limpieza de Pagina

        public void limpiar()
        {

            _vista.TipoGasto.SelectedIndex = 0;
            _vista.DescripcionGasto.Text = "";
            _vista.FechaGasto.Text = "";
            _vista.MontoGasto.Text = "";
            _vista.EstadoGasto.SelectedIndex = 0;
            _vista.AsociarPropuestaGasto.Checked = false;
            _vista.PropuestaAsociada.Enabled = false;

        }

        #endregion


        #region Evento

        public void ingresarGasto()
        {
            Core.LogicaNegocio.Entidades.Gasto gasto = new Core.LogicaNegocio.Entidades.Gasto();

            gasto.Descripcion = _vista.DescripcionGasto.Text;

            gasto.Estado = _vista.EstadoGasto.SelectedItem.Text;

            gasto.FechaGasto = Convert.ToDateTime(_vista.FechaGasto.Text);

            gasto.FechaIngreso = DateTime.Now;

            gasto.Monto = float.Parse(_vista.MontoGasto.Text);

            gasto.Tipo = _vista.TipoGasto.SelectedItem.Text;

            if (_vista.AsociarPropuestaGasto.Checked)
            {
                int i = 0;

                if (propuestas.Count == 0)
                    gasto.IdVersion = 0;

                for (i = 0; i < propuestas.Count; i++)

                    if (propuestas.ElementAt(i).Titulo.Equals(_vista.PropuestaAsociada.SelectedItem.Text))

                        gasto.IdVersion = Int32.Parse(propuestas.ElementAt(i).Version);
            }
            Ingresar(gasto);

        }

        #endregion

        #region Comando
        public void Ingresar(Core.LogicaNegocio.Entidades.Gasto gasto)
        {
            Core.LogicaNegocio.Comandos.ComandoGasto.IngresarGasto ingresar; //objeto del comando Ingresar.

            //fábrica que instancia el comando Ingresar.
            ingresar = Core.LogicaNegocio.Fabricas.FabricaComandoGasto.CrearComandoIngresar(gasto);

            gasto = ingresar.Ejecutar();

            if (gasto.Codigo == -1)
            {
                _vista.MensajeError.Text = "No se localiza el procedimiento de InsertarGasto en la base de datos.";
                _vista.MensajeError.Visible = true;
            }
            else if (gasto.Codigo == -2)
            {
                _vista.MensajeError.Text = "Error en el intento de insercion del gasto, SqlException.";
                _vista.MensajeError.Visible = true;
            }
            else
            {
                limpiar();
                _vista.MensajeError.Text = "El gasto se ha insertado correctamente!!!";
                _vista.MensajeError.Visible = true;
            }

        }
        #endregion

        #region Metodos

        public void BuscarPropuesta()
        {
            _presentadorPropuesta = new ConsultarPropuestaPresentador();

            int i = 0;
            int estado = 1;
           
            propuestas = _presentadorPropuesta.BuscarPorTitulo(estado);
            for (i = 0; i < propuestas.Count; i++)
            {
                _vista.PropuestaAsociada.Items.Add(propuestas.ElementAt(i).Titulo);
            }
        }
        #endregion

    }
}
