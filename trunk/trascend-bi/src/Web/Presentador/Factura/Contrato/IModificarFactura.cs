using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Factura.Contrato
{
    public interface IModificarFactura
    {
         MultiView MultiViewPropuesta { get; set; }

         TextBox NombrePropuesta { get; set; }
         TextBox NumeroPropuesta { get; set; }

         DropDownList Facturas { get; set; }

         TextBox FechaIngreso { get; set; }
         TextBox TituloFactura { get; set; }
         TextBox Descripcion { get; set; }
         TextBox Estado { get; set; }
         TextBox Codigo { get; set; }
         TextBox Porcentaje { get; set; }
         TextBox MontoTotal { get; set; }
         TextBox FechaPago { get; set; }

         void Mensaje(string msg);
    }
}
