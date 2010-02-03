using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Factura.Contrato;
using Presentador.Factura.Vistas;
using Microsoft.Practices.Web.UI.WebControls;


public partial class Paginas_Facturas_AnularFacturas : PaginaBase, IAnularFactura
{

    private AnularFacturaPresenter _presenter;

    #region Propiedades

    public Label NombrePropuesta
    {
        get { return lbNombrePropuesta; }
        set { lbNombrePropuesta = value; }
    }

    public Label MontoPropuesta
    {
        get { return lbMontoPropuesta; }
        set { lbMontoPropuesta = value; }
    }

    public TextBox Busqueda
    {
        get { return uxBusqueda; }
        set { uxBusqueda = value; }
    }

    public Label NumeroFactura
    {
        get { return lbNumeroFactura; }
        set { lbNumeroFactura = value; }
    }

    public Label TituloFactura
    {
        get { return lbTituloFactura; }
        set { lbTituloFactura = value; }
    }

    public Label DescripcionFactura
    {
        get { return lbDescripcionFactura; }
        set { lbDescripcionFactura = value; }
    }

    public Label EstadoFactura
    {
        get { return lbEstadoFactura; }
        set { lbEstadoFactura = value; }
    }

    public Label PorcentajeFactura
    {
        get { return lbPorcentajeFactura; }
        set { lbPorcentajeFactura = value; }
    }

    public Label TotalFactura
    {
        get { return lbTotalFactura; }
        set { lbTotalFactura = value; }
    }

    public Label FechaFactura
    {
        get { return lbFechaFactura; }
        set { lbFechaFactura = value; }
    }

    #region Mensajes

    public Label Mensaje
    {
        get { return lbMensaje; }
        set { lbMensaje = value; }
    }

    public void Pintar(string mensaje)
    {
        this.lbMensaje.Text = mensaje;
    }

    public bool MensajeVisible
    {
        get { return lbMensaje.Visible; }
        set { lbMensaje.Visible = value; }
    }

    #endregion

    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
 
    }

    protected void Page_Init(object sender, EventArgs e)
    {

        Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        try
        {
            for (int i = 0; i < usuario.PermisoUsu.Count; i++)
            {
                if (usuario.PermisoUsu[i].IdPermiso == 13)
                {
                    i = usuario.PermisoUsu.Count;

                    _presenter = new AnularFacturaPresenter(this);

                    permiso = true;

                }
            }

            if (permiso == false)
            {
                Response.Redirect(paginaSinPermiso);
            }
        }
        catch (Exception a)
        {
            Response.Redirect(paginaDefault);

        }
    }

    protected void uxBusquedaBoton_Click(object sender, EventArgs e)
    {
        lbMensaje.Text = "";
        _presenter.ConsultarFactura();
        if (lbMensaje.Text.Equals(""))
            tbDatos.Visible = true;
        else
        {
            tbDatos.Visible = false;
            btAnular.Visible = false;
        }
    }

    protected void btAnular_Click(object sender, EventArgs e)
    {
        _presenter.AnularFactura();
        DesactivarElementos();
    }

    public void ActivarElementos()
    {
        tbDatos.Visible = true;
        btAnular.Visible = true;
    }

    public void DesactivarElementos()
    {
        tbDatos.Visible = false;
        btAnular.Visible = false;
        Busqueda.Text = "";
    }

}