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
using Core.AccesoDatos;
using Core.AccesoDatos.Interfaces;
using Presentador.Base;
using System.Web;


namespace Presentador.Cliente.Vistas
{
    public class ModificarClientePresenter : PresentadorBase
    {

        #region Propiedades
        private IModificarCliente _vista;
        private const string campoVacio = "";

        #endregion



        #region constructor

        public ModificarClientePresenter()
        {
        }

        public ModificarClientePresenter(IModificarCliente vista)
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
            _vista.AreaNegocioCliente.Text = campoVacio;
            _vista.CalleAvenidaCliente.Text = campoVacio;
            _vista.CiudadCliente.Text = campoVacio;
            _vista.EdificioCasaCliente.Text = campoVacio;
            _vista.NombreCliente.Text = campoVacio;
            _vista.PisoApartamentoCliente.Text = campoVacio;
            _vista.rifCliente.Text = campoVacio;
            _vista.UrbanizacionCliente.Text = campoVacio;
            _vista.TelefonoTrabajoCliente.Text = campoVacio;
            _vista.CodigoTrabajoCliente.Text = campoVacio;
            _vista.TelefonoCelular.Text = campoVacio;
            _vista.CodCelular.Text = campoVacio;
            _vista.TelefonoFax.Text = campoVacio;
            _vista.CodFax.Text = campoVacio;


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

            }

            if (_vista.RbCampoBusqueda.SelectedValue == "2")
            {
                _vista.BotonBuscar.Visible = true;
                _vista.Valor.Visible = false;
                _vista.NombreCliente.Visible = false;
                _vista.ConsultaRif.Visible = true;
                _vista.RifCliente.Visible = true;
                _vista.GetObjectContainerConsultaCliente.DataSource = "";

            }
        }

        #endregion



        public void OnBotonBuscar()
        {
            IList<Core.LogicaNegocio.Entidades.Cliente> listaCliente = new List<Core.LogicaNegocio.Entidades.Cliente>();
            listaCliente = BuscarListaClientes();




            if (listaCliente.Count != 0)
            {
                CargarGrid(listaCliente);
            }
            else
            {
                _vista.PintarInformacion2(ManagerRecursos.GetString("MensajeConsulta"), "confirmacion");
                _vista.InformacionVisible2 = true;
            }
        }

        public IList<Core.LogicaNegocio.Entidades.Cliente> BuscarListaClientes()
        {
            Core.LogicaNegocio.Entidades.Cliente cliente = new Core.LogicaNegocio.Entidades.Cliente();
            IList<Core.LogicaNegocio.Entidades.Cliente> listaCliente = new List<Core.LogicaNegocio.Entidades.Cliente>();
            try
            {
                if (_vista.RbCampoBusqueda.SelectedValue == "1")// nombre de cliente
                {
                    cliente.Nombre = _vista.Valor.Text;
                    listaCliente = ConsultarClienteNombre(cliente);

                }

                if (_vista.RbCampoBusqueda.SelectedValue == "2")// rif del cliente
                {
                    cliente.Rif = _vista.ConsultaRif.Text;
                    listaCliente = ConsultarClienteRif(cliente);

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

            return listaCliente;
        }


        public void CargarGrid(IList<Core.LogicaNegocio.Entidades.Cliente> clientes)
        {
            _vista.GridCliente.DataSource = clientes;
            _vista.GridCliente.DataBind();
            _vista.GridCliente.Visible = true;

        }


        public void CargarDatos(Core.LogicaNegocio.Entidades.Cliente cliente)
        {
            int i = 0;
            IList<Core.LogicaNegocio.Entidades.TelefonoTrabajo> telefonos = new List<TelefonoTrabajo>();


            _vista.GetObjectContainerConsultaCliente.DataSource = cliente;

            _vista.IdCliente.Text = cliente.IdCliente.ToString();
            _vista.NombreCliente.Text = cliente.Nombre.ToString();
            _vista.AreaNegocioCliente.Text = cliente.AreaNegocio.ToString();
            _vista.CalleAvenidaCliente.Text = cliente.Direccion.Avenida.ToString();
            _vista.CiudadCliente.Text = cliente.Direccion.Ciudad.ToString();
            _vista.EdificioCasaCliente.Text = cliente.Direccion.Edif_Casa.ToString();
            _vista.PisoApartamentoCliente.Text = cliente.Direccion.Oficina.ToString();
            _vista.rifCliente.Text = cliente.Rif.ToString();
            _vista.UrbanizacionCliente.Text = cliente.Direccion.Urbanizacion.ToString();
            _vista.TelefonoTrabajoCliente.Text = cliente.Telefono[0].Numero.ToString();
            _vista.CodigoTrabajoCliente.Text = cliente.Telefono[0].Codigoarea.ToString();

            if (cliente.Telefono[1] != null)
            {
                _vista.TelefonoCelular.Text = cliente.Telefono[1].Codigoarea.ToString();
                _vista.CodCelular.Text = cliente.Telefono[1].Numero.ToString();
            }

            if (cliente.Telefono[2] != null)
            {
                _vista.TelefonoFax.Text = cliente.Telefono[2].Codigoarea.ToString();
                _vista.CodFax.Text = cliente.Telefono[2].Numero.ToString();
            }

        }


        public Core.LogicaNegocio.Entidades.Cliente CargarObjetoCliente()
        {

            Core.LogicaNegocio.Entidades.Cliente cliente = new Core.LogicaNegocio.Entidades.Cliente();
            try
            {
                cliente.Direccion = new Direccion();

                cliente.Telefono = new TelefonoTrabajo[3];

                cliente.Telefono[0] = new TelefonoTrabajo();
                cliente.Telefono[0].Codigoarea = int.Parse((string)_vista.CodigoTrabajoCliente.Text);
                cliente.Telefono[0].Numero = int.Parse((string)_vista.TelefonoTrabajoCliente.Text);
                cliente.Telefono[0].Tipo = "Trabajo";

                if (!_vista.CodCelular.Text.Equals("") && !_vista.TelefonoCelular.Text.Equals(""))
                {
                    cliente.Telefono[1] = new TelefonoTrabajo();
                    cliente.Telefono[1].Codigoarea = int.Parse((string)_vista.CodCelular.Text);
                    cliente.Telefono[1].Numero = int.Parse((string)_vista.TelefonoCelular.Text);
                    cliente.Telefono[1].Tipo = "Celular";
                }

                if (!_vista.CodFax.Text.Equals("") && !_vista.TelefonoFax.Text.Equals(""))
                {
                    cliente.Telefono[2] = new TelefonoTrabajo();
                    cliente.Telefono[2].Codigoarea = int.Parse((string)_vista.CodFax.Text);
                    cliente.Telefono[2].Numero = int.Parse((string)_vista.TelefonoFax.Text);
                    cliente.Telefono[2].Tipo = "Fax";
                }



                cliente.IdCliente = int.Parse((string)_vista.IdCliente.Text);


                cliente.Rif = _vista.TipoRif.SelectedValue.ToString() + " - " + _vista.rifCliente.Text.ToString();

                cliente.Nombre = _vista.NombreCliente.Text;

                cliente.Direccion = new Core.LogicaNegocio.Entidades.Direccion();

                cliente.Direccion.Avenida = _vista.CalleAvenidaCliente.Text;

                cliente.Direccion.Urbanizacion = _vista.UrbanizacionCliente.Text;

                cliente.Direccion.Edif_Casa = _vista.EdificioCasaCliente.Text;

                cliente.Direccion.Oficina = _vista.PisoApartamentoCliente.Text;

                cliente.Direccion.Ciudad = _vista.CiudadCliente.Text;

                cliente.AreaNegocio = _vista.AreaNegocioCliente.Text;

            }
            catch (WebException e)
            {
                _vista.Pintar(ManagerRecursos.GetString("codigoErrorWeb"),
                    ManagerRecursos.GetString("mensajeErrorWeb"), e.Source, e.Message + "\n " + e.StackTrace);
                _vista.DialogoVisible = true;

            }
            catch (AgregarClienteLNException e)
            {
                _vista.Pintar(ManagerRecursos.GetString("codigoErrorIngresar"),
                    ManagerRecursos.GetString("mensajeErrorIngresar"), e.Source, e.Message + "\n " + e.StackTrace);
                _vista.DialogoVisible = true;

            }
            catch (Exception e)
            {
                _vista.Pintar(ManagerRecursos.GetString("codigoErrorGeneral"),
                    ManagerRecursos.GetString("mensajeErrorGeneral"), e.Source, e.Message + "\n " + e.StackTrace);
                _vista.DialogoVisible = true;

            }

            return cliente;
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


        public IList<Core.LogicaNegocio.Entidades.Cliente> ConsultarClienteRif(Core.LogicaNegocio.Entidades.Cliente entidad)
        {
            IList<Core.LogicaNegocio.Entidades.Cliente> listacliente = new List<Core.LogicaNegocio.Entidades.Cliente>();


            try
            {
                Core.LogicaNegocio.Comandos.ComandoCliente.ConsultarRif comando; //tengo q crear una nueva consulta

                comando = FabricaComandosCliente.CrearComandoConsultarRif(entidad);

                listacliente = comando.ejecutar();


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
            return listacliente;
        }

        public void uxObjectConsultaClienteSelecting(string rif)
        {
            Core.LogicaNegocio.Entidades.Cliente cliente = new Core.LogicaNegocio.Entidades.Cliente();


            IList<Core.LogicaNegocio.Entidades.Cliente> listacliente = new List<Core.LogicaNegocio.Entidades.Cliente>();

            cliente.Rif = rif;

            listacliente = ConsultarClienteRif(cliente);
            cliente = listacliente[0];
            //Carga datos en la vista
            CargarDatos(cliente);
            CambiarVista(1);

        }


        public void uxObjectConsultaClienteDeleting(string rif)
        {

            Core.LogicaNegocio.Entidades.Cliente cliente = new Core.LogicaNegocio.Entidades.Cliente();

            IList<Core.LogicaNegocio.Entidades.Cliente> listacliente = new List<Core.LogicaNegocio.Entidades.Cliente>();

            cliente.Rif = rif;

            listacliente = ConsultarClienteRif(cliente);

            EliminarCliente(listacliente[0]);

        }

        public void EliminarCliente(Core.LogicaNegocio.Entidades.Cliente cliente)
        {
            Core.LogicaNegocio.Comandos.ComandoCliente.Eliminar eliminar; //objeto del comando Eliminar.
            eliminar = Core.LogicaNegocio.Fabricas.FabricaComandosCliente.CrearComandoEliminar(cliente);
            eliminar.Ejecutar();
            LimpiarFormulario();
            _vista.PintarInformacion2(ManagerRecursos.GetString("mensajeClienteEliminado"), "confirmacion");
            _vista.InformacionVisible2 = true;
            OnBotonBuscar();
        }


        public void DesactivarCliente()
        {
            Core.LogicaNegocio.Entidades.Cliente cliente = new Core.LogicaNegocio.Entidades.Cliente();
            cliente = CargarObjetoCliente();
            EliminarCliente(cliente);

            _vista.PintarInformacion(ManagerRecursos.GetString("mensajeClienteEliminado"), "confirmacion");
            _vista.InformacionVisible = true;
            LimpiarFormulario();
            _vista.Agregar.Visible = false;
            _vista.BotonVolver.Visible = true;

        }


        public void ActualizarCliente()
        {
            Core.LogicaNegocio.Entidades.Cliente cliente = new Core.LogicaNegocio.Entidades.Cliente();

            cliente = CargarObjetoCliente();

            Actualizar(cliente);

            _vista.PintarInformacion(ManagerRecursos.GetString("ClienteModificacionExitosa"), "confirmacion");
            _vista.InformacionVisible = true;

            DesactivarCampos();
            _vista.Agregar.Visible = false;

        }

        public void DesactivarCampos()
        {
            _vista.AreaNegocioCliente.Enabled = false;
            _vista.CalleAvenidaCliente.Enabled = false;
            _vista.CiudadCliente.Enabled = false;
            _vista.EdificioCasaCliente.Enabled = false;
            _vista.NombreCliente.Enabled = false;
            _vista.PisoApartamentoCliente.Enabled = false;
            _vista.rifCliente.Enabled = false;
            _vista.UrbanizacionCliente.Enabled = false;
            _vista.TelefonoTrabajoCliente.Enabled = false;
            _vista.CodigoTrabajoCliente.Enabled = false;
            _vista.TelefonoCelular.Enabled = false;
            _vista.CodCelular.Enabled = false;
            _vista.TelefonoFax.Enabled = false;
            _vista.CodFax.Enabled = false;
        }

        #endregion

        #region Comando

        public void Actualizar(Core.LogicaNegocio.Entidades.Cliente cliente)
        {
            Core.LogicaNegocio.Comandos.ComandoCliente.Modificar actualizar; //objeto del comando Actualizar.

            //fábrica que instancia el comando Modificar.
            actualizar = Core.LogicaNegocio.Fabricas.FabricaComandosCliente.CrearComandoModificar(cliente);

            actualizar.Ejecutar();

        }



        #endregion
    }
}
