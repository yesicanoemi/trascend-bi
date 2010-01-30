using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Cliente.Contrato
{
    public interface IModificarCliente
    {
        TextBox NombreCliente { get; set; }
        RadioButtonList RbCampoBusqueda { get; set; }
    }
}
