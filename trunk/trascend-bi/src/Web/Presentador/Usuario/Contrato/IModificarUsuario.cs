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


        Label AsteriscoStatus { get; set; }

        // Label AsteriscoLogin { get; set; }

        Label NombreUsuarioLabel { get; set; }

        Label StatusDdLLabel { get; set; }

        TextBox NombreUsuario { get; set; }

        DropDownList StatusDdL { get; set; }

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

        RadioButtonList RbCampoBusqueda { get; set; }

        Button BotonBuscar { get; set; }

        RequiredFieldValidator ValidarNombreVacio { get; set; }

        RequiredFieldValidator ValidarNoSeleccion { get; set; }

        //void CambiarPagina();

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
