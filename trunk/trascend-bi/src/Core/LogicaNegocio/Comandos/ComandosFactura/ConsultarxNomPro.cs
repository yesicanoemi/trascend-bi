using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoFactura
{
    /// <summary>
    /// Clase pública 'ConsultarxNomPro'.
    /// Implementa el comando 'ConsultarxNomPro' de la entidad 'Factura'.
    /// </summary>
    public class ConsultarxNomPro : Comando<Factura>
    {
        private Propuesta propuesta;
        #region Constructor

        /// <summary>Constructor por defecto de la clase 'ConsultarxNomPro'.</summary>
        public ConsultarxNomPro()
        { }

        /// <summary>Constructor de la clase 'ConsultarxNomPro'.</summary>
        /// <param name="Factura">Entidad sobre la cual se aplicará el comando.</param>
        public ConsultarxNomPro(Propuesta propuesta)
        {
            this.propuesta = propuesta;
        }


        #endregion


        #region Metodos
        /// <summary>Método que implementa la ejecución del comando 'ConsultarxNomPro'.</summary>
        public IList<Factura> Ejecutar()
        {
            IList<Factura> _facturas = null;
            FacturaSQLServer bdfactura = new FacturaSQLServer();
           
            _facturas = bdfactura.ConsultarFacturasNomPro(propuesta);
            return _facturas;
        }
        #endregion
    }
}