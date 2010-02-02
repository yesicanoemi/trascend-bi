using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Presentador.Logout;
using System.Web.SessionState;

public partial class Paginas_Logout_Logout : PaginaBase, ILogoutPresenter
{
    private LogoutPresenter _presentador;

    public HttpSessionState Sesion
    {
        get { return Session; }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Redirect(paginaDefault);
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        _presentador = new LogoutPresenter(this);
        
        _presentador.Logout();
        
        Response.Redirect(paginaDefault);

    }
}
