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
    public class ConsultarGastoPresenter
    {
        private IConsultarGasto _vista;
        private Core.LogicaNegocio.Entidades.Propuesta propuesta;
        private Core.LogicaNegocio.Entidades.Gasto gasto;
        private IList<Core.LogicaNegocio.Entidades.Gasto> listaGasto;
        private IList<Core.LogicaNegocio.Entidades.Gasto> listaGastoAux;
        private IList<Core.LogicaNegocio.Entidades.Propuesta> listaPropuesta;
        private ConsultarPropuestaPresentador _presentadorPropuesta;        

        #region Constructor

        public ConsultarGastoPresenter(IConsultarGasto vista)
        {
            _vista = vista;
        }

        #endregion

        #region Metodos

        /*
        public int OpcionSeleccion()
        {
            _presentadorPropuesta = new ConsultarPropuestaPresentador();
            listaGasto = new List<Core.LogicaNegocio.Entidades.Gasto>();

            if (_vista.CheckOpcionBuscar.SelectedIndex == 0) // Busqueda por propuesta
            {
              
                string estado = "Aprobada";
               
                listaPropuesta = _presentadorPropuesta.BuscarPorTitulo(estado);

                for (int i = 0; i < listaPropuesta.Count; i++)
                {
                    _vista.SeleccionDato.Items.Add(listaPropuesta.ElementAt(i).Titulo);
                }

                _vista.SeleccionDato.DataBind();
                 

                opcion = 0;
            }

            if (_vista.CheckOpcionBuscar.SelectedIndex == 1) // Busqueda por Tipo
            {
                
                listaGasto = ConsultarPorTipo();

                for (int i = 0; i < listaGasto.Count; i++)
                {
                    _vista.SeleccionDato.Items.Add(listaGasto.ElementAt(i).Tipo);
                }

                _vista.SeleccionDato.DataBind();
                

                opcion = 1;
            }

            if (_vista.CheckOpcionBuscar.SelectedIndex == 2) // Busqueda por Estado
            {
                opcion = 2;
            }
            return opcion;
        }
        */

        public void BuscarInformacion()
        {
            listaGasto = new List<Core.LogicaNegocio.Entidades.Gasto>();
            listaGastoAux = new List<Core.LogicaNegocio.Entidades.Gasto>();

            if (_vista.CheckOpcionBuscar.SelectedIndex == 0) // La Seleccion fue por Propuesta
            {
                propuesta = new Core.LogicaNegocio.Entidades.Propuesta();
                propuesta.Titulo = _vista.BusquedaConsulta.Text;

                listaGasto = ConsultarPorPropuesta(propuesta);

                try
                {
                    if (listaGasto != null)
                    {
                        _vista.GetObjectContainerConsultaGasto.DataSource = listaGasto;
                    }
                }

                catch (WebException e)
                {
                    //Mensaje de error al usuario
                }

            }

            if (_vista.CheckOpcionBuscar.SelectedIndex == 1) // La Seleccion fue por Tipo de Gasto
            {
                gasto = new Core.LogicaNegocio.Entidades.Gasto();
                gasto.Tipo = _vista.BusquedaConsulta.Text;

                listaGasto = ConsultaGasto(gasto);

                try
                {
                    if (listaGasto != null)
                    {
                        for (int i = 0; i < listaGasto.Count; i++)
                        {
                            if (listaGasto.ElementAt(i).Tipo.Equals(_vista.BusquedaConsulta.Text))
                            {
                                listaGastoAux.Add(listaGasto.ElementAt(i));
                            }

                        }
                        _vista.GetObjectContainerConsultaGasto.DataSource = listaGastoAux;
                    }
                }

                catch (WebException e)
                {
                    //Mensaje de error al usuario
                }
            }
            if (_vista.CheckOpcionBuscar.SelectedIndex == 2) // La Seleccion por Estado
            {
                gasto = new Core.LogicaNegocio.Entidades.Gasto();
                gasto.Estado = _vista.BusquedaConsulta.Text;

                listaGasto = ConsultarPorEstado(gasto);
                //listaGasto.Add(gasto);

                try
                {
                    if (listaGasto != null)
                    {
                        _vista.GetObjectContainerConsultaGasto.DataSource = listaGasto;
                    }
                }

                catch (WebException e)
                {
                    //Mensaje de error al usuario
                }
            }
        }

        public IList<Core.LogicaNegocio.Entidades.Gasto> ConsultaGasto(Core.LogicaNegocio.Entidades.Gasto _gasto)
        {
            Core.LogicaNegocio.Comandos.ComandoGasto.ConsultarGasto _consultaGasto;

            _consultaGasto = Core.LogicaNegocio.Fabricas.FabricaComandoGasto.CrearComandoConsultar(_gasto);

            listaGasto = _consultaGasto.Ejecutar();

            return listaGasto;
        }


        public IList<Core.LogicaNegocio.Entidades.Gasto> ConsultarPorTipo(Core.LogicaNegocio.Entidades.Gasto _gasto)
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
        public IList<Core.LogicaNegocio.Entidades.Gasto> ConsultarPorEstado(Core.LogicaNegocio.Entidades.Gasto _gasto)
        {
            Core.LogicaNegocio.Comandos.ComandoGasto.ConsultarGastoPorEstado _ConsultaPorEstado;

            _ConsultaPorEstado = Core.LogicaNegocio.Fabricas.FabricaComandoGasto.CrearComandoConsultarPorEstado(_gasto);

            listaGasto = _ConsultaPorEstado.Ejecutar();

            return listaGasto;
        }

        #endregion
    }
}


