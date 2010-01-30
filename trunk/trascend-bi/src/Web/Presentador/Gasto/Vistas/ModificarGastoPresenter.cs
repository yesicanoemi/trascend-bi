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
    public class ModificarGastoPresenter
    {
        private IModifcarGasto _vista;
        private Core.LogicaNegocio.Entidades.Propuesta propuesta;
        private Core.LogicaNegocio.Entidades.Gasto gasto;
        private IList<Core.LogicaNegocio.Entidades.Gasto> listaGasto;
        private Core.LogicaNegocio.Entidades.Gasto gastoAux;
        private IList<Core.LogicaNegocio.Entidades.Gasto> listaGastoAux;
        private IList<Core.LogicaNegocio.Entidades.Propuesta> listaPropuesta;
        private ConsultarPropuestaPresentador _presentadorPropuesta;
        private int opcion;

        #region Constructor

        public ModificarGastoPresenter(IModifcarGasto vista)
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
        */

        /*
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
         * */

        public void uxObjectModificarGastoSelecting(string codigo)
        {
            _vista.CodigoGasto.Text = codigo;
            _vista.TipoGasto.Enabled = true;
            _vista.DescripcionGasto.Enabled = true;
            _vista.FechaGasto2.Enabled = true;
            _vista.MontoGasto.Enabled = true;
            _vista.EstadoGasto.Enabled = true;
            _vista.PropuestaAsociada.Enabled = true;
            _vista.AsociarPropuestaGasto.Enabled = true;
            
        }       

        public void ModificarGasto()
        {
            gasto = new Core.LogicaNegocio.Entidades.Gasto();

            gasto.Codigo = Int32.Parse(_vista.CodigoGasto.Text);
            gasto.Descripcion = _vista.DescripcionGasto.Text;
            gasto.Estado = _vista.EstadoGasto.Text;
            //gasto.FechaGasto = Convert.ToDateTime(_vista.FechaGasto.Text);
            gasto.FechaIngreso = DateTime.Now;
            gasto.Monto = float.Parse(_vista.MontoGasto.Text);
            gasto.Tipo = _vista.TipoGasto.Text;

            if (_vista.AsociarPropuestaGasto.Checked)
            {
                int i = 0;

                if (listaPropuesta.Count == 0)
                    gasto.IdVersion = 0;

                for (i = 0; i < listaPropuesta.Count; i++)

                    if (listaPropuesta.ElementAt(i).Titulo.Equals(_vista.PropuestaAsociada.SelectedItem.Text))

                        gasto.IdVersion = Int32.Parse(listaPropuesta.ElementAt(i).Version);
            }

            ModificarGastoPorCodigo(gasto);
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

        public void ModificarGastoPorCodigo(Core.LogicaNegocio.Entidades.Gasto _gasto)
        {
            Core.LogicaNegocio.Comandos.ComandoGasto.ModificarGasto _ModificaGastoPorCodigo;

            _ModificaGastoPorCodigo = Core.LogicaNegocio.Fabricas.FabricaComandoGasto.CrearComandoModificar(_gasto);

            _ModificaGastoPorCodigo.Ejecutar();   
            
        }
        #endregion

    }
}
