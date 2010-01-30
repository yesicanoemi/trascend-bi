using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Factura.Contrato;

public partial class Paginas_Facturas_EliminarFacturas : PaginaBase, IAnularFactura
{
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

    public DetailsView DetalleFactura
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

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }
    }
}