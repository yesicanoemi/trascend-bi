using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Reportes.Contrato
{
    public interface IReporteFacturasPorCobrar
    {
        #region Propiedades
        TextBox FechaInicio { get; set; }
        TextBox FechaFin { get; set; }
        Button Boton { get; set; }
        GridView Grid { get; set; }
        #endregion

        void Mensaje(string mensaje);
    }
}
