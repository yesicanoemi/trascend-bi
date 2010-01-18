using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Contacto.ContactoInterface;
using Presentador.Contacto.ContactoPresentador;

public partial class Paginas_Contactos_EliminarContactos : System.Web.UI.Page, IEliminarContacto
{


    private EliminarPresentador _presentador;


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

    public Button BotonBuscar
    {
        set { uxBotonBuscar= value; }
        get { return uxBotonBuscar; }
    }

    public Label LabelBuscar
    {
        set { uxLabelBusqueda = value; }
        get { return uxLabelBusqueda; }
    }

    public Label LabelConfirmar
    {
        set { uxLabelConfirmacion = value; }
        get { return uxLabelConfirmacion; }
    }

    public Button BotonEliminar
    {
        set { uxBotonEliminar = value; }
        get { return uxBotonEliminar; }
    }

    public MultiView MultiViewEliminar
    {
        get { return uxMultiViewEliminar; }
        set { uxMultiViewEliminar = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        _presentador = new EliminarPresentador(this);
    }

    protected void Aceptar_Click(object sender, EventArgs e)
    {
        _presentador.Onclick();
    }

    protected void BuscarClick(object sender, EventArgs e)
    {
        _presentador.OnClickBusqueda();
    }

    protected void ConfirmarClick(object sender, EventArgs e)
    {
        _presentador.onClickConfirmar();
    }
}
