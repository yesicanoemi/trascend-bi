using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Cliente.AccesoDatos
{
    class ConsultarClienteBDExcepciones:ConsultarException
    {
        public ConsultarClienteBDExcepciones()
        {
        
        }

        public ConsultarClienteBDExcepciones(string s, Exception e)
            : base(s,e)
        { 
            
        }
    }
}
