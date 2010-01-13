using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Factura.Contrato;
using Presentador.Factura.Vistas;

public partial class Paginas_Facturas_AgregarFacturas : System.Web.UI.Page,IAgregarFactura
{
    AgregarFacturaPresenter _presenter;

    protected void Page_Load(object sender, EventArgs e)
    {
        _presenter = new AgregarFacturaPresenter(this);
    }
}
