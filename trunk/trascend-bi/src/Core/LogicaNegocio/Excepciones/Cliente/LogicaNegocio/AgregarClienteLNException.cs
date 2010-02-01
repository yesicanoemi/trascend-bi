using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Cliente.LogicaNegocio
{
    /// <summary>
    /// Clase que modela una excepcion de Ingresar
    /// </summary>
    public class AgregarClienteLNException : ApplicationException
    {
        public AgregarClienteLNException() { }

        public AgregarClienteLNException(string s, Exception e) : base(s, e)
        {

        }

    }
}