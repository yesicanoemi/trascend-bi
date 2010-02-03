using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;

namespace Presentador.Reportes.Contrato
{
    //Facturas Por Cobrar Anuales
    public interface IReporteEquipo8c
    {
        #region Informacion Basica
        GridView FacturasPorCobrar { get; set; }
        DropDownList Anios { get; set; }
        ObjectContainerDataSource GetObjectContainerReporte8c { get; set; }
        Label LabelContador { get; set; }

        #endregion

    }
}
