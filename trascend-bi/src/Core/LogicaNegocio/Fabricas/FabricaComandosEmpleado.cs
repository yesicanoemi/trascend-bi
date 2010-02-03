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

      
        public static ConsultarE CrearComandoConsultarE(IList<Persona> empleado)
        {
            return new ConsultarE(empleado);
        }
        public static ConsultarPorNombre CrearComandoConsultarPorNombre(Empleado empleado)
        {
            return new ConsultarPorNombre(empleado);
        }

        public static ConsultarCargo CrearComandoConsultarCargo(IList<string> cargo)
        {
            return new ConsultarCargo(cargo);
        }

        public static ConsultarPorCI CrearComandoConsultarPorCI(Empleado empleado)
        {
            return new ConsultarPorCI(empleado);
        }

        public static ConsultarPorCargo CrearComandoConsultarPorCargo(Empleado empleado)
        {
            return new ConsultarPorCargo(empleado);
        }

        public static ConsultarEmpleado CrearComandoConsultarEmpleado(Empleado empleado)
        {
            return new ConsultarEmpleado(empleado);
        }

        public static EliminarEmpleado CrearComandoEliminarEmpleado(Empleado empleado)
        {
            return new EliminarEmpleado(empleado);
        }

        public static ConsultarCargoNuevo CrearComandoConsultarCargoNuevo(Cargo cargo)
        {
            return new ConsultarCargoNuevo(cargo);
        }

        public static ConsultarPorCodigo CrearConsultarPorCodigo(Empleado empleado)
        {
            return new ConsultarPorCodigo(empleado);
        }


        public static ConsultarCedula CrearComandoConsultarCedula(int cedula)
        {
            return new ConsultarCedula(cedula);
        }


        public static EliminarConsultarPorCI CrearComandoEliminarConsultarPorCI(Empleado empleado)
        {
            return new EliminarConsultarPorCI(empleado);
        }

        public static ELiminarConsultarPorNombre CrearComandoEliminarConsultarPorNombre(Empleado empleado)
        {
            return new ELiminarConsultarPorNombre(empleado);
     }

        public static EliminarConsultarPorCargo CrearComandoEliminarConsultarPorCargo(Empleado empleado)
        {
            return new EliminarConsultarPorCargo(empleado);
     } 

    }
}
