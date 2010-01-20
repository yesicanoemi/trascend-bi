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
    public class AgregarFacturaPresenter
    {
        IAgregarFactura _vista;
        FacturaController _controller = new FacturaController();
        Core.LogicaNegocio.Entidades.Propuesta _propuesta;
        Core.LogicaNegocio.Entidades.Factura _factura;

        public AgregarFacturaPresenter(IAgregarFactura vista)
        {
            _vista = vista;
        }

        /*
        public void OnBotonAceptar()
        {

            InhabilitarCampos();
            CambiarVista(1);
            float MontosCancelados = 0;
            float MontoRestante = 0;
            float PorcCancelado = 0;
            int i = 0;

            Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarPropuestas consulta =
               Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarPropuestas();

            IList<Core.LogicaNegocio.Entidades.Propuesta> ListaPropuestas = consulta.Ejecutar();

            try
            {
                foreach (Core.LogicaNegocio.Entidades.Propuesta PropuestaAux in ListaPropuestas)
                {
                    if (PropuestaAux.Titulo.Equals(_vista.NombrePropuesta.Text))
                    {
                        _propuesta = PropuestaAux;
                        _vista.MontoTotal.Text = _propuesta.MontoTotal.ToString();


                        Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarxNomPro factura =
                   Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarxNomPro(_propuesta);

                        IList<Core.LogicaNegocio.Entidades.Factura> ListaFacturas = factura.Ejecutar();


                        foreach (Core.LogicaNegocio.Entidades.Factura FacturaAux in ListaFacturas)
                        {
                            MontosCancelados += CalcularPorcentaje(FacturaAux, _propuesta);
                        }
                        
                        _vista.TotalCancelado.Text = MontosCancelados.ToString();


                        foreach (Core.LogicaNegocio.Entidades.Factura FacturaAux in ListaFacturas)
                        {
                            i++;
                            _vista.MontoCancelado.Text += "Factura " + i.ToString() + ". " + "Fecha: " +
                                FacturaAux.Fechaingreso + " Titulo: " + FacturaAux.Titulo + " Monto: " + CalcularPorcentaje(FacturaAux, _propuesta) + " Estado: " + FacturaAux.Estado + "\n" + "\n";
                        }


                        PorcCancelado = (MontosCancelados * 100) / _propuesta.MontoTotal;
                        _vista.PorcentajeCancelado.Text = PorcCancelado.ToString();



                        MontoRestante = _propuesta.MontoTotal - MontosCancelados;
                        _vista.MontoFaltante.Text = MontoRestante.ToString();

                        _vista.PorcentajeFaltante.Text = (100 - PorcCancelado).ToString();


                        //_vista.CodigoFactura.Text = Convert.ToString(.Count + 1);
                        _vista.FechaIngreso.Text = DateTime.Now.ToString("dd/MM/yyyy");



                        Core.LogicaNegocio.Comandos.ComandoFactura.Consultar factura2 =
                   Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultar();

                        IList<Core.LogicaNegocio.Entidades.Factura> ListaFacturas2 = factura2.Ejecutar();
                        // _vista.CodigoFactura.Text = (ListaFacturas2.Count + 1).ToString();


                        i = 0;
                        foreach (Core.LogicaNegocio.Entidades.Factura fact in ListaFacturas2)
                        {

                            if (fact.Numero > i)
                                i = fact.Numero;


                        }

                        _vista.CodigoFactura.Text = (i + 1).ToString();


                    }
                }
            }
            catch (InsertarFacturaADException e)
            {
                _vista.Mensaje(e.Message);
            }
            catch (IngresarFacturaLNException e)
            {
                _vista.Mensaje(e.Message);
            }
            catch (Exception e)
            {
                _vista.Mensaje(e.Message);
            }
        }
        */

        /*
        public void OnAgregarFactura()
        {
            try
            {
                if (int.Parse(_vista.MontoPagar.Text) > int.Parse(_vista.MontoFaltante.Text))
                    throw new Exception("No se puede pagar una cantidad de dinero mayor al costo total");

                this.IngresarFactura();
            }
            catch (InsertarFacturaADException e)
            {
                _vista.Mensaje(e.Message);
            }
            catch (IngresarFacturaLNException e)
            {
                _vista.Mensaje(e.Message);
            }
            catch (Exception e)
            {
                _vista.Mensaje(e.Message);
            }
        }

        */


        private float CalcularPorcentaje(Core.LogicaNegocio.Entidades.Factura factura, Core.LogicaNegocio.Entidades.Propuesta propuesta)
        {
            float MontoTotal = propuesta.MontoTotal;
            float MontoPagado = 0;
            float Porcentaje = factura.Procentajepagado;

            MontoPagado = (Porcentaje * MontoTotal) / 100;

            return MontoPagado;
        }


        public void CargarGrid()
        {
            _vista.ResultadoPropuesta.DataSource = null;

            _vista.ResultadoPropuesta.DataBind();

            float MontosCancelados = 0;
            float MontoRestante = 0;
            float PorcCancelado = 0;
            int i = 0;

            Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarPropuestas consulta =
               Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarPropuestas();

            IList<Core.LogicaNegocio.Entidades.Propuesta> ListaPropuestas = consulta.Ejecutar();

            try
            {
                foreach (Core.LogicaNegocio.Entidades.Propuesta PropuestaAux in ListaPropuestas)
                {
                    if (PropuestaAux.Titulo.Equals(_vista.PropuestaBuscar.Text))
                    {
                        _vista.ResultadoPropuesta.DataSource = PropuestaAux;

                        _vista.ResultadoPropuesta.DataBind();
                        //     _propuesta = PropuestaAux;
                        //     _vista.MontoTotal.Text = _propuesta.MontoTotal.ToString();


                        //     Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarxNomPro factura =
                        //Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarxNomPro(_propuesta);

                        //     IList<Core.LogicaNegocio.Entidades.Factura> ListaFacturas = factura.Ejecutar();


                        //     foreach (Core.LogicaNegocio.Entidades.Factura FacturaAux in ListaFacturas)
                        //     {
                        //         MontosCancelados += CalcularPorcentaje(FacturaAux, _propuesta);
                        //     }

                        //     _vista.TotalCancelado.Text = MontosCancelados.ToString();


                        //     foreach (Core.LogicaNegocio.Entidades.Factura FacturaAux in ListaFacturas)
                        //     {
                        //         i++;
                        //         _vista.MontoCancelado.Text += "Factura " + i.ToString() + ". " + "Fecha: " +
                        //             FacturaAux.Fechaingreso + " Titulo: " + FacturaAux.Titulo + " Monto: " + CalcularPorcentaje(FacturaAux, _propuesta) + " Estado: " + FacturaAux.Estado + "\n" + "\n";
                        //     }


                        //     PorcCancelado = (MontosCancelados * 100) / _propuesta.MontoTotal;
                        //     _vista.PorcentajeCancelado.Text = PorcCancelado.ToString();



                        //     MontoRestante = _propuesta.MontoTotal - MontosCancelados;
                        //     _vista.MontoFaltante.Text = MontoRestante.ToString();

                        //     _vista.PorcentajeFaltante.Text = (100 - PorcCancelado).ToString();


                        //     //_vista.CodigoFactura.Text = Convert.ToString(.Count + 1);
                        //     _vista.FechaIngreso.Text = DateTime.Now.ToString("dd/MM/yyyy");



                        //     Core.LogicaNegocio.Comandos.ComandoFactura.Consultar factura2 =
                        //Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultar();

                        //     IList<Core.LogicaNegocio.Entidades.Factura> ListaFacturas2 = factura2.Ejecutar();
                        //     // _vista.CodigoFactura.Text = (ListaFacturas2.Count + 1).ToString();


                        //     i = 0;
                        //     foreach (Core.LogicaNegocio.Entidades.Factura fact in ListaFacturas2)
                        //     {

                        //         if (fact.Numero > i)
                        //             i = fact.Numero;


                        //     }

                        //     _vista.CodigoFactura.Text = (i + 1).ToString();


                    }
                }
            }
            catch (InsertarFacturaADException e)
            {
                _vista.Mensaje(e.Message);
            }
            catch (IngresarFacturaLNException e)
            {
                _vista.Mensaje(e.Message);
            }
            catch (Exception e)
            {
                _vista.Mensaje(e.Message);
            }
        }



        /*
        /// <summary>
        /// Cambia la vista del multiview
        /// </summary>
        public void CambiarVista(int index)
        {
            _vista.MultiViewPropuesta.ActiveViewIndex = index;
          

        }
        */

        #region Manejo de Eventos

        /*
        public void IngresarFactura()
        {
            Core.LogicaNegocio.Entidades.Factura factura = new Core.LogicaNegocio.Entidades.Factura();
            try
            {
                factura.Titulo = _vista.TituloFactura.Text;
                factura.Descripcion = _vista.Descripcion.Text;
                factura.Estado = _vista.EstadoFactura.SelectedItem.Value;
                factura.Numero = Int32.Parse(_vista.CodigoFactura.Text);

                
                factura.Procentajepagado = Int32.Parse(_vista.PorcentajePagar.Text);
                factura.Fechaingreso = ConvertirToFecha(_vista.FechaIngreso.Text);
                factura.Fechapago = ConvertirToFecha(_vista.FechaPagoFact.Text);
                
                //DateTime.Now.ToString("dd/MM/yyyy")
                //factura.Fechapago = _vista.FechaPagoFact.ToString("MM/dd/yyyy");
               
                //Ingresar(factura);
                //LimpiarCampos();

                Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarPropuestas consulta =
                Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarPropuestas();

             IList<Core.LogicaNegocio.Entidades.Propuesta> ListaPropuestas = consulta.Ejecutar();

             foreach (Core.LogicaNegocio.Entidades.Propuesta PropuestaAux in ListaPropuestas)
             {
                 if (PropuestaAux.Titulo.Equals(_vista.NombrePropuesta.Text))
                 {
                     _propuesta = PropuestaAux;
                 }
             }
                factura.Prop = _propuesta;
                this.Ingresar(factura);
            }
            catch (WebException e)
            {
               
            }

        }
       */
        #endregion



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

        /*
        public void Ingresar(Core.LogicaNegocio.Entidades.Factura factura)
        {
            Core.LogicaNegocio.Comandos.ComandoFactura.Ingresar ingresar; //objeto del comando Ingresar.

            //fábrica que instancia el comando Ingresar.
            ingresar = Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoIngresar(factura);

            //try
            //{    
            //ejecuta el comando.
            ingresar.Ejecutar();
        }

        */
    }


}
