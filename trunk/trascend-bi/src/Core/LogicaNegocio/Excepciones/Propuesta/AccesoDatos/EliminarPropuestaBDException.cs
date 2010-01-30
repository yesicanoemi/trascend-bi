using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Propuesta.AccesoDatos
{
    public class EliminarPropuestaBDException : EliminarException
    {
        public EliminarPropuestaBDException()
        {

        }
        public EliminarPropuestaBDException(string s, Exception e)
            : base(s, e)
        {

        }
    }
}