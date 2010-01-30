using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones
{
    public class EliminarException : ApplicationException
    {
        public EliminarException()
        {

        }

        public EliminarException(string s) : base(s)
        {

        }

        public EliminarException(string s, Exception e) : base(s, e)
        {

        }
    }
}
