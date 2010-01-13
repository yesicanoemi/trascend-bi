using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Contacto.ContactoInterface;
using Presentador.Contacto.ContactoPresentador;

public partial class Paginas_Contactos_AgregarContactos : System.Web.UI.Page, IAgregarContacto
{
    private AgregarPresentador _presentador;


    public TextBox TextBoxNombreContacto
    {
        get { return uxNombreContacto; }
        set { uxNombreContacto = value; }
    }

    public TextBox TextBoxApellidoContacto
    {
        get { return uxApellidoContacto; }
        set { uxApellidoContacto = value; }
    }

    public DropDownList DropDownCargoContacto
    {
        get { return uxCargoContacto; }
        set { uxCargoContacto = value; }
    }

    public DropDownList DropDownAreaNegocio
    {
        get { return uxAreaNegocio; }
        set { uxAreaNegocio = value; }
    }

    public TextBox TextBoxTelfOficina
    {
        get { return uxTelfOficina; }
        set { uxTelfOficina = value; }
    }

    public TextBox TextBoxTelfCelular
    {
        get { return uxTelfCelular; }
        set { uxTelfCelular = value; }
    
    }
    public DropDownList DropDownCliente
    {
        get { return uxCliente; }
        set { uxCliente = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        _presentador = new AgregarPresentador(this);
    }

    protected void Aceptar_Click(object sender, EventArgs e)
    {
        _presentador.Onclick();
    }
}
