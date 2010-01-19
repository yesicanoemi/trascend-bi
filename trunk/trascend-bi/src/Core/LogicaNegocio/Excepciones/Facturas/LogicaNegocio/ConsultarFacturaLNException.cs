using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Facturas.LogicaNegocio
{
    public class ConsultarFacturaLNException : ConsultarException
    {
        public ConsultarFacturaLNException(string s, Exception e)
            : base(s, e)
        {

        }
        public ConsultarFacturaLNException()
        {
        }
    }
}

