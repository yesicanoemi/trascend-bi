using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones
{
    public class ReportesException : ApplicationException
    {
        public ReportesException()
        {

        }
        public ReportesException(string s, Exception e)
            : base(s, e)
        {

        }
    }
}
