using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Factura.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Fabricas;
using Core.LogicaNegocio.Comandos;
using System.Net;
using Core.LogicaNegocio.Excepciones.Facturas.AccesoDatos;
using Core.LogicaNegocio.Excepciones.Facturas.LogicaNegocio;
using Core.LogicaNegocio.Excepciones;


namespace Presentador.Factura.Vistas
{
    public class ConsultarFacturaPresenter
    {
        IConsultarFactura _vista;
        //FacturaController _controller = new FacturaController();
        Core.LogicaNegocio.Entidades.Propuesta _propuesta;
        Core.LogicaNegocio.Entidades.Factura _factura;

        public ConsultarFacturaPresenter(IConsultarFactura vista)
        {
            _vista = vista;
        }

        public void CargarTabla()
        {
            try
            {
                _propuesta = new Core.LogicaNegocio.Entidades.Propuesta();
                _propuesta.Titulo = _vista.ParametroTexto.Text;


                IList<Core.LogicaNegocio.Entidades.Propuesta> listaPropuesta;
                Core.LogicaNegocio.Comandos.ComandoPropuesta.Consultar consultaPropuesta;
                consultaPropuesta = Core.LogicaNegocio.Fabricas.FabricaComandosPropuesta.CrearComandoConsultar(1, _propuesta.Titulo);
                listaPropuesta = consultaPropuesta.Ejecutar();

                if (listaPropuesta.Count == 0)
                    throw new ConsultarException("No existe la propuesta");


                _propuesta = listaPropuesta.ElementAt(0);

                _vista.TituloPropuesta.Text = listaPropuesta.ElementAt(0).Titulo.ToString();
                _vista.MontoTotal.Text = listaPropuesta.ElementAt(0).MontoTotal.ToString();



                Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarxNomPro ComandoConsultarTabla;
                ComandoConsultarTabla = Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarxNomPro(_propuesta);
                IList<Core.LogicaNegocio.Entidades.Factura> listaFacturas = ComandoConsultarTabla.Ejecutar();


                _vista.TablaFacturas.DataSource = listaFacturas;
                _vista.TablaFacturas.DataBind();

                _vista.MultiViewFacturas.Visible = true;
                _vista.MultiViewFacturas.ActiveViewIndex = 0;

            }
            catch (WebException e)
            {
                _vista.Pintar("Error WEB consultando");
                _vista.MensajeVisible = true;
            }
            catch (ConsultarException e)
            {
                _vista.Pintar(e.Message);
                _vista.MensajeVisible = true;
            }
            catch (Exception e)
            {
                _vista.Pintar(e.Message);
                _vista.MensajeVisible = true;
            }
        }

        public void CargarDatos()
        {
            try
            {
                _factura = new Core.LogicaNegocio.Entidades.Factura();
                _factura.Numero = int.Parse(_vista.ParametroTexto2.Text);
                Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarxFacturaID ComandoConsultarFactura;
                ComandoConsultarFactura = Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarxFacturaID(_factura);

                _factura = ComandoConsultarFactura.Ejecutar();


                _vista.Titulo.Text = _factura.Titulo;
                _vista.Descripcion.Text = _factura.Descripcion;
                _vista.FechaIngreso.Text = _factura.Fechaingreso.ToShortDateString().ToString();
                _vista.FechaPago.Text = _factura.Fechapago.ToShortDateString().ToString();
                _vista.Estado.Text = _factura.Estado;
                _vista.Porcentaje.Text = _factura.Procentajepagado.ToString();

                _vista.MultiViewFacturas.Visible = true;
                _vista.MultiViewFacturas.ActiveViewIndex = 1;
            }
            catch (WebException e)
            {
                _vista.Pintar("Error WEB consultando");
            }
            catch (ConsultarException e)
            {
                _vista.Pintar(e.Message);
                _vista.MensajeVisible = true;
            }
            catch (Exception e)
            {
                _vista.Pintar(e.Message);
                _vista.MensajeVisible = true;
            }
        }

        public string FormatearFechaParaMostrar(DateTime fecha)
        {
            return fecha.ToShortDateString();
        }
    }
}
