using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Cargo.Contrato;
using Presentador.Cargo.Vistas;

public partial class Paginas_Cargos_AgregarCargos : System.Web.UI.Page, IAgregarCargo
{
    private AgregarCargoPresenter _presentador;

    protected void Page_Load(object sender, EventArgs e)
    {
        _presentador = new AgregarCargoPresenter(this);
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


    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        Console.WriteLine("lololololololololololololololol");
        _presentador.IngresarCargo();
    }
     
}
