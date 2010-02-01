using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Presentador.Gasto.Contrato
{
    public interface IModifcarGasto
    {
        #region Datos del Gasto


        TextBox BusquedaConsulta { get; set; }
        RadioButtonList CheckOpcionBuscar { get; set; }
        Label CodigoGasto { get; set; }
        TextBox DescripcionGasto { get; set; }
        TextBox FechaGasto2 { get; set; }
        TextBox MontoGasto { get; set; }
        TextBox EstadoGasto { get; set; }
        TextBox TipoGasto { get; set; }
        Label MensajeError { get; set; }
        GridView GridViewConsultaGasto { get; set; }
        GridView GridViewParametro { get; set; }
        GridView GridViewCliente { get; set; }
        ObjectContainerDataSource GetObjectContainerConsultaGasto { get; set; }
        ObjectContainerDataSource GetObjectContainerConsultaGastoSeleccion { get; set; }
        ObjectContainerDataSource GetObjectContainerCliente { get; set; }   
        MultiView ModificarGasto { get; set; }
        Label LIdVersion { get; set; }
        TextBox FechaIngreso { get; set; }
        Label LabelInfo { get; set; }
        Button BotonBuscarDatos { get; set; }

        #endregion
    }
}
