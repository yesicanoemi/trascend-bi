﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Factura.Contrato;
using Core.LogicaNegocio.Excepciones;
using System.Net;

namespace Presentador.Factura.Vistas
{
    public class AnularFacturaPresenter
    {

        #region Propiedades
        private IAnularFactura _vista;
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor del presentador AnularFacturaPresenter
        /// </summary>
        /// <param name="laVista">Recive la pagina</param>
        public AnularFacturaPresenter(IAnularFactura laVista)
        {
            _vista = laVista;
        }
        #endregion

        public void ConsultarFactura()
        {
            try
            {
                Core.LogicaNegocio.Entidades.Factura factura =
                    new Core.LogicaNegocio.Entidades.Factura();

                factura.Numero = int.Parse(_vista.Busqueda.Text);

                Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarxFacturaID comandoConsultar =
                    Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarxFacturaID(factura);

                factura = comandoConsultar.Ejecutar();

                _vista.NombrePropuesta.Text = factura.Prop.Titulo;
                _vista.MontoPropuesta.Text = factura.Prop.MontoTotal.ToString();
                _vista.NumeroFactura.Text = factura.Numero.ToString();
                _vista.TituloFactura.Text = factura.Titulo;
                _vista.DescripcionFactura.Text = factura.Descripcion;
                _vista.FechaFactura.Text = factura.Fechaingreso.ToShortDateString().ToString();
                _vista.PorcentajeFactura.Text = factura.Procentajepagado.ToString() + " %";
                _vista.TotalFactura.Text = (factura.Prop.MontoTotal * (factura.Procentajepagado/100)).ToString();

                _vista.ActivarElementos();
            }
            catch (WebException e)
            {
                _vista.Pintar("Error WEB anulando la factura");
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

        public void AnularFactura()
        {
            try
            {
                Core.LogicaNegocio.Comandos.ComandoFactura.Anular comandoAnular =
                    Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoAnular(
                int.Parse(_vista.NumeroFactura.Text));

                comandoAnular.Ejecutar();

                _vista.DesactivarElementos();
                _vista.Pintar("La Factura ha sido anulada con exito.");
                _vista.MensajeVisible = true;
            }
            catch (EliminarException e)
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
    }
}
