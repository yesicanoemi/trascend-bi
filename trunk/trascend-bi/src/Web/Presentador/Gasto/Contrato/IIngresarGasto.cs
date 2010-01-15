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
        TextBox CodigoGasto { get; set; }
        TextBox EstadoGasto { get; set; }
        TextBox MontoGasto { get; set; }
        TextBox FechaGasto { get; set; }
        TextBox FechaIngresoGasto { get; set; }
        #endregion
    }
}