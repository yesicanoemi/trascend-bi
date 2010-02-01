using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Usuario.AccesoDatos
{
    class ModificarUsuarioBDExcepciones: ModificarException
    {
         public ModificarUsuarioBDExcepciones()
        { 
        
        }

         public ModificarUsuarioBDExcepciones(string s, Exception e)
            : base(s, e)
        { 

        }
    }
}
