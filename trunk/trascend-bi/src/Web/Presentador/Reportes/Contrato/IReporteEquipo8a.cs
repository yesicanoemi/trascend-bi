using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;
namespace Presentador.Reportes.Contrato
{
    //Facturas Emitidas Anuales
    public interface IReporteEquipo8a
    {
        #region Informacion Basica
        GridView FacturasEmitidas { get; set; }
        DropDownList Anios { get; set; }
        ObjectContainerDataSource GetObjectContainerReporte8a { get; set; }
        //ObjectContainerDataSource
        #endregion
    }
}
