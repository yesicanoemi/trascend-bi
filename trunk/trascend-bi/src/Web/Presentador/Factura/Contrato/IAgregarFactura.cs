using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Factura.Contrato
{
    public interface IAgregarFactura
    {
        //MultiView MultiViewPropuesta { get; set; }
        //   TextBox ProyectoAsociado { get; set; }

        #region InformacionPropuesta


        RadioButtonList RadioButtons { get; set; }
        TextBox PropuestaBuscar { get; set; }
        GridView ResultadoPropuesta { get; set; }
        GridView ResultadoFacturas { get; set; }
        Button BotonBusqueda { get; set; }

        #endregion

        void Mensaje(string msg);
    }
}
