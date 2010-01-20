using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Presentador.Reportes.Contrato
{
    public interface IReporteEquipo1a
    {
        RadioButtonList RadioButton { get; set; }
        TextBox TextBoxBusqueda { get; set; }
    }
}
