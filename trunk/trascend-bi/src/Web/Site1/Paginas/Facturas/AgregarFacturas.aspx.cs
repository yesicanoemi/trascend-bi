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
    #region Propiedades
    public MultiView MultiViewPropuesta
    {
        get { return uxMultiViewPropuesta; }
        set { throw new System.NotImplementedException(); }
    }
    public TextBox ProyectoAsociado
    {
        get { return this.uxProyectoAsociado; }
        set { this.uxProyectoAsociado = value; }
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        _presenter = new AgregarFacturaPresenter(this);
    }

    protected void uxBuscarTitulo_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == true)
        {
            if (uxTituloPropuesta.Text == "propuesta1")
            {
                _presenter.OnBotonAceptar();
            }
            /*else
            {
                Response.Redirect();
            }*/

        }

    }
}
