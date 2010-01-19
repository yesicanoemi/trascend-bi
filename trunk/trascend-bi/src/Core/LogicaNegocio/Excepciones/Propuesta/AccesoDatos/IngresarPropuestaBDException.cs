using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Propuesta.AccesoDatos
{
    class IngresarPropuestaBDException : IngresarException
    {
        public IngresarPropuestaBDException()
        { 
        
        }

        public IngresarPropuestaBDException(string s, Exception e)
            : base(s, e)
        { 
        
        }

    }
}
