using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Contacto.ContactoInterface;
using Presentador.Contacto.ContactoPresentador;
using Microsoft.Practices.Web.UI.WebControls;
using Presentador.Aplicacion;
using System.Net;
using Presentador.Base;

public partial class Paginas_Contactos_EliminarContactos : PaginaBase, IEliminarContacto
{
    #region Propiedades

    private EliminarPresentador _presentador;

    protected const string paginaEliminar = "~/Paginas/Contactos/EliminarContactos.aspx";


    public TextBox TextBoxNombre
    {
        get { return uxConsultaNombreContacto; }
        set { uxConsultaNombreContacto = value; }
    }

    public TextBox TextBoxApellido
    {
        get { return uxConsultaApellidoContacto; }
        set { uxConsultaApellidoContacto = value; }
    }

    public TextBox TextBoxCodTelefono
    {
        get { return uxConsultaCodigoContacto; }
        set { uxConsultaCodigoContacto = value; }
    }

    public TextBox TextBoxNumTelefono
    {
        get { return uxConsultaTelefonoContacto; }
        set { uxConsultaTelefonoContacto = value; }
    }

    public DropDownList ClienteDdl
    {
        get { return uxConsultaClienteContacto; }
        set { uxConsultaClienteContacto = value; }
    }

    public MultiView MultiViewConsultar
    {
        get { return uxMultiViewConsultar; }
        set { throw new System.NotImplementedException(); }
    }

    public GridView GridViewConsultaContacto
    {
        get { return uxConsultaContacto; }
        set { throw new System.NotImplementedException(); }
    }

    public ObjectContainerDataSource GetObjectContainerConsultaContacto
    {
        get { return uxObjectConsultaContacto; }
        set { uxObjectConsultaContacto = value; }
    }

    public RadioButtonList RbCampoBusqueda
    {
        get { return uxRbCampoBusqueda; }
        set { uxRbCampoBusqueda = value; }
    }

    public Button BotonBuscar
    {
        get { return uxBotonBuscar; }
        set { uxBotonBuscar = value; }
    }

    public Label NombreC
    {
        get { return uxNombreC; }
        set { uxNombreC = value; }
    }

    public Label ApellidoC
    {
        get { return uxApellidoC; }
        set { uxApellidoC = value; }
    }

    public Label AreaC
    {
        get { return uxArea; }
        set { uxArea = value; }
    }

    public Label CargoC
    {
        get { return uxCargo; }
        set { uxCargo = value; }
    }

    public Label TelefonoC1
    {
        get { return uxTelefono1; }
        set { uxTelefono1 = value; }
    }

    public Label TipoTlfC1
    {
        get { return uxTipoTlf1; }
        set { uxTipoTlf1 = value; }
    }

    public Label TelefonoC2
    {
        get { return uxTelefono2; }
        set { uxTelefono2 = value; }
    }

    public Label TipoTlfC2
    {
        get { return uxTipoTlf2; }
        set { uxTipoTlf2 = value; }
    }

    public Label ClienteC
    {
        get { return uxCliente; }
        set { uxCliente = value; }
    }

    public Label NombreContacto
    {
        get { return uxNombreContacto; }
        set { uxNombreContacto = value; }
    }

    public Label ApellidoContacto
    {
        get { return uxApellidoContacto; }
        set { uxApellidoContacto = value; }
    }

    public Label CodigoTlf
    {
        get { return uxCodigo; }
        set { uxCodigo = value; }
    }

    public Label Tlf
    {
        get { return uxTlf; }
        set { uxTlf = value; }
    }

    public Label NombreCliente
    {
        get { return uxNombreCliente; }
        set { uxNombreCliente = value; }
    }

    public RequiredFieldValidator RequiredFieldValidator
    {
        get { return uxRequiredFieldValidator; }
        set { uxRequiredFieldValidator = value; }
    }

    public RequiredFieldValidator RequiredFieldValidator1
    {
        get { return uxRequiredFieldValidator1; }
        set { uxRequiredFieldValidator1 = value; }
    }

    public TextBox Valor
    {
        get { return uxValor; }
        set { uxValor = value; }
    }

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

    public void PintarInformacionEliminar(string mensaje, string estilo)
    {
        uxMensajeEliminar.PintarControl(mensaje, estilo);
    }

    public bool InformacionVisibleEliminar
    {
        get { return uxMensajeEliminar.Visible; }
        set { uxMensajeEliminar.Visible = value; }
    }

    public void PintarInformacionError(string mensaje, string estilo)
    {
        MensajeInformacionError.PintarControl(mensaje, estilo);
    }

    public bool InformacionVisibleError
    {
        get { return MensajeInformacionError.Visible; }
        set { MensajeInformacionError.Visible = value; }
    }

    #endregion

    #region Diálogo

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

    #endregion

    #region Métodos

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {

        Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        try
        {
            for (int i = 0; i < usuario.PermisoUsu.Count; i++)
            {
                if (usuario.PermisoUsu[i].IdPermiso == 10)
                {
                    i = usuario.PermisoUsu.Count;

                    _presentador = new EliminarPresentador(this);

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

        }

    }

    protected void uxRbCampoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
    {
        _presentador.CampoBusqueda_Selected();
    }

    protected void uxBotonBuscar_Click(object sender, EventArgs e)
    {
        _presentador.OnBotonBuscar();
    }

    protected void SelectContacto(object sender, GridViewSelectEventArgs e)
    {
        _presentador.uxObjectConsultaContactoSelecting
                            (uxConsultaContacto.DataKeys[e.NewSelectedIndex].Value.ToString());
    }

    protected void uxGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowIndex % 2 == 0)
            e.Row.BackColor = System.Drawing.Color.FromName("#FFFFCC");
    }

    protected void uxBotonEliminar_Click(object sender, EventArgs e)
    {
        _presentador.OnBotonEliminar();
    }

    protected void uxBotonCancelar_Click(object sender, EventArgs e)
    {
        _presentador.OnBotonCancelar();
    }

    public void CambiarPagina()
    {
       
        Response.Redirect(paginaEliminar);
        
    }

    protected void uxValor_TextChanged(object sender, EventArgs e)
    {

    }

    #endregion
}