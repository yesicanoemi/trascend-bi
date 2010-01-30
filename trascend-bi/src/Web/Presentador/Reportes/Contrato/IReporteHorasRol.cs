using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Reportes.Contrato
{
    public interface IReporteHorasRol
    {
        DropDownList SeleccionRol { get; set; }
        DropDownList SeleccionAnio { get; set; }
        Label LabelHoras { get; set; }
        Label LabelTextoHoras { get; set; }
    }
}
