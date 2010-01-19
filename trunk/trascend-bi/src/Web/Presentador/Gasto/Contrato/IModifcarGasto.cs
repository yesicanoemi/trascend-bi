using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;

namespace Presentador.Gasto.Contrato
{
    public interface IModifcarGasto
    {
        #region Datos del Gasto

        Label LTipoConsulta { get; set; }
        DropDownList TipoConsulta { get; set; }
        Label LSeleccion { get; set; }
        DropDownList SeleccionDato { get; set; }
        Label LFechaGasto { get; set; }
        TextBox FechaGasto { get; set; }
        GridView GridViewConsultaGasto { get; set; }
        ObjectContainerDataSource GetObjectContainerConsultaGasto { get; set; }

        #endregion
    }
}
