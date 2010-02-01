using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Factura.Contrato
{
    public interface IAnularFactura
    {
        TextBox Busqueda { get; set; }
        Label NombrePropuesta { get; set; }
        Label MontoPropuesta { get; set; }
        Label NumeroFactura { get; set; }
        Label TituloFactura { get; set; }
        Label DescripcionFactura { get; set; }
        Label PorcentajeFactura { get; set; }
        Label TotalFactura { get; set; }
        Label FechaFactura { get; set; }
        Label Mensaje { get; set; }

        #region Mensaje
        void Pintar(string mensaje);
        bool MensajeVisible { get; set; }
        #endregion

        #region Mostrar Elementos
        void ActivarElementos();
        void DesactivarElementos();
        #endregion
    }
}
