using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;

namespace Presentador.Contacto.ContactoInterface
{
    public interface IEliminarContacto
    {
        #region Propiedades

        TextBox TextBoxNombre { get; set; }

        TextBox TextBoxApellido { get; set; }

        TextBox TextBoxCodTelefono { get; set; }

        TextBox TextBoxNumTelefono { get; set; }

        DropDownList ClienteDdl { get; set; }

        MultiView MultiViewConsultar { get; set; }

        GridView GridViewConsultaContacto { get; set; }

        ObjectContainerDataSource GetObjectContainerConsultaContacto { get; set; }

        RadioButtonList RbCampoBusqueda { get; set; }

        Button BotonBuscar { get; set; }

        Label ClienteC { get; set; }

        Label TipoTlfC1 { get; set; }

        Label TelefonoC1 { get; set; }

        Label TipoTlfC2 { get; set; }

        Label TelefonoC2 { get; set; }

        Label CargoC { get; set; }

        Label AreaC { get; set; }

        Label ApellidoC { get; set; }

        Label NombreC { get; set; }

        Label NombreContacto { get; set; }

        Label ApellidoContacto { get; set; }

        Label CodigoTlf { get; set; }

        Label Tlf { get; set; }

        Label NombreCliente { get; set; }

        RequiredFieldValidator RequiredFieldValidator { get; set; }

        RequiredFieldValidator RequiredFieldValidator1 { get; set; }

        TextBox Valor { get; set; }

        #region Diálogo

        bool DialogoVisible { get; set; }

        void Pintar(string codigo, string mensaje, string actor, string detalles);

        bool InformacionVisible { get; set; }

        void PintarInformacion(string mensaje, string estilo);

        #endregion

        void CambiarPagina();

        #endregion

    }
}
