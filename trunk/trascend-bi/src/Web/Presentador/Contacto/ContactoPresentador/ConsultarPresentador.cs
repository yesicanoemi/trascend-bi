using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Contacto.ContactoInterface;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Resources;
using Core.LogicaNegocio.Excepciones;
using Core.LogicaNegocio.Fabricas;


namespace Presentador.Contacto.ContactoPresentador
{
    public class ConsultarPresentador
    {
        #region Propiedades

        private IConsultarContacto _vista;

        #endregion
  
        #region Constructor

        public ConsultarPresentador(IConsultarContacto vista)
        {
            _vista = vista;

        }

        #endregion

        /// <summary>
        /// Método que redirecciona al usuario a otra página (de consulta)
        /// </summary>

        public void OnBotonAceptar()
        {
            _vista.CambiarPagina();
        }

        /// <summary>
        /// Metodo para cambiar la vista 
        /// </summary>
        /// <param name="index">Numero de vista</param>

        public void CambiarVista(int index)
        {

            _vista.MultiViewConsultar.ActiveViewIndex = index;
        }


        public void CargarClientes()
        {
            Core.LogicaNegocio.Entidades.Cliente cliente = new Core.LogicaNegocio.Entidades.Cliente();
            
            IList<Core.LogicaNegocio.Entidades.Cliente> listaClientes;

            //listaClientes = ConsultarClienteParametroNombre() ;

            _vista.ClienteDdl.Items.Clear();
            _vista.ClienteDdl.Items.Add(" -- ");
            _vista.ClienteDdl.Items[0].Value = "0";
           // _vista.ClienteDdl.DataSource = listaClientes;
            _vista.ClienteDdl.DataValueField = "IdCliente";
            _vista.ClienteDdl.DataTextField = "Nombre";
            _vista.ClienteDdl.DataBind();

        }

        /// <summary>
        /// Metodo para cargar los datos por pantalla una vez seleccionado el contacto
        /// </summary>
        /// <param name="usuario">Entidad Contacto con sus datos</param>

        private void CargarDatos(Core.LogicaNegocio.Entidades.Contacto contacto)
        {
            _vista.NombreC.Text = contacto.Nombre;

            _vista.ApellidoC.Text = contacto.Apellido;

            _vista.CargoC.Text = contacto.Cargo;

            _vista.AreaC.Text = contacto.AreaDeNegocio;

            _vista.TelefonoC.Text = contacto.TelefonoDeTrabajo.Codigoarea.ToString() 
                                    + contacto.TelefonoDeTrabajo.Numero.ToString();

            _vista.TipoTlfC.Text = contacto.TelefonoDeTrabajo.Tipo;

            _vista.ClienteC.Text = contacto.ClienteContac.Nombre;
        }

        /// <summary>
        /// Acción al seleccionar el checkbox
        /// </summary>
        
        public void CampoBusqueda_Selected()
        {
            if (_vista.RbCampoBusqueda.SelectedValue == "1")
            {
                _vista.TextBoxNombre.Visible = true;

                _vista.TextBoxApellido.Visible = true;

                _vista.TextBoxCodTelefono.Visible = false;

                _vista.TextBoxNumTelefono.Visible = false;

                _vista.ClienteDdl.Visible = false;

                _vista.BotonBuscar.Visible = true;

                //_vista.ValidarNombreVacio.Visible = true;

               _vista.GetObjectContainerConsultaContacto.DataSource = "";
            }

            if (_vista.RbCampoBusqueda.SelectedValue == "2")
            {
                _vista.TextBoxNombre.Visible = false;

                _vista.TextBoxApellido.Visible = false;

                _vista.TextBoxCodTelefono.Visible = true;

                _vista.TextBoxNumTelefono.Visible = true;

                _vista.BotonBuscar.Visible = true;

                _vista.ClienteDdl.Visible = false;

                //_vista.ValidarNombreVacio.Visible = false;

               _vista.GetObjectContainerConsultaContacto.DataSource = "";
            }

            if (_vista.RbCampoBusqueda.SelectedValue == "3")
            {
                _vista.TextBoxNombre.Visible = false;

                _vista.TextBoxApellido.Visible = false;

                _vista.TextBoxCodTelefono.Visible = false;

                _vista.TextBoxNumTelefono.Visible = false;

                _vista.ClienteDdl.Visible = true;

                _vista.BotonBuscar.Visible = true;

                //_vista.ValidarNombreVacio.Visible = false;

                _vista.GetObjectContainerConsultaContacto.DataSource = "";
            }

        }

        /// <summary>
        /// Acción del Botón Buscar
        /// </summary>

        public void OnBotonBuscar()
        {
            _vista.GetObjectContainerConsultaContacto.DataSource = "";

            Core.LogicaNegocio.Entidades.Contacto contacto = new Core.LogicaNegocio.Entidades.Contacto();

            IList<Core.LogicaNegocio.Entidades.Contacto> listContac = 
                                                        new List<Core.LogicaNegocio.Entidades.Contacto>();

            //Llena el objeto contacto con los datos de la consulta

            contacto.Nombre = _vista.TextBoxNombre.Text;

            contacto.Apellido = _vista.TextBoxApellido.Text;

            try
            {
                //Consulta por nombre y apellido

                if (_vista.RbCampoBusqueda.SelectedValue == "1")
                {
                    listContac = null;

                    listContac = ConsultarContactoNombreApellido(contacto);
                }

                //Consulta por número de tlf

                if (_vista.RbCampoBusqueda.SelectedValue == "2")
                {
                    if ((_vista.TextBoxCodTelefono.Text != null) &&
                        (_vista.TextBoxNumTelefono.Text != null))
                    {
                        contacto.TelefonoDeTrabajo.Codigoarea = int.Parse(_vista.TextBoxCodTelefono.Text);

                        contacto.TelefonoDeTrabajo.Numero = int.Parse(_vista.TextBoxNumTelefono.Text);

                        listContac = null;

                        IList<Core.LogicaNegocio.Entidades.Contacto> aux =
                                                        new List<Core.LogicaNegocio.Entidades.Contacto>();

                        aux.Add(ConsultarContactoXTelefono(contacto));

                        if ((aux[0].TelefonoDeTrabajo.Codigoarea > 0) && (aux[0].TelefonoDeTrabajo.Numero > 0))
                        {
                            listContac = aux;
                        
                        }

                        //_vista.InformacionVisible = false;

                    }

                    else
                    {
                        //debe llenar el codigo y el tlf

                    }
                }

                //Consulta por cliente

                if (_vista.RbCampoBusqueda.SelectedValue == "3")
                {
                    contacto.ClienteContac.IdCliente = int.Parse(_vista.ClienteDdl.Text);

                    listContac = ConsultarContactoXCliente(contacto);

                    //_vista.InformacionVisible = false;

                }

                if (listContac.Count > 0)
                {
                    //_vista.InformacionVisible = false;

                    _vista.GetObjectContainerConsultaContacto.DataSource = listContac;

                    _vista.GetObjectContainerConsultaContacto.DataBind();

                }
                else
                {
                    //_vista.PintarInformacion(ManagerRecursos.GetString
                    //("MensajeConsulta"), "mensajes");
                    //_vista.InformacionVisible = true;

                }

            }

            catch (Exception e)
            {

            }

                /*
            catch (WebException e)
            {

                _vista.Pintar(ManagerRecursos.GetString("codigoErrorWeb"),
                    ManagerRecursos.GetString("mensajeErrorWeb"), e.Source, e.Message +
                                                                "\n " + e.StackTrace);
                _vista.DialogoVisible = true;

            }
            catch (ConsultarException e)
            {
                _vista.Pintar(ManagerRecursos.GetString("codigoErrorConsultar"),
                    ManagerRecursos.GetString("mensajeErrorConsultar"), e.Source, e.Message +
                                                                "\n " + e.StackTrace);
                _vista.DialogoVisible = true;

            }
            catch (Exception e)
            {
                _vista.Pintar(ManagerRecursos.GetString("codigoErrorGeneral"),
                    ManagerRecursos.GetString("mensajeErrorGeneral"), e.Source, e.Message +
                                                                "\n " + e.StackTrace);
                _vista.DialogoVisible = true;

            }*/

        }

        /// <summary>
        /// Método de Consulta una vez seleccionado el contacto 
        /// </summary>
        /// <param name="idContacto">Id del contacto</param>

        public void uxObjectConsultaContactoSelecting(string idContacto)
        {
            Core.LogicaNegocio.Entidades.Contacto contacto = new Core.LogicaNegocio.Entidades.Contacto();

            contacto.IdContacto = int.Parse(idContacto);

            contacto.Nombre = "";

            contacto.Apellido = "";

            IList<Core.LogicaNegocio.Entidades.Contacto> listaContac = 
                                                            ConsultarContactoNombreApellido(contacto);

            for (int i = 0; i < listaContac.Count; i++)
            {
                if (listaContac[i].IdContacto == contacto.IdContacto)
                {
                    CargarDatos(listaContac[i]);

                    i = listaContac.Count;
                }
            
            }

            CambiarVista(1);

        }

        #region Comandos

        /// <summary>
        /// Método para el comando ConsultarContactoNombreApellido
        /// </summary>
        /// <param name="entidad">Entidad comando a consultar (por nombre y apellido)</param>
        /// <returns>Lista de contacto que cumplan con el parámetro de búsqueda</returns>

        public IList<Core.LogicaNegocio.Entidades.Contacto> ConsultarContactoNombreApellido
                                                (Core.LogicaNegocio.Entidades.Contacto entidad)
        {
            IList<Core.LogicaNegocio.Entidades.Contacto> contacto1 = null;

            Core.LogicaNegocio.Comandos.ComandoContacto.ConsultarContactoNombreApellido comando;

            comando = FabricaComandosContacto.CrearComandoConsultarContactoNombreApellido(entidad);

            contacto1 = comando.Ejecutar();

            return contacto1;
        }

        /// <summary>
        /// Método para el comando ConsultarContactoXTelefono
        /// </summary>
        /// <param name="entidad">Entidad comando a consultar (por tlf)</param>
        /// <returns>Lista de contacto que cumplan con el parámetro de búsqueda</returns>

        public Core.LogicaNegocio.Entidades.Contacto ConsultarContactoXTelefono
                                                (Core.LogicaNegocio.Entidades.Contacto entidad)
        {
            Core.LogicaNegocio.Entidades.Contacto contacto1 = null;

            Core.LogicaNegocio.Comandos.ComandoContacto.ConsultarContactoXTelefono comando;

            comando = FabricaComandosContacto.CrearComandoConsultarContactoXTelefono(entidad);

            contacto1 = comando.Ejecutar();

            return contacto1;
        }

        /// <summary>
        /// Método para el comando ConsultarContactoXCliente
        /// </summary>
        /// <param name="entidad">Entidad comando a consultar (por cliente)</param>
        /// <returns>Lista de contacto que cumplan con el parámetro de búsqueda</returns>

        public IList<Core.LogicaNegocio.Entidades.Contacto> ConsultarContactoXCliente
                                                (Core.LogicaNegocio.Entidades.Contacto entidad)
        {
            IList<Core.LogicaNegocio.Entidades.Contacto> contacto1 = null;

            Core.LogicaNegocio.Comandos.ComandoContacto.ConsultarContactoXCliente comando;

            comando = FabricaComandosContacto.CrearComandoConsultarContactoXCliente(entidad);

            contacto1 = comando.Ejecutar();

            return contacto1;
        }

        #endregion
    }
    
}
