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
        static Core.LogicaNegocio.Entidades.Propuesta _propuesta = new Core.LogicaNegocio.Entidades.Propuesta();
        Core.LogicaNegocio.Entidades.Factura _factura;
        
        

        public AgregarFacturaPresenter(IAgregarFactura vista)
        {
            _vista = vista;
        }

        public void CargarDatosPropuesta()
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

        public void IngresarPropuesta()
        {
            Core.LogicaNegocio.Entidades.Factura Factura = new Core.LogicaNegocio.Entidades.Factura();
            
            Factura.Titulo = _vista.Titulo.Text;
            Factura.Descripcion = _vista.Descripcion.Text;
            Factura.Prop = _propuesta;
            Factura.Fechaingreso = DateTime.Now;
            Factura.Estado = "Por Cobrar";
            Factura.Fechapago = DateTime.Now;
            Factura.Procentajepagado = float.Parse(_vista.Porcentaje.Text);

            Core.LogicaNegocio.Comandos.ComandoFactura.Ingresar Ingresar;
            Ingresar = Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoIngresar(Factura);
            Ingresar.Ejecutar();
            



        }

        public void ActualizarMonto()
        {
            _vista.Monto.Text = (_propuesta.MontoTotal * float.Parse(_vista.Porcentaje.Text)).ToString();
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


     /*   private float CalcularPorcentaje(Core.LogicaNegocio.Entidades.Factura factura, Core.LogicaNegocio.Entidades.Propuesta propuesta)
        {
            float MontoTotal = propuesta.MontoTotal;
            float MontoPagado = 0;
            float Porcentaje = factura.Procentajepagado;

            MontoPagado = (Porcentaje * MontoTotal) / 100;

            return MontoPagado;
        } */


      /*  public void CargarGrid()
        {
            _vista.ResultadoPropuesta.DataSource = null;

            _vista.ResultadoPropuesta.DataBind();

            Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarPropuestas consulta =
               Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarPropuestas();

            IList<Core.LogicaNegocio.Entidades.Propuesta> ListaPropuestas = consulta.Ejecutar();

            try
            {
                if (_vista.RadioButtons.SelectedItem.Text.Equals("Buscar por Nombre"))
                    BuscarProcPorNombre(ListaPropuestas);
                else
                    BuscarProcPorID(ListaPropuestas);
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
        } */

     /*   private void BuscarProcPorNombre(IList<Core.LogicaNegocio.Entidades.Propuesta> ListaPropuestas)
        {
            foreach (Core.LogicaNegocio.Entidades.Propuesta PropuestaAux in ListaPropuestas)
            {
                if (PropuestaAux.Titulo.Equals(_vista.NombrePropuesta.Text))
                {

                    IList<Core.LogicaNegocio.Entidades.Propuesta> ListaPropuestasN = new List<Core.LogicaNegocio.Entidades.Propuesta>();

                    ListaPropuestasN.Add(PropuestaAux);

                    _vista.ResultadoPropuesta.DataSource = ListaPropuestasN;

                    _vista.ResultadoPropuesta.DataBind();

                    _propuesta = PropuestaAux;

                    Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarxNomPro factura =
                        Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarxNomPro(_propuesta);

                    IList<Core.LogicaNegocio.Entidades.Factura> ListaFacturas = factura.Ejecutar();

                    //llenar la tabla de facturas
                    _vista.GridFacturas.DataSource = ListaFacturas;

                    _vista.GridFacturas.DataBind();

                    float MontosCancelados = 0;

                    foreach (Core.LogicaNegocio.Entidades.Factura FacturaAux in ListaFacturas)
                    {
                        MontosCancelados += CalcularPorcentaje(FacturaAux, _propuesta);
                    }

                    //_vista.TotalCancelado.Text = MontosCancelados.ToString();
                    _vista.MontoTotal.Text = MontosCancelados.ToString();

                    float PorcCancelado = 0;
                    float MontoRestante  = 0;

                    PorcCancelado = (MontosCancelados * 100) / _propuesta.MontoTotal;
                    //_vista.PorcentajeCancelado.Text = PorcCancelado.ToString();
                    _vista.Porcentaje.Text = PorcCancelado.ToString();

                    MontoRestante = _propuesta.MontoTotal - MontosCancelados;
                    //_vista.MontoFaltante.Text = MontoRestante.ToString();
                    _vista.MontoFaltante.Text = MontoRestante.ToString();

                    //_vista.PorcentajeFaltante.Text = (100 - PorcCancelado).ToString();
                    _vista.PorcentajeFaltante.Text = (100 - PorcCancelado).ToString();

                    ////_vista.CodigoFactura.Text = Convert.ToString(.Count + 1);
                    //_vista.FechaIngreso.Text = DateTime.Now.ToString("dd/MM/yyyy");



                    Core.LogicaNegocio.Comandos.ComandoFactura.Consultar factura2 =
               Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultar();

                    IList<Core.LogicaNegocio.Entidades.Factura> ListaFacturas2 = factura2.Ejecutar();
                    // _vista.CodigoFactura.Text = (ListaFacturas2.Count + 1).ToString();


                    int i = 0;

                    foreach (Core.LogicaNegocio.Entidades.Factura fact in ListaFacturas2)
                    {

                        if (fact.Numero > i)
                            i = fact.Numero;


                    }

                    _vista.FechaEmision.Text = DateTime.Today.ToString();
                    _vista.NumeroFactura.Text = (i + 1).ToString();

                    Core.LogicaNegocio.Entidades.Factura NewFactura = new Core.LogicaNegocio.Entidades.Factura();

                    break;
                }
            }
        } */

    /*    private void BuscarProcPorID(IList<Core.LogicaNegocio.Entidades.Propuesta> ListaPropuestas)
        {
            foreach (Core.LogicaNegocio.Entidades.Propuesta PropuestaAux in ListaPropuestas)
            {
                if (PropuestaAux.Id == int.Parse(_vista.PropuestaBuscar.Text))
                {
                    IList<Core.LogicaNegocio.Entidades.Propuesta> ListaPropuestasN = new List<Core.LogicaNegocio.Entidades.Propuesta>();

                    ListaPropuestasN.Add(PropuestaAux);

                    _vista.ResultadoPropuesta.DataSource = ListaPropuestasN;

                    _vista.ResultadoPropuesta.DataBind();

                    _propuesta = PropuestaAux;

                    Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarxNomPro factura =
                        Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarxNomPro(_propuesta);

                    IList<Core.LogicaNegocio.Entidades.Factura> ListaFacturas = factura.Ejecutar();

                    //llenar la tabla de facturas
                    _vista.ResultadoFacturas.DataSource = ListaFacturas;

                    _vista.ResultadoFacturas.DataBind();

                    float MontosCancelados = 0;

                    foreach (Core.LogicaNegocio.Entidades.Factura FacturaAux in ListaFacturas)
                    {
                        MontosCancelados += CalcularPorcentaje(FacturaAux, _propuesta);
                    }

                    //_vista.TotalCancelado.Text = MontosCancelados.ToString();
                    _vista.MontoTotal.Text = MontosCancelados.ToString();

                    float PorcCancelado = 0;
                    float MontoRestante = 0;

                    PorcCancelado = (MontosCancelados * 100) / _propuesta.MontoTotal;
                    //_vista.PorcentajeCancelado.Text = PorcCancelado.ToString();
                    _vista.PorcentajeTotal.Text = PorcCancelado.ToString();

                    MontoRestante = _propuesta.MontoTotal - MontosCancelados;
                    //_vista.MontoFaltante.Text = MontoRestante.ToString();
                    _vista.MontoFaltante.Text = MontoRestante.ToString();

                    //_vista.PorcentajeFaltante.Text = (100 - PorcCancelado).ToString();
                    _vista.PorcentajeFaltante.Text = (100 - PorcCancelado).ToString();

                    ////_vista.CodigoFactura.Text = Convert.ToString(.Count + 1);
                    //_vista.FechaIngreso.Text = DateTime.Now.ToString("dd/MM/yyyy");



                    Core.LogicaNegocio.Comandos.ComandoFactura.Consultar factura2 =
               Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultar();

                    IList<Core.LogicaNegocio.Entidades.Factura> ListaFacturas2 = factura2.Ejecutar();
                    // _vista.CodigoFactura.Text = (ListaFacturas2.Count + 1).ToString();


                    int i = 0;

                    foreach (Core.LogicaNegocio.Entidades.Factura fact in ListaFacturas2)
                    {

                        if (fact.Numero > i)
                            i = fact.Numero;


                    }

                    _vista.FechaEmision.Text = DateTime.Today.ToString();
                    _vista.NumeroFactura.Text = (i + 1).ToString();


                }
            }
        } */

       /* public void RecogerDatosFactura()
        {
            Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarPropuestas consulta =
               Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarPropuestas();

            IList<Core.LogicaNegocio.Entidades.Propuesta> ListaPropuestas = consulta.Ejecutar();

            if (_vista.RadioButtons.SelectedItem.Text.Equals("Buscar por Nombre"))
            {
                foreach (Core.LogicaNegocio.Entidades.Propuesta PropuestaAux in ListaPropuestas)
                {
                    if (PropuestaAux.Titulo.Equals(_vista.PropuestaBuscar.Text))
                    {
                        Core.LogicaNegocio.Entidades.Factura NewFactura = new Core.LogicaNegocio.Entidades.Factura();

                        NewFactura.Titulo = _vista.Titulo.Text;
                        NewFactura.Descripcion = _vista.Descripcion.Text;
                        NewFactura.Procentajepagado = float.Parse(_vista.PorcentajePagar.Text);
                        NewFactura.Fechapago = DateTime.Parse(_vista.FechaPago.Text);
                        NewFactura.Fechaingreso = DateTime.Parse(_vista.FechaEmision.Text);
                        NewFactura.Estado = _vista.Estado.Text;
                        NewFactura.Prop = PropuestaAux;

                        Ingresar(NewFactura);
                    }
                }
            }
            else
            {
                foreach (Core.LogicaNegocio.Entidades.Propuesta PropuestaAux in ListaPropuestas)
                {
                    if (PropuestaAux.Id == int.Parse(_vista.PropuestaBuscar.Text))
                    {
                        Core.LogicaNegocio.Entidades.Factura NewFactura = new Core.LogicaNegocio.Entidades.Factura();

                        NewFactura.Titulo = _vista.Titulo.Text;
                        NewFactura.Descripcion = _vista.Descripcion.Text;
                        NewFactura.Procentajepagado = float.Parse(_vista.PorcentajePagar.Text);
                        NewFactura.Fechapago = DateTime.Parse(_vista.FechaPago.Text);
                        NewFactura.Fechaingreso = DateTime.Parse(_vista.FechaEmision.Text);
                        NewFactura.Estado = _vista.Estado.Text;
                        NewFactura.Prop = PropuestaAux;

                        Ingresar(NewFactura);
                    }
                }
            }

            
        }/*

        /*
        /// <summary>
        /// Cambia la vista del multiview
        /// </summary>
        public void CambiarVista(int index)
        {
            _vista.MultiViewPropuesta.ActiveViewIndex = index;
          

        }
        */

       



        /// <summary>
        /// Metodo que recibo un string y devuelve un objeto datetim con el formato DD/MM/AAAA
        /// </summary>
        /// <param name="fecha">string de fecha en formato MM/DD/AAAA</param>
        /// <returns>Datetime</returns>
      

        public void InhabilitarCampos()
        {

        }

        
   

        
    }


}
