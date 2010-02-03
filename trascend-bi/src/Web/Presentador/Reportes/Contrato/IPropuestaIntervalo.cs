using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Reportes.Contrato
{
   public interface IPropuestaIntervalo
    {
        #region Informacion Basica

        GridView Grid { get; set; }

        TextBox FechaInicio { get; set; }

        TextBox FechaFin { get; set; }

        Button Boton { get; set; }

        Label Mensaje { get; set; }


        #endregion

        #region Mensaje
        void Pintar(string mensaje);
        bool MensajeVisible { get; set; }
        #endregion
    }
}
