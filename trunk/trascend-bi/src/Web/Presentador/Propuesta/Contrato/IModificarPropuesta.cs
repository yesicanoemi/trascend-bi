using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Propuesta.Contrato
{
    public interface IModificarPropuesta
    {
        DropDownList opcion { get; set; }
        DropDownList SeleccionOpcion { get; set; }
        Label LabelSelec { get; set; }
        Label LabelTipoC { get; set; }
        Label LabelT { get; set; }
        Label LabelV { get; set; }
        Label LabelFFirm { get; set; }
        Label LabelRecep { get; set; }
        Label LabelCarg { get; set; }
        Label LabelFechaI { get; set; }
        Label LabelFechaFi { get; set; }
        Label LabelTotalHoras { get; set; }
        Label LabelMont { get; set; }
        Label LabelEquip { get; set; }
        TextBox TextBoxTP { get; set; }
        TextBox TextBoxVP { get; set; }
        TextBox TextBoxFFirmP { get; set; }
        TextBox TextBoxRecepP { get; set; }
        TextBox TextBoxCargP { get; set; }
        TextBox TextBoxFechaIP { get; set; }
        TextBox TextBoxFechaFiP { get; set; }
        TextBox TextBoxTotalHorasP { get; set; }
        TextBox TextBoxMontP { get; set; }
        ListBox ListaEmpleados { get; set; }
    }
}
