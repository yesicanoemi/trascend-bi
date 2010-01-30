using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Propuesta.AccesoDatos
{
    public class ConsultarPropuestaBDException : ConsultarException
    {
        public ConsultarPropuestaBDException()
        {

        }
        public ConsultarPropuestaBDException(string s, Exception e)
            : base(s, e)
        {

        }
    }
}
