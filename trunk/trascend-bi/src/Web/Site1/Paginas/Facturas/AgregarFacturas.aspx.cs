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

   /* public TextBox ProyectoAsociado
    {
        get { return this.uxProyectoAsociado; }
        set { this.uxProyectoAsociado = value; }
    }
    */

    public Label LNombrePropuesta
    {
        get { return this.uxLabelNomProp; }
        set { this.uxLabelNomProp = value; }
    }


    #region InformacionPropuesta

    public Label LDescripcion
    {
        get { return this.uxLabelDescProp; }
        set { this.uxLabelDescProp = value; }
    }

    public TextBox Descripcion
    {
        get { return this.uxDescProp; }
        set { this.uxDescProp = value; }
    }

    public Label LMontoTotal
    {
        get { return this.uxLabelMontoTotal; }
        set { this.uxLabelMontoTotal = value; }
    }

    public TextBox MontoTotal
    {
        get { return this.uxMontoTotal; }
        set { this.uxMontoTotal = value; }
    }

    public Label LMontoCancelado
    {
        get { return this.uxLabelMontoCancelado; }
        set { this.uxLabelMontoCancelado = value; }
    }

    public TextBox MontoCancelado
    {
        get { return this.uxMontoCancelado; }
        set { this.uxMontoCancelado = value; }
    }

    public Label LTotalCancelado
    {
        get { return this.uxLabelTotalCancelado; }
        set { this.uxLabelTotalCancelado = value; }
    }

    public TextBox TotalCancelado
    {
        get { return this.uxTotalCancelado; }
        set { this.uxTotalCancelado = value; }
    }

    public Label LPorcentajeCancelado
    {
        get { return this.uxLabelPorcCancelado; }
        set { this.uxLabelPorcCancelado = value; }
    }

    public TextBox PorcentajeCancelado
    {
        get { return this.uxPorcentajeCancelado; }
        set { this.uxPorcentajeCancelado = value; }
    }

    public Label LMontoFaltante
    {
        get { return this.uxLabelMontoFalt; }
        set { this.uxLabelMontoFalt = value; }
    }

    public TextBox MontoFaltante
    {
        get { return this.uxMontoFaltante; }
        set { this.uxMontoFaltante = value; }
    }

    public Label LPorcentajeFaltante
    {
        get { return this.uxLabelPorcFalt; }
        set { this.uxLabelPorcFalt = value; }
    }

    public TextBox PorcentajeFaltante
    {
        get { return this.uxPorcFaltante; }
        set { this.uxPorcFaltante = value; }
    }

    #endregion


    #region Facturacion

    public Label LMontoPagar
    {
        get { return this.uxLabelMontoPagar; }
        set { this.uxLabelMontoPagar = value; }
    }

    public TextBox MontoPagar
    {
        get { return this.uxMontoPagar; }
        set { this.uxMontoPagar = value; }
    }

    public Label LPorcentajePagar
    {
        get { return this.uxLabelPorcPagar; }
        set { this.uxLabelPorcPagar = value; }
    }

    public TextBox PorcentajePagar
    {
        get { return this.uxPorcentajePagar; }
        set { this.uxPorcentajePagar = value; }
    }

    public Label LCodigoFactura
    {
        get { return this.uxLabelCodFactura; }
        set { this.uxLabelCodFactura = value; }
    }

    public TextBox CodigoFactura
    {
        get { return this.uxCodigoFactura; }
        set { this.uxCodigoFactura = value; }
    }

    public Label LTituloFactura
    {
        get { return this.uxLabelTituloFact; }
        set { this.uxLabelTituloFact = value; }
    }

    public TextBox TituloFactura
    {
        get { return this.uxTituloFactura; }
        set { this.uxTituloFactura = value; }
    }

    public DropDownList EstadoFactura
    {
        get { return this.uxEstado; }
        set { this.uxEstado = value; }
    }


    public TextBox FechaPagoFact
    {
        get { return this.uxFechaPago; }
        set { this.uxFechaPago = value; }
    }

    /*public Button Aceptar
    {
        get { return this.uxAceptar; }
        set { this.uxAceptar = value; }
    }*/

    #endregion

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
