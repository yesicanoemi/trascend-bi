using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Cargo.Vistas;
using Presentador.Cargo.Contrato;

public partial class Paginas_Cargos_AdministrarCargos : System.Web.UI.Page, IAdministrarCargo
{
    private AdministrarCargoPresenter _presenter;

    protected void Page_Load(object sender, EventArgs e)
    {
        _presenter = new AdministrarCargoPresenter(this);
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

    public Label LabelError
    {
        get { return uxLabelError; }
        set { uxLabelError = value; }
    }


    protected void uxBotonBuscar_Click(object sender, EventArgs e)
    {
        LabelError.Visible = false;
        _presenter.ConsultarCargo();
    }

    protected void uxBotonEliminar_Click(object sender, EventArgs e)
    {
        LabelError.Visible = false;
        if (!_presenter.EliminarCargo())
        {
            LabelError.Text = "Error eliminando el cargo";
            LabelError.Visible = true;
        }
        else
        {
            LabelError.Text = "Cargo eliminado satisfactoriamente";
            LabelError.Visible = true;
        }
    }

    protected void uxBotonGuardar_Click(object sender, EventArgs e)
    {
        LabelError.Visible = false;
        if (!_presenter.ModificarCargo())
        {
            LabelError.Text = "Error guardando los cambios";
            LabelError.Visible = true;
        }
        else
        {
            LabelError.Text = "Cambios guardos satisfactoriamente";
            LabelError.Visible = true;
        }
    }
}
