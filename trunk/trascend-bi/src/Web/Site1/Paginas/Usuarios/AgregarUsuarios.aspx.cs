using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Usuario.Contrato;
using Presentador.Usuario.Vistas;
using Microsoft.Practices.Web.UI.WebControls;
using Presentador.Aplicacion;
using Core.LogicaNegocio.Excepciones;

public partial class Paginas_Usuarios_AgregarUsuarios : PaginaBase, IAgregarUsuario
{

    #region PropiedadesPaginas

    private AgregarUsuarioPresenter _presentador;

    private AgregarUsuarioPresenter _presenter;

    protected const string paginaConsulta = "~/Paginas/Usuarios/AgregarUsuario.aspx";

    #endregion

    #region Información Básica

    #region Propiedades del Diálogo

    public void Pintar(string codigo, string mensaje, string actor, string detalles)
    {
        uxDialogoError.Pintar(codigo, mensaje, actor, detalles);
    }

    public bool DialogoVisible
    {
        get { return uxDialogoError.Visible; }
        set { uxDialogoError.Visible = value; }
    }

    #endregion

    #region Información

    public void PintarInformacion(string mensaje, string estilo)
    {
        uxMensajeInformacion.PintarControl(mensaje, estilo);
    }

    public bool InformacionVisible
    {
        get { return uxMensajeInformacion.Visible; }
        set { uxMensajeInformacion.Visible = value; }
    }

    public void PintarInformacionBotonAceptar(string mensaje, string estilo)
    {
        uxMensajeInformacionBotonAceptar.PintarControl(mensaje, estilo);
    }

    public bool InformacionVisibleBotonAceptar
    {
        get { return uxMensajeInformacionBotonAceptar.Visible; }
        set { uxMensajeInformacionBotonAceptar.Visible = value; }
    }

    #endregion

    #region Propiedades
    public Label CorreoEnviado
    {
        get { return uxCorreEnviado; }
        set { uxCorreEnviado = value; }
    }
    public TextBox NombreUsuario
    {
        get { return uxLogin; }
        set { uxLogin = value; }
    }

    public TextBox ContrasenaUsuario
    {
        get { return uxContrasena; }
        set { uxLogin = value; }
    }


    public MultiView MultiViewAgregar
    {
        get { return uxMultiViewAgregar; }
        set { throw new System.NotImplementedException(); }
    }

    public GridView GridViewConsultaEmpleado
    {
        get { return uxConsultaEmpleado; }
        set { throw new System.NotImplementedException(); }
    }

    public ObjectContainerDataSource GetObjectContainerConsultaEmpleado
    {
        get { return uxObjectConsultaEmpleado; }
        set { uxObjectConsultaEmpleado = value; }
    }

    //Retorna el nombre del empleado a buscar
    public TextBox EmpleadoBuscar
    {
        get { return uxNombreEmpleadoBuscar; }
        set { uxNombreEmpleadoBuscar = value; }
    }

    public Label NombreEmp
    {
        get { return uxNombreEmp; }
        set { uxNombreEmp = value; }
    }

    public Label ApellidoEmp
    {
        get { return uxApellidoEmp; }
        set { uxApellidoEmp = value; }
    }

    public Label CedulaEmp
    {
        get { return uxCedula; }
        set { uxCedula = value; }
    }

    public Label StatusEmp
    {
        get { return uxStatusE; }
        set { uxStatusE = value; }
    }

    public CheckBoxList CBLAgregar
    {
        get { return uxCBLAgregar; }
        set { uxCBLAgregar = value; }
    }

    public CheckBoxList CBLConsultar
    {
        get { return uxCBLConsultar; }
        set { uxCBLConsultar = value; }
    }

    public CheckBoxList CBLModificar
    {
        get { return uxCBLModificar; }
        set { uxCBLModificar = value; }
    }

    public CheckBoxList CBLEliminar
    {
        get { return uxCBLEliminar; }
        set { uxCBLEliminar = value; }
    }

    public CheckBoxList CBLReporte
    {
        get { return uxCBLReporte; }
        set { uxCBLReporte = value; }
    }
    #endregion

    #endregion

    #region Métodos

    protected void SelectEmpleados(object sender, GridViewSelectEventArgs e)
    {
        _presentador.uxObjectConsultaUsuarioSelecting
                            (uxConsultaEmpleado.DataKeys[e.NewSelectedIndex].Value.ToString());
    }

    protected void Page_Init(object sender, EventArgs e)
    {

        Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        Core.LogicaNegocio.Entidades.Permiso _permiso = new
                                Core.LogicaNegocio.Entidades.Permiso();

        _presenter = new AgregarUsuarioPresenter();

        _permiso = _presenter.ConsultarIdPermiso();

        int idPermiso = _permiso.IdPermiso;

        bool permiso = false;
        

        try
        {
            for (int i = 0; i < usuario.PermisoUsu.Count; i++)
            {
                if (usuario.PermisoUsu[i].IdPermiso == idPermiso)
                {
                    i = usuario.PermisoUsu.Count;

                    _presentador = new AgregarUsuarioPresenter(this);

                    permiso = true;

                }
            }

            if (permiso == false)
            {
                Response.Redirect(paginaSinPermiso);
            }
        }
        catch (Exception a)
        {
            Response.Redirect(paginaDefault);
            //throw new PermisoException("No posee privilegios para ver esta pagina", a);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void uxBotonBuscar_Click(object sender, EventArgs e)
    {
        _presentador.OnBotonBuscar();
    }

    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        _presentador.OnBotonAceptar();
    }
    protected void uxBotonRegresar_Click(object sender, EventArgs e)
    {
        _presentador.onBotonRegresar();
        //Response.Redirect("~/Paginas/Usuarios/ModificarUsuarios.aspx");

    }
    public void CambiarPagina()
    {
        Response.Redirect(paginaConsulta);

    }

    public void CambiarPaginaDefault()
    {
     //   Response.Redirect(paginaInicialUsuario);
    }

    protected void lbAllAgregar_Click(object sender, EventArgs e)
    {
        foreach (ListItem li in CBLAgregar.Items)
        {
            li.Selected = true;
        }
    }
    protected void lbNoneAgregar_Click(object sender, EventArgs e)
    {
        foreach (ListItem li in CBLAgregar.Items)
        {
            li.Selected = false;
        }
    }

    protected void lbAllConsultar_Click(object sender, EventArgs e)
    {
        foreach (ListItem li in CBLConsultar.Items)
        {
            li.Selected = true;
        }
    }
    protected void lbNoneConsultar_Click(object sender, EventArgs e)
    {
        foreach (ListItem li in CBLConsultar.Items)
        {
            li.Selected = false;
        }
    }
    protected void lbAllModificar_Click(object sender, EventArgs e)
    {
        foreach (ListItem li in CBLModificar.Items)
        {
            li.Selected = true;
        }
    }
    protected void lbNoneModificar_Click(object sender, EventArgs e)
    {
        foreach (ListItem li in CBLModificar.Items)
        {
            li.Selected = false;
        }
    }
    protected void lbAllEliminar_Click(object sender, EventArgs e)
    {
        foreach (ListItem li in CBLEliminar.Items)
        {
            li.Selected = true;
        }
    }
    protected void lbNoneEliminar_Click(object sender, EventArgs e)
    {
        foreach (ListItem li in CBLEliminar.Items)
        {
            li.Selected = false;
        }
    }
    protected void lbAllReporte_Click(object sender, EventArgs e)
    {
        foreach (ListItem li in CBLReporte.Items)
        {
            li.Selected = true;
        }

    }
    protected void lbNoneReporte_Click(object sender, EventArgs e)
    {
        foreach (ListItem li in CBLReporte.Items)
        {
            li.Selected = false;
        }

    }
    #endregion
}
