using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Empleados.AccesoDatos
{
    public class ConsultarEmpleadoBDException:ConsultarException
    {
        public ConsultarEmpleadoBDException()
        { 
        }

        public ConsultarEmpleadoBDException(string s, Exception e)
            :  base(s,e)
        {

        }

    }
}
