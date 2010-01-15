using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Cliente.ClienteInterface;

namespace Presentador.Cliente.ClientePresentador
{
    public class ModificarClientePresentador
    {

        private IModificarCliente _vista;

        public ModificarClientePresentador(IModificarCliente vista)
        {
            _vista = vista;
        }
        public void Onclick()
        {
            

        }
    }

}

