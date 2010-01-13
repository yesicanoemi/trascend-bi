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
            DropDownList DropDownCargoContacto { get; set; }
            DropDownList DropDownAreaNegocio { get; set; }
            TextBox TextBoxTelfOficina { get; set; }
            TextBox TextBoxTelfCelular { get; set; }
            DropDownList DropDownCliente { get; set; }
    }
}
