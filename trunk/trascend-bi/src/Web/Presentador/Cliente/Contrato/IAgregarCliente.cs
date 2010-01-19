﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Cliente.Contrato
{
    public interface IAgregarCliente
    {
        #region informacion Basicas
        TextBox rifCliente { get; set; }
        TextBox NombreCliente { get; set; }
        TextBox CalleAvenidaCliente { get; set; }
        TextBox UrbanizacionCliente { get; set; }
        TextBox EdificioCasaCliente { get; set; }
        TextBox PisoApartamentoCliente { get; set; }
        DropDownList CiudadCliente { get; set; }
        DropDownList AreaNegocioCliente { get; set; }
        TextBox TelefonoTrabajoCliente { get; set; }
        TextBox CodigoTrabajoCliente { get; set; }
        
        #endregion

    }
}
