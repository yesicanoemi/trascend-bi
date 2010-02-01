using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Usuario.AccesoDatos
{
    class ConsultarUsuarioBDExcepciones: ConsultarException
    {

        public ConsultarUsuarioBDExcepciones()
        { 
        
        }

        public ConsultarUsuarioBDExcepciones(string s, Exception e)
            : base(s, e)
        { 

        }
    }
}
