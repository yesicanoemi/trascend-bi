using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Cargos_ConsultarCargos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public TextBox NombreCargo
    {
        get { return uxNombre; }
        set { uxNombre = value; }
    }

    public TextBox DescripcionCargo
    {
        get { return uxDescripcion; }
        set { uxDescripcion = value; }
    }

    public TextBox SueldoMinimo
    {
        get { return uxSueldoMinimo; }
        set { uxSueldoMinimo = value; }
    }

    public TextBox SueldoMaximo
    {
        get { return uxSueldoMaximo; }
        set { uxSueldoMaximo = value; }
    }

    public TextBox VigenciaSueldo
    {
        get { return uxVigenciaSueldo; }
        set { uxVigenciaSueldo = value; }
    }


    protected void uxBotonBuscar_Click(object sender, EventArgs e)
    {
        
    }
}
