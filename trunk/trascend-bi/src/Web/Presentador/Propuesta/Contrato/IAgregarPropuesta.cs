using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;


namespace Presentador.Propuesta.Contrato
{
  
    public interface IAgregarPropuesta
    {
        #region Informacion Basica
        
        TextBox Titulo { get; set; }
       
        TextBox Version { get; set; }
        
        TextBox FechaFirma { get; set; }
        
        TextBox NombreReceptor { get; set; }
        
        TextBox ApellidoReceptor { get; set; }
        
        DropDownList CargoReceptor { get; set; }
        
        TextBox FechaInicio { get; set; }
        
        TextBox FechaFin { get; set; }
        //TextBox EquipoTrabajo { get; set; } Ver como se va a pedir esta informacion
        
        TextBox TotalHoras { get; set; }
        
        TextBox MontoTotal { get; set; }
        #endregion

    }
}
