using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Reportes.Contrato;
using Presentador.Reportes.Vistas;

public partial class Paginas_Reportes_ReportesEquipo1 : PaginaBase, IReporteEquipo1a
{
    PresentadorReporteEquipo1a _presentador;

    public RadioButtonList RadioButton
    {
        get { return uxradioButton; }
        set { uxradioButton = value; }
    }

    public TextBox TextBoxBusqueda
    {
        get { return uxTextBoxBusqueda; }
        set { uxTextBoxBusqueda = value; }
    }

    protected void BuscarClick(object sender, EventArgs e)
    {
        _presentador.Onclick();
    }
    
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
            if (usuario.PermisoUsu[i].IdPermiso == 33)
            {
                i = usuario.PermisoUsu.Count;

                _presentador = new PresentadorReporteEquipo1a(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }
     }
}
