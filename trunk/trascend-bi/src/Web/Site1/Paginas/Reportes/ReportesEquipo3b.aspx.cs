using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.Practices.Web.UI.WebControls;
using Presentador.Reportes.Contrato;
using Presentador.Reportes.Vistas;

public partial class Paginas_Reportes_ReportesEquipo3b : System.Web.UI.Page, IReporteFacturasEmitidas
{

    #region Propiedades

    private ReporteFaturasEmitidasPresenter _presentador;

    #endregion
    
    #region Informacion Basica

    public GridView GridViewReporteFactura3b
    {
        get { return uxReporteFactura3b; }
        set { throw new System.NotImplementedException(); }
    }

    public ObjectContainerDataSource GetObjectContainerReporteFactura3b
    {
        get { return uxObjectReporte3b; }
        set { uxObjectReporte3b = value; }
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

    protected void Page_Init(object sender, EventArgs e)
    {
        _presentador = new ReporteFaturasEmitidasPresenter(this);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        _presentador.OnBotonBuscar();
    }
}
