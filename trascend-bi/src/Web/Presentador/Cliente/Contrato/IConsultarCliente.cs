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
        RadioButtonList RbCampoBusqueda { get; set; }

        MultiView MultiViewConsulta { get; set; }






        #endregion

        /*Label CodTelefonoCliente
        {
            get;
            set;
        }

        

        DropDownList SeleccionOpcion
        {
            get;
            set;
        }

        DropDownList SeleccionAreaCliente
        {
            get;
            set;
        }

        Label TipoConsulta
        {
            get;
            set;
        }
        Label Seleccion
        {
            get;
            set;
        }
        Label SeleccionArea
        {
            get;
            set;
        }
        Label Rif
        {
            get;
            set;
        }

        Label RifCliente
        {
            get;
            set;
        }
        
        Label Nombre
        {
            get;
            set;
        }

        Label NombreCliente
        {
            get;
            set;
        }
        
        Label CalleAvenida
        {
            get;
            set;
        }

        Label CalleAvenidaCliente
        {
            get;
            set;
        }
        Label Urbanizacion
        {
            get;
            set;
        }
        Label UrbanizacionCliente
        {
            get;
            set;
        }

        Label EdificioCasa
        {
            get;
            set;
        }
        Label EdificioCasaCliente
        {
            get;
            set;
        }
        Label PisoApartamento
        {
            get;
            set;
        }
        Label PisoApartamentoCliente
        {
            get;
            set;
        }
        Label Ciudad
        {
            get;
            set;
        }
        Label CiudadCliente
        {
            get;
            set;
        }

        Label Telefono
        {
            get;
            set;
        }

        Label TelefonoCliente
        {
            get;
            set;
        }

        Label AreaNegocio
        {
            get;
            set;
        }

        Label AreaNegocioCliente
        {
            get;
            set;
        }

        Label Contacto
        {
            get;
            set;
        }

        ListBox ContactoCliente
        {
            get;
            set;
        }

       

        */
        ObjectContainerDataSource GetObjectContainerConsultaCliente { get; set; }
        ObjectContainerDataSource GetObjectContainerConsultaDireccion { get; set; }
        ObjectContainerDataSource GetObjectContainerConsultaTelefono { get; set; }

    }
}
