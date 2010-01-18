using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;


namespace Presentador.Reportes.Contrato
{
    public interface IReporteGastoFecha
    {
        #region Informacion Basica

        TextBox FechaInicio { get; set; }

        TextBox FechaFin { get; set; }

        #endregion
    }
}
