﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Factura.Contrato
{
    public interface IModificarFactura
    {
        TextBox NumeroFactura { get; set; }
        GridView DetalleFactura { get; set; }
    }
}
