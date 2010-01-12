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
        Factura IngresarFactura(Factura factura);

        IList<Factura> ConsultarFacturas();

        Factura ConsultarFacturaID(Factura factura);
    }
}
