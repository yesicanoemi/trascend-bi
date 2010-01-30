using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;

namespace Presentador.Empleado.Contrato
{
    public interface IEliminarEmpleado
    {
        DropDownList opcion { get; set; }
        DropDownList SeleccionCargo { get; set; }
        MultiView MultiViewConsultar { get; set; }
        GridView GridViewConsultarEmpleado { get; set; }
        ObjectContainerDataSource GetOCConsultarEmp { get; set; }
        TextBox TextBoxParametro { get; set; }
        Label LabelSelec { get; set; }
        Label LabelParametro { get; set; }
    }
}