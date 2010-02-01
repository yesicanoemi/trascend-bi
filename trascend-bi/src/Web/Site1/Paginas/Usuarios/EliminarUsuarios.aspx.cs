using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Usuario.Contrato;
using Presentador.Usuario.Vistas;
using System.Web.SessionState;
using Microsoft.Practices.Web.UI.WebControls;
using Core.LogicaNegocio.Excepciones;


public partial class Paginas_Usuarios_EliminarUsuarios : PaginaBase, IEliminarUsuario
{
    private EliminarUsuarioPresenter _presentador;

    private EliminarUsuarioPresenter _presenter;

    #region Propiedades

    public Label AsteriscoStatus
    {
        get { return uxAsteriscoStatus; }
        set { uxAsteriscoStatus = value; }
    }

    /*public Label AsteriscoLogin
    {
        get { return uxAsteriscoLogin; }
        set { uxAsteriscoLogin = value; }
    }*/
    public Label NombreUsuarioLabel
    {
        get { return uxLoginLabel; }
        set { uxLoginLabel = value; }
    }

    public Label StatusDdLLabel
    {
        get { return uxStatusDdLLabel; }
        set { uxStatusDdLLabel = value; }
    }

    public TextBox Login
    {
        get { return uxLogin; }
        set { uxLogin = value; }
    }

    public Button BotonBuscar
    {
        get { return uxBotonBuscar; }
        set { uxBotonBuscar = value; }
    }

    public RequiredFieldValidator ValidarNombreVacio
    {
        get { return uxRequiredFieldValidator; }
        set { uxRequiredFieldValidator = value; }
    }

    public RequiredFieldValidator ValidarNoSeleccion
    {
        get { return uxRequiredFieldValidator2; }
        set { uxRequiredFieldValidator2 = value; }
    }

    public DropDownList StatusDdL
    {
        get { return uxStatusDdL; }
        set { uxStatusDdL = value; }
    }

    public RadioButtonList RbCampoBusqueda
    {
        get { return uxRbCampoBusqueda; }
        set { uxRbCampoBusqueda = value; }
    }

    public MultiView MultiViewEliminar
    {
        get { return uxMultiViewEliminar; }
        set { uxMultiViewEliminar = value; }
    }

    public GridView GridViewConsultarEliminarUsuario
    {
        get { return uxConsultaEliminarUsuario; }
        set { uxConsultaEliminarUsuario = value; }
    }
    public ObjectContainerDataSource GetObjectContainerConsultaEliminarUsuario
    {
        get { return uxObjectConsultaEliminarUsuario; }
        set { uxObjectConsultaEliminarUsuario = value; }
    }
    #endregion

    #region InformacionBasica
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

    #endregion

    #region Metodos
    protected void Page_Init(object sender, EventArgs e)
    {

        Core.LogicaNegocio.Entidades.Usuario usuario =
                        (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];
        Core.LogicaNegocio.Entidades.Permiso _permiso = new
                        Core.LogicaNegocio.Entidades.Permiso();
        bool permiso = false;

        _presenter = new EliminarUsuarioPresenter();

        _permiso = _presenter.ConsultarIdPermiso();

        int idPermiso = _permiso.IdPermiso;

        try
        {
            //int conteo = usuario.PermisoUsu.Count;
            for (int i = 0; i < usuario.PermisoUsu.Count; i++)
            {
                if (usuario.PermisoUsu[i].IdPermiso == idPermiso)
                {
                    i = usuario.PermisoUsu.Count;

                    _presentador = new EliminarUsuarioPresenter(this);

                    permiso = true;

                }
            }

            if (permiso == false)
            {
                Response.Redirect(paginaSinPermiso);
            }

        }
        catch (NullReferenceException a)
        {
            //_presentador = new EliminarUsuarioPresenter(this);

            //_presentador.sesionTerminada();

            Response.Redirect(paginaDefault);

            //throw new PermisoException("No posee privilegios para ver esta pagina", a);
        }

    }
    protected void SelectUsuarios(object sender, GridViewSelectEventArgs e)
    {

        _presentador.uxObjectConsultaEliminarUsuarioSelecting
                    (uxConsultaEliminarUsuario.DataKeys[e.NewSelectedIndex].Value.ToString());
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void uxBotonBuscar_Click(object sender, EventArgs e)
    {
        _presentador.OnBotonBuscar();
    }

    protected void uxRbCampoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
    {
        _presentador.CampoBusqueda_Selected();
    }
    #endregion

}







