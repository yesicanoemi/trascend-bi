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

    public DropDownList RangoSueldo
    {
        get { return uxRangoSueldo; }
        set { uxRangoSueldo = value; }
    }

    public TextBox VigenciaSueldo
    {
        get { return uxVigenciaSueldo; }
        set { uxVigenciaSueldo = value; }
    }

    public TextBox Inflacion
    {
        get { return uxInflacion; }
        set { uxInflacion = value; }
    }

    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        _presentador.IngresarCargo();
    }
}
