using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Gasto.Acceso_a_Datos
{
    public class ConsultarGastoBDExceptions: ConsultarException
    {
        public ConsultarGastoBDExceptions()
        { 
        
        }
        public ConsultarGastoBDExceptions(string s, Exception e): base(s,e)
        { 
        
        }
    }
}
