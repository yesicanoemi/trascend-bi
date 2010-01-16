using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Cargo.Vistas;
using Presentador.Cargo.Contrato;

public partial class Paginas_Cargos_ConsultarCargos : System.Web.UI.Page, IAdministrarCargo
{
    private ConsultarCargoPresenter _presenter;

    protected void Page_Load(object sender, EventArgs e)
    {
        _presenter = new ConsultarCargoPresenter(this);
    }

    public DropDownList NombreCargo
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
        _presenter.ConsultarCargo();
    }
    protected void uxBotonEliminar_Click(object sender, EventArgs e)
    {
        _presenter.EliminarCargo();
    }
    protected void uxBotonGuardar_Click(object sender, EventArgs e)
    {
        _presenter.ModificarCargo();
    }
}
