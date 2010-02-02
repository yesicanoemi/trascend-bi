using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoCargo
{
    public class Ingresar : Comando<Cargo>
    {
        private Cargo _cargo;
   
        /// <summary>
        /// Constructor del comando para ingresar cargo
        /// </summary>
        /// <param name="cargo">El cargo a ingresar</param>
        public Ingresar(Cargo cargo)
        {
            this._cargo = cargo;
        }

        /// <summary>
        /// Metodo de ejecucion para agregar cargos
        /// </summary>
        /// <returns>true si se logro agregar el cargo y false si hubo error</returns>
        public void Ejecutar()
        {
            DAOCargoSQLServer bd = new DAOCargoSQLServer();
            bd.IngresarCargo(_cargo);
        }
    }
}
