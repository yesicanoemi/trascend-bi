using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;

namespace Presentador.Reportes.Contrato
{
    public interface IReporteGastoAnual
    {
        #region Informacion Basica

        GridView GridViewReporteGastos3a { get; set; }

        ObjectContainerDataSource GetObjectContainerReporteGastos3a { get; set; }

        DropDownList AnioGasto { get; set; }

        Label TotalGastos { get; set; }


        #endregion
        void Mensaje(string msg);
    }
}