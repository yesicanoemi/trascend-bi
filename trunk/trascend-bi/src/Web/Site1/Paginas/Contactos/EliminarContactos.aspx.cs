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
        get { return uxEliminaNombreContacto; }
        set { uxEliminaNombreContacto = value; }
    }

    public TextBox TextBoxApellido
    {
        get { return uxEliminaApellidoContacto; }
        set { uxEliminaApellidoContacto = value; }
    }

    public TextBox TextBoxCedula
    {
        get { return uxEliminaCedulaContacto; }
        set { uxEliminaCedulaContacto = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        _presentador = new EliminarPresentador(this);
    }

    protected void Aceptar_Click(object sender, EventArgs e)
    {
        _presentador.Onclick();
    }
}
