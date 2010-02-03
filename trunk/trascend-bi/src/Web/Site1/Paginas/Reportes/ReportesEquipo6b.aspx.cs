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
using Presentador.Reportes.Contrato;
using Presentador.Reportes.Vistas;

public partial class Paginas_Reportes_ReportesEquipo6b : PaginaBase, IReporteFacturasPorCobrar
{
    ReporteFacturasPorCobrarPresenter _presenter;

    /// <summary>
    /// Sobrecarga del metodo Page_Init
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Init(object sender, EventArgs e)
    {
        Core.LogicaNegocio.Entidades.Usuario usuario =
                   (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        try
        {
            for (int i = 0; i < usuario.PermisoUsu.Count; i++)
            {
                if (usuario.PermisoUsu[i].IdPermiso == 40)
                {
                    i = usuario.PermisoUsu.Count;

                    _presenter = new ReporteFacturasPorCobrarPresenter(this);

                    permiso = true;

                }
            }
        }
        catch (Exception a)
        {
            if (permiso == false)
            {
                Response.Redirect(paginaSinPermiso);
            }
            else
            {
                Response.Redirect(paginaDefault);
            }
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region Propiedades
    public GridView Grid
    {
        get { return uxGridView; }
        set { uxGridView = value; }
    }

    public Button Boton
    {
        get { return Boton; }
        set { Boton = value; }
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
    #endregion

    #region Eventos
    /// <summary>
    /// Evento del boton buscar on click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button3_Click(object sender, EventArgs e)
    {
        _presenter.CargarGrid();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void Mensaje(string mensaje)
    {
        uxMensaje.Text = mensaje;
        uxMensaje.Visible = true;
    }

    /// <summary>
    /// Metodo que envia una fecha(DateTime) al presentador para ser transformada en ShortDate
    /// </summary>
    /// <param name="fecha">fecha(DateTime) a ser transformada</param>
    /// <returns>Devuelve una fecha(ShortDate) de una vez en string</returns>
    protected string FormatearFecha(DateTime fecha)
    {
        return _presenter.FormatearFechaParaMostrar(fecha);
    }

    /// <summary>
    /// Sobrecarga del evento GridView_onRowDataBound para colorear intercalarmente rows con el color FFFFCC
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void uxGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex % 2 == 0)
            e.Row.BackColor = System.Drawing.Color.FromName("#FFFFCC");
    }
    #endregion
}
