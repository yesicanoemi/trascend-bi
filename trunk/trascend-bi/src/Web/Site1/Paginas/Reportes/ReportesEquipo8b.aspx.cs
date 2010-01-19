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

public partial class Paginas_Reportes_ReportesEquipo8b : PaginaBase, IReporteEquipo8b
{
    public DropDownList Anios
    {
        get { return this.uxAnios; }
        set { this.uxAnios = value; }
    }
    public GridView FacturasCobradas
    {
        get { return this.uxFacturasCobradas; }
        set { this.uxFacturasCobradas = value; }
    }
    public ObjectContainerDataSource GetObjectContainerReporte8b
    {
        get { return uxObjectReporte8b; }
        set { uxObjectReporte8b = value; }
    }

    ReporteEquipo8bPresenter _presenter;

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
            if (usuario.PermisoUsu[i].IdPermiso == 42)
            {
                i = usuario.PermisoUsu.Count;

                _presenter = new ReporteEquipo8bPresenter(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }

    }
    protected void uxBotonBuscar_Click(object sender, EventArgs e)
    {
        _presenter.onBotonBuscar();
    }
    protected void uxAnios_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void uxFacturasCobradas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
