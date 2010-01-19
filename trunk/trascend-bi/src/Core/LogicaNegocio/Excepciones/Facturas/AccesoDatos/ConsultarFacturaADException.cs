using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Facturas.AccesoDatos
{
    public class ConsultarFacturaADException : ConsultarException
    {
        public ConsultarFacturaADException()
        {

        }
        public ConsultarFacturaADException(string s, Exception e): base(s, e)
        {

        }
    }
}
