using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Gasto.Contrato
{
    public interface IIngresarGasto
    {
        #region Datos del Gasto
        TextBox DescripcionGasto { get; set; }
        TextBox FechaGasto { get; set; }
        TextBox MontoGasto { get; set; }
        TextBox EstadoGasto { get; set; }
        TextBox TipoGasto { get; set; }
        DropDownList PropuestaAsociada { get; set; }
        #endregion
    }
}