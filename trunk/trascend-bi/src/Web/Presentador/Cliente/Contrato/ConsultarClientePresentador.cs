using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Cliente.ClienteInterface;

namespace Presentador.Cliente.ClientePresentador
{
    public class ConsultarClientePresentador
    {
//
        private IConsultarCliente _vista;

        public ConsultarClientePresentador(IConsultarCliente vista)
        {
            _vista = vista;
        }
        public void Onclick()
        {
        
        }
    }

}
