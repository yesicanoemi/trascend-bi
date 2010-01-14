using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;

namespace Core.LogicaNegocio.Comandos.ComandoCargo
{
    public class Modificar : Comando<Cargo>
    {
        private Cargo _cargo;


        public Modificar(Cargo cargo)
        {
            this._cargo = cargo;
        }

        override public void Ejecutar()
        {

        }
    }
}
