using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Cargo.Contrato
{
    public interface IAgregarCargo
    {
        #region Informacion Basica
        TextBox NombreCargo { get; set; }
        TextBox DescripcionCargo { get; set; }
        DropDownList RangoSueldo { get; set; }
        TextBox VigenciaSueldo { get; set; }
        TextBox Inflacion { get; set; }
        #endregion
    }
}
