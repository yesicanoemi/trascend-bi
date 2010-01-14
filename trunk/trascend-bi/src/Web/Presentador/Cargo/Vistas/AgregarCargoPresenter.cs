using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Cargo.Contrato;
using Core.LogicaNegocio.Entidades;

namespace Presentador.Cargo.Vistas
{
    public class AgregarCargoPresenter
    {
        private IAgregarCargo _vista;
        //private CargoController _controlador;

        public AgregarCargoPresenter(IAgregarCargo laVista)
        {
            _vista = laVista;
        }

        public void IngresarCargo()
        {
            Core.LogicaNegocio.Entidades.Cargo cargo = new Core.LogicaNegocio.Entidades.Cargo();
            
            cargo.Nombre = _vista.NombreCargo.Text;
            cargo.Descripcion = _vista.DescripcionCargo.Text;

        }
    }
}
