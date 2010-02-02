using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Logout;

namespace Presentador.Logout
{
    public class LogoutPresenter
    {
        #region Propiedades
        public Core.LogicaNegocio.Entidades.Usuario SesionUsuario;

        private ILogoutPresenter _vista;
        #endregion

        #region Constructor
        public LogoutPresenter(ILogoutPresenter vista)
        {
            _vista=vista;
        }
        #endregion

        #region Metodos
        public void Logout()
        {
            _vista.Sesion.Clear();

        }
        #endregion
    }
}
