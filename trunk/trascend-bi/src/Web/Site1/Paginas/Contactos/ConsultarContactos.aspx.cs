using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Contacto.ContactoInterface;
using Presentador.Contacto.ContactoPresentador;

public partial class Paginas_Contactos_ConsultarContactos : PaginaBase, IConsultarContacto
{
    

        private ConsultarPresentador _presentador;


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
            if (usuario.PermisoUsu[i].IdPermiso == 10)
            {
                i = usuario.PermisoUsu.Count;

                _presentador = new ConsultarPresentador(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }
    }
}
