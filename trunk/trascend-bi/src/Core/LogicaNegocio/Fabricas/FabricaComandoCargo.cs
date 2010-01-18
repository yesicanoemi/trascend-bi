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
        /// <summary>
        /// Metodo para crear el comando para ingresar
        /// </summary>
        /// <param name="cargo">El cargo</param>
        /// <returns>El comando</returns>
        public static Ingresar CrearComandoIngresar(Cargo cargo)
        {
            return new Ingresar(cargo);
        }

        /// <summary>
        /// Metodo para crear el comando para Modificar
        /// </summary>
        /// <param name="cargo">El cargo</param>
        /// <returns>El comando</returns>
        public static Modificar CrearComandoModificar(Cargo cargo)
        {
            return new Modificar(cargo);
        }

        /// <summary>
        /// Metodo para crear el comando para Eliminar
        /// </summary>
        /// <param name="cargo">El cargo</param>
        /// <returns>El comando</returns>
        public static Eliminar CrearComandoEliminar(Cargo cargo)
        {
            return new Eliminar(cargo);
        }

        /// <summary>
        /// Metodo para crear el comando para ingresar
        /// </summary>
        /// <param name="cargo">El id del cargo</param>
        /// <returns>El comando</returns>
        public static Eliminar CrearComandoEliminar(int idCargo)
        {
            return new Eliminar(idCargo);
        }

        /// <summary>
        /// Metodo para crear el comando para Consultar
        /// </summary>
        /// <param name="cargo">El cargo</param>
        /// <returns>El comando</returns>
        public static Consultar CrearComandoConsultar(Cargo cargo)
        {
            return new Consultar(cargo);
        }

        /// <summary>
        /// Metodo para crear el comando para ConsultarTodos los cargos
        /// </summary>
        /// <returns>El comando</returns>
        public static ConsultarTabla CrearComandoConsultarTabla()
        {
            return new ConsultarTabla();
        }
    }
}
