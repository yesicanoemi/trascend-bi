using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;
using Presentador.Aplicacion;

public partial class MasterPage : System.Web.UI.MasterPage
{
    private DefaultPresenter _presentador;

    protected const string paginaDefault = "~/Default.aspx";
    public HttpSessionState Sesion
    {
        get { return Session; }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
      
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Sesion.Count==0)
        {
            Response.Redirect(paginaDefault);
        }
        
    }
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {

    }
    
}
