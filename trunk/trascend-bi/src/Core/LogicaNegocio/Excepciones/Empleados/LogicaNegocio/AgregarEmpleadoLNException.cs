using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Empleados.LogicaNegocio
{
    public class AgregarEmpleadoLNException : ApplicationException
    {
        public AgregarEmpleadoLNException() { }

        public AgregarEmpleadoLNException(string s, Exception e) : base(s, e)
        {

        }
    }
}
