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

        #region Información Básica

        TextBox NombreUsuario { get; set; }

        DropDownList StatusDdL { get; set; }

        MultiView MultiViewConsultar { get; set; }

        GridView GridViewConsultaUsuario { get; set; }

        ObjectContainerDataSource GetObjectContainerConsultaUsuario { get; set; }

        Label NombreUsu { get; set; }

        Label NombreEmp { get; set; }

        Label ApellidoEmp { get; set; }

        Label UsuarioU { get; set; }

        CheckBoxList CBLAgregar { get; set; }

        CheckBoxList CBLConsultar { get; set; }

        CheckBoxList CBLModificar { get; set; }

        CheckBoxList CBLEliminar { get; set; }

        CheckBoxList CBLReporte { get; set; }

        RadioButtonList RbCampoBusqueda { get; set; }

        Button BotonBuscar { get; set; }

        RequiredFieldValidator ValidarNombreVacio { get; set; }
        
        void CambiarPagina();


        #region Dialogo

        bool DialogoVisible { get; set; }

        void Pintar(string codigo, string mensaje, string actor, string detalles);

        bool InformacionVisible { get; set; }

        void PintarInformacion(string mensaje, string estilo);

        #endregion

        #endregion

    }
}
