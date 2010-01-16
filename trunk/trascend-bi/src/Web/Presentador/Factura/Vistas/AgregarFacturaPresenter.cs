﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Factura.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Fabricas;
using Core.LogicaNegocio.Comandos;
using System.Net;



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

        public void OnBotonAceptar()
        {

             InhabilitarCampos();
             CambiarVista(1);
             float MontosCancelados = 0;
             float MontoRestante = 0;
             
             Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarPropuestas consulta =
                Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarPropuestas();

             IList<Core.LogicaNegocio.Entidades.Propuesta> ListaPropuestas = consulta.Ejecutar();

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
                         _vista.MontoCancelado.Text += FacturaAux.Fechaingreso + " " + FacturaAux.Titulo + " " + CalcularPorcentaje(FacturaAux, _propuesta) + "\n";
                     }

                     //_vista.PorcentajeCancelado = 

                     MontoRestante = _propuesta.MontoTotal - MontosCancelados;
                     _vista.MontoFaltante.Text = MontoRestante.ToString();
                     // _vista.PorcentajeFaltante.Text = 

                 }
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


        #region Manejo de Eventos

      
        /*public void CargarDatosPropuesta(Core.LogicaNegocio.Entidades.Propuesta propuesta)
        {
            
            
        }*/


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
                factura.Fechaingreso = DateTime.Now;

                //DateTime.Now.ToString("dd/MM/yyyy")
                //factura.Fechapago = _vista.FechaPagoFact.ToString("MM/dd/yyyy");
               
                //Ingresar(factura);
                //LimpiarCampos();
            }
            catch (WebException e)
            {
               
            }

        }
        #endregion



/*
        public void CargarDatosPropuesta(Core.LogicaNegocio.Entidades.Propuesta propuesta)
        {

            IList<Core.LogicaNegocio.Entidades.Propuesta> ListaPropuestas = null;
            Core.LogicaNegocio.Comandos.ComandoPropuesta.Consultar consulta; //objeto del comando Consultar.

            //fábrica que instancia el comando Consultar.
            consulta = Core.LogicaNegocio.Fabricas.FabricaComandosPropuesta.CrearComandoConsultar(propuesta);

            //try
            //{    
            //ejecuta el comando.
            ListaPropuestas = consulta.Ejecutar();   
            
        }

 */
        /// <summary>
        /// Metodo que recibo un string y devuelve un objeto datetim con el formato DD/MM/AAAA
        /// </summary>
        /// <param name="fecha">string de fecha en formato MM/DD/AAAA</param>
        /// <returns>Datetime</returns>
        public DateTime ConvertirToFecha(string fecha)
        {
            string[] str = fecha.Split('/');
            return new DateTime(Convert.ToInt32(str[2]), Convert.ToInt32(str[0]), Convert.ToInt32(str[1]));

        }


        public void InhabilitarCampos()
        {
            _vista.MontoTotal.Enabled = false;
            _vista.MontoCancelado.Enabled = false;
            _vista.TotalCancelado.Enabled = false;
            _vista.PorcentajeCancelado.Enabled = false;
            _vista.MontoFaltante.Visible = true;
            _vista.PorcentajeFaltante.Visible = false;
            _vista.FechaIngreso.Enabled = false;
            _vista.CodigoFactura.Enabled = false;
            _vista.MontoPagar.Enabled = false;
        }


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


    }


}
