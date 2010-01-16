using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Factura.Contrato
{
    public interface IAgregarFactura
    {
        MultiView MultiViewPropuesta { get; set; }
     //   TextBox ProyectoAsociado { get; set; }
      
        #region InformacionPropuesta

       
        TextBox Descripcion { get; set; }
        TextBox MontoTotal { get; set; }
        TextBox MontoCancelado { get; set; }
        TextBox TotalCancelado { get; set; }
        TextBox PorcentajeCancelado { get; set; }
        TextBox MontoFaltante { get; set; }
        TextBox PorcentajeFaltante { get; set; }
        TextBox NombrePropuesta { get; set; }

        #endregion



        #region Facturacion

        TextBox MontoPagar { get; set; }
        TextBox PorcentajePagar { get; set; }
        TextBox CodigoFactura { get; set; }
        TextBox TituloFactura { get; set; }
        DropDownList EstadoFactura { get; set; }
        TextBox FechaPagoFact { get; set; }
        TextBox FechaIngreso { get; set; }
        //Button Aceptar { get; set; }

        #endregion
    }
}
