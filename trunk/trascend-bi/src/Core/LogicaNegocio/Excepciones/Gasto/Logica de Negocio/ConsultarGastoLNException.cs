using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Gasto.Logica_de_Negocio
{
    public class ConsultarGastoLNException: ApplicationException
    {
        public ConsultarGastoLNException()
        { }

        public ConsultarGastoLNException(string s, Exception e) : base(s, e) 
        { }
    }
}
