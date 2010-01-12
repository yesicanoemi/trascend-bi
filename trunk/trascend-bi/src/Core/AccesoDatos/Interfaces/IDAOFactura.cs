using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using System.Collections.Generic;

namespace Core.AccesoDatos.Interfaces
{
    public interface IDAOFactura
    {
        public Factura IngresarFactura(Factura factura);

        public IList<Factura> ConsultarFacturas();

        public Factura ConsultarFacturaID(Factura factura);
    }
}
