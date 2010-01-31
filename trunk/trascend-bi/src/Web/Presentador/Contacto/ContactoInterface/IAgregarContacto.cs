using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Presentador.Contacto.ContactoInterface
{
    public interface IAgregarContacto
    {
        
        #region Propiedades

            TextBox TextBoxNombreContacto { get; set; }

            TextBox TextBoxApellidoContacto { get; set; }

            TextBox TextBoxCargoContacto { get; set; }

            TextBox TextBoxAreaNegocio { get; set; }

            TextBox TextBoxTelfOficina { get; set; }

            TextBox TextBoxTelfCelular { get; set; }

            TextBox TextBoxCodOficina { get; set; }

            TextBox TextBoxCodCelular { get; set; }

            TextBox TextBoxTelfFax { get; set; }

            TextBox TextBoxCodFax { get; set; }

           

        //RequiredFieldValidator RequiredFieldValidator { get; set; }

        //RequiredFieldValidator RequiredFieldValidator1 { get; set; }

            TextBox Valor { get; set; }

            //#region Diálogo

            //bool DialogoVisible { get; set; }

            //void Pintar(string codigo, string mensaje, string actor, string detalles);

            //bool InformacionVisible { get; set; }

            //void PintarInformacion(string mensaje, string estilo);

            //#endregion
        #endregion
    }
        
}
