using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Cargo.Contrato;

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
        }
    }
}
