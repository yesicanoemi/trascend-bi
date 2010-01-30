using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Propuesta.AccesoDatos
{
    public class ReportePropuestaBdException : ReportesException
    {
        public ReportePropuestaBdException()
        {

        }
        public ReportePropuestaBdException(string s, Exception e)
            : base(s, e)
        {

        }
    }
}
