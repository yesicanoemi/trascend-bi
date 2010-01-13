using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Empleado.Contrato
{
    public interface IAgregarEmpleado
    {
        #region Informacion Basica
        TextBox NombreEmpleado { get; set; }
        TextBox ApellidoEmpleado { get; set; }
        TextBox CedulaEmpleado { get; set; }
        TextBox CuentaEmpleado { get; set; }
        TextBox SueldoEmpleado { get; set; }
        TextBox FechaNacEmpleado { get; set; }
        TextBox DireccionEmpleado { get; set; }
        TextBox FechaIngresoEmpleado { get; set; }
        TextBox FechaEgresoEmpleado { get; set; }
        #endregion
    }
}