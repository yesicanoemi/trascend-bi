using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;

namespace Presentador.Contacto.ContactoInterface
{
    public interface IModificarContacto
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

        TextBox ClienteC { get; set; }

        DropDownList TipoTlfC1 { get; set; }

        TextBox CodTelefonoC1 { get; set; }

        TextBox TelefonoC1 { get; set; }

        DropDownList TipoTlfC2 { get; set; }

        TextBox CodTelefonoC2 { get; set; }

        TextBox TelefonoC2 { get; set; }

        TextBox CargoC { get; set; }

        TextBox AreaC { get; set; }

        TextBox ApellidoC { get; set; }

        TextBox NombreC { get; set; }

        Label NombreContacto { get; set; }

        Label ApellidoContacto { get; set; }

        Label CodigoTlf { get; set; }

        Label Tlf { get; set; }

        Label NombreCliente { get; set; }

        TextBox Valor { get; set; }

        Label IdClienteH { get; set; }

        Label IdContactoH { get; set; }

        void CambiarPagina();

        #region Validaciones

        RequiredFieldValidator RequiredFieldValidator { get; set; }

        RequiredFieldValidator RequiredFieldValidator1 { get; set; }

        RequiredFieldValidator RequiredFieldValidator3 { get; set; }

        RequiredFieldValidator RequiredFieldValidator4 { get; set; }

        RequiredFieldValidator RequiredFieldValidator5 { get; set; }

        RequiredFieldValidator RequiredFieldValidator6 { get; set; }

        RequiredFieldValidator RequiredFieldValidator7 { get; set; }

        RequiredFieldValidator RequiredFieldValidator8 { get; set; }

        #endregion  

        #region Diálogo

        bool DialogoVisible { get; set; }

        void Pintar(string codigo, string mensaje, string actor, string detalles);

        bool InformacionVisible { get; set; }

        void PintarInformacion(string mensaje, string estilo);

        bool InformacionVisible2 { get; set; }

        void PintarInformacion2(string mensaje, string estilo);

        bool InformacionVisibleError { get; set; }

        void PintarInformacionError(string mensaje, string estilo);

        #endregion

        #endregion 
    }
}
