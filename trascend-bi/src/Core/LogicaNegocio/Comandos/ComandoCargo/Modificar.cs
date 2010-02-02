using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.LogicaNegocio.Excepciones;

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
            try
            {
                DAOCargoSQLServer bd = new DAOCargoSQLServer();
                bd.ModificarCargo(_cargo);
            }
            catch (Exception e)
            {
                throw new ModificarException();
            }
        }
    }
}
