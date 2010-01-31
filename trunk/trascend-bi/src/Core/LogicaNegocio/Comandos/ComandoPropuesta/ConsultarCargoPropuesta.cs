using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;
using Core.AccesoDatos.Fabricas;

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
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOCargo iDAOCargo = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOCargo();

            //CargoSQLServer bd = new CargoSQLServer();
            return iDAOCargo.ConsultarCargos();
        }
    }
}
