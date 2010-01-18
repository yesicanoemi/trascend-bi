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
        LabelError.Visible = false;
        DesactivarBotones();
    }

    #region Propiedades
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
    #endregion

    #region Metodos
    /// <summary>
    /// Metodo para la accion del boton de busqueda
    /// </summary>
    protected void uxBotonBuscar_Click(object sender, EventArgs e)
    {
        LabelError.Visible = false;
        _presenter.ConsultarCargo();
        ActivarBotones();
    }

    /// <summary>
    /// Metodo para la accion del boton de eliminar
    /// </summary>
    protected void uxBotonEliminar_Click(object sender, EventArgs e)
    {
        if (!_presenter.EliminarCargo())
        {
            LabelError.Text = "Error eliminando el cargo";
            LabelError.Visible = true;
        }
        else
        {
            LabelError.Text = "Cargo eliminado satisfactoriamente";
            LabelError.Visible = true;
            DesactivarBotones();
        }
    }

    /// <summary>
    /// Metodo para la accion del boton de guardar
    /// </summary>
    protected void uxBotonGuardar_Click(object sender, EventArgs e)
    {
        if (!_presenter.ModificarCargo())
        {
            if (LabelError.Text.Equals("Debe rellenar todos los campos"))
            {
                LabelError.Visible = true;
                ActivarBotones();
            }
            else
            {
                LabelError.Text = "Error guardando los cambios";
                LabelError.Visible = true;
            }
        }
        else
        {
            LabelError.Text = "Cambios guardos satisfactoriamente";
            LabelError.Visible = true;
            DesactivarBotones();
        }
    }

    /// <summary>
    /// Metodo para habilitar los botones
    /// </summary>
    private void ActivarBotones()
    {
        uxBotonGuardar.Enabled = true;
        uxBotonEliminar.Enabled = true;
    }

    /// <summary>
    /// Metodo para desabilitar los botones
    /// </summary>
    private void DesactivarBotones()
    {
        uxBotonGuardar.Enabled = false;
        uxBotonEliminar.Enabled = false;
    }
    #endregion
}