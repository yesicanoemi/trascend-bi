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

                _propuesta = listaPropuesta.ElementAt(0);

                _vista.TituloPropuesta.Text = listaPropuesta.ElementAt(0).Titulo.ToString();
                _vista.MontoTotal.Text = listaPropuesta.ElementAt(0).MontoTotal.ToString();
            }
            catch (Exception e){ }


            try
            {
                Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarxNomPro ComandoConsultarTabla;
                ComandoConsultarTabla = Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarxNomPro(_propuesta);
                IList<Core.LogicaNegocio.Entidades.Factura> listaFacturas = ComandoConsultarTabla.Ejecutar();

                _vista.TablaFacturas.DataSource = listaFacturas;
                _vista.TablaFacturas.DataBind();
            }
            catch (Exception e) { }
        }

        public void CargarDatos()
        {

            _factura = new Core.LogicaNegocio.Entidades.Factura();
            _factura.Numero = int.Parse(_vista.ParametroTexto.Text);
            Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarxFacturaID ComandoConsultarFactura;
            ComandoConsultarFactura = Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarxFacturaID(_factura);

            _factura = ComandoConsultarFactura.Ejecutar();

            _vista.Titulo.Text = _factura.Titulo;
            _vista.Descripcion.Text = _factura.Descripcion;
            _vista.FechaIngreso.Text = _factura.Fechaingreso.ToShortDateString().ToString();
            _vista.FechaPago.Text = _factura.Fechapago.ToShortDateString().ToString();
            _vista.Estado.Text = _factura.Estado;
            _vista.Porcentaje.Text = _factura.Procentajepagado.ToString();
        }

        public string FormatearFechaParaMostrar(DateTime fecha)
        {
            return fecha.ToShortDateString();
        }



        /// <summary>
        /// Metodo que recibo un string y devuelve un objeto datetim con el formato DD/MM/AAAA
        /// </summary>
        /// <param name="fecha">string de fecha en formato MM/DD/AAAA</param>
        /// <returns>Datetime</returns>
        public DateTime ConvertirToFecha(string fecha)
        {
            string[] str = fecha.Split('/');
            return new DateTime(Convert.ToInt32(str[2]), Convert.ToInt32(str[1]), Convert.ToInt32(str[0]));

        }



        public void InhabilitarCampos()
        {

        }

   
    }


}
