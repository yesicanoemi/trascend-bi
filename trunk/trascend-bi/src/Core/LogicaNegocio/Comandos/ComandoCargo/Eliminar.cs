using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;

namespace Core.LogicaNegocio.Comandos.ComandoCargo
{
    public class Eliminar : Comando<Cargo>
    {
        private Cargo _cargo;


        public Eliminar(Cargo cargo)
        {
            this._cargo = cargo;
        }

        override public void Ejecutar()
        {

        }
    }
}
