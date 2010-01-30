using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Reportes.Contrato;
using Presentador.Reportes.Vistas;

public partial class Paginas_Reportes_ReportesEquipo2 : PaginaBase, IReporteHorasRol 
{
    private ReporteHorasRolPresenter _presenter;
    #region Propiedades de la Pagina

    public DropDownList SeleccionRol
    {
        get { return uxRol; }
        set { uxRol = value; }
    }
    public DropDownList SeleccionAnio
    {
        get { return uxAnio; }
        set { uxAnio = value; }
    }
    public Label LabelHoras
    {
        get { return uxLabelHoras; }
        set { uxLabelHoras = value; }
    }
    public Label LabelTextoHoras
    {
        get { return uxLabelTextoH; }
        set { uxLabelTextoH = value; }
    }
    #endregion

    #region Metodos

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
            if (usuario.PermisoUsu[i].IdPermiso == 35)
            {
                i = usuario.PermisoUsu.Count;


                uxBotonRol.Visible = false;
                _presenter = new ReporteHorasRolPresenter(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }
        
    }

    
    protected void uxBotonAnio_Click(object sender, EventArgs e)
    {
        _presenter.BuscaRol();
        uxBotonAnio.Visible = false;
        uxBotonRol.Visible = true;
        uxAnio.Visible = false;
    }
    protected void uxBotonRol_Click(object sender, EventArgs e)
    {
        _presenter.ContarHoras();
        uxBotonRol.Visible = false;
    }
    #endregion
}
