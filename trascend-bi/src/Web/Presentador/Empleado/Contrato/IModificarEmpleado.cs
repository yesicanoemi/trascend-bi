using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;

namespace Presentador.Empleado.Contrato
{
    public interface IModificarEmpleado
    {
        TextBox ParametroCedula { get; set; }
        RadioButtonList opcion { get; set; }
        //DropDownList SeleccionCargo { get; set; }
        MultiView MultiViewConsultar { get; set; }
        GridView GridViewConsultarEmpleado { get; set; }
        ObjectContainerDataSource GetOCConsultarEmp { get; set; }
        TextBox TextBoxParametro { get; set; }
        //Label LabelSelec { get; set; }
        //Label LabelParametro { get; set; }
        TextBox TextBoxCI { get; set; }
        TextBox TextBoxNombre { get; set; }
        TextBox TextBoxApellido { get; set; }
        TextBox TextBoxNumCuenta { get; set; }
        TextBox TextBoxFechaNac { get; set; }
        TextBox TextBoxDirCalle { get; set; }
        TextBox TextBoxDirAve { get; set; }
        TextBox TextBoxDirUrb { get; set; }
        TextBox TextBoxDirEdifCasa { get; set; }
        TextBox TextBoxDirPisoApto { get; set; }
        TextBox TextBoxDirCiudad { get; set; }
        DropDownList TextBoxCargo { get; set; }
        Button Aceptar { get; set; }
        TextBox TextBoxSueldoBase { get; set; }
        DropDownList drowListaCargo
        {
            get;
            set;
        }
        DropDownList SeleccionEstado
        {
            get;
            set;
        }

    }


}

