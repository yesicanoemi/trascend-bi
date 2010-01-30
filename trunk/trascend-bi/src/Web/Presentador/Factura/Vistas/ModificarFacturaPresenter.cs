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
    public class ModificarFacturaPresenter
    {

        IModificarFactura _vista;
        Core.LogicaNegocio.Entidades.Propuesta _propuesta;
        Core.LogicaNegocio.Entidades.Factura _factura;

        public ModificarFacturaPresenter(IModificarFactura vista)
        {
            _vista = vista;
        }

        public void OnBotonAceptar()
        {

             CambiarVista(1);
             float MontosCancelados = 0;
             float MontoRestante = 0;
             float PorcCancelado = 0;
             int i = 0;

             try
             {
                 Core.LogicaNegocio.Comandos.ComandosFactura.ConsultarPropuestas consulta =
                    Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarPropuestas();

                 IList<Core.LogicaNegocio.Entidades.Propuesta> ListaPropuestas = consulta.Ejecutar();

                 foreach (Core.LogicaNegocio.Entidades.Propuesta PropuestaAux in ListaPropuestas)
                 {
                     if (PropuestaAux.Titulo.Equals(_vista.NombrePropuesta.Text))
                     {
                         _propuesta = PropuestaAux;



                         Core.LogicaNegocio.Comandos.ComandosFactura.ConsultarxNomPro factura =
                    Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarxNomPro(_propuesta);

                         IList<Core.LogicaNegocio.Entidades.Factura> ListaFacturas = factura.Ejecutar();


                         foreach (Core.LogicaNegocio.Entidades.Factura FacturaAux in ListaFacturas)
                         {
                             MontosCancelados += CalcularPorcentaje(FacturaAux, _propuesta);
                         }

                         //Aquí meter en dropdown list
                         /*  foreach (Core.LogicaNegocio.Entidades.Factura FacturaAux in ListaFacturas)
                           {
                               i++;
                               _vista.MontoCancelado.Text += "Factura " + i.ToString() + ". " + "Fecha: " + 
                                   FacturaAux.Fechaingreso + " Titulo: " + FacturaAux.Titulo + " Monto: " + CalcularPorcentaje(FacturaAux, _propuesta) + " Estado: " + FacturaAux.Estado + "\n" + "\n";
                           }  */


                         foreach (Core.LogicaNegocio.Entidades.Factura FacturaAux in ListaFacturas)
                         {
                             if (FacturaAux.Estado.Equals("Por Cobrar"))
                             {
                                 i++;
                                 _vista.Facturas.Items.Add(FacturaAux.Titulo.ToString());
                             }
                         }

                     }
                 }
             }
             catch (ModificarFacturaADException e)
             {
                 _vista.Mensaje(e.Message);
             }
             catch (ModificarFacturaLNException e)
             {
                 _vista.Mensaje(e.Message);
             }
             catch (Exception e)
             {
                 _vista.Mensaje(e.Message);
             }

                
        }




        public void OnBotonAceptar_2()
        {

            CambiarVista(1);
            float MontosCancelados = 0;
            float MontoRestante = 0;
            float PorcCancelado = 0;
            int i = 0;

            try
            {
                Core.LogicaNegocio.Comandos.ComandosFactura.ConsultarPropuestas consulta =
                   Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarPropuestas();

                IList<Core.LogicaNegocio.Entidades.Propuesta> ListaPropuestas = consulta.Ejecutar();

                foreach (Core.LogicaNegocio.Entidades.Propuesta PropuestaAux in ListaPropuestas)
                {
                    if (PropuestaAux.Id == Convert.ToInt32(_vista.NumeroPropuesta.Text))
                    {
                        _propuesta = PropuestaAux;



                        Core.LogicaNegocio.Comandos.ComandosFactura.ConsultarxIDPro factura =
                   Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarxIDPro(_propuesta);

                        IList<Core.LogicaNegocio.Entidades.Factura> ListaFacturas = factura.Ejecutar();


                        foreach (Core.LogicaNegocio.Entidades.Factura FacturaAux in ListaFacturas)
                        {
                            MontosCancelados += CalcularPorcentaje(FacturaAux, _propuesta);
                        }


                        //Aquí meter en dropdown list
                        /* foreach (Core.LogicaNegocio.Entidades.Factura FacturaAux in ListaFacturas)
                         {
                             i++;
                             _vista.MontoCancelado.Text += "Factura " + i.ToString() + ". " + "Fecha: " +
                                 FacturaAux.Fechaingreso + " Titulo: " + FacturaAux.Titulo + " Monto: " + CalcularPorcentaje(FacturaAux, _propuesta) + " Estado: " + FacturaAux.Estado + "\n" + "\n";
                         }   */


                        foreach (Core.LogicaNegocio.Entidades.Factura FacturaAux in ListaFacturas)
                        {
                            if (FacturaAux.Estado.Equals("Por Cobrar"))
                            {
                                i++;
                                _vista.Facturas.Items.Add(FacturaAux.Titulo.ToString());
                            }
                        }

                    }
                }
            }
            catch (ModificarFacturaADException e)
            {
                _vista.Mensaje(e.Message);
            }
            catch (ModificarFacturaLNException e)
            {
                _vista.Mensaje(e.Message);
            }
            catch (Exception e)
            {
                _vista.Mensaje(e.Message);
            }


        }



        private float CalcularPorcentaje(Core.LogicaNegocio.Entidades.Factura factura, Core.LogicaNegocio.Entidades.Propuesta propuesta)
        {
            float MontoTotal = propuesta.MontoTotal;
            float MontoPagado = 0;
            float Porcentaje = factura.Procentajepagado;

            MontoPagado = (Porcentaje * MontoTotal) / 100;

            return MontoPagado;
        }


        

        /// <summary>
        /// Cambia la vista del multiview
        /// </summary>
        public void CambiarVista(int index)
        {
            _vista.MultiViewPropuesta.ActiveViewIndex = index;
          

        }


        public void CargarFactura()
        {

                     float MontosCancelados = 0;
                     float MontoRestante = 0;
                     float PorcCancelado = 0;
                     int i = 0;

                     Core.LogicaNegocio.Comandos.ComandosFactura.ConsultarPropuestas consulta =
                        Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarPropuestas();
       
                     IList<Core.LogicaNegocio.Entidades.Propuesta> ListaPropuestas = consulta.Ejecutar();

                     foreach (Core.LogicaNegocio.Entidades.Propuesta PropuestaAux in ListaPropuestas)
                     {
                         if (PropuestaAux.Titulo.Equals(_vista.NombrePropuesta.Text) || (PropuestaAux.Id == Convert.ToInt32(_vista.NumeroPropuesta.Text)) )
                         {
                             _propuesta = PropuestaAux;
                             _vista.MontoTotal.Text = _propuesta.MontoTotal.ToString();


                             Core.LogicaNegocio.Comandos.ComandosFactura.ConsultarxNomPro factura =
                        Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarxNomPro(_propuesta);

                             IList<Core.LogicaNegocio.Entidades.Factura> ListaFacturas = factura.Ejecutar();


                             foreach (Core.LogicaNegocio.Entidades.Factura FacturaAux in ListaFacturas)
                             {

                                 if (FacturaAux.Titulo.Equals(_vista.Facturas.SelectedItem.ToString()))
                                 {
                                     _vista.FechaIngreso.Text = FacturaAux.Fechaingreso.ToString();
                                     _vista.FechaPago.Text = FacturaAux.Fechaingreso.ToString();
                                     _vista.TituloFactura.Text = FacturaAux.Titulo.ToString();
                                     _vista.Descripcion.Text = FacturaAux.Descripcion.ToString();
                                     _vista.Estado.Text = FacturaAux.Estado.ToString();
                                     _vista.Codigo.Text = FacturaAux.Numero.ToString();
                                     _vista.Porcentaje.Text = FacturaAux.Procentajepagado.ToString();
                                 }
                             }


                             
                         }
                     }
             
        }



        public void ActualizarFactura()
        {
            Core.LogicaNegocio.Entidades.Factura factura = new Core.LogicaNegocio.Entidades.Factura();
            try
            {
               
                factura.Numero = Int32.Parse(_vista.Codigo.Text);
                this.Actualizar(factura);
            }
            catch (WebException e)
            {

            }

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


        public void Actualizar(Core.LogicaNegocio.Entidades.Factura factura)
        {
            Core.LogicaNegocio.Comandos.ComandosFactura.Modificar actualizacion; //objeto del comando Ingresar.

            //fábrica que instancia el comando Ingresar.
            actualizacion = Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoModificar(factura);

            //try
            //{    
            //ejecuta el comando.
            actualizacion.Ejecutar();
        }
    }
}








/*factura.Procentajepagado = Int32.Parse(_vista.Porcentaje.Text);
                factura.Fechaingreso = ConvertirToFecha(_vista.FechaIngreso.Text);
                factura.Fechapago = ConvertirToFecha(_vista.FechaPagoFact.Text);
                factura.Titulo = _vista.TituloFactura.Text;
                factura.Descripcion = _vista.Descripcion.Text;
                factura.Estado = _vista.Estado.Text;*/