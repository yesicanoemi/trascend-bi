using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Facturas
{
    public class ConsultarFacturaException : ConsultarException
    {
        public ConsultarFacturaException(string s, Exception e):base(s,e)
        {

        }
    }
}
