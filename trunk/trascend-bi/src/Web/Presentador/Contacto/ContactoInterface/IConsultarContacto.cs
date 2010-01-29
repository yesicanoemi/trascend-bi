using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;

namespace Presentador.Contacto.ContactoInterface
{
    public interface IConsultarContacto
    {
        
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

        Label TipoTlfC { get; set; }

        Label TelefonoC { get; set; }

        Label CargoC { get; set; }

        Label AreaC { get; set; }

        Label ApellidoC { get; set; }

        Label NombreC { get; set; }

        void CambiarPagina();
            
    }
}
