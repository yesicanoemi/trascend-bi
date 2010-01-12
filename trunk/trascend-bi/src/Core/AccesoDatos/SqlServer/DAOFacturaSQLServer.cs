using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.AccesoDatos.Interfaces;
using Core.LogicaNegocio.Entidades;
using System.Collections.Generic;

namespace Core.AccesoDatos.SqlServer
{
    class DAOFacturaSQLServer : IDAOFactura
    {
        public Factura IngresarFactura(Factura factura)
        {
            return new Factura(); //por ahora
        }

        public IList<Factura> ConsultarFacturas()
        {
            return new IList<Factura>();
        }

        public Factura ConsultarFacturaID(Factura factura)
        {
            return new Factura(); //por ahora
        }
    }
}
