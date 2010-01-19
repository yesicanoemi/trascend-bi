using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Factura.Contrato
{
    public interface IConsultarFactura
    {
        MultiView MultiViewPropuesta { get; set; }

        TextBox NombrePropuesta { get; set; }
        TextBox NumeroPropuesta { get; set; }
        TextBox MontoCancelado { get; set; }
    }
}
