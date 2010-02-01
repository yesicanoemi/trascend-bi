using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Presentador.Gasto.Contrato
{
    public interface IIngresarGasto
    {
        #region Datos del Gasto
        TextBox DescripcionGasto { get; set; }
        TextBox FechaGasto { get; set; }
        TextBox MontoGasto { get; set; }
        DropDownList EstadoGasto { get; set; }
        DropDownList TipoGasto { get; set; }
        ListBox PropuestaAsociada { get; set; }
        CheckBox AsociarPropuestaGasto { get; set; }
        Label MensajeError { get; set; }
        HtmlTable Datos { get; set; }
        #endregion
    }
}