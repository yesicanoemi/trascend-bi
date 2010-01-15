using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Entidades
{
    using System;
    using System.Collections.Generic;

    public class Entidad
    {
        private IList<Empleado> Empleados;

        public virtual IList<Empleado> Empleados
        {
            get
            {
                return Empleados;
            }
            set
            {
                Empleados = value;
            }
        }
    }
}
