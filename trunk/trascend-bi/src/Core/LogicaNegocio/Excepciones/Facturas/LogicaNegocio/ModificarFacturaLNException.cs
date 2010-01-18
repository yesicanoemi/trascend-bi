using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Facturas.LogicaNegocio
{
    class ModificarFacturaLNException : ModificarException
    {
        public ModificarFacturaLNException(string s, Exception e): base(s, e)
        {

        }
    }
}
