using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Cliente.ClienteInterface;

namespace Presentador.Cliente.ClientePresentador
{
    public class EliminarClientePresentador
    {
//
        private IEliminarCliente _vista;

        public EliminarClientePresentador(IEliminarCliente vista)
        {
            _vista = vista;
        }
        public void Onclick()
        {
           
        }
    }

}
