using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Usuario.Contrato;
using Presentador.Usuario.Vistas;
using System.Web.SessionState;


public partial class Paginas_Usuarios_EliminarUsuarios : PaginaBase, IEliminarUsuario
{
    private EliminarUsuarioPresenter _presenter;

    #region Propiedades

    public DropDownList UsuarioEliminar
    {
        get { return uxUsuarioEliminar; }
        set { uxUsuarioEliminar = value; }
    }

    #endregion

    protected void Page_Init(object sender, EventArgs e)
    {
        _presenter = new EliminarUsuarioPresenter(this);

    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            _presenter.CargarUsuarios();
            _presenter.OnBotonEliminar();


    }

    public void Volver()
    {
        Response.Redirect(paginaInicial);
    }

}







