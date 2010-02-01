using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Cargo.Contrato;
using Presentador.Cargo.Vistas;

public partial class Paginas_Cargos_AgregarCargos : PaginaBase, IAgregarCargo
{
    private AgregarCargoPresenter _presentador;

    protected void Page_Init(object sender, EventArgs e)
    {

        Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 1)
            {
                i = usuario.PermisoUsu.Count;

                _presentador = new AgregarCargoPresenter(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       // _presentador.FechaActual();
    }

    #region Propiedades
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

    public Label LabelError
    {
        get { return uxLabelError; }
        set { uxLabelError = value; }
    }

    public GridView VistaCargo
    {
        get { return uxVistaCargo; }
        set { uxVistaCargo = value; }
    }
    #endregion


    #region Metodos
    /// <summary>
    /// Metodo del evento del boton aceptar
    /// </summary>
    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        LabelError.Visible = false;
        _presentador.IngresarCargo();
        _presentador.CargarVistaCargo();
    }

    public void Mensaje(string mensaje)
    {
        LabelError.Text = mensaje;
        LabelError.Visible = true;
    }

    protected void uxVistaCargo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            string s = e.Row.DataItem.ToString();

            uxVistaCargo.Columns[0].ItemStyle.Width = s.Length;
            uxVistaCargo.Columns[0].ItemStyle.Wrap = false;
        }

    }

    /// <summary>
    /// Metodo que envia una fecha(DateTime) al presentador para ser transformada en ShortDate
    /// </summary>
    /// <param name="fecha">fecha(DateTime) a ser transformada</param>
    /// <returns>Devuelve una fecha(ShortDate) de una vez en string</returns>
    protected string FormatearFecha(DateTime fecha)
    {
        return _presentador.FormatearFechaParaMostrar(fecha);
    }
    #endregion

    protected void uxSueldoMinimo_TextChanged(object sender, EventArgs e)
    {
       // _presentador.ValidarMontoMinimo();
    }
    protected void uxSueldoMaximo_TextChanged(object sender, EventArgs e)
    {
        //_presentador.ValidarMontoMaximo();
    }
}
