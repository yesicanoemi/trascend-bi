using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Presentador.Cliente.Vistas;
using Presentador.Cliente.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Fabricas;
using Core.LogicaNegocio.Comandos;

namespace Presentador.Cliente.Vistas
{
   public class ModificarClientePresenter
    {

        
            private IModificarCliente _vista;
            private string campoVacio = "";

            #region Constructor
            public ModificarClientePresenter(IModificarCliente vista)
            {
                _vista = vista;
            }
            #endregion
    }
}
