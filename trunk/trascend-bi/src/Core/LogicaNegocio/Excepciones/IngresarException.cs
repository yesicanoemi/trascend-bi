using System;

namespace Core.LogicaNegocio.Excepciones
{
    public class IngresarException : ApplicationException
    {
        public IngresarException()
        {
        }
        public IngresarException(string s, Exception e)
            : base(s, e)
        {

        }
    }
}
