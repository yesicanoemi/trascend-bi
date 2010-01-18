using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Facturas.AccesoDatos
{
    class ModificarFacturaADException: ModificarException
    {
        public ModificarFacturaADException(string s, Exception e) : base(s, e)
        {
            s += ". En la capa de Acceso a Datos modificando una factura.";
        }
    }
}
