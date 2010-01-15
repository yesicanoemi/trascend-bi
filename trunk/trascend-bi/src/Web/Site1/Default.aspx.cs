using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using Presentador.Aplicacion;

public partial class _Default : PaginaBase, IDefaultPresenter
{
    private DefaultPresenter _presenter;

    #region Propiedades

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

    #endregion

    protected void Page_Init(object sender, EventArgs e)
    {
        _presenter = new DefaultPresenter(this);

    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        if(Page.IsValid == true)
            {
               // if ((uxLogin.Text == "usuario") && (uxContrasena.Text == "clave"))
               // {
                    _presenter.OnBotonAceptar();
                //}
                /*else
                {
                    Response.Redirect();
                }*/
            
            }
    }

    public void IngresarSistema()
    {
        Response.Redirect(paginaPrueba);
        
    }

}