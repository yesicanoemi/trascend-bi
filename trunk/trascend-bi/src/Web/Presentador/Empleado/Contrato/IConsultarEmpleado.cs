using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Empleado.Contrato
{
    public interface IConsultarEmpleado
    {
        DropDownList opcion { get; set; }
        DropDownList SeleccionOpcion { get; set; }
        Label LabelCI { get; set; }
        Label LabelNombre { get; set; }
        Label LabeApellido { get; set; }
        Label LabeNumCuenta { get; set; }
        Label LabeFechaNac { get; set; }
        Label LabelDireccion { get; set; }
        Label LabelCargo { get; set; }
        Label LabelEstado { get; set; }
    }
}
