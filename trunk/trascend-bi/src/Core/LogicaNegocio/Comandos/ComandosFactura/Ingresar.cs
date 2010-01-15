using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoFactura
{
    public class Ingresar : Comando<Factura>
    {
        private Factura factura;


        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public Ingresar()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        /// <param name="factura">Entidad sobre la cual se aplicará el comando.</param>
        public Ingresar(Factura factura)
        {
            this.factura = factura;
        }

        #endregion

        #region Metodos
        /// <summary>Método que implementa la ejecución del comando 'Ingresar'.</summary>
        public Factura Ejecutar()
        {
            Factura _factura = null;
            FacturaSQLServer bdfactura = new FacturaSQLServer();
            _factura = bdfactura.IngresarFactura(factura);
            return _factura;
        }
        #endregion
    }
}