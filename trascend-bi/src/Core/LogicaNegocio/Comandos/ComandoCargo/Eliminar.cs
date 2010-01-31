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
    public class Eliminar : Comando<Cargo>
    {
        private Cargo _cargo;

        #region Constructor
        /// <summary>
        /// Constructor del comando
        /// </summary>
        /// <param name="cargo">Cargo a eliminar</param>
        public Eliminar(Cargo cargo)
        {
            this._cargo = cargo;
        }

        /// <summary>
        /// Constructor del comando para que funcione por id del cargo
        /// </summary>
        /// <param name="idCargo">el id del cargo</param>
        public Eliminar(int idCargo)
        {
            _cargo = new Cargo();
            _cargo.Id = idCargo;
        }
        #endregion

        /// <summary>
        /// Metodo de ejecucion de la eliminacion de cargo
        /// </summary>
        /// <returns>true si se elimino correctamente y false si hubo error</returns>
        public void Ejecutar()
        {
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOCargo acceso = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOCargo();

            acceso.EliminarCargo(_cargo.Id);
            
        }
    }
}
