using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoPropuesta
{
    public class ConsultarCargoPropuesta : Comando<Cargo>
    {
        private Cargo _cargo;

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cargo">el cargo a consultar</param>
        public ConsultarCargoPropuesta(Cargo cargo)
        {
            this._cargo = cargo;
        }
        #endregion


        /// <summary>
        /// Metodo de ejecucion del comando
        /// </summary>
        /// <returns>el cargo con valores consultados</returns>
        public IList<Entidad> Ejecutar()
        {
            CargoSQLServer bd = new CargoSQLServer();
            return bd.ConsultarCargos();
        }
    }
}
