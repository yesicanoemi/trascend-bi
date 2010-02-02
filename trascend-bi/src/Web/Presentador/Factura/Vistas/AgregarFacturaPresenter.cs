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
using Core.AccesoDatos.Interfaces;
using Core.LogicaNegocio.Excepciones;


namespace Presentador.Factura.Vistas
{
    public class AgregarFacturaPresenter
    {
        IAgregarFactura _vista;
        FacturaController _controller = new FacturaController();
        static Core.LogicaNegocio.Entidades.Propuesta _propuesta = new Core.LogicaNegocio.Entidades.Propuesta();
        Core.LogicaNegocio.Entidades.Factura _factura;
        
        

        public AgregarFacturaPresenter(IAgregarFactura vista)
        {
            _vista = vista;
        }

        public void CargarDatosPropuesta()
        {
            try
            {
                float MontoPagado;
                float MontoRestante;
                float PorcentajePagado = 0;
                float PorcentajeRestante;

                IList<Core.LogicaNegocio.Entidades.Propuesta> listaPropuesta;
                Core.LogicaNegocio.Comandos.ComandoPropuesta.Consultar consultaPropuesta;
                consultaPropuesta = Core.LogicaNegocio.Fabricas.FabricaComandosPropuesta.CrearComandoConsultar(1, _vista.NombrePropuesta.Text);
                listaPropuesta = consultaPropuesta.Ejecutar();

                _propuesta = listaPropuesta.ElementAt(0);

                _vista.LabelNombrePropuesta.Text = listaPropuesta.ElementAt(0).Titulo.ToString();
                _vista.MontoTotal.Text = listaPropuesta.ElementAt(0).MontoTotal.ToString();

                IList<Core.LogicaNegocio.Entidades.Factura> listaFacturasPropuesta;
                Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarxNomPro consultaFacturas;
                consultaFacturas = Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarxNomPro(listaPropuesta.ElementAt(0));
                listaFacturasPropuesta = consultaFacturas.Ejecutar();

                foreach (Core.LogicaNegocio.Entidades.Factura Factura in listaFacturasPropuesta)
                {
                    if (Factura.Estado.Equals("Por Cobrar") || Factura.Estado.Equals("Cobrada"))
                        PorcentajePagado += Factura.Procentajepagado;
                }
                MontoPagado = (PorcentajePagado / 100) * listaPropuesta.ElementAt(0).MontoTotal;
                PorcentajeRestante = 100 - PorcentajePagado;
                MontoRestante = listaPropuesta.ElementAt(0).MontoTotal - MontoPagado;

                _vista.PorcentajePagado.Text = PorcentajePagado.ToString();
                _vista.PorcentajeRestante.Text = PorcentajeRestante.ToString();
                _vista.MontoPagado.Text = MontoPagado.ToString();
                _vista.MontoRestante.Text = MontoRestante.ToString();
            }
            catch (WebException e)
            {
                _vista.Pintar("Error WEB al ingresar la factura");
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

        public void IngresarPropuesta()
        {
            try
            {
                Core.LogicaNegocio.Entidades.Factura Factura = new Core.LogicaNegocio.Entidades.Factura();

                Factura.Titulo = _vista.Titulo.Text;
                Factura.Descripcion = _vista.Descripcion.Text;
                Factura.Prop = _propuesta;
                Factura.Fechaingreso = DateTime.Now;
                Factura.Estado = _vista.Estado.SelectedItem.Text;
                Factura.Fechapago = DateTime.Now;
                Factura.Procentajepagado = float.Parse(_vista.Porcentaje.Text);

                Core.LogicaNegocio.Comandos.ComandoFactura.Ingresar Ingresar;
                Ingresar = Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoIngresar(Factura);
                Ingresar.Ejecutar();
            }
            catch (WebException e)
            {
                _vista.Pintar("Error WEB al ingresar la factura");
                _vista.MensajeVisible = true;
            }
            catch (IngresarException e)
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


        public void LlenarDDLEstados()
        {
            try
            {
                IDAOFactura facturabd = FabricaDAOSQLServer.ObtenerFabricaDAO().ObtenerDAOFactura();

                IList<String> estados = facturabd.ConsultarEstados();

                for (int i = estados.Count - 1; i >= 0; i--)
                {
                    _vista.Estado.Items.Add(estados[i].ToString());
                }
            }
            catch (ConsultarException e) { }
            catch (Exception e) { }
        }


        /// <summary>
        /// Metodo que recibo un string y devuelve un objeto datetim con el formato DD/MM/AAAA
        /// </summary>
        /// <param name="fecha">string de fecha en formato MM/DD/AAAA</param>
        /// <returns>Datetime</returns>

        public void CalcularMontoTotal()
        {
            if (_vista.Porcentaje.Text != "")
            {
                _vista.Monto.Text = ((_propuesta.MontoTotal * float.Parse(_vista.Porcentaje.Text)) / 100).ToString();
            }
        }

        public void InhabilitarCampos()
        {

        }

        
   

        
    }


}
