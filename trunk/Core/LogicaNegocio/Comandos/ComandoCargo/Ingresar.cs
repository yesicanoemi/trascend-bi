using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;

namespace Core.LogicaNegocio.Comandos.ComandoCargo
{
    public class Ingresar : Comando<Cargo>
    {
        private Cargo _cargo;
   
        
        public Ingresar(Cargo cargo)
        {
            this._cargo = cargo;
        }

        public void Ejecutar()
        {
            
        }
    }
}
