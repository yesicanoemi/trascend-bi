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

public partial class Paginas_Reportes_ReportesEquipo9 : System.Web.UI.Page, IPropuestaIntervalo
{

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

    PropuestasIntervaloPresenter _presenter;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {
        _presenter = new PropuestasIntervaloPresenter(this);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        _presenter.CargarGrid();
    }
}
