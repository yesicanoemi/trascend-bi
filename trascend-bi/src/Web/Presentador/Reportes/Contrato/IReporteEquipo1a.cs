using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using Microsoft.Practices.Web.UI.WebControls;

namespace Presentador.Reportes.Contrato
{
    public interface IReporteEquipo1a
    {
        #region Propiedades

        RadioButtonList RadioButton { get; set; }

        TextBox TextBoxBusqueda { get; set; }

        GridView GridViewReportePaquete1a { get; set; }

        ObjectContainerDataSource GetObjectContainerObjectReporte1a { get; set; }

        GridView GridViewConsultarEmpleado { get; set; }

        ObjectContainerDataSource GetOCConsultarEmp { get; set; }
        
        #region Dialogo

        bool DialogoVisible { get; set; }

        void Pintar(string codigo, string mensaje, string actor, string detalles);

        bool InformacionVisible { get; set; }

        void PintarInformacion(string mensaje, string estilo);

        #endregion

        #endregion 
    }
}
