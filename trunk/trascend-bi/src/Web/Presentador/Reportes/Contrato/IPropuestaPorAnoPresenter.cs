using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Reportes.Contrato
{
    public interface IPropuestaPorAnoPresenter
    {
        GridView Grid { get; set; }

        Button Boton { get; set; }

        DropDownList List { get; set; }
    }
}
