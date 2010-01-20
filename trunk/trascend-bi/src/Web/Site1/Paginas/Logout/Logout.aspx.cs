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

public partial class Paginas_Logout_Logout : PaginaBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect(paginaDefault);
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        Response.Redirect(paginaDefault);

    }
}
