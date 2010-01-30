using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Contacto.ContactoInterface
{
    public interface IEliminarContacto
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
        Label LabelConfirmar{ set; get; }
        Button BotonEliminar { set; get; }
        MultiView MultiViewEliminar { get; set; }
    }
}