using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Usuario.Contrato;
using Presentador.Usuario.Vistas;

public partial class Paginas_Usuarios_EliminarUsuarios : System.Web.UI.Page, IEliminarUsuario
{
    private EliminarUsuarioPresenter _presenter;

    #region Propiedades

    public TextBox UsuarioEliminar
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
        _presenter.OnBotonEliminar();
    }
}





