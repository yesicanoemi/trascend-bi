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

    public class EliminarGastoPresenter
    {

        private IEliminarGasto _vista;
        private Core.LogicaNegocio.Entidades.Propuesta propuesta;
        private Core.LogicaNegocio.Entidades.Gasto gasto;
        private IList<Core.LogicaNegocio.Entidades.Gasto> listaGasto;
        private Core.LogicaNegocio.Entidades.Gasto gastoAux;
        private IList<Core.LogicaNegocio.Entidades.Gasto> listaGastoAux;
        private IList<Core.LogicaNegocio.Entidades.Cliente> listaCliente;
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

        // listaGastoAux = new List<Core.LogicaNegocio.Entidades.Gasto>();

        public void BuscarInformacion() 
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

            // La Seleccion fue por Propuesta
            if (_vista.CheckOpcionBuscar.SelectedIndex == 0) 
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
                    _vista.MensajeError.Text = e.Message;
                    _vista.MensajeError.Visible = true;
                }
                catch (Exception e)
                {
                    _vista.MensajeError.Text = e.Message;
                    _vista.MensajeError.Visible = true;
                }
            }

            // La Seleccion fue por Tipo de Gasto
            if (_vista.CheckOpcionBuscar.SelectedIndex == 1) 
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
                    _vista.MensajeError.Text = e.Message;
                    _vista.MensajeError.Visible = true;
                }

                catch (Exception e)
                {
                    _vista.MensajeError.Text = e.Message;
                    _vista.MensajeError.Visible = true;
                }
            }

            // La Seleccion por fecha
            if (_vista.CheckOpcionBuscar.SelectedIndex == 2) 
            {
                try
                {
                    gasto = new Core.LogicaNegocio.Entidades.Gasto();
                    gasto.FechaGasto = Convert.ToDateTime(_vista.BusquedaConsulta.Text);

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
                    _vista.MensajeError.Text = e.Message;
                    _vista.MensajeError.Visible = true;
                }
                catch (Exception e)
                {
                    _vista.MensajeError.Text = e.Message;
                    _vista.MensajeError.Visible = true;
                }
            }
        }

        /// <summary>
        /// Metodo que al seleccionar el tipo de busqueda coloca el tipo de info que debe 
        /// ingresar en el campo
        /// </summary>
        public void verseleccion()
        {
            if (_vista.CheckOpcionBuscar.SelectedValue.Equals("0"))
            {
                _vista.LabelInfo.Text = "Ingrese Nombre Propuesta";
                _vista.BusquedaConsulta.Visible = true;
                _vista.BotonBuscarDatos.Visible = true;        
            }

            if (_vista.CheckOpcionBuscar.SelectedValue.Equals("1"))
            {
                _vista.LabelInfo.Text = "Ingrese Nombre de Cliente";
                _vista.BusquedaConsulta.Visible = true;
                _vista.BotonBuscarDatos.Visible = true;
               }

            if (_vista.CheckOpcionBuscar.SelectedValue.Equals("2"))
            {
                _vista.LabelInfo.Text = "Ingrese Fecha a través de la Imagen";
                _vista.BusquedaConsulta.Visible = true; 
                _vista.BotonBuscarDatos.Visible = true;
                _vista.Calendario.Visible = true;

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
                _vista.MensajeError.Text = e.Message;
                _vista.MensajeError.Visible = true;
            }
            catch (Exception e)
            {
                _vista.MensajeError.Text = e.Message;
                _vista.MensajeError.Visible = true;
            }
        }
        
        public void eliminarGasto(int codigo)
        {
            Core.LogicaNegocio.Entidades.Gasto gasto = new Core.LogicaNegocio.Entidades.Gasto();

            gasto.Codigo = codigo;

            Eliminar(gasto);
        }
        
        public void Eliminar(Core.LogicaNegocio.Entidades.Gasto gasto)
        {
            //objeto del comando Ingresar
            Core.LogicaNegocio.Comandos.ComandoGasto.EliminarGasto eliminar; 

            //fábrica que instancia el comando Eliminar
            eliminar = Core.LogicaNegocio.Fabricas.FabricaComandoGasto.CrearComandoEliminar(gasto);

            eliminar.Ejecutar();
           
            if (gasto.Codigo <= 0)
            {
                _vista.MensajeError.Text = "No se pudo eliminar de la base de datos.";
                _vista.MensajeError.Visible = true;
            }
            else
            {
                limpiar();
                _vista.MensajeError.Text = "El gasto se ha eliminado correctamente!!!";
                _vista.MensajeError.Visible = true;
            }
        }

        public IList<Core.LogicaNegocio.Entidades.Gasto> ConsultaGasto(int Opcion , string Parametro)
        {
            Core.LogicaNegocio.Comandos.ComandoGasto.ConsultarGasto _consultaGasto;

            _consultaGasto = Core.LogicaNegocio.Fabricas.FabricaComandoGasto.CrearComandoConsultar(Opcion,Parametro);

            listaGasto = _consultaGasto.Ejecutar();

            return listaGasto;
        }

        public IList<Core.LogicaNegocio.Entidades.Gasto> ConsultarPorTipo()
        {
            Core.LogicaNegocio.Comandos.ComandoGasto.ConsultarGastoPorTipo _consultaPorTipo;

            _consultaPorTipo = Core.LogicaNegocio.Fabricas.FabricaComandoGasto.CrearComandoConsultarPorTipo(listaGasto);

            listaGasto = _consultaPorTipo.Ejecutar();

            return listaGasto;
        }

        //public IList<Core.LogicaNegocio.Entidades.Gasto> ConsultarPorPropuesta(Core.LogicaNegocio.Entidades.Propuesta _propuesta)
        //{
        //    Core.LogicaNegocio.Comandos.ComandoGasto.ConsultarGastoPorPropuesta _ConsultaPorPropuesta;

        //    _ConsultaPorPropuesta = Core.LogicaNegocio.Fabricas.FabricaComandoGasto.CrearComandoConsultarPorPropuesta(_propuesta);

        //    listaGasto = _ConsultaPorPropuesta.Ejecutar();

        //    return listaGasto;
        //}

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