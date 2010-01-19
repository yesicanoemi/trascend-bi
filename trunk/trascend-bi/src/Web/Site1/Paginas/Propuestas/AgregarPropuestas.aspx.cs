using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.Practices.Web.UI.WebControls;
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

    public TextBox CargoReceptor
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

    public GridView GridViewEmpleado
    {
        get { return uxEmpleados; }
        set { throw new System.NotImplementedException(); }
    }

    public ObjectContainerDataSource ObtenerValorDataSource
    {
        get { return uxobjectEmpleado; }
        set { uxobjectEmpleado = value; }
    }

    public TextBox NombreEquipo1
    {
        get { return Nombre1; }
        set { Nombre1 = value; }
    }

    public TextBox ApellidoEquipo1
    {
        get { return Apellido1; }
        set { Apellido1 = value; }
    }

    public TextBox RolEquipo1
    {
        get { return Rol1; }
        set { Rol1 = value; }
    }

    public TextBox NombreEquipo2
    {
        get { return Nombre2; }
        set { Nombre2 = value; }
    }

    public TextBox ApellidoEquipo2
    {
        get { return Apellido2; }
        set { Apellido2 = value; }
    }

    public TextBox RolEquipo2
    {
        get { return Rol2; }
        set { Rol2 = value; }
    }

    public TextBox NombreEquipo3
    {
        get { return Nombre3; }
        set { Nombre3 = value; }
    }

    public TextBox ApellidoEquipo3
    {
        get { return Apellido3; }
        set { Apellido3 = value; }
    }

    public TextBox RolEquipo3
    {
        get { return Rol3; }
        set { Rol3 = value; }
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

                _presentador.ConsultarEmpleados();

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
