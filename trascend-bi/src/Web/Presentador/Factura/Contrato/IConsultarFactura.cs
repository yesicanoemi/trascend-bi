﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Factura.Contrato
{
    public interface IConsultarFactura
    {
        DropDownList ParametroBox { get; set; }
        TextBox ParametroTexto { get; set; }
        MultiView MultiViewFacturas { get; set; }
        Label TituloPropuesta { get; set; }
        Label MontoTotal { get; set; }
        GridView TablaFacturas { get; set; }
        Label Titulo { get; set; }
        Label Descripcion { get; set; }
        Label Porcentaje { get; set; }
        Label FechaIngreso { get; set; }
        Label FechaPago { get; set; }
        Label Estado { get; set; }

        void Mensaje(string msg);
    }
}