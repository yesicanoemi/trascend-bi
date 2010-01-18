using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using Presentador.Aplicacion;

public partial class _Default : PaginaBase, IDefaultPresenter
{
    #region Propiedades

    private DefaultPresenter _presenter;

    public TextBox Login
    {
        get { return uxLogin; }
        set { uxLogin = value; }
    }

    public TextBox Password
    {
        get { return uxContrasena; }
        set { uxContrasena = value; }
    }

    public HttpSessionState Sesion
    {
        get { return Session; }

    }

    #endregion

    #region Métodos

    protected void Page_Init(object sender, EventArgs e)
    {
        _presenter = new DefaultPresenter(this);

    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == true)
        {

            _presenter.OnBotonAceptar();

        }
    }

    public void IngresarSistema()
    {
        Response.Redirect(paginaPrueba);

    }

    #endregion

}