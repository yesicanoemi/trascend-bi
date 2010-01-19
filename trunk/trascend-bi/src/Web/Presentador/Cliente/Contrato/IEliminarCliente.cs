using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Cliente.Contrato
{
    public interface IEliminarCliente
    {
        Label LabelEliminar { get; set; }
        DropDownList ListaCliente { get; set; }
        Label LabelEliminarCompletado { get; set; }
    }
}
