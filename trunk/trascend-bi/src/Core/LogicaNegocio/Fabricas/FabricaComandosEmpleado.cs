using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Comandos.ComandoEmpleado;

namespace Core.LogicaNegocio.Fabricas
{
    public class FabricaComandosEmpleado
    {
        public static Ingresar CrearComandoIngresar(Empleado empleado)
        {
            return new Ingresar(empleado);
        }

        public static Modificar CrearComandoModificar(Empleado empleado)
        {
            return new Modificar(empleado);
        }

        public static Consultar CrearComandoConsultar(IList<Empleado> empleado)
        {
            return new Consultar(empleado);
        }   
    }
}
