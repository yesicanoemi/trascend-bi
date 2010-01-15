using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoFactura
{
    /// <summary>
    /// Clase pública 'Consultar'.
    /// Implementa el comando 'Consultar' de la entidad 'Factura'.
    /// </summary>
    public class ConsultarxNomPro : Comando<Factura>
    {
        private Propuesta propuesta;
        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public ConsultarxNomPro()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        /// <param name="Factura">Entidad sobre la cual se aplicará el comando.</param>
        public ConsultarxNomPro(Propuesta propuesta)
        {
            this.propuesta = propuesta;
        }


        #endregion


        #region Metodos
        /// <summary>Método que implementa la ejecución del comando 'Consultar'.</summary>
        public IList<Factura> Ejecutar()
        {
            IList<Factura> _facturas = null;
            FacturaSQLServer bdfactura = new FacturaSQLServer();
            Propuesta propuesta = new Propuesta();
            _facturas = bdfactura.ConsultarFacturasNomPro(propuesta);
            return _facturas;
        }
        #endregion
    }
}