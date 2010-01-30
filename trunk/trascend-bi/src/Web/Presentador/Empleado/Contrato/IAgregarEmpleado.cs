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
        TextBox AvenidaEmpleado { get; set; }
        TextBox CalleEmpleado { get; set; }
        TextBox CiudadEmpleado { get; set; }
        TextBox UrbanizacionEmpleado { get; set; }
        TextBox EdificioEmpleado { get; set; }
        TextBox PisoEmpleado { get; set; }
        string RangoSueldo { get; set; }
        bool RangoVisible { get; set; }
        DropDownList ComboCargos { get; set; }
        #endregion
        #region Dialogo
        bool DialogoVisible { get; set; }
        void Pintar(string codigo, string mensaje, string actor, string detalles);
        void PintarInformacion(string mensaje, string estilo);
        #endregion
    }
}