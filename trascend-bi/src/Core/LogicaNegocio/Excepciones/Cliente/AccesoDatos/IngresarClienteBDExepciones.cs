using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Core.LogicaNegocio.Excepciones.Cliente.AccesoDatos
{
    public class IngresarClienteBDExepciones:IngresarException
    {
        public IngresarClienteBDExepciones()
        { 
        
        }

        public IngresarClienteBDExepciones(string s, Exception e)
            : base(s, e)
        { 

        }
    }
}
