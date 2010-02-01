using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Usuario.AccesoDatos
{
    class AgregarUsuarioBDExcepciones:IngresarException
    {
        public AgregarUsuarioBDExcepciones()
        { 
        
        }

        public AgregarUsuarioBDExcepciones(string s, Exception e)
            : base(s, e)
        { 

        }
    }
}
