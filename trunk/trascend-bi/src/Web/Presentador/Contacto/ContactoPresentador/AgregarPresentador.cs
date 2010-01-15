using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Contacto.ContactoInterface;

namespace Presentador.Contacto.ContactoPresentador
{
    public class AgregarPresentador
    {
        
            private IAgregarContacto _vista;

            public AgregarPresentador(IAgregarContacto vista)
            {
                _vista = vista;
            }
            public void Onclick()
            {
                string x = _vista.TextBoxTelfCelular.Text;
                _vista.TextBoxTelfCelular.Text = _vista.TextBoxTelfOficina.Text;
                _vista.TextBoxTelfOficina.Text = _vista.TextBoxApellidoContacto.Text;
                _vista.TextBoxApellidoContacto.Text = _vista.TextBoxNombreContacto.Text;
                _vista.TextBoxNombreContacto.Text = x;
            }
        }
    
}
