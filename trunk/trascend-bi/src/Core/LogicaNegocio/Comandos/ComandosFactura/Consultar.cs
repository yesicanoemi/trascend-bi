using System;
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
    public class Consultar : Comando<Factura>
    {

        #region Constructor
        public Consultar()
        {
        }

        #endregion

        #region Metodos

        public IList<Factura> Ejecutar()
        {
            IList<Factura> facturas = null;
            FacturaSQLServer bdpropuestas = new FacturaSQLServer();
            try
            {
                facturas = bdpropuestas.ConsultarFacturas();
            }
            catch (ConsultarFacturaADException e) { }
            catch (ConsultarFacturaLNException e) { throw new ConsultarFacturaLNException("Error en la Consulta", e); }
            catch (Exception e) { throw new ConsultarFacturaLNException("Error en la Consulta", e); }

            return facturas;
        }

        #endregion
    }
}