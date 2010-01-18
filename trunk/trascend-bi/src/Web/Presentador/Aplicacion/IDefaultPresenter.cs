using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace Presentador.Aplicacion
{
    public interface IDefaultPresenter
    {
        TextBox Login { get; set; }

        TextBox Password { get; set; }

        HttpSessionState Sesion { get; }

        void IngresarSistema();
    }
}
