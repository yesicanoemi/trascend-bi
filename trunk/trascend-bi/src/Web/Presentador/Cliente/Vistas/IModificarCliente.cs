﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Cliente.ClienteInterface
{
    public interface IModificarCliente
    {

        TextBox TextBoxNombre { get; set; }
        TextBox TextBoxApellido { get; set; }
        TextBox TextBoxRif { get; set; }
        
    }
}
