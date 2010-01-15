using System;
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

        public AgregarFacturaPresenter(IAgregarFactura vista)
        {
            _vista = vista;
        }
        public void OnBotonAceptar()
        {
            
             CambiarVista(1);

        }
        /// <summary>
        /// Cambia la vista del multiview
        /// </summary>
        public void CambiarVista(int index)
        {
            _vista.MultiViewPropuesta.ActiveViewIndex = index;
          

        }


        #region Manejo de Eventos
        public void IngresarFactura()
        {
            Core.LogicaNegocio.Entidades.Factura factura = new Core.LogicaNegocio.Entidades.Factura();
            try
            {
                factura.Titulo = _vista.TituloFactura.Text;
                factura.Descripcion = _vista.Descripcion.Text;
                //factura.Estado = _vista.EstadoFactura.Items.Contains;
                factura.Numero = Int32.Parse(_vista.CodigoFactura.Text);

                
                factura.Procentajepagado = Int32.Parse(_vista.PorcentajePagar.Text);
                factura.Fechaingreso = DateTime.Now;
                //factura.Fechapago = _vista.FechaPagoFact.ToString("MM/dd/yyyy");
               
                //Ingresar(factura);
                //LimpiarCampos();
            }
            catch (WebException e)
            {
               
            }

        }
        #endregion



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
