using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Comandos.ComandoCargo;
using Core.LogicaNegocio.Entidades;

namespace Core.LogicaNegocio.Fabricas
{
    public class FabricaComandoCargo
    {
        public static Ingresar CrearComandoIngresar(Cargo cargo)
        {
            return new Ingresar(cargo);
        }

        public static Modificar CrearComandoModificar(Cargo cargo)
        {
            return new Modificar(cargo);
        }

        public static Eliminar CrearComandoEliminar(Cargo cargo)
        {
            return new Eliminar(cargo);
        }

        public static Eliminar CrearComandoEliminar(int idCargo)
        {
            return new Eliminar(idCargo);
        }

        public static Consultar CrearComandoConsultar(Cargo cargo)
        {
            return new Consultar(cargo);
        }
    }
}
