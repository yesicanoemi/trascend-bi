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
   
        
        public Ingresar(Cargo cargo)
        {
            this._cargo = cargo;
        }

        public Boolean Ejecutar()
        {
            CargoSQLServer bd = new CargoSQLServer();
            return bd.IngresarCargo( _cargo );
        }
    }
}
