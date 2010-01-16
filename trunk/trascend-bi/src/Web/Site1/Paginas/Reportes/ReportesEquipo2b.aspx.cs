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

public partial class Paginas_Reportes_ReportesEquipo2b : System.Web.UI.Page, IReporteGastoFecha
{
    private ReporteGastoFechaPresenter _presentador;
    private DateTime _fechaini;
    private DateTime _fechafin;

    #region Propiedades
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

    protected void Page_Init(object sender, EventArgs e)
    {
        _presentador = new ReporteGastoFechaPresenter(this);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void uxAceptar_Click(object sender, EventArgs e)
    {
        uxAceptar.Visible = true;

        _presentador.ConsultarGastoFecha(_fechaini, _fechafin);

    }
}
