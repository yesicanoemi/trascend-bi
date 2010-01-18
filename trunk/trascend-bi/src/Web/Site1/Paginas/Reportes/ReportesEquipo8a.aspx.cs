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
using Presentador.Reportes.Contrato;
using Presentador.Reportes.Vistas;
using Microsoft.Practices.Web.UI.WebControls;

public partial class Paginas_Reportes_ReportesEquipo8a : System.Web.UI.Page, IReporteEquipo8a
{
    public DropDownList Anios
    {
        get { return this.uxAnios; }
        set { this.uxAnios = value; }
    }
    public GridView FacturasEmitidas
    {
        get { return this.uxFacturasEmitidas; }
        set { this.uxFacturasEmitidas = value; }
    }
    public ObjectContainerDataSource GetObjectContainerReporte8a
    {
        get { return uxObjectReporte8a; }
        set { uxObjectReporte8a = value; }
    }

    ReporteEquipo8aPresenter _presenter;

    protected void Page_Load(object sender, EventArgs e)
    {
        _presenter = new ReporteEquipo8aPresenter(this);

    }
    protected void uxBotonBuscar_Click(object sender, EventArgs e)
    {
        _presenter.BuscarFactura();
    }
    protected void uxAnios_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void uxFacturasEmitidas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}