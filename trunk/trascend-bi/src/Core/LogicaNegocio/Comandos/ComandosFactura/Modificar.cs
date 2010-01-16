using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

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
            Factura _factura = null;
            FacturaSQLServer bdpropuestas = new FacturaSQLServer();
            _factura = bdpropuestas.UpdateFactura(factura);
            return _factura;
        }

        #endregion
    }
}
