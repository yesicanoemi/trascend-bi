using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Factura.Contrato;
using Presentador.Factura.Vistas;

public partial class Paginas_Facturas_ModificarFacturas : PaginaBase, IModificarFactura
{

    ModificarFacturaPresenter _presenter;

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

    public DropDownList Facturas
    {
        get { return this.uxFacturas; }
        set { this.uxFacturas = value; }
    }

    public TextBox FechaIngreso
    {
        get { return this.uxFechaIngreso; }
        set { this.uxFechaIngreso = value; }
    }

    public TextBox TituloFactura
    {
        get { return this.uxTituloFactura; }
        set { this.uxTituloFactura = value; }
    }

    public TextBox Descripcion
    {
        get { return this.uxDescFact; }
        set { this.uxDescFact = value; }
    }

    public TextBox Estado
    {
        get { return this.uxEstado; }
        set { this.uxEstado = value; }
    }

    public TextBox Codigo
    {
        get { return this.uxCodigoFactura; }
        set { this.uxCodigoFactura = value; }
    }

    public TextBox Porcentaje
    {
        get { return this.uxPorcentajePagar; }
        set { this.uxPorcentajePagar = value; }
    }

    public TextBox MontoTotal
    {
        get { return this.uxMontoPagar; }
        set { this.uxMontoPagar = value; }
    }

    public TextBox FechaPago
    {
        get { return this.uxFechaPago; }
        set { this.uxFechaPago = value; }
    }


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
            if (usuario.PermisoUsu[i].IdPermiso == 19)
            {
                i = usuario.PermisoUsu.Count;

                _presenter = new ModificarFacturaPresenter(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }
    }


    protected void uxConsultarxNombreProp_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == true)
        {
            
            _presenter.OnBotonAceptar();

        }
    }
    protected void uxConsultarxNumProp_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == true)
        {

            _presenter.OnBotonAceptar_2();

        }
    }



    protected void Button3_Click(object sender, EventArgs e)
    {
        _presenter.CargarFactura();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        _presenter.ActualizarFactura();
    }
}
