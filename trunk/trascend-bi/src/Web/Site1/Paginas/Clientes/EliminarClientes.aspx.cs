using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Cliente.Contrato;
using Presentador.Cliente.Vistas;

public partial class Paginas_Clientes_EliminarClientes : PaginaBase, IEliminarCliente
{
    private EliminarClientePresentador _Presentador;
    #region Propiedad de la Pagina

    public Label LabelEliminar
    {
        get { return uxLabelEliminar; }
        set { uxLabelEliminar = value; }
    }
    public DropDownList ListaCliente
    {
        get { return uxSeleccionCliente; }
        set { uxSeleccionCliente = value; }
    }
    public Label LabelEliminarCompletado
    {
        get { return uxLabelCompletado; }
        set { uxLabelCompletado = value; }
    }

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        bool o = false;
        _Presentador = new EliminarClientePresentador(this);
        _Presentador.LlenarLista(o);
    }

    protected void Page_Init(object sender, EventArgs e)
    {

        Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 8)
            {
                i = usuario.PermisoUsu.Count;

                //Deben colocar aqui la instancia del presentador a usar 

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
        _Presentador.LlenarLista(o);
    }


}
