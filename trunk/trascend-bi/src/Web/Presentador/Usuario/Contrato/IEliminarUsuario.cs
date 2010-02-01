using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;

namespace Presentador.Usuario.Contrato
{
    public interface IEliminarUsuario
    {
        #region Informacion Basica

        Label AsteriscoStatus { get; set; }

        // Label AsteriscoLogin { get; set; }

        Label NombreUsuarioLabel { get; set; }

        Label StatusDdLLabel { get; set; }

        TextBox Login { get; set; }

        MultiView MultiViewEliminar { get; set; }

        GridView GridViewConsultarEliminarUsuario { get; set; }

        ObjectContainerDataSource GetObjectContainerConsultaEliminarUsuario { get; set; }

        DropDownList StatusDdL { get; set; }

        Button BotonBuscar { get; set; }

        RequiredFieldValidator ValidarNombreVacio { get; set; }

        RequiredFieldValidator ValidarNoSeleccion { get; set; }

        RadioButtonList RbCampoBusqueda { get; set; }

        #region Dialogo

        bool DialogoVisible { get; set; }

        void Pintar(string codigo, string mensaje, string actor, string detalles);

        bool InformacionVisible { get; set; }

        bool InformacionVisibleBotonAceptar { get; set; }

        void PintarInformacion(string mensaje, string estilo);

        void PintarInformacionBotonAceptar(string mensaje, string estilo);

        #endregion
        // void Mensaje(string msg);
        // void Volver();
        #endregion
    }

}