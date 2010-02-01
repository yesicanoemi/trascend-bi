using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones
{
    public class PermisoException : ApplicationException
    {
        public PermisoException()
        {
        }
        public PermisoException(string s, Exception e)
            : base(s, e)
        {

        }
    }
}
