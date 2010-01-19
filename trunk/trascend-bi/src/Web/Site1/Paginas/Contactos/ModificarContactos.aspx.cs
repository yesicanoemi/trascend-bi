using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Contacto.ContactoInterface;
using Presentador.Contacto.ContactoPresentador;

public partial class Paginas_Contactos_ModificarContactos : PaginaBase, IModificarContacto
{
    private ModificarPresentador _presentador;


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
    //////////
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

    public CheckBox CheckBoxNombre
    {
        get { return uxCheckBoxNombre; }
        set { uxCheckBoxNombre = value; }
    }

    public CheckBox CheckBoxApellido
    {
        get { return uxChecBoxApellido; }
        set { uxChecBoxApellido = value; }
    }

    public CheckBox CheckBoxTelefono
    {
        get { return uxCheckBoxTelefono; }
        set { uxCheckBoxTelefono = value; }
    }

    public Table TablaResultados
    {
        get { return uxTablaResultado; }
        set { uxTablaResultado = value; }
    }

    public TextBox TextBoxBusqueda
    {
        get { return uxTextBoxOpcion; }
        set { uxTextBoxOpcion = value; }
    }

    /* 8888888888888888888888888888888888888 */

    public TextBox TextBoxNombreModificar
    {
        get { return uxNombreModificar; }
        set { uxNombreModificar = value; }
    }

    public TextBox TextBoxApellidoModificar
    {
        get { return uxApellidoModificar; }
        set { uxApellidoModificar = value; }
    }
    //////////
    public TextBox TextBoxCodTelefonoModificar
    {
        get { return uxCodOficinaModificar; }
        set { uxCodOficinaModificar = value; }
    }

    public TextBox TextBoxNumTelefonoModificar
    {
        get { return uxTelfOficinaModificar; }
        set { uxTelfOficinaModificar = value; }
    }

    public TextBox TextBoxCodCelModificar
    {
        get { return uxCodCelModificar; }
        set { uxCodCelModificar = value; }
    }

    public TextBox TextBoxNumCelModificar
    {
        get { return uxTelfCelularModificar; }
        set { uxTelfCelularModificar = value; }
    }

    public TextBox TextBoxAreaNegocioModificar
    {
        get { return uxAreaNegocioModificar; }
        set { uxAreaNegocioModificar = value; }
    }

    public TextBox TextBoxCargoModificar
    {
        get { return uxCargoModificar; }
        set { uxCargoModificar = value; }
    }

    public CheckBox CheckBoxFaxModificar
    {
        get { return uxFaxModificar; }
        set { uxFaxModificar = value; }
    }

    /* 8888888888888888888888888888888888888 */

    public Button BotonBuscar
    {
        set { uxBotonBuscar = value; }
        get { return uxBotonBuscar; }
    }

    public Label LabelBuscar
    {
        set { uxLabelBusqueda = value; }
        get { return uxLabelBusqueda; }
    }

    public Button BotonModificar
    {
        set { uxBotoModificar = value; }
        get { return uxBotoModificar; }
    }

    public MultiView MultiViewModificar
    {
        get { return uxMultiViewModificar; }
        set { uxMultiViewModificar = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Aceptar_Click(object sender, EventArgs e)
    {
        _presentador.Onclick();
    }

    protected void BuscarClick(object sender, EventArgs e)
    {
        _presentador.OnClickBusqueda();
    }

    protected void ModificarClick(object sender, EventArgs e)
    {
        _presentador.onClickConfirmar();
    }

    protected void Page_Init(object sender, EventArgs e)
    {

        Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 11)
            {
                i = usuario.PermisoUsu.Count;

                _presentador = new ModificarPresentador(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }
    }
}
