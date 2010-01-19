using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Contacto.ContactoInterface
{
    public interface IConsultarContacto
    {
        
            TextBox TextBoxNombre { get; set; }
            TextBox TextBoxApellido { get; set; }
            TextBox TextBoxCodTelefono { get; set; }
            TextBox TextBoxNumTelefono { get; set; }
            CheckBox CheckBoxNombre { get; set; }
            CheckBox CheckBoxApellido { get; set; }
            CheckBox CheckBoxTelefono { get; set; }
            Table TablaResultados { get; set; }
            
    }
}
