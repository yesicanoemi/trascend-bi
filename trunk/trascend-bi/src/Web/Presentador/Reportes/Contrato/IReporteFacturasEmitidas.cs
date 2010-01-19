using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;

namespace Presentador.Reportes.Contrato
{
    public interface IReporteFacturasEmitidas
    {
        #region Informacion Basica

        GridView GridViewReporteFactura3b { get; set; }

        ObjectContainerDataSource GetObjectContainerReporteFactura3b { get; set; }

        TextBox FechaInicio { get; set; }

        TextBox FechaFin { get; set; }

        #region Dialogo

        bool DialogoVisible { get; set; }

        void Pintar(string codigo, string mensaje, string actor, string detalles);

        bool InformacionVisible { get; set; }

        void PintarInformacion(string mensaje, string estilo);

        #endregion

        #endregion
    }
}
