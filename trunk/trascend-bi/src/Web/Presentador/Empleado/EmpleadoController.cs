using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.Servicios.Implementacion;

namespace Presentador.Empleado
{
    public class EmpleadoController
    {
        #region Empleado
        public Core.LogicaNegocio.Entidades.Empleado InsertarEmpleado(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            //Llamado de metodos para la insercion del empleado
            ServicioEmpleado servicio = new ServicioEmpleado();
            return servicio.Ingresar(empleado);
        }
        #endregion
    }
}
