﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Factura.Contrato;
using Core.LogicaNegocio.Excepciones;

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

                factura.Numero = int.Parse(_vista.NumeroFactura.Text);

                Core.LogicaNegocio.Comandos.ComandosFactura.ConsultarxFacturaID comandoConsultar =
                    Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarxFacturaID( factura );

                factura = comandoConsultar.Ejecutar();
    
            }
            catch (ConsultarException e)
            {
            }
            catch (Exception e)
            {
            }
        }

        public void AnularFactura()
        {
            try
            {
                Core.LogicaNegocio.Comandos.ComandosFactura.Anular comandoAnular =
                    Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoAnular(
                int.Parse(_vista.NumeroFactura.Text));

                comandoAnular.Ejecutar();
            }
            catch (EliminarException e)
            {
                
            }
            catch (Exception e)
            {

            }
        }
    }
}