using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Factura.Contrato;
using Core.LogicaNegocio.Entidades;

namespace Presentador.Factura.Vistas
{
    public class AgregarFacturaPresenter
    {
        IAgregarFactura _vista;
        FacturaController _controller = new FacturaController();

        public AgregarFacturaPresenter(IAgregarFactura vista)
        {
            _vista = vista;
        }
    }
}
