using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoCargo
{
    public class Modificar : Comando<Cargo>
    {
        private Cargo _cargo;

        /// <summary>
        /// Constructor del comando
        /// </summary>
        /// <param name="cargo">el cargo a modificar</param>
        public Modificar(Cargo cargo)
        {
            this._cargo = cargo;
        }

        /// <summary>
        /// Metodo de ejecucion de modificacion de cargo
        /// </summary>
        /// <returns>El cargo con valores modificados</returns>
        public void Ejecutar()
        {
            /*CargoSQLServer bd = new CargoSQLServer();
             * AQUI SE DEBE HACER LA LLAMADA CON EL NUEVO PATRON DAO.
            bd.ModificarCargo(_cargo);*/
        }
    }
}
