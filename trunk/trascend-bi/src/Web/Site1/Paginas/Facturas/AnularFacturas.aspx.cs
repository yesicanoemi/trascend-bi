using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Factura.Contrato;
using Presentador.Factura.Vistas;

public partial class Paginas_Facturas_EliminarFacturas : PaginaBase, IAnularFactura
{

    private AnularFacturaPresenter _presenter;

    #region Propiedades
    public TextBox NumeroFactura
    {
        get
        {
            return uxBusqueda;
        }
        set
        {
            uxBusqueda = value;
        }
    }

    public GridView DetalleFactura
    {
        get
        {
            return uxDetalleFactura;
        }
        set
        {
            uxDetalleFactura = value;
        }
    }
    #endregion

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
            if (usuario.PermisoUsu[i].IdPermiso == 20)
            {
                i = usuario.PermisoUsu.Count;

                //instancia del presentador
                _presenter = new AnularFacturaPresenter(this);

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
        _presenter.ConsultarFactura();
    }

    protected void btAnular_Click(object sender, EventArgs e)
    {
        _presenter.AnularFactura();
    }
}