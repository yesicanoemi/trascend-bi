using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Facturas.AccesoDatos
{
    class InsertarFacturaADException: IngresarException
    {
        public InsertarFacturaADException(string s, Exception e): base(s, e)
        {
            s += ". En la capa de Acceso a Datos ingresando una factura.";
        }
    }
}
