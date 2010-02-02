using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Presentador.Gasto.Contrato
{
    public interface IEliminarGasto
    {
        #region Datos del Gasto

        Label LTipoConsulta { get; set; }
        Label LabelInfo { get; set; }
        TextBox BusquedaConsulta { get; set; }
        RadioButtonList CheckOpcionBuscar { get; set; }
        Button BotonBuscarDatos { get; set; }
        GridView GridViewConsultaGasto { get; set; }
        GridView GridViewParametro { get; set; }
        ObjectContainerDataSource GetObjectContainerConsultaGasto { get; set; }
        ObjectContainerDataSource GetObjectContainerConsultaGastoSeleccion { get; set; }
        ObjectContainerDataSource GetObjectContainerCliente { get; set; }
        HtmlTable TablaSeleccionGrid { get; set; }
        HtmlTable TablaConsultaParametro { get; set; }
        HtmlTable TablaCliente { get; set; }
        HtmlTable TablaInicio { get; set; }
        Image Calendario { get; set; }
        Label MensajeError { get; set; }

        #endregion
    }
}