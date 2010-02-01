using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Cargo.Vistas;
using Presentador.Cargo.Contrato;

public partial class Paginas_Cargos_AdministrarCargos : PaginaBase, IAdministrarCargo
{
    private AdministrarCargoPresenter _presenter;

    protected void Page_Init(object sender, EventArgs e)
    {

        /*Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 3)
            {
                i = usuario.PermisoUsu.Count;

               */ _presenter = new AdministrarCargoPresenter(this);

               /* permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }*/
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
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
        _presenter.EliminarCargo();
    }

    /// <summary>
    /// Metodo para la accion del boton de guardar
    /// </summary>
    protected void uxBotonGuardar_Click(object sender, EventArgs e)
    {
        _presenter.ModificarCargo();
    }

    public void Mensaje(string mensaje)
    {
        LabelError.Text = mensaje;
        LabelError.Visible = true;
    }

    /// <summary>
    /// Metodo para habilitar los botones
    /// </summary>
    public void ActivarBotones()
    {
        uxBotonGuardar.Enabled = true;
        uxBotonEliminar.Enabled = true;
    }

    /// <summary>
    /// Metodo para desabilitar los botones
    /// </summary>
    public void DesactivarBotones()
    {
        uxBotonGuardar.Enabled = false;
        uxBotonEliminar.Enabled = false;
    }
    #endregion
}