using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Factura.Contrato
{
    public interface IAnularFactura
    {
        TextBox NumeroFactura { get; set; }
        GridView DetalleFactura { get; set; }
    }
}
