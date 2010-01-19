using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

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
            IList<Factura> _facturas = null;
            FacturaSQLServer bdpropuestas = new FacturaSQLServer();
            _facturas = bdpropuestas.ConsultarFacturas();
            return _facturas;
        }

        #endregion
    }
}