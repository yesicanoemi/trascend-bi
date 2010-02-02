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
using Presentador.Cliente.Vistas;
using System.Net;
using System.Collections;
using Core.LogicaNegocio.Excepciones.Gasto.Acceso_a_Datos;
using Core.LogicaNegocio.Excepciones.Gasto.Logica_de_Negocio;

namespace Presentador.Gasto.Vistas
{
    public class ConsultarGastoPresenter
    {
        #region Atributos
        private IConsultarGasto _vista;
        private Core.LogicaNegocio.Entidades.Propuesta propuesta;
        private Core.LogicaNegocio.Entidades.Gasto gasto;
        private IList<Core.LogicaNegocio.Entidades.Gasto> listaGasto;
        private IList<Core.LogicaNegocio.Entidades.Cliente> listaCliente;
        private IList<Core.LogicaNegocio.Entidades.Gasto> listaGastoAux;
        private IList<Core.LogicaNegocio.Entidades.Propuesta> listaPropuesta;
        private ConsultarPropuestaPresentador _presentadorPropuesta;
        #endregion

        #region Constructor

        public ConsultarGastoPresenter(IConsultarGasto vista)
        {
            _vista = vista;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que Ejecuta la busqueda de acuerdo a la seleccion del usuario
        /// y retorna una lista de propuesta cliente o gastos por rango de fecha
        /// </summary>
        public void BuscarInformacion() // 
        {
            #region Atributos de la pagina
            _vista.BotonBuscarDatos.Visible = false;
            _vista.BusquedaConsulta.Visible = false;
            _vista.CheckOpcionBuscar.Visible = false;
            _vista.LTipoConsulta.Visible = false;
            _vista.TablaInicio.Visible = false;
            _vista.TablaConsultaParametro.Visible = false;
           

            #endregion

            listaGasto = new List<Core.LogicaNegocio.Entidades.Gasto>();
            
            int Opcion = _vista.CheckOpcionBuscar.SelectedIndex;
            string Parametro = _vista.BusquedaConsulta.Text;
           

            if (_vista.CheckOpcionBuscar.SelectedIndex == 0) // La Seleccion fue por Propuesta
            {
                try
                {

                    ConsultarPropuestaPresentador _presentadorPropuesta2 =
                        new ConsultarPropuestaPresentador();
                    listaPropuesta = _presentadorPropuesta2.LlenarListaParametro(1, Parametro);

                    if (listaPropuesta != null)
                    {
                        _vista.GetObjectContainerConsultaGastoSeleccion.DataSource = listaPropuesta;

                        _vista.TablaConsultaParametro.Visible = true;

                    }
                }

                catch (ConsultarGastoLNException e)
                {
                    _vista.Error.Text = e.Message;
                    _vista.Error.Visible = true;
                }
                catch (Exception e)
                {
                    _vista.Error.Text = e.Message;
                    _vista.Error.Visible = true;
                }

            }

            if (_vista.CheckOpcionBuscar.SelectedIndex == 1) // La Seleccion fue por Nombre Cliente
            {
                try
                {

                    // Se crea la entidad Cliente que es necesaria para el comando consultar de cliente
                    Core.LogicaNegocio.Entidades.Cliente cliente =
                        new Core.LogicaNegocio.Entidades.Cliente();

                    cliente.Nombre = _vista.BusquedaConsulta.Text;


                    // Instancia del presentador
                    ConsultarClientePresentador _presentadorcliente =
                        new ConsultarClientePresentador();

                    // Llamado al metodo
                    listaCliente = _presentadorcliente.ConsultarClienteNombre(cliente);


                    if (listaCliente != null)
                    {
                        _vista.GetObjectContainerCliente.DataSource = listaCliente;
                        _vista.TablaCliente.Visible = true;
                    }
                }
                catch (ConsultarGastoLNException e)
                {
                    _vista.Error.Text = e.Message;
                    _vista.Error.Visible = true;
                }
                catch (Exception e)
                {
                    _vista.Error.Text = e.Message;
                    _vista.Error.Visible = true;
                }
               

               
            }
            if (_vista.CheckOpcionBuscar.SelectedIndex == 2) // La Seleccion por fecha
            {
                try
                {
                    gasto = new Core.LogicaNegocio.Entidades.Gasto();
                    gasto.FechaGasto = Convert.ToDateTime( _vista.BusquedaConsulta.Text);

                    listaGasto = ConsultarPorFecha(gasto);
 
                    if (listaGasto != null)
                    {
                        _vista.GetObjectContainerConsultaGasto.DataSource = listaGasto;
                        _vista.TablaInicio.Visible = false;
                        _vista.GridViewParametro.Visible = false;
                        _vista.TablaSeleccionGrid.Visible = true;
                    }
                }

                catch (ConsultarGastoLNException e)
                {
                    _vista.Error.Text = e.Message;
                    _vista.Error.Visible = true;
                }
                catch (Exception e)
                {
                    _vista.Error.Text = e.Message;
                    _vista.Error.Visible = true;
                }
            }
        }

        /// <summary>
        /// Metodo que una vez seleccionado el parametro de consulta realiza la busqueda
        /// de los gastos asociados
        /// </summary>
        /// <param name="Id"> recibe el codigo de propuesta en caso de que
        /// la seleccion previa fuese propuesta</param>
        /// <param name="tipoConsulta">recibe el string de nombre de cliente en caso de ser
        /// busqueda de cliente</param>
        public void busquedaparametrizado(int Id, string tipoConsulta)
        {
            try
            {
                if (tipoConsulta.Equals("Propuesta")) // Es por Propuesta
                {
                    listaGasto = ConsultaGasto(Id, "Propuesta");
                    _vista.GetObjectContainerConsultaGasto.DataSource = listaGasto;
                    _vista.TablaInicio.Visible = false;
                    _vista.GridViewParametro.Visible = false;
                    _vista.TablaSeleccionGrid.Visible = true;
                }
                else // Es por Cliente
                {
                    listaGasto = ConsultaGasto(-1, tipoConsulta);
                    _vista.GetObjectContainerConsultaGasto.DataSource = listaGasto;
                    _vista.TablaInicio.Visible = false;
                    _vista.GridViewParametro.Visible = false;
                    _vista.TablaSeleccionGrid.Visible = true;
                    _vista.TablaCliente.Visible = false;
                }
            }
            catch (ConsultarGastoLNException e)
            {
                _vista.Error.Text = e.Message;
                _vista.Error.Visible = true;
            }
            catch (Exception e)
            {
                _vista.Error.Text = e.Message;
                _vista.Error.Visible = true;
            }
        }


        public IList<Core.LogicaNegocio.Entidades.Gasto> ConsultaGasto(int Opcion, string Parametro)
        {
            try
            {
                Core.LogicaNegocio.Comandos.ComandoGasto.ConsultarGasto _consultaGasto;

                _consultaGasto = Core.LogicaNegocio.Fabricas.FabricaComandoGasto.CrearComandoConsultar(Opcion, Parametro);

                listaGasto = _consultaGasto.Ejecutar();

                return listaGasto;
            }
            catch (ConsultarGastoBDExceptions e)
            {
                _vista.Error.Text = e.Message;
                _vista.Error.Visible = true;
                return listaGasto;
            }
            catch (Exception e)
            {
                throw new ConsultarGastoLNException
                    ("Error Durante la Ejecución del proceso", e);
                return listaGasto;
            }
        }


        public IList<Core.LogicaNegocio.Entidades.Gasto> 
            ConsultarPorTipo(Core.LogicaNegocio.Entidades.Gasto _gasto)
        {
            try
            {
                Core.LogicaNegocio.Comandos.ComandoGasto.ConsultarGastoPorTipo _consultaPorTipo;

                _consultaPorTipo = Core.LogicaNegocio.Fabricas.FabricaComandoGasto.
                    CrearComandoConsultarPorTipo(listaGasto);

                listaGasto = _consultaPorTipo.Ejecutar();

                return listaGasto;
            }
            catch (ConsultarGastoBDExceptions e)
            {
                _vista.Error.Text = e.Message;
                _vista.Error.Visible = true;
                return listaGasto;
            }
            catch (Exception e)
            {
                throw new ConsultarGastoLNException
                    ("Error Durante la Ejecución del proceso", e);
                return listaGasto;
            }
        }


        public void verseleccion()
        {
            if (_vista.CheckOpcionBuscar.SelectedValue.Equals("0"))
            {
                _vista.LabelInfo.Text = "Ingrese Nombre Propuesta";
                _vista.Calendario.Visible = false;
                _vista.BusquedaConsulta.Visible = true;
                _vista.BotonBuscarDatos.Visible = true;
            }
            if (_vista.CheckOpcionBuscar.SelectedValue.Equals("1"))
            {
                _vista.LabelInfo.Text = "Ingrese Nombre de Cliente";
                _vista.Calendario.Visible = false;
                _vista.BusquedaConsulta.Visible = true;
                _vista.BotonBuscarDatos.Visible = true;
            }
            if (_vista.CheckOpcionBuscar.SelectedValue.Equals("2"))
            {
                _vista.LabelInfo.Text = "Ingrese Fecha a través de la Imagen";
                _vista.Calendario.Visible=true;
                _vista.BusquedaConsulta.Visible = true;
                _vista.BotonBuscarDatos.Visible = true;
            }
        }

        public IList<Core.LogicaNegocio.Entidades.Gasto> ConsultarPorFecha(Core.LogicaNegocio.Entidades.Gasto _gasto)
        {
            try
            {
                Core.LogicaNegocio.Comandos.ComandoGasto.ConsultarGastoPorFecha _ConsultaPorFecha;

                _ConsultaPorFecha = Core.LogicaNegocio.Fabricas.FabricaComandoGasto.CrearComandoConsultarPorFecha(_gasto);

                listaGasto = _ConsultaPorFecha.Ejecutar();

                return listaGasto;
            }
            catch (ConsultarGastoBDExceptions e)
            {
                _vista.Error.Text = e.Message;
                _vista.Error.Visible = true;
                return listaGasto;
            }
            catch (Exception e)
            {
                throw new ConsultarGastoLNException
                    ("Error Durante la Ejecución del proceso", e);
                return listaGasto;
            }
        }
        public IList<Core.LogicaNegocio.Entidades.Gasto> ConsultarPorEstado(Core.LogicaNegocio.Entidades.Gasto _gasto)
        {
            try
            {
                Core.LogicaNegocio.Comandos.ComandoGasto.ConsultarGastoPorEstado _ConsultaPorEstado;

                _ConsultaPorEstado = Core.LogicaNegocio.Fabricas.FabricaComandoGasto.CrearComandoConsultarPorEstado(_gasto);

                listaGasto = _ConsultaPorEstado.Ejecutar();

                return listaGasto;
            }
            catch (ConsultarGastoBDExceptions e)
            {
                _vista.Error.Text = e.Message;
                _vista.Error.Visible = true;
                return listaGasto;
            }
            catch (Exception e)
            {
                throw new ConsultarGastoLNException
                    ("Error Durante la Ejecución del proceso", e);
                return listaGasto;
            }
        }

        #endregion
    }
}


