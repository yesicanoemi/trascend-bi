using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Cliente.AccesoDatos
{
    public class ModificarClienteBDExcepciones : ModificarException
    {
        public ModificarClienteBDExcepciones()
        {

        }

        public ModificarClienteBDExcepciones(string s, Exception e)
            : base(s, e)
        {

        }
    }
}