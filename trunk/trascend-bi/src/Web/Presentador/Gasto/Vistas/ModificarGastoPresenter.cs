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
using Presentador.Cliente.Vistas;

namespace Presentador.Gasto.Vistas
{
    public class ModificarGastoPresenter
    {
        private IModifcarGasto _vista;
        private Core.LogicaNegocio.Entidades.Propuesta propuesta;
        private Core.LogicaNegocio.Entidades.Gasto gasto;
        private IList<Core.LogicaNegocio.Entidades.Gasto> listaGasto;
        private IList<Core.LogicaNegocio.Entidades.Cliente> listaCliente;
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

       

        public void BuscarInformacion() // 
        {
            try
            {
                #region Atributos de la pagina


                _vista.BusquedaConsulta.Visible = false;
                _vista.CheckOpcionBuscar.Visible = false;
                _vista.BotonBuscarDatos.Visible = false;



                #endregion

                listaGasto = new List<Core.LogicaNegocio.Entidades.Gasto>();

                int Opcion = _vista.CheckOpcionBuscar.SelectedIndex;
                string Parametro = _vista.BusquedaConsulta.Text;


                if (_vista.CheckOpcionBuscar.SelectedIndex == 0) // La Seleccion fue por Propuesta
                {

                    ConsultarPropuestaPresentador _presentadorPropuesta2 = new ConsultarPropuestaPresentador();
                    listaPropuesta = _presentadorPropuesta2.LlenarListaParametro(1, Parametro);

                    try
                    {
                        if (listaPropuesta != null)
                        {
                            _vista.GetObjectContainerConsultaGastoSeleccion.DataSource = listaPropuesta;
                            _vista.LabelInfo.Visible = false;

                        }
                    }

                    catch (WebException e)
                    {
                        //Mensaje de error al usuario
                    }

                }

                if (_vista.CheckOpcionBuscar.SelectedIndex == 1) // La Seleccion fue por Nombre Cliente
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

                    try
                    {
                        if (listaCliente != null)
                        {
                            _vista.GetObjectContainerCliente.DataSource = listaCliente;
                            _vista.ModificarGasto.ActiveViewIndex = 1;
                        }
                    }

                    catch (WebException e)
                    {
                        //Mensaje de error al usuario
                    }
                }
            }
            catch
            {
                _vista.ModificarGasto.ActiveViewIndex = 3;
                _vista.MensajeError.Text = "Debe Seleccionar una Opcion";
                
            }
           
        }

        public void verseleccion()
        {
            if (_vista.CheckOpcionBuscar.SelectedValue.Equals("0"))
            {
                _vista.LabelInfo.Text = "Ingrese Nombre Propuesta";
            }
            if (_vista.CheckOpcionBuscar.SelectedValue.Equals("1"))
            {
                _vista.LabelInfo.Text = "Ingrese Nombre de Cliente";
            }
            if (_vista.CheckOpcionBuscar.SelectedValue.Equals("2"))
            {
                _vista.LabelInfo.Text = "Ingrese Fecha a través de la Imagen";
            }
        }

        public void uxObjectModificarGastoSelecting(string codigo)
        {
            _vista.CodigoGasto.Text = codigo;
            _vista.TipoGasto.Enabled = true;
            _vista.DescripcionGasto.Enabled = true;
            _vista.FechaGasto2.Enabled = true;
            _vista.MontoGasto.Enabled = true;
            _vista.EstadoGasto.Enabled = true;
          //  _vista.PropuestaAsociada.Enabled = true;
          //  _vista.AsociarPropuestaGasto.Enabled = true;
            
        }

        public void ModificarGasto()
        {
            try
            {
                gasto = new Core.LogicaNegocio.Entidades.Gasto();

                gasto.Codigo = Int32.Parse(_vista.CodigoGasto.Text);
                gasto.Descripcion = _vista.DescripcionGasto.Text;
                gasto.Estado = _vista.EstadoGasto.Text;
                gasto.FechaGasto = Convert.ToDateTime(_vista.FechaGasto2.Text);
                gasto.FechaIngreso = Convert.ToDateTime(_vista.FechaIngreso.Text);
                gasto.Monto = float.Parse(_vista.MontoGasto.Text);
                gasto.Tipo = _vista.TipoGasto.Text;
                gasto.IdVersion = Int32.Parse(_vista.LIdVersion.Text);



                ModificarGastoPorCodigo(gasto);
                _vista.ModificarGasto.ActiveViewIndex = 3;
                _vista.MensajeError.Text = "El gasto se ha modificado con Exito";
            }
            catch (Exception e)
            {
                _vista.ModificarGasto.ActiveViewIndex = 3;
                _vista.MensajeError.Text = "No Se pudo Modificar el Gasto";
            }
        }

        public void busquedaparametrizado(int Id, string tipoConsulta)
        {
            if (tipoConsulta.Equals("Propuesta")) // Es por Propuesta
            {
                listaGasto = ConsultaGasto(Id, "Propuesta");
                _vista.GetObjectContainerConsultaGasto.DataSource = listaGasto;
                _vista.GridViewParametro.Visible = false;
                _vista.ModificarGasto.ActiveViewIndex = 2;
            }
            else // Es por Cliente
            {
                listaGasto = ConsultaGasto(-1, tipoConsulta);
                _vista.GetObjectContainerConsultaGasto.DataSource = listaGasto;
                _vista.GridViewParametro.Visible = false;
                _vista.ModificarGasto.ActiveViewIndex = 2;
              
            }
        }

        public void busquedaparametrizado2(int Id, string tipoConsulta)
        {
            if (tipoConsulta.Equals("Propuesta")) // Es por Propuesta
            {
                listaGasto = GastoaModificar(Id);
                for (int i = 0; i < listaGasto.Count; i++)
                {
                    _vista.CodigoGasto.Text = listaGasto.ElementAt(i).Codigo.ToString();
                    _vista.TipoGasto.Text = listaGasto.ElementAt(i).Tipo;
                    _vista.DescripcionGasto.Text = listaGasto.ElementAt(i).Descripcion;
                    _vista.FechaGasto2.Text = listaGasto.ElementAt(i).FechaGasto.ToString();
                    _vista.FechaIngreso.Text = listaGasto.ElementAt(i).FechaIngreso.ToString();
                    _vista.MontoGasto.Text = listaGasto.ElementAt(i).Monto.ToString();
                    _vista.EstadoGasto.Text = listaGasto.ElementAt(i).Estado;
                    _vista.LIdVersion.Text = listaGasto.ElementAt(i).IdVersion.ToString();
                    _vista.GridViewParametro.Visible = false;
                    _vista.GridViewConsultaGasto.Visible = false;
                    _vista.ModificarGasto.ActiveViewIndex = 4;       
               
                }
                
            }
            else // Es por Cliente
            {
                listaGasto = ConsultaGasto(-1, tipoConsulta);
                _vista.GetObjectContainerConsultaGasto.DataSource = listaGasto;
                _vista.GridViewParametro.Visible = false;
            }
        }

        public IList<Core.LogicaNegocio.Entidades.Gasto> ConsultaGasto(int Opcion, string Parametro)
        {
            Core.LogicaNegocio.Comandos.ComandoGasto.ConsultarGasto _consultaGasto;

            _consultaGasto = Core.LogicaNegocio.Fabricas.FabricaComandoGasto.CrearComandoConsultar(Opcion, Parametro);

            listaGasto = _consultaGasto.Ejecutar();

            return listaGasto;
        }

        public IList<Core.LogicaNegocio.Entidades.Gasto> GastoaModificar(int IdGasto)
        {
            Core.LogicaNegocio.Comandos.ComandoGasto.ConsultaGastoM _GastoModificar;

            _GastoModificar = Core.LogicaNegocio.Fabricas.FabricaComandoGasto.CrearComandoConsultaraModificar(IdGasto);

            listaGasto = _GastoModificar.Ejecutar();

            return listaGasto;
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
