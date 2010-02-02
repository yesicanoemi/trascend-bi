using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Usuario.AccesoDatos
{
    class ConsultarPermisosBDExcepciones: PermisoException
    {
         public ConsultarPermisosBDExcepciones()
        { 
        
        }

         public ConsultarPermisosBDExcepciones(string s, Exception e)
            : base(s, e)
        { 

        }
    }
}
