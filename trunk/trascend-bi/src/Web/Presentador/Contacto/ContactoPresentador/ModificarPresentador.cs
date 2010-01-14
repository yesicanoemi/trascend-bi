using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Contacto.ContactoInterface;

namespace Presentador.Contacto.ContactoPresentador
{
    public class ModificarPresentador
    {
        
            private IModificarContacto _vista;

            public ModificarPresentador(IModificarContacto vista)
            {
                _vista = vista;
            }
            public void Onclick()
            {
    //            string x=_vista.TextBoxNombre.Text;
    //            _vista.TextBoxNombre.Text = _vista.TextBoxApellido.Text;
    //            _vista.TextBoxApellido.Text = x;
            }
        }
    
}
