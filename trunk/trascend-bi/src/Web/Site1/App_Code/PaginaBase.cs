using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Collections.Generic;
using System.Web.SessionState;
using System.Collections;

/// <summary>
/// Summary description for PaginaBase
/// </summary>
public abstract class PaginaBase : System.Web.UI.Page
{

    #region Propiedades

    public const string SesionUsuario = "SesionUsuario";

    protected const string paginaPrueba = "~/Paginas/Home/Home.aspx";

    protected const string paginaInicial = "~/Paginas/Usuarios/DefaultUsuarios.aspx";

    protected const string paginaSinPermiso = "~/Paginas/Usuarios/DefaultUsuarios.aspx";

    protected const string paginaDefault = "~/Default.aspx";

    #endregion

    #region Constructor

    public PaginaBase()
    {

        //this.Init += new EventHandler(BasePage_Init);

        //this.Load += new EventHandler(BasePage_Load);

    }

    #endregion
}
