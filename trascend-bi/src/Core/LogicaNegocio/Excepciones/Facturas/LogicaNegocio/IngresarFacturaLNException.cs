﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Facturas.LogicaNegocio
{
    public class IngresarFacturaLNException : IngresarException
    {
        public IngresarFacturaLNException(string s, Exception e)
            : base(s, e)
        {

        }
        public IngresarFacturaLNException()
        {

        }
    }
}