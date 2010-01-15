using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Cliente.ClienteInterface;

namespace Presentador.Cliente.ClientePresentador
{
    public class AgregarClientePresentador
    {
        
            private IAgregarCliente _vista;

            public AgregarClientePresentador(IAgregarCliente vista)
            {
                _vista = vista;
            }
            public void Onclick()
            {
                
            }
        }
       
    }

