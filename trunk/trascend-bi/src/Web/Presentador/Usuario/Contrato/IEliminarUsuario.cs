﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Usuario.Contrato
{
    public interface IEliminarUsuario
    {
        DropDownList UsuarioEliminar { get; set; }
        void Volver();
    }
   
}