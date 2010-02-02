using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Core.LogicaNegocio.Excepciones.Empleados.AccesoDatos
{
    class IngresarEmpleadoBDExepciones:IngresarException
    {
        public IngresarEmpleadoBDExepciones()
        { 
        
        }

        public IngresarEmpleadoBDExepciones(string s, Exception e)
            : base(s, e)
        { 

        }
    }
}