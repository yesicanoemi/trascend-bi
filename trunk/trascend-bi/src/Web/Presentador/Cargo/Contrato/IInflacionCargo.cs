﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Cargo.Contrato
{
    public interface IInflacionCargo
    {
        TextBox Inflacion { get; set; }
        GridView TablaSueldos { get; set; }
    }
}
