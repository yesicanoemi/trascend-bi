﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Cargo.Contrato
{
    public interface IAgregarCargo
    {
        #region Informacion Basica
        TextBox NombreCargo { get; set; }
        TextBox DescripcionCargo { get; set; }
        TextBox SueldoMinimo { get; set; }
        TextBox SueldoMaximo { get; set; }
        TextBox VigenciaSueldo { get; set; }
        Label LabelError { get; set; }
        GridView VistaCargo { get; set; }
        #endregion

        #region Metodos
        void Mensaje(string mensaje);
        #endregion
    }
}