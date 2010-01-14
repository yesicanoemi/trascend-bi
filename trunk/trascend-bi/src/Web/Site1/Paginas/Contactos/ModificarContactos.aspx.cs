using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Contacto.ContactoInterface;
using Presentador.Contacto.ContactoPresentador;

public partial class Paginas_Contactos_ModificarContactos : System.Web.UI.Page, IModificarContacto
{
    private ModificarPresentador _presentador;


    public TextBox TextBoxNombre
    {
        get { return uxModificarNombreContacto; }
        set { uxModificarNombreContacto = value; }
    }

    public TextBox TextBoxApellido
    {
        get { return uxModificarApellidoContacto; }
        set { uxModificarApellidoContacto = value; }
    }

    public TextBox TextBoxCedula
    {
        get { return uxModificarCedulaContacto; }
        set { uxModificarCedulaContacto = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        _presentador = new ModificarPresentador(this);
    }

    protected void Aceptar_Click(object sender, EventArgs e)
    {
        _presentador.Onclick();
    }
}
