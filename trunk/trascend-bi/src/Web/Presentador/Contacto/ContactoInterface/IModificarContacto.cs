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
        TextBox TextBoxCodTelefono { get; set; }
        TextBox TextBoxNumTelefono { get; set; }
        CheckBox CheckBoxNombre { get; set; }
        CheckBox CheckBoxApellido { get; set; }
        CheckBox CheckBoxTelefono { get; set; }
        Table TablaResultados { get; set; }
        TextBox TextBoxBusqueda { get; set; }
        Button BotonBuscar { set; get; }
        Label LabelBuscar { set; get; }
        Button BotonModificar { set; get; }
        MultiView MultiViewModificar { get; set; }

        TextBox TextBoxNombreModificar { get; set; }
        TextBox TextBoxApellidoModificar { get; set; }
        TextBox TextBoxCodTelefonoModificar { get; set; }
        TextBox TextBoxNumTelefonoModificar { get; set; }
        TextBox TextBoxCodCelModificar { get; set; }
        TextBox TextBoxNumCelModificar { get; set; }
        TextBox TextBoxAreaNegocioModificar {get; set;}
        TextBox TextBoxCargoModificar { get; set; }
        CheckBox CheckBoxFaxModificar { get; set; }
            
    }
}
