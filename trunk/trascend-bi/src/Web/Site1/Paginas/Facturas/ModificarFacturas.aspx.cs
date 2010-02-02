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

    public DropDownList Estado
    {
        get
        {
            return uxEstados;
        }
        set
        {
            uxEstados = value;
        }
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

                    _presenter = new ModificarFacturaPresenter(this);

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

        _presenter.LLenarDDLEstados();

    }

    protected void uxBusquedaBoton_Click(object sender, EventArgs e)
    {
        lbMensaje.Text = "";
        _presenter.ConsultarFactura();
        if (lbMensaje.Text.Equals(""))
            tbDatos.Visible = true;
        else
            tbDatos.Visible = false;
    }

    protected void btGuardar_Click(object sender, EventArgs e)
    {
        _presenter.SaldarFactura();
        tbDatos.Visible = false;
    }

    protected void uxTablaSueldos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex % 2 == 0)
            e.Row.BackColor = System.Drawing.Color.FromName("#FFFFCC");
    }

    protected string FormatearFecha(DateTime fecha)
    {
        return _presenter.FormatearFechaParaMostrar(fecha);
    }
}
