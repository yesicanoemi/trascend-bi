using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;

namespace Presentador.Cliente.Contrato
{
    public interface IModificarCliente
    {
        #region Propiedades



        TextBox Valor { get; set; }
        TextBox ConsultaRif { get; set; }
        Label RifCliente { get; set; }
        Label LabelNombreCliente { get; set; }
        Button BotonBuscar { get; set; }
        Button BotonVolver { get; set; }
        GridView GridCliente { get; set; }
        RadioButtonList RbCampoBusqueda { get; set; }
        MultiView MultiViewConsulta { get; set; }
        TextBox IdCliente { get; set; }

        #endregion

        #region Dialogo

        bool DialogoVisible { get; set; }
        void Pintar(string codigo, string mensaje, string actor, string detalles);
        bool InformacionVisible { get; set; }
        void PintarInformacion(string mensaje, string estilo);
        bool InformacionVisible2 { get; set; }
        void PintarInformacion2(string mensaje, string estilo);

        #endregion


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
        Button Agregar { get; set; }

        #endregion

        ObjectContainerDataSource GetObjectContainerConsultaCliente { get; set; }
    }
}
