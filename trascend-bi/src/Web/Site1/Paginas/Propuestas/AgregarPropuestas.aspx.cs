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
    private AgregarPropuestaPresenter _presentador2;
   
    IList<string[]> _lista;

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

    public MultiView MultiViewPropuesta
    {
        get { return uxMultiViewPropuesta; }
        set { throw new System.NotImplementedException(); }
    }

    public CheckBoxList TrabajoEquipo
    {
        get { return uxEquipo; }
        set {uxEquipo = value;}
    
    }

    public ObjectContainerDataSource ObtenerValorDataSource
    {
        get { return uxobjectEmpleado; }
        set { uxobjectEmpleado = value; }
    }

    public TextBox RolEquipo1
    {
        get { return Rol1; }
        set { Rol1 = value; }
    }
   
    #endregion

    protected void Page_Init(object sender, EventArgs e)
    {

        _lista  = new List<string[]>();
        _presentador2 = new AgregarPropuestaPresenter(this);
        
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

        _presentador.ConsultarCargos();

    }



    protected void Page_Load(object sender, EventArgs e)
    {
        
    }  

    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        uxBotonAceptar.Visible = true;
        MultiViewPropuesta.ActiveViewIndex = 0;
        _presentador.AgregarPropuesta();

    }

    public void Mensaje(string msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
        Page.Controls.Add(lbl);
    }
    protected void uxBotonSiguiente_Click(object sender, EventArgs e)
    {
        MultiViewPropuesta.ActiveViewIndex = 1;
    }
    protected void uxBotonAtras_Click(object sender, EventArgs e)
    {
        MultiViewPropuesta.ActiveViewIndex = 0;
    }
}
