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
    public class ConsultarxFacturaID : Comando<Factura>
    {
        private Factura factura;
        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public ConsultarxFacturaID()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        /// <param name="Factura">Entidad sobre la cual se aplicará el comando.</param>
        public ConsultarxFacturaID(Factura factura)
        {
            this.factura = factura;
        }


        #endregion


        #region Metodos
        /// <summary>Método que implementa la ejecución del comando 'Consultar'.</summary>
        public Factura Ejecutar()
        {
            Factura _factura = null;
            FacturaSQLServer bdfactura = new FacturaSQLServer();
            _factura = bdfactura.ConsultarFacturaID(factura);
            return _factura;
        }
        #endregion
    }
}