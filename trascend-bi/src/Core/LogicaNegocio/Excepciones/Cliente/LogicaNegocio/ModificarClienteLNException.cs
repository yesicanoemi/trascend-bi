using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Cliente.LogicaNegocio
{
    /// <summary>
    /// Clase que modela una excepcion de Modificar
    /// </summary>
    public class ModificarClienteLNException : ApplicationException
    {
        public ModificarClienteLNException() { }

        public ModificarClienteLNException(string s, Exception e) : base(s, e)
        {

        }

    }

}