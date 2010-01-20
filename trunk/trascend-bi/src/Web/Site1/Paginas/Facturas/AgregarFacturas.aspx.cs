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

    public RadioButtonList RadioButtons
    {
        get { return this.uxRadioButton; }
        set { this.uxRadioButton = value; }
    }

    public TextBox PropuestaBuscar
    {
        get { return this.uxBusqueda; }
        set { this.uxBusqueda = value; }
    }

    public GridView ResultadoPropuesta
    {
        get { return this.uxGridPropuesta; }
        set { this.uxGridPropuesta = value; }
    }

    public Button BotonBusqueda
    {
        get { return this.uxBusquedaBoton; }
        set { this.uxBusquedaBoton = value; }
    }

    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {


    }


    public void Mensaje(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
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

    protected void uxBusquedaBoton_Click(object sender, EventArgs e)
    {
        _presenter.CargarGrid();
    }
}
