using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Usuarios_AgregarUsuarios : System.Web.UI.Page
{
    #region Propiedades
    public GridView GridViewUsuarios 
    {
        get {return this.uxConsultaUsuarios; }
        set { this.uxConsultaUsuarios=value; }

    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void PageChangingUsuarios(object sender, GridViewPageEventArgs e)
    {
       
    }

    protected void SelectUsuarios(object sender, GridViewSelectEventArgs e)
    {
        
    }
    protected void uxBuscar_Click(object sender, EventArgs e)
    {

    }
}
