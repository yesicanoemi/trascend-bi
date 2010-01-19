using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Fabricas;
using Core.LogicaNegocio.Comandos;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Gasto.Contrato;
using Presentador.Propuesta.Vistas;
using System.Net;
using System.Collections;


namespace Presentador.Gasto.Vistas
{
    public class EliminarGastoPresenter
    {
        private IEliminarGasto _vista;
        private Core.LogicaNegocio.Entidades.Propuesta propuesta;
        private Core.LogicaNegocio.Entidades.Gasto gasto;
        private IList<Core.LogicaNegocio.Entidades.Gasto> listaGasto;
        private Core.LogicaNegocio.Entidades.Gasto gastoAux;
        private IList<Core.LogicaNegocio.Entidades.Gasto> listaGastoAux;
        private IList<Core.LogicaNegocio.Entidades.Propuesta> listaPropuesta;
        private ConsultarPropuestaPresentador _presentadorPropuesta;
        private int opcion;

        #region Constructor

        public EliminarGastoPresenter(IEliminarGasto vista)
        {
            _vista = vista;
        }

        #endregion

        #region Limpieza de Pagina

        public void limpiar()
        {

        }

        #endregion

        #region Metodos

        public int OpcionSeleccion()
        {

            _presentadorPropuesta = new ConsultarPropuestaPresentador();
            listaGasto = new List<Core.LogicaNegocio.Entidades.Gasto>();

            if (_vista.TipoConsulta.SelectedIndex == 0) // Busqueda por propuesta
            {
                _vista.TipoConsulta.Enabled = false;
                _vista.LTipoConsulta.Enabled = false;
                _vista.SeleccionDato.Enabled = true;
                _vista.LSeleccion.Enabled = true;
                string estado = "Aprobada";
                listaPropuesta = _presentadorPropuesta.BuscarPorTitulo(estado);

                for (int i = 0; i < listaPropuesta.Count; i++)
                {
                    _vista.SeleccionDato.Items.Add(listaPropuesta.ElementAt(i).Titulo);
                }

                _vista.SeleccionDato.DataBind();

                opcion = 0;
            }

            if (_vista.TipoConsulta.SelectedIndex == 1) // Busqueda por Tipo
            {
                _vista.TipoConsulta.Enabled = false;
                _vista.LTipoConsulta.Enabled = false;
                _vista.SeleccionDato.Enabled = true;
                _vista.LSeleccion.Enabled = true;

                listaGasto = ConsultarPorTipo();

                for (int i = 0; i < listaGasto.Count; i++)
                {
                    _vista.SeleccionDato.Items.Add(listaGasto.ElementAt(i).Tipo);
                }

                _vista.SeleccionDato.DataBind();

                opcion = 1;
            }

            if (_vista.TipoConsulta.SelectedIndex == 2) // Busqueda por Fecha del Gasto
            {
                _vista.TipoConsulta.Enabled = false;
                _vista.LTipoConsulta.Enabled = false;
                _vista.LFechaGasto.Enabled = true;
                _vista.FechaGasto.Enabled = true;

                opcion = 2;
            }
            return opcion;
        }

        public void BuscarInformacion()
        {
            listaGasto = new List<Core.LogicaNegocio.Entidades.Gasto>();
            listaGastoAux = new List<Core.LogicaNegocio.Entidades.Gasto>();

            if (_vista.TipoConsulta.SelectedIndex == 0) // La Seleccion fue por Propuesta
            {
                _vista.SeleccionDato.Enabled = false;
                _vista.LSeleccion.Enabled = false;

                propuesta = new Core.LogicaNegocio.Entidades.Propuesta();
                propuesta.Titulo = _vista.SeleccionDato.SelectedItem.Text;

                listaGasto = ConsultarPorPropuesta(propuesta);

                try
                {
                    if (listaGasto != null)
                    {
                        _vista.GetObjectContainerEliminarGasto.DataSource = listaGasto;
                    }
                }

                catch (WebException e)
                {
                    //Mensaje de error al usuario
                }

            }

            if (_vista.TipoConsulta.SelectedIndex == 1) // La Seleccion fue por Tipo de Gasto
            {
                _vista.SeleccionDato.Enabled = false;
                _vista.LSeleccion.Enabled = false;

                listaGasto = ConsultarPorTipo();

                try
                {
                    if (listaGasto != null)
                    {
                        for (int i = 0; i < listaGasto.Count; i++)
                        {
                            if (listaGasto.ElementAt(i).Tipo.Equals(_vista.SeleccionDato.SelectedItem.Text))
                            {
                                listaGastoAux.Add(listaGasto.ElementAt(i));
                            }

                        }
                        _vista.GetObjectContainerEliminarGasto.DataSource = listaGastoAux;
                    }
                }

                catch (WebException e)
                {
                    //Mensaje de error al usuario
                }
            }
            if (_vista.TipoConsulta.SelectedIndex == 2) // La Seleccion fue por Fecha
            {
                _vista.LFechaGasto.Enabled = false;
                _vista.FechaGasto.Enabled = false;

                gasto = new Core.LogicaNegocio.Entidades.Gasto();
                gasto.FechaGasto = DateTime.Parse(_vista.FechaGasto.Text);

                listaGasto = ConsultarPorFecha(gasto);
                //listaGasto.Add(gasto);

                try
                {
                    if (listaGasto != null)
                    {
                        _vista.GetObjectContainerEliminarGasto.DataSource = listaGasto;
                    }
                }

                catch (WebException e)
                {
                    //Mensaje de error al usuario
                }
            }
        }

        public void eliminarGasto(int codigo)
        {
            Core.LogicaNegocio.Entidades.Gasto gasto = new Core.LogicaNegocio.Entidades.Gasto();

            gasto.Codigo = codigo;

            Eliminar(gasto);
        }

        #endregion

        #region Comando

        public void Eliminar(Core.LogicaNegocio.Entidades.Gasto gasto)
        {
            Core.LogicaNegocio.Comandos.ComandoGasto.EliminarGasto eliminar; //objeto del comando Ingresar.

            //fábrica que instancia el comando Eliminar.
            eliminar = Core.LogicaNegocio.Fabricas.FabricaComandoGasto.CrearComandoEliminar(gasto);

            eliminar.Ejecutar();
        }

        public IList<Core.LogicaNegocio.Entidades.Gasto> ConsultarPorTipo()
        {
            Core.LogicaNegocio.Comandos.ComandoGasto.ConsultarGastoPorTipo _consultaPorTipo;

            _consultaPorTipo = Core.LogicaNegocio.Fabricas.FabricaComandoGasto.CrearComandoConsultarPorTipo(listaGasto);

            listaGasto = _consultaPorTipo.Ejecutar();

            return listaGasto;
        }

        public IList<Core.LogicaNegocio.Entidades.Gasto> ConsultarPorPropuesta(Core.LogicaNegocio.Entidades.Propuesta _propuesta)
        {
            Core.LogicaNegocio.Comandos.ComandoGasto.ConsultarGastoPorPropuesta _ConsultaPorPropuesta;

            _ConsultaPorPropuesta = Core.LogicaNegocio.Fabricas.FabricaComandoGasto.CrearComandoConsultarPorPropuesta(_propuesta);

            listaGasto = _ConsultaPorPropuesta.Ejecutar();

            return listaGasto;
        }

        public IList<Core.LogicaNegocio.Entidades.Gasto> ConsultarPorFecha(Core.LogicaNegocio.Entidades.Gasto _gasto)
        {
            Core.LogicaNegocio.Comandos.ComandoGasto.ConsultarGastoPorFecha _ConsultaPorFecha;

            _ConsultaPorFecha = Core.LogicaNegocio.Fabricas.FabricaComandoGasto.CrearComandoConsultarPorFecha(_gasto);

            listaGasto = _ConsultaPorFecha.Ejecutar();

            return listaGasto;
        }

        #endregion

    }
}
