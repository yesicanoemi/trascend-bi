using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Comandos.ComandoCargo
{
    public class Modificar : Comando
    {
        private Cargo _cargo;


        public Modificar(Cargo cargo)
        {
            this._cargo = cargo;
        }

        public void Ejecutar()
        {

        }
    }
}
