using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Propuesta.Contrato;
using Presentador.Propuesta.Vistas;

public partial class Paginas_Propuestas_AgregarPropuestas : PaginaBase, IAgregarPropuesta
{
    private AgregarPropuestaPresenter _presentador;

    #region Propiedades
    public TextBox Titulo
    {
        get { return uxTitulo; }
        set { uxTitulo = value; }
    }

    public TextBox Version
    {
        get { return uxVersion; }
        set { uxVersion = value; }
    }

    public TextBox FechaFirma
    {
        get { return uxFechaFirma; }
        set { uxFechaFirma = value; }
    }

    public TextBox NombreReceptor
    {
        get { return uxNombreReceptor; }
        set { uxNombreReceptor = value; }
    }

    public TextBox ApellidoReceptor
    {
        get { return uxApellidoReceptor; }
        set { uxApellidoReceptor = value; }
    }

    public DropDownList CargoReceptor
    {
        get { return uxCargoReceptor; }
        set { uxCargoReceptor = value; }
    }

    public TextBox FechaInicio
    {
        get { return uxFechaInicio; }
        set { uxFechaInicio = value; }
    }

    public TextBox FechaFin
    {
        get { return uxFechaFin; }
        set { uxFechaFin = value; }
    }

    /* public TextBox EquipoTrabajo
     {
         get { }
         set { }
     }*/

    public TextBox TotalHoras
    {
        get { return uxTotalHoras; }
        set { uxTotalHoras = value; }
    }

    public TextBox MontoTotal
    {
        get { return uxMontoTotal; }
        set { uxMontoTotal = value; }
    }
    #endregion

    protected void Page_Init(object sender, EventArgs e)
    {

        Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 25)
            {
                i = usuario.PermisoUsu.Count;

                _presentador = new AgregarPropuestaPresenter(this);

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

    }

    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        uxBotonAceptar.Visible = true;
        _presentador.AgregarPropuesta();
    }
}
