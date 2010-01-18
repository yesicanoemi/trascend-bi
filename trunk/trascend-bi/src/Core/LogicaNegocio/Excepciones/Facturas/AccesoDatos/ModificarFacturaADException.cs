using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Facturas.AccesoDatos
{
    public class ModificarFacturaADException: ModificarException
    {
        public ModificarFacturaADException(string s, Exception e) : base(s, e)
        {

        }
    }
}
