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
    /// <summary>
    /// Clase pública 'ConsultarxNomPro'.
    /// Implementa el comando 'ConsultarxNomPro' de la entidad 'Factura'.
    /// </summary>
    public class ConsultarxNomPro : Comando<Factura>
    {
        private Propuesta _propuesta;
        #region Constructor

        /// <summary>Constructor por defecto de la clase 'ConsultarxNomPro'.</summary>
        public ConsultarxNomPro()
        { }

        /// <summary>Constructor de la clase 'ConsultarxNomPro'.</summary>
        /// <param name="Factura">Entidad sobre la cual se aplicará el comando.</param>
        public ConsultarxNomPro(Propuesta propuesta)
        {
            this._propuesta = propuesta;
        }


        #endregion


        #region Metodos
        /// <summary>Método que implementa la ejecución del comando 'ConsultarxNomPro'.</summary>
        public IList<Factura> Ejecutar()
        {
            IList<Factura> facturas = new List<Factura>();
            FacturaSQLServer bdfactura = new FacturaSQLServer();
            try
            {
                if (_propuesta == null) { throw new ConsultarFacturaLNException(); }
                facturas = bdfactura.ConsultarFacturasNomPro(_propuesta);
            }
            catch (ConsultarFacturaADException e) { }
            catch (ConsultarFacturaLNException e) { throw new ConsultarFacturaLNException("Se recibio una propuesta vacia", e); }
            catch (Exception e) { throw new ConsultarFacturaLNException("Error al Consultar", e); }
            return facturas;
        }
        #endregion
    }
}