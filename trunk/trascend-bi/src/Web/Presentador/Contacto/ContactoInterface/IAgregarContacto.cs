using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Contacto.ContactoInterface
{
    public interface IAgregarContacto
    {
        
            TextBox TextBoxNombreContacto { get; set; }
            TextBox TextBoxApellidoContacto { get; set; }
            TextBox TextBoxCargoContacto { get; set; }
            TextBox TextBoxAreaNegocio { get; set; }
            TextBox TextBoxTelfOficina { get; set; }
            TextBox TextBoxTelfCelular { get; set; }
            TextBox TextBoxCodOficina { get; set; }
            TextBox TextBoxCodCelular { get; set; }
    }
}
