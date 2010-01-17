using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Cargo.Contrato;
using Core.LogicaNegocio.Entidades;
using System.Data;

namespace Presentador.Cargo.Vistas
{
    public class InflacionCargoPresenter
    {

        private IInflacionCargo _vista;

        public InflacionCargoPresenter(IInflacionCargo laVista)
        {
            _vista = laVista;
        }

        public void CargarTabla()
        {
        }
    }
}
