using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Cliente.Contrato
{
    public interface IAgregarCliente
    {
        #region informacion Cliente

        TextBox rifCliente { get; set; }
        TextBox NombreCliente { get; set; }
        TextBox CalleAvenidaCliente { get; set; }
        TextBox UrbanizacionCliente { get; set; }
        TextBox EdificioCasaCliente { get; set; }
        TextBox PisoApartamentoCliente { get; set; }
        TextBox CiudadCliente { get; set; }
        TextBox AreaNegocioCliente { get; set; }
        TextBox TelefonoTrabajoCliente { get; set; }
        TextBox CodigoTrabajoCliente { get; set; }
        TextBox TelefonoCelular { get; set; }
        TextBox CodCelular { get; set; }
        TextBox TelefonoFax { get; set; }
        TextBox CodFax { get; set; }
        DropDownList TipoRif { get; set; }
        Button InsertarOtro { get; set; }
        Button AgregarContactos { get; set; }

        #endregion

        Button Agregar { get; set; }

        #region Dialogo

        bool DialogoVisible { get; set; }
        void Pintar(string codigo, string mensaje, string actor, string detalles);
        bool InformacionVisible { get; set; }
        void PintarInformacion(string mensaje, string estilo);
        //void Mensaje(string msg);

        #endregion
    }
}
