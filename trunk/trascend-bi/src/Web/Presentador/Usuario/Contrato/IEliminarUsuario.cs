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

        TextBox Login { get; set; }
        
        MultiView MultiViewEliminar { get; set; }

        GridView GridViewConsultarEliminarUsuario { get; set; }

        ObjectContainerDataSource GetObjectContainerConsultaEliminarUsuario { get; set; }

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