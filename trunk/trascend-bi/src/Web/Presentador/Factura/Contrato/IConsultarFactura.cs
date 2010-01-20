using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Factura.Contrato
{
    public interface IConsultarFactura
    {
        RadioButtonList RadioButtons { get; set; }
        TextBox PropuestaBuscar { get; set; }
        GridView ResultadoPropuesta { get; set; }
        GridView ResultadoFacturas { get; set; }
        Button BotonBusqueda { get; set; }
        Label MontoTotal { get; set; }
        Label PorcentajeTotal { get; set; }
        Label MontoFaltante { get; set; }
        Label PorcentajeFaltante { get; set; }

        void Mensaje(string msg);
    }
}
