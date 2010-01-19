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

        #region Dialogo

        bool DialogoVisible { get; set; }

        void Pintar(string codigo, string mensaje, string actor, string detalles);

        bool InformacionVisible { get; set; }

        void PintarInformacion(string mensaje, string estilo);

        #endregion

    }
}
