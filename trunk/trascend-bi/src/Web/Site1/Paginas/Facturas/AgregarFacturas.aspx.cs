using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Factura.Contrato;
using Presentador.Factura.Vistas;

public partial class Paginas_Facturas_AgregarFacturas : PaginaBase,IAgregarFactura
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

    
    #region InformacionPropuesta

    public TextBox Descripcion
    {
        get { return this.uxDescProp; }
        set { this.uxDescProp = value; }
    }

    public TextBox MontoTotal
    {
        get { return this.uxMontoTotal; }
        set { this.uxMontoTotal = value; }
    }

    public TextBox MontoCancelado
    {
        get { return this.uxMontoCancelado; }
        set { this.uxMontoCancelado = value; }
    }

    public TextBox TotalCancelado
    {
        get { return this.uxTotalCancelado; }
        set { this.uxTotalCancelado = value; }
    }

    public TextBox PorcentajeCancelado
    {
        get { return this.uxPorcentajeCancelado; }
        set { this.uxPorcentajeCancelado = value; }
    }

    public TextBox MontoFaltante
    {
        get { return this.uxMontoFaltante; }
        set { this.uxMontoFaltante = value; }
    }

    public TextBox PorcentajeFaltante
    {
        get { return this.uxPorcFaltante; }
        set { this.uxPorcFaltante = value; }
    }

    public TextBox NombrePropuesta
    {
        get { return this.uxTituloPropuesta; }
        set { this.uxTituloPropuesta = value; }
    }

    #endregion


    #region Facturacion

    public TextBox FechaIngreso
    {
        get { return this.uxFechaIngresoFactProp; }
        set { this.uxFechaIngresoFactProp = value; }
    }

    public TextBox MontoPagar
    {
        get { return this.uxMontoPagar; }
        set { this.uxMontoPagar = value; }
    }

    public TextBox PorcentajePagar
    {
        get { return this.uxPorcentajePagar; }
        set { this.uxPorcentajePagar = value; }
    }

    public TextBox CodigoFactura
    {
        get { return this.uxCodigoFactura; }
        set { this.uxCodigoFactura = value; }
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


    }

    protected void uxBuscarTitulo_Click(object sender, EventArgs e)
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
    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        _presenter.OnAgregarFactura();
    }

    protected void Page_Init(object sender, EventArgs e)
    {

        Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 17)
            {
                i = usuario.PermisoUsu.Count;

                _presenter = new AgregarFacturaPresenter(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }
    }
}
