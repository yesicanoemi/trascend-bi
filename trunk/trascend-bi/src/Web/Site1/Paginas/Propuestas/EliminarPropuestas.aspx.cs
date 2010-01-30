using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Propuesta.Contrato;
using Presentador.Propuesta.Vistas;

public partial class Paginas_Propuestas_EliminarPropuestas : PaginaBase, IEliminarPropuesta
{
    private EliminarPropuestaPresentador _presenter;
    #region Propiedades De La Pagina

    public Label LabelEliminar
    {
        get { return uxLabelEliminar; }
        set { uxLabelEliminar = value; }
    }
    public DropDownList ListaPropuesta
    {
        get { return uxSeleccionPropuesta; }
        set { uxSeleccionPropuesta = value; }
    }
    public Label LabelEliminarCompletado
    {
        get { return uxLabelCompletado; }
        set { uxLabelCompletado = value; }
    }

    #endregion
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
            if (usuario.PermisoUsu[i].IdPermiso == 28)
            {
                i = usuario.PermisoUsu.Count;
                
                bool o = false;
                _presenter = new EliminarPropuestaPresentador(this);
                _presenter.LlenarLista(o);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }
    }


    protected void uxBotonEliminar_Click(object sender, EventArgs e)
    {
        bool o = true;
        uxBotonEliminar.Visible = false;
        _presenter.LlenarLista(o);
    }
}
