using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;

namespace Presentador.Usuario.Contrato
{
    public interface IModificarUsuario
    {
        #region Informacion Basica

        TextBox NombreUsuario { get; set; }

        MultiView MultiViewModificar { get; set; }

        GridView GridViewConsultarModificarUsuario { get; set; }

        ObjectContainerDataSource GetObjectContainerConsultaModificarUsuario { get; set; }

        Label NombreUsu { get; set; }

        Label NombreEmp { get; set; }

        Label ApellidoEmp { get; set; }

        CheckBoxList CBLAgregar { get; set; }

        CheckBoxList CBLConsultar { get; set; }

        CheckBoxList CBLModificar { get; set; }

        CheckBoxList CBLEliminar { get; set; }

        DropDownList DLStatusUsuario { get; set; }

        CheckBoxList CBLReporte { get; set; }

        #region Dialogo

        bool DialogoVisible { get; set; }

        void Pintar(string codigo, string mensaje, string actor, string detalles);

        bool InformacionVisible { get; set; }

        void PintarInformacion(string mensaje, string estilo);

        #endregion


        #endregion

    }
}
