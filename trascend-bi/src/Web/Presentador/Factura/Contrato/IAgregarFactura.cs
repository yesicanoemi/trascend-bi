using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Factura.Contrato
{
    public interface IAgregarFactura
    {
        //MultiView MultiViewPropuesta { get; set; }
        //   TextBox ProyectoAsociado { get; set; }

        #region InformacionPropuesta


        
        TextBox NombrePropuesta { get; set; }
        Label LabelNombrePropuesta { get; set; }
        Label MontoTotal { get; set; }
        Label PorcentajePagado { get; set; }
        Label PorcentajeRestante { get; set; }
        Label MontoPagado { get; set; }
        Label MontoRestante { get; set; }
        TextBox Titulo { get; set; }
        TextBox Descripcion { get; set; }
        TextBox Porcentaje { get; set; }
        DropDownList Estado { get; set; }
        Label Monto { get; set; }
        

        #endregion

        void Mensaje(string msg);
    }
}
