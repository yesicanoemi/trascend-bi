using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Cargo.Contrato
{
    public interface IAdministrarCargo
    {
        #region Informacion Basica
        DropDownList NombreCargo { get; set; }
        TextBox DescripcionCargo { get; set; }
        TextBox SueldoMinimo { get; set; }
        TextBox SueldoMaximo { get; set; }
        TextBox VigenciaSueldo { get; set; }
        #endregion
    }
}
