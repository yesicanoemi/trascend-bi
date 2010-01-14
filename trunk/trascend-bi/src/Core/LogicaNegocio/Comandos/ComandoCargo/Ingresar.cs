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

        override public void Ejecutar()
        {
            Comando<Cargo> ingresarCargo = Fabricas.FabricaComandoCargo.CrearComandoIngresar(_cargo);
            try
            {
                ingresarCargo.Ejecutar();
            }
            catch (Exception e)
            { 
                // no se pudo ingresar el cargo
            }
        }
    }
}
