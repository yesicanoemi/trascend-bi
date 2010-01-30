using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Reportes.Contrato
{
    public interface IReportePaqueteCargoAnual
    {
        #region Propiedades
        DropDownList SeleccionCargo { get; set; }
        Table TablaSolucion { get; set; }
        #endregion
    }
}