using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Presentador.Reportes.Vistas;
using Presentador.Reportes.Contrato;

public partial class Paginas_Reportes_ReportesEquipo9 : PaginaBase, IPropuestaIntervalo
{

    PropuestasIntervaloPresenter _presenter;

    #region Propiedades

    public GridView Grid
    {
        get { return this.GridView1; }
        set { this.GridView1 = value; }
    }

    public Button Boton
    {
        get { return this.Boton; }
        set { this.Boton = value; }
    }

    public TextBox FechaInicio
    {
        get { return uxFechaInicio; }
        set { uxFechaInicio = value; }
    }

    public TextBox FechaFin
    {
        get { return uxFechaFin; }
        set { uxFechaFin = value; }

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

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 44)
            {
                i = usuario.PermisoUsu.Count;

                _presenter = new PropuestasIntervaloPresenter(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        lbMensaje.Text = "";
        _presenter.CargarGrid();
    }

    protected string FormatearFecha(DateTime fecha)
    {
        return _presenter.FormatearFechaParaMostrar(fecha);
    }

    protected void uxGridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex % 2 == 0)
            e.Row.BackColor = System.Drawing.Color.FromName("#FFFFCC");
    }
}
