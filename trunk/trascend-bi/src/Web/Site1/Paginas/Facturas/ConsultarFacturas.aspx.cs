using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Factura.Contrato;
using Presentador.Factura.Vistas;

public partial class Paginas_Facturas_ConsultarFacturas : System.Web.UI.Page, IConsultarFactura
{

    ConsultarFacturaPresenter _presenter;

    public MultiView MultiViewPropuesta
    {
        get { return uxMultiViewPropuesta; }
        set { throw new System.NotImplementedException(); }
    }

    public TextBox NombrePropuesta
    {
        get { return this.uxTituloPropuesta; }
        set { this.uxTituloPropuesta = value; }
    }

    public TextBox NumeroPropuesta
    {
        get { return this.uxNumProp; }
        set { this.uxNumProp = value; }
    }


    public TextBox MontoCancelado
    {
        get { return this.uxDescProp; }
        set { this.uxDescProp = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        _presenter = new ConsultarFacturaPresenter(this);
    }


    protected void uxConsultarxNombreProp_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == true)
        {
            // if (uxTituloPropuesta.Text == "propuesta1")

            _presenter.OnBotonAceptar();

            /*else
            {
                Response.Redirect();
            }*/

        }
    }


    protected void uxConsultarxNumProp_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == true)
        {
           
            _presenter.OnBotonAceptar_2();

        }
    }
}
