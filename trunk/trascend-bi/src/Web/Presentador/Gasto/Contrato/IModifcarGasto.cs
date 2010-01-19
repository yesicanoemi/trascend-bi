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
        MultiView MultiViewConsultar { get; set; }
        GridView GridViewModificarGasto { get; set; }
        ObjectContainerDataSource GetObjectContainerModificarGasto { get; set; }

        TextBox DescripcionGasto { get; set; }
        TextBox FechaGasto2 { get; set; }
        TextBox MontoGasto { get; set; }
        TextBox EstadoGasto { get; set; }
        TextBox TipoGasto { get; set; }
        DropDownList PropuestaAsociada { get; set; }
        CheckBox AsociarPropuestaGasto { get; set; }
        Label MensajeError { get; set; }

        void CambiarPagina();

        #endregion
    }
}
