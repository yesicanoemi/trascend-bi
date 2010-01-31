using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Factura.Contrato;
using Presentador.Factura.Vistas;

public partial class Paginas_Facturas_AgregarFacturas1 : PaginaBase,IAgregarFactura
{
    AgregarFacturaPresenter _presentador;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {
        Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 1)
            {
                i = usuario.PermisoUsu.Count;

                _presentador = new AgregarFacturaPresenter(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }
    }

    #region Propiedades
    public TextBox NombrePropuesta
    {
        get { return this.uxNombrePropuesta;}
        set { uxNombrePropuesta = value; } 
    }

    public Label LabelNombrePropuesta 
    {
        get {return this.lbNombrePropuesta;}
        set { lbNombrePropuesta = value; }
    }

    public Label MontoTotal
    {
        get { return this.lbMontoTotal; }
        set { lbMontoTotal = value; }
    }

    public Label PorcentajePagado
    {
        get { return this.lbPorcentajePagado; }
        set { lbPorcentajePagado = value; }
    }

    public Label PorcentajeRestante
    {
        get { return this.lbPorcentajeRestante; }
        set { lbPorcentajeRestante = value; }
    }

    public Label MontoPagado
    {
        get { return this.lbMontoPagado; }
        set { lbMontoPagado = value; }
    }

    public Label MontoRestante
    {
        get { return this.lbMontoRestante; }
        set { lbMontoRestante = value; }
    }

    public TextBox Titulo
    {
        get { return this.uxTitulo; }
        set { uxTitulo = value; }
    }

    public TextBox Descripcion
    {
        get { return this.uxDescripcion; }
        set { uxDescripcion = value; }
    }

    public TextBox Porcentaje
    {
        get { return this.uxPorcentaje; }
        set { uxPorcentaje = value; }
    }

    public DropDownList Estado
    {
        get { return this.uxEstado; }
        set { uxEstado = value; }
    }

    public Label Monto
    {
        get { return this.lbMonto; }
        set { lbMonto = value; }
    }

    public MultiView MultiViewFactura
    {
        get { return uxMultiViewFactura; }
        set { throw new System.NotImplementedException(); }
    }

    public void Mensaje(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }

  
    #endregion



    protected void btBotonBuscar_Click(object sender, EventArgs e)
    {
        _presentador.CargarDatosPropuesta();

    }

    protected void btBotonIngresar_Click(object sender, EventArgs e)
    {
        _presentador.IngresarPropuesta();
    }
    protected void btBotonIngresarFactura_Click(object sender, EventArgs e)
    {
       
        MultiViewFactura.ActiveViewIndex = 1;
    }
    protected void btBotonVolver_Click(object sender, EventArgs e)
    {
        
        MultiViewFactura.ActiveViewIndex = 0;
    }
    protected void uxPorcentaje_TextChanged(object sender, EventArgs e)
    {
        _presentador.ActualizarMonto();
    }
}
