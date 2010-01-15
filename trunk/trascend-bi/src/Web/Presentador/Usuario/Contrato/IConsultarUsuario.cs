using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;

namespace Presentador.Usuario.Contrato
{
    public interface IConsultarUsuario
    {

        #region Informacion Basica

        TextBox NombreUsuario { get; set; }

        MultiView MultiViewConsultar { get; set; }

        GridView GridViewConsultaUsuario { get; set; }

        ObjectContainerDataSource GetObjectContainerConsultaUsuario { get; set; }

        Label NombreUsu { get; set; }

        Label NombreEmp { get; set; }

        Label ApellidoEmp { get; set; }

        Label UsuarioU { get; set; }

        #endregion
    }
}
