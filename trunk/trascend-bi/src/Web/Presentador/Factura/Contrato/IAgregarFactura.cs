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
        Label LNombrePropuesta { get; set; }

        #region InformacionPropuesta

        Label LDescripcion { get; set; }
        TextBox Descripcion { get; set; }
        Label LMontoTotal { get; set; }
        TextBox MontoTotal { get; set; }
        Label LMontoCancelado { get; set; }
        TextBox MontoCancelado { get; set; }
        Label LTotalCancelado { get; set; }
        TextBox TotalCancelado { get; set; }
        Label LPorcentajeCancelado { get; set; }
        TextBox PorcentajeCancelado { get; set; }
        Label LMontoFaltante { get; set; }
        TextBox MontoFaltante { get; set; }
        Label LPorcentajeFaltante { get; set; }
        TextBox PorcentajeFaltante { get; set; }

        #endregion



        #region Facturacion

        Label LMontoPagar { get; set; }
        TextBox MontoPagar { get; set; }
        Label LPorcentajePagar { get; set; }
        TextBox PorcentajePagar { get; set; }
        Label LCodigoFactura { get; set; }
        TextBox CodigoFactura { get; set; }
        Label LTituloFactura { get; set; }
        TextBox TituloFactura { get; set; }
        DropDownList EstadoFactura { get; set; }
        TextBox FechaPagoFact { get; set; }
        //Button Aceptar { get; set; }

        #endregion
    }
}
