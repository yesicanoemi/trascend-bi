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

    public Table TablaResultados
    {
        get { return uxTablaResultados; }
        set { uxTablaResultados = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Aceptar_Click(object sender, EventArgs e)
    {
        _presentador.Onclick();
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
