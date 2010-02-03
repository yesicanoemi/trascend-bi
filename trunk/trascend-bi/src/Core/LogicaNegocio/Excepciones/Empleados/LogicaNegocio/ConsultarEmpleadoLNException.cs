using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Empleados.LogicaNegocio
{
    public class ConsultarEmpleadoLNException : ApplicationException
    {
        public ConsultarEmpleadoLNException()
        {

        }

        public ConsultarEmpleadoLNException(string s, Exception e)
            : base(s,e)
        { 

        }
    }
}
