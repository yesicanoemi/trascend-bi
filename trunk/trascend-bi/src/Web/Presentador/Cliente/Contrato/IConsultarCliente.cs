using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;

namespace Presentador.Cliente.Contrato
{
    public interface IConsultarCliente
    {
        #region Propiedades



        TextBox Valor { get; set; }
        TextBox ConsultaRif { get; set; }
        Label RifCliente { get; set; }
        Label NombreCliente { get; set; }
        Button BotonBuscar { get; set; }
        DetailsView MuestraCliente { get; set; }
        DetailsView MuestraDireccion { get; set; }
        GridView MuestraTelefono { get; set; }
        GridView GridCliente { get; set; }
        RadioButtonList RbCampoBusqueda { get; set; }

        MultiView MultiViewConsulta { get; set; }






        #endregion

        #region Dialogo

        bool DialogoVisible { get; set; }
        void Pintar(string codigo, string mensaje, string actor, string detalles);
        bool InformacionVisible { get; set; }
        void PintarInformacion(string mensaje, string estilo);

        #endregion

        ObjectContainerDataSource GetObjectContainerConsultaCliente { get; set; }
        ObjectContainerDataSource GetObjectContainerConsultaDireccion { get; set; }
        ObjectContainerDataSource GetObjectContainerConsultaTelefono { get; set; }
        ObjectContainerDataSource GetObjectContainerConsultaContacto { get; set; }

    }
}
