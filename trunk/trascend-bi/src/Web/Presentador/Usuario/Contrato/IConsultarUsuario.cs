using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Usuario.Contrato
{
    public interface IConsultarUsuario
    {

        #region Informacion Basica

        TextBox NombreUsuario { get; set; }

        #endregion
    }
}
