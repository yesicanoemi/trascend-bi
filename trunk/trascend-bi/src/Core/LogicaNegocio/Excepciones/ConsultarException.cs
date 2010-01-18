using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones
{
    public class ConsultarException : ApplicationException
    {
        public ConsultarException(string s, Exception e)
            : base(s, e)
        {

        }
    }
}
