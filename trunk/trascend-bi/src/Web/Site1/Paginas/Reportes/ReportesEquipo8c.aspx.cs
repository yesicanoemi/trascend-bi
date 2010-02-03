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
using Microsoft.Practices.Web.UI.WebControls;

public partial class Paginas_Reportes_ReportesEquipo8c : PaginaBase, IReporteEquipo8c
{
    public DropDownList Anios
    {
        get { return this.uxAnios; }
        set { this.uxAnios = value; }
    }
    public GridView FacturasPorCobrar
    {
        get { return this.uxFacturasPorCobrar; }
        set { this.uxFacturasPorCobrar = value; }
    }
    public ObjectContainerDataSource GetObjectContainerReporte8c
    {
        get { return uxObjectReporte8c; }
        set { uxObjectReporte8c = value; }
    }

    public Label LabelContador
    {
        get { return uxLabelContador; }
        set { uxLabelContador = value; }
    }

    ReporteEquipo8cPresenter _presenter;

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
            if (usuario.PermisoUsu[i].IdPermiso == 43)
            {
                i = usuario.PermisoUsu.Count;

                _presenter = new ReporteEquipo8cPresenter(this);

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
    protected void uxFacturasPorCobrar_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
