using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;
using Core.AccesoDatos.Fabricas;

namespace Core.LogicaNegocio.Comandos.ComandoCargo
{
    public class Consultar : Comando<Cargo>
    {
        private Cargo _cargo;

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cargo">el cargo a consultar</param>
        public Consultar(Cargo cargo)
        {
            this._cargo = cargo;
        }
        #endregion


        /// <summary>
        /// Metodo de ejecucion del comando
        /// </summary>
        /// <returns>el cargo con valores consultados</returns>
        public Cargo Ejecutar()
        {
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOCargo bd = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOCargo();

            return (Cargo)bd.ConsultarCargo( _cargo );
        }
    }
}
