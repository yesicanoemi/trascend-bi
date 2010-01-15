using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Contacto.ContactoInterface;

namespace Presentador.Contacto.ContactoPresentador
{
    public class ConsultarPresentador
    {
        
            private IConsultarContacto _vista;

            public ConsultarPresentador(IConsultarContacto vista)
            {
                _vista = vista;
            }
            public void Onclick()
            {
                string x=_vista.TextBoxNombre.Text;
                _vista.TextBoxNombre.Text = _vista.TextBoxApellido.Text;
                _vista.TextBoxApellido.Text = x;
            }
        }
    
}
