using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Cliente.LogicaNegocio
{
    /// <summary>
    /// Clase que modela una excepcion de Consultar
    /// </summary>
    public class ConsultarClienteLNException : ApplicationException
    {
        public ConsultarClienteLNException() { }

        public ConsultarClienteLNException(string s, Exception e) : base(s, e)
        {

        }

    }
}