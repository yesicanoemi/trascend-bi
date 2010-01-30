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
        Label MontoTotal { get; set; }
        Label PorcentajeTotal { get; set; }
        Label MontoFaltante { get; set; }
        Label PorcentajeFaltante { get; set; }
        
        Label FechaEmision { get; set; }
        Label NumeroFactura { get; set; }
        TextBox Titulo { get; set; }
        TextBox Descripcion { get; set; }
        TextBox PorcentajePagar { get; set; }
        TextBox FechaPago { get; set; }
        TextBox Estado { get; set; }
        TextBox MontoCalculado { get; set; }

        #endregion

        void Mensaje(string msg);
    }
}
