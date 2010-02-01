using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Base;
using Presentador.Aplicacion;
using Presentador.Usuario.Contrato;
using Presentador.Usuario.Vistas;

namespace Presentador.Usuario.Vistas
{
    public class DefaultUsuarioPresenter : PresentadorBase
    {
        private IDefaultUsuario _vistaDefault;
        #region Constructor
        public DefaultUsuarioPresenter()
        {

        }

        public DefaultUsuarioPresenter(IDefaultUsuario _vista)
        {
            _vistaDefault = _vista;
        }
        #endregion



    }
}
