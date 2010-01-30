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

public partial class Paginas_Reportes_ReportesEquipo1b : PaginaBase, IReportePaqueteCargoAnual
{
    private Presentador.Reportes.ReporteEmpleadoPaquetePresenter _presentador;

    public DropDownList SeleccionCargo
    {
        get { return uxCargo; }
        set { uxCargo = value; }
    }

    public Table TablaSolucion
    {
        get { return uxTablaSolucion; }
        set { uxTablaSolucion = value; }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        uxAceptar.Visible = false;
        _presentador = new Presentador.Reportes.ReporteEmpleadoPaquetePresenter(this);
        _presentador.BuscaCargo();
        uxAceptar.Visible = true;
        /*
        Core.LogicaNegocio.Entidades.Usuario usuario =
                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 34)
            {
                i = usuario.PermisoUsu.Count;

                uxAceptar.Visible = false;
                _presentador = new Presentador.Reportes.ReporteEmpleadoPaquetePresenter(this);
                _presentador.BuscaCargo();
                uxAceptar.Visible = true;

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }
        */
    }


    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void uxAceptar_Click(object sender, EventArgs e)
    {
        _presentador.BuscarReultado();
        uxAceptar.Visible = false;
    }

}
