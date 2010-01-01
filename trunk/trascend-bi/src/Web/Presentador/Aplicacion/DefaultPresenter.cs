using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presentador.Aplicacion
{
    public class DefaultPresenter
    {
        private IDefaultPresenter _vista;
        public DefaultPresenter(IDefaultPresenter vista)
        {
            _vista = vista;
        
        }
        public void OnBotonAceptar()
        {
            _vista.IngresarSistema();
        
        }
    }
}
