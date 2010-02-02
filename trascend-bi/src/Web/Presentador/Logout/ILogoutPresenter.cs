using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;

namespace Presentador.Logout
{
    public interface ILogoutPresenter
    {
        HttpSessionState Sesion { get; }
    }
}
