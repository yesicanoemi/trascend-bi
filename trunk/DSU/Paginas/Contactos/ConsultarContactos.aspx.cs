using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Contacto.ContactoInterface;
using Presentador.Contacto.ContactoPresentador;

public partial class Paginas_Contactos_ConsultarContactos : System.Web.UI.Page, IConsultarContacto
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

        public TextBox TextBoxCedula
        {
            get { return uxConsultaCedulaContacto; }
            set { uxConsultaCedulaContacto = value; }
        }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        _presentador = new ConsultarPresentador(this);
    }

    protected void Aceptar_Click(object sender, EventArgs e)
    {
        _presentador.Onclick();
    }
}
