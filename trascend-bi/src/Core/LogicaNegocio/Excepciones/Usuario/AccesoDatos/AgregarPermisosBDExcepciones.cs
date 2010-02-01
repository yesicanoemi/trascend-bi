using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Excepciones.Usuario.AccesoDatos
{
    class AgregarPermisosBDExcepciones : PermisoException
    {
        public AgregarPermisosBDExcepciones()
        {

        }

        public AgregarPermisosBDExcepciones(string s, Exception e)
            : base(s, e)
        {

        }
    }
}
