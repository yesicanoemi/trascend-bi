using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.Web;
using System.Configuration;
using Presentador.Cliente.Contrato;
using Core.LogicaNegocio.Fabricas;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Comandos.ComandoCliente;
using Core.LogicaNegocio.Excepciones.Cliente.LogicaNegocio;
using Presentador.Base;
using System.Web;


namespace Presentador.Cliente.Vistas
{
    public class ConsultarClientePresentador : PresentadorBase
    {

        #region Propiedades
        private IConsultarCliente _vista;

        private const string campoVacio = "";
        #endregion



        #region constructor

        public ConsultarClientePresentador()
        {
        }

        public ConsultarClientePresentador(IConsultarCliente vista)
        {
            _vista = vista;
        }

        #endregion


        private IList<Core.LogicaNegocio.Entidades.Cliente> cliente;

        #region Métodos


        public void CambiarVista(int index)
        {
            _vista.MultiViewConsulta.ActiveViewIndex = index;


        }

        private void LimpiarFormulario()
        {
            _vista.ConsultaRif.Text = campoVacio;

            _vista.Valor.Text = campoVacio;

        }


        #region Radio Buttons

        /// <summary>
        /// Acción al seleccionar el radiobutton
        /// </summary>
        /// 
        public void CampoBusqueda_Selected()
        {
            LimpiarFormulario();
 
            if (_vista.RbCampoBusqueda.SelectedValue == "1")
            {
                _vista.BotonBuscar.Visible = true;
                _vista.Valor.Visible = true;
                _vista.NombreCliente.Visible = true;
                _vista.ConsultaRif.Visible = false;
                _vista.RifCliente.Visible = false;
                _vista.GetObjectContainerConsultaCliente.DataSource = "";
                _vista.GetObjectContainerConsultaDireccion.DataSource = "";
                _vista.GetObjectContainerConsultaTelefono.DataSource = "";
            }

            if (_vista.RbCampoBusqueda.SelectedValue == "2")
            {
                _vista.BotonBuscar.Visible = true;
                _vista.Valor.Visible = false;
                _vista.NombreCliente.Visible = false;
                _vista.ConsultaRif.Visible = true;
                _vista.RifCliente.Visible = true;
                _vista.GetObjectContainerConsultaCliente.DataSource = "";
                _vista.GetObjectContainerConsultaDireccion.DataSource = "";
                _vista.GetObjectContainerConsultaTelefono.DataSource = "";
            }   
        }

        #endregion



        public void OnBotonBuscar()
        {
            Core.LogicaNegocio.Entidades.Cliente cliente = new Core.LogicaNegocio.Entidades.Cliente();

            try
            {
                if (_vista.RbCampoBusqueda.SelectedValue == "1")// nombre de cliente
                {
                    cliente.Nombre = _vista.Valor.Text;
                    IList<Core.LogicaNegocio.Entidades.Cliente> listaCliente = ConsultarClienteNombre(cliente);
                    CargarDatos(listaCliente[0]);
                    CambiarVista(1);

                }

                if (_vista.RbCampoBusqueda.SelectedValue == "2")// rif del cliente
                {
                    cliente.Rif = _vista.ConsultaRif.Text;
                    Core.LogicaNegocio.Entidades.Cliente seleccionCliente = ConsultarClienteRif(cliente);
                    CargarDatos(seleccionCliente);
                    CambiarVista(1);
                }
            }
            catch (WebException e)
            {
                _vista.Pintar(ManagerRecursos.GetString("codigoErrorWeb"),
                    ManagerRecursos.GetString("mensajeErrorWeb"), e.Source, e.Message + "\n " + e.StackTrace);
                _vista.DialogoVisible = true;

            }
            catch (Exception e)
            {
                _vista.Pintar(ManagerRecursos.GetString("codigoErrorGeneral"),
                    ManagerRecursos.GetString("mensajeErrorGeneral"), e.Source, e.Message + "\n " + e.StackTrace);
                _vista.DialogoVisible = true;

            }
        }



        public void CargarDatos(Core.LogicaNegocio.Entidades.Cliente cliente)
        {
            int i=0;
            IList<Core.LogicaNegocio.Entidades.TelefonoTrabajo> telefonos = new List<TelefonoTrabajo>();
            
            
            _vista.GetObjectContainerConsultaCliente.DataSource = cliente;
            _vista.GetObjectContainerConsultaDireccion.DataSource = cliente.Direccion;
            while (i < 3)
            {
                if (cliente.Telefono[i] != null)
                {
                    telefonos.Add(cliente.Telefono[i]);    
                }
                i++;
            }
            _vista.GetObjectContainerConsultaTelefono.DataSource = telefonos;
            _vista.GetObjectContainerConsultaTelefono.DataBind();
        }



        public IList<Core.LogicaNegocio.Entidades.Cliente>
            ConsultarClienteNombre(Core.LogicaNegocio.Entidades.Cliente entidad)
        {
            IList<Core.LogicaNegocio.Entidades.Cliente> listaCliente = null;


            try
            {
                Core.LogicaNegocio.Comandos.ComandoCliente.ConsultarNombre comando; //tengo q crear una nueva consulta

                comando = FabricaComandosCliente.CrearComandoConsultarNombre(entidad);

                listaCliente = comando.ejecutar();

                
            }
            catch (ConsultarClienteLNException e)
            {
                _vista.Pintar(ManagerRecursos.GetString("codigoErrorConsultar"),
                    ManagerRecursos.GetString("mensajeErrorConsultar"), e.Source, e.Message + "\n " + e.StackTrace);
                _vista.DialogoVisible = true;

            }
            catch (Exception e)
            {
                _vista.Pintar(ManagerRecursos.GetString("codigoErrorGeneral"),
                    ManagerRecursos.GetString("mensajeErrorGeneral"), e.Source, e.Message + "\n " + e.StackTrace);
                _vista.DialogoVisible = true;

            }
            return listaCliente;
        }


        public Core.LogicaNegocio.Entidades.Cliente ConsultarClienteRif(Core.LogicaNegocio.Entidades.Cliente entidad)
        {
            Core.LogicaNegocio.Entidades.Cliente seleccioncliente = new Core.LogicaNegocio.Entidades.Cliente();


            try
            {
                Core.LogicaNegocio.Comandos.ComandoCliente.ConsultarRif comando; //tengo q crear una nueva consulta

                comando = FabricaComandosCliente.CrearComandoConsultarRif(entidad);

                seleccioncliente = comando.ejecutar();

                
            }
            catch (ConsultarClienteLNException e)
            {
                _vista.Pintar(ManagerRecursos.GetString("codigoErrorConsultar"),
                    ManagerRecursos.GetString("mensajeErrorConsultar"), e.Source, e.Message + "\n " + e.StackTrace);
                _vista.DialogoVisible = true;

            }
            catch (Exception e)
            {
                _vista.Pintar(ManagerRecursos.GetString("codigoErrorGeneral"),
                    ManagerRecursos.GetString("mensajeErrorGeneral"), e.Source, e.Message + "\n " + e.StackTrace);
                _vista.DialogoVisible = true;

            }
            return seleccioncliente;
        }

        public void uxObjectConsultaClienteSelecting(string rif)
        {
            Core.LogicaNegocio.Entidades.Cliente cliente = new Core.LogicaNegocio.Entidades.Cliente();

            Core.LogicaNegocio.Entidades.Cliente cliente2 = new Core.LogicaNegocio.Entidades.Cliente();

            cliente.Rif = rif;

            cliente2 = ConsultarClienteRif(cliente);

            CambiarVista(1);

        }


        #endregion
    }
}
