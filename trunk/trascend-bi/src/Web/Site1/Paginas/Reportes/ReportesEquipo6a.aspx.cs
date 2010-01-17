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

public partial class Paginas_Reportes_ReportesEquipo6 : System.Web.UI.Page, IReporteFacturasPorCobrar
{

    ReporteFacturasCobradasPresenter _presenter;

    protected void Page_Init(object sender, EventArgs e)
    {
        _presenter = new ReporteFacturasCobradasPresenter(this);
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

    protected void Button3_Click(object sender, EventArgs e)
    {
        _presenter.CargarGrid();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
