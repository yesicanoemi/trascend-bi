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

        public void OnBotonAceptar()
        {

             InhabilitarCampos();
             CambiarVista(1);
             float MontosCancelados = 0;
             float MontoRestante = 0;
             float PorcCancelado = 0;
             int i = 0;
             try
             {
                 Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarPropuestas consulta =
                    Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarPropuestas();

                 IList<Core.LogicaNegocio.Entidades.Propuesta> ListaPropuestas = consulta.Ejecutar();

                 foreach (Core.LogicaNegocio.Entidades.Propuesta PropuestaAux in ListaPropuestas)
                 {
                     if (PropuestaAux.Titulo.Equals(_vista.NombrePropuesta.Text))
                     {
                         _propuesta = PropuestaAux;



                         Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarxNomPro factura =
                    Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarxNomPro(_propuesta);

                         IList<Core.LogicaNegocio.Entidades.Factura> ListaFacturas = factura.Ejecutar();


                         foreach (Core.LogicaNegocio.Entidades.Factura FacturaAux in ListaFacturas)
                         {
                             MontosCancelados += CalcularPorcentaje(FacturaAux, _propuesta);
                         }


                         foreach (Core.LogicaNegocio.Entidades.Factura FacturaAux in ListaFacturas)
                         {
                             i++;
                             _vista.MontoCancelado.Text += "Factura " + i.ToString() + ". " + "Fecha: " +
                                 FacturaAux.Fechaingreso + " Titulo: " + FacturaAux.Titulo + " Monto: " + CalcularPorcentaje(FacturaAux, _propuesta) + " Estado: " + FacturaAux.Estado + "\n" + "\n";
                         }


                     }
                 }
             }
            catch (ConsultarFacturaADException e)
            {
                //error en la capa de BD
            }
            catch (ConsultarFacturaLNException e)
            {
                //error en la capa LN
            }
            catch (Exception e)
            {
                //Error aqui
            }

                
        }




        public void OnBotonAceptar_2()
        {

            InhabilitarCampos();
            CambiarVista(1);
            float MontosCancelados = 0;
            float MontoRestante = 0;
            float PorcCancelado = 0;
            int i = 0;

            try
            {

                Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarPropuestas consulta =
                   Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarPropuestas();

                IList<Core.LogicaNegocio.Entidades.Propuesta> ListaPropuestas = consulta.Ejecutar();

                foreach (Core.LogicaNegocio.Entidades.Propuesta PropuestaAux in ListaPropuestas)
                {
                    if (PropuestaAux.Id == Convert.ToInt32(_vista.NumeroPropuesta.Text))
                    {
                        _propuesta = PropuestaAux;



                        Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarxIDPro factura =
                   Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarxIDPro(_propuesta);

                        IList<Core.LogicaNegocio.Entidades.Factura> ListaFacturas = factura.Ejecutar();


                        foreach (Core.LogicaNegocio.Entidades.Factura FacturaAux in ListaFacturas)
                        {
                            MontosCancelados += CalcularPorcentaje(FacturaAux, _propuesta);
                        }


                        foreach (Core.LogicaNegocio.Entidades.Factura FacturaAux in ListaFacturas)
                        {
                            i++;
                            _vista.MontoCancelado.Text += "Factura " + i.ToString() + ". " + "Fecha: " +
                                FacturaAux.Fechaingreso + " Titulo: " + FacturaAux.Titulo + " Monto: " + CalcularPorcentaje(FacturaAux, _propuesta) + " Estado: " + FacturaAux.Estado + "\n" + "\n";
                        }


                    }
                }
            }
            catch (ConsultarFacturaADException e)
            {
                //error en la capa de BD
            }
            catch (ConsultarFacturaLNException e)
            {
                //error en la capa LN
            }
            catch (Exception e)
            {
                //Error aqui
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


        public void InhabilitarCampos()
        {
          
            _vista.MontoCancelado.Enabled = false;
          
        }
    }
}
