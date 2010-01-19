using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;

namespace Presentador.Usuario.Contrato
{
    public interface IAgregarUsuario
    {
        #region Información Básica

        TextBox NombreUsuario { get; set; }

        TextBox ContrasenaUsuario { get; set; }

        MultiView MultiViewAgregar { get; set; }

        GridView GridViewConsultaEmpleado { get; set; }

        ObjectContainerDataSource GetObjectContainerConsultaEmpleado { get; set; }

        TextBox EmpleadoBuscar { get; set; }

        Label NombreEmp { get; set; }

        Label ApellidoEmp { get; set; }

        Label CedulaEmp { get; set; }

        Label StatusEmp { get; set; }

        CheckBoxList CBLAgregar { get; set; }

        CheckBoxList CBLConsultar { get; set; }

        CheckBoxList CBLModificar { get; set; }

        CheckBoxList CBLEliminar { get; set; }

        CheckBoxList CBLReporte { get; set; }

        void CambiarPagina();

        #region Dialogo

        bool DialogoVisible { get; set; }

        void Pintar(string codigo, string mensaje, string actor, string detalles);

        bool InformacionVisible { get; set; }

        bool InformacionVisibleBotonAceptar { get; set; }

        void PintarInformacion(string mensaje, string estilo);

        void PintarInformacionBotonAceptar(string mensaje, string estilo);

        #endregion

        #endregion
    }
}
