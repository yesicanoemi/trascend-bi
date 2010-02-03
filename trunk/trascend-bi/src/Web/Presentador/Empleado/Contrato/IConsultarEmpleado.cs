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
        Label MensajeConsulta { get; set; }
        RegularExpressionValidator ERCedula { get; set; }
        RequiredFieldValidator ValidacionCedula { get; set; }
        TextBox ParametroCedula{ get; set;}
        RadioButtonList opcion { get; set; }
        //DropDownList SeleccionCargo { get; set; }
        MultiView MultiViewConsultar { get; set; }
        GridView GridViewConsultarEmpleado { get; set; }
        ObjectContainerDataSource GetOCConsultarEmp { get; set; }
        TextBox TextBoxParametro { get; set; }
        //Label LabelSelec { get; set; }
        //Label LabelParametro { get; set; }
        Label LabelCI { get; set; }
        Label LabelNombre { get; set; }
        Label LabelApellido { get; set; }
        Label LabelNumCuenta { get; set; }
        Label LabelFechaNac { get; set; }
        Label LabelDirCalle { get; set; }
        Label LabelDirAve { get; set; }
        Label LabelDirUrb { get; set; }
        Label LabelDirEdifCasa { get; set; }
        Label LabelDirPisoApto { get; set; }
        Label LabelDirCiudad { get; set; }
        Label LabelCargo { get; set; }
        Label LabelEstado { get; set; }
        Button Aceptar { get; set; }
        Label LabelSueldoBase { get; set; }
        DropDownList drowListaCargo
        {
            get;
            set;
        }

    }
}

