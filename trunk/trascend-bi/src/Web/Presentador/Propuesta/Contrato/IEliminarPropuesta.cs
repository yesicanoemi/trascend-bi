using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentador.Propuesta.Contrato
{
    public interface IEliminarPropuesta
    {
         Label LabelEliminar { get; set; }
         DropDownList ListaPropuesta { get; set; }
         Label LabelEliminarCompletado { get; set; }
    }
}
