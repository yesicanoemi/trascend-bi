using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoCargo
{
    public class Eliminar : Comando<Cargo>
    {
        private Cargo _cargo;


        public Eliminar(Cargo cargo)
        {
            this._cargo = cargo;
        }

        public Eliminar(int idCargo)
        {
            _cargo = new Cargo();
            _cargo.Id = idCargo;
        }

        public void Ejecutar()
        {
            CargoSQLServer bd = new CargoSQLServer();
            bd.EliminarCargo(_cargo.Id);
        }
    }
}
