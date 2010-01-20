using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;

namespace Presentador.Gasto.Contrato
{
    public interface IConsultarGasto
    {
        #region Datos del Gasto

        Label LTipoConsulta { get; set;}       
        TextBox BusquedaConsulta { get; set;}
        RadioButtonList CheckOpcionBuscar { get; set; }       
        Button BotonBuscarDatos { get; set; }        
        GridView GridViewConsultaGasto {get; set;}
        ObjectContainerDataSource GetObjectContainerConsultaGasto { get; set; }
        
        #endregion
    }
}
