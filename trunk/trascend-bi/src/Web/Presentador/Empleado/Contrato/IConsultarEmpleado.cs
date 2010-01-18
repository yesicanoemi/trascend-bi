using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;

namespace Presentador.Empleado.Contrato
{
    public interface IConsultarEmpleado
    {
        DropDownList opcion { get; set; }
        DropDownList SeleccionCargo { get; set; }
        MultiView MultiViewConsultar { get; set; }
        GridView GridViewConsultarEmpleado { get; set; }
        ObjectContainerDataSource GetOCConsultarEmp { get; set; }
        TextBox TextBoxParametro { get; set; }
        Label LabelSelec { get; set; }
        Label LabelParametro { get; set; }
        Label LabelCI { get; set; }
        Label LabelNombre { get; set; }
        Label LabelApellido { get; set; }
        Label LabelNumCuenta { get; set; }
        Label LabelFechaNac { get; set; }
        Label LabelDireccion { get; set; }
        Label LabelCargo { get; set; }
        Label LabelEstado { get; set; }
    }
}
