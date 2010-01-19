﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.LogicaNegocio.Excepciones.Facturas.AccesoDatos;
using Core.LogicaNegocio.Excepciones.Facturas.LogicaNegocio;
using Core.LogicaNegocio.Excepciones;

namespace Core.LogicaNegocio.Comandos.ComandoFactura
{
    public class Modificar : Comando<Factura>
    {
        private Factura factura;

        #region Constructor
        public Modificar()
        {
        }

        public Modificar(Factura factura)
        {
            this.factura = factura;
        }
        #endregion

        #region Metodos

        public Factura Ejecutar()
        {
            Factura _factura = new Factura();
            FacturaSQLServer bdpropuestas = new FacturaSQLServer();
            try
            {
                if (factura == null) { throw new ModificarFacturaLNException(); }
                _factura = bdpropuestas.UpdateFactura(factura);
            }
            catch (ModificarFacturaADException e) { }
            catch (ModificarFacturaLNException e) { throw new IngresarFacturaLNException("Se esta recibiendo una factura vacia", e); }
            catch (Exception e) { throw new IngresarFacturaLNException("Error al Modificar", e); }
            return _factura;
        }

        #endregion
    }
}
