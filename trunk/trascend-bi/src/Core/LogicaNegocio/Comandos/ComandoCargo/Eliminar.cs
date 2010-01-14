using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Comandos.ComandoCargo
{
    public class Eliminar : Comando
    {
        private Cargo _cargo;


        public Eliminar(Cargo cargo)
        {
            this._cargo = cargo;
        }

        public void Ejecutar()
        {

        }
    }
}
