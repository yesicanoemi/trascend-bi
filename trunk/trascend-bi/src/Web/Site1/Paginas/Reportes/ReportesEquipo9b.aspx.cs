﻿using System;
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

public partial class Paginas_Reportes_ReportesEquipo9b : System.Web.UI.Page, IPropuestaPorAnoPresenter
{
    public GridView Grid
    {
        get { return this.GridView1; }
        set { this.GridView1 = value; }
    }

    PropuestasPorAnoPresenter _presenter;

    protected void Page_Load(object sender, EventArgs e)
    {
        _presenter = new PropuestasPorAnoPresenter(this);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        _presenter.CargarGrid();
    }
}
