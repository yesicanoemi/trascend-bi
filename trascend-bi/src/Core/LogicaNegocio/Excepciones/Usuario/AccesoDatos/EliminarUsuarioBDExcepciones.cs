using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Usuario.AccesoDatos
{
    class EliminarUsuarioBDExcepciones:EliminarException
    {
        public EliminarUsuarioBDExcepciones()
        { 
        
        }

        public EliminarUsuarioBDExcepciones(string s, Exception e)
            : base(s, e)
        { 

        }
    }
}
