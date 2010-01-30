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

public partial class Paginas_Reportes_ReportesEquipo9b : PaginaBase, IPropuestaPorAnoPresenter
{
    public GridView Grid
    {
        get { return this.uxGrid; }
        set { this.uxGrid = value; }
    }

    public Button Boton
    {
        get { return this.uxBoton; }
        set { this.uxBoton = value; }
    }

    public DropDownList List
    {
        get { return this.uxAnios; }
        set { this.uxAnios = value; }
    }

    PropuestasPorAnoPresenter _presenter;

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
            if (usuario.PermisoUsu[i].IdPermiso == 45)
            {
                i = usuario.PermisoUsu.Count;

                _presenter = new PropuestasPorAnoPresenter(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }

    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        _presenter.CargarGrid();
    }


}
