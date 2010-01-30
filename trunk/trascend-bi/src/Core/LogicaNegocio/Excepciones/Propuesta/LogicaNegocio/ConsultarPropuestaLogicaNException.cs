using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Propuesta.LogicaNegocio
{
    public class ConsultarPropuestaLogicaNException : ConsultarException
    {
        public ConsultarPropuestaLogicaNException(string s, Exception e)
            : base(s, e)
        {

        }
    }
}
