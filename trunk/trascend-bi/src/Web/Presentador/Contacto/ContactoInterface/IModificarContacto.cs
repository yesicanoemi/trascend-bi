using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Contacto.ContactoInterface
{
    public interface IModificarContacto
    {
        
            TextBox TextBoxNombre { get; set; }
            TextBox TextBoxApellido { get; set; }
            TextBox TextBoxCedula { get; set; }
            
    }
}
