using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;

namespace Presentador.Reportes.Contrato
{
    //Facturas Cobradas Anuales
    public interface IReporteEquipo8b
    {
        #region Informacion Basica
        GridView FacturasCobradas { get; set; }
        ObjectContainerDataSource GetObjectContainerReporte8b { get; set; }
        DropDownList Anios { get; set; }
        //ObjectContainerDataSource
        #endregion
    }
}
