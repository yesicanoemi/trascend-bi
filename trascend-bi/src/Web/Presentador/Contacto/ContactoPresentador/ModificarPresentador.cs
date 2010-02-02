using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Contacto.ContactoInterface;
using Core.LogicaNegocio.Entidades;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Resources;
using Core.LogicaNegocio.Excepciones;
using Core.LogicaNegocio.Fabricas;
using Presentador.Base;
using Core.LogicaNegocio.Comandos.ComandoContacto;
using System.Net;

namespace Presentador.Contacto.ContactoPresentador
{
    public class ModificarPresentador : PresentadorBase
    {

        #region Propiedades

        private IModificarContacto _vista;

        private const string campoVacio = "";

        #endregion
  
        #region Constructor

        public ModificarPresentador(IModificarContacto vista)
        {
            _vista = vista;

        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método que guarda los nuevos datos del Contacto
        /// </summary>

        public void OnBotonAceptar()
        {
            Core.LogicaNegocio.Entidades.Contacto contacto = new Core.LogicaNegocio.Entidades.Contacto();
            
            try
            {
                contacto.Nombre = _vista.NombreC.Text;

                contacto.Apellido = _vista.ApellidoC.Text;

                contacto.Cargo = _vista.CargoC.Text;

                contacto.AreaDeNegocio = _vista.AreaC.Text;

                contacto.TelefonoDeTrabajo.Codigoarea = Int32.Parse(_vista.CodTelefonoC1.Text);

                contacto.TelefonoDeTrabajo.Numero = Int32.Parse(_vista.TelefonoC1.Text);

                contacto.TelefonoDeTrabajo.Tipo = _vista.TipoTlfC1.Text;

                contacto.ClienteContac = new Core.LogicaNegocio.Entidades.Cliente();

                contacto.ClienteContac.Nombre = _vista.ClienteC.Text;

                if ((_vista.CodTelefonoC2.Text != "") && (_vista.TelefonoC2.Text != ""))
                {
                    contacto.TelefonoDeCelular.Codigocel = Int32.Parse(_vista.CodTelefonoC2.Text);

                    contacto.TelefonoDeCelular.Numero = Int32.Parse(_vista.TelefonoC2.Text);

                    contacto.TelefonoDeCelular.Tipo = _vista.TipoTlfC2.Text;
                }

                contacto.IdContacto = Int32.Parse(_vista.IdContactoH.Text);

                contacto.ClienteContac.IdCliente = Int32.Parse(_vista.IdClienteH.Text);

                if ((_vista.CodTelefonoC1.Text.Length == 3) &&
                                    (_vista.TelefonoC1.Text.Length == 7))
                {
                    if (((_vista.CodTelefonoC2.Text.Length == 3) &&
                                (_vista.TelefonoC2.Text.Length == 7)) ||
                                        ((_vista.CodTelefonoC2.Text.Length == 0) &&
                                                    (_vista.TelefonoC2.Text.Length == 0)))
                    {
                        ModificarContacto(contacto);

                        LimpiarElementosVisibles();

                        CambiarVista(0);
                    }
                    else
                    {
                        _vista.PintarInformacion2(ManagerRecursos.GetString
                           ("mensajeTelefonoIncorrecto"), "mensajes");
                        _vista.InformacionVisible2 = true;
                    }
                }
                else
                {
                    _vista.PintarInformacion2(ManagerRecursos.GetString
                               ("mensajeTelefonoIncorrecto"), "mensajes");
                    _vista.InformacionVisible2 = true;
                }
            }
            catch (WebException e)
            {
                _vista.Pintar("0001", "Error al Modificar Contacto", "Especificacion del Error", e.ToString());
                _vista.DialogoVisible = true;
            }
            catch (Exception e)
            {
                _vista.Pintar("0001", "Error al Modificar Contacto", "Especificacion del Error", e.ToString());
                _vista.DialogoVisible = true;
            }

        }

        /// <summary>
        /// Método que oculta los elementos de la vista
        /// </summary>

        public void LimpiarElementosVisibles()
        {
            _vista.TextBoxNombre.Visible = false;

            _vista.TextBoxApellido.Visible = false;

            _vista.TextBoxCodTelefono.Visible = false;

            _vista.TextBoxNumTelefono.Visible = false;

            _vista.ClienteDdl.Visible = false;

            _vista.BotonBuscar.Visible = false;

            _vista.NombreContacto.Visible = false;

            _vista.ApellidoContacto.Visible = false;

            _vista.CodigoTlf.Visible = false;

            _vista.Tlf.Visible = false;

            _vista.NombreCliente.Visible = false;

            _vista.Valor.Visible = false;

            _vista.GetObjectContainerConsultaContacto.DataSource = "";

            _vista.PintarInformacion2(ManagerRecursos.GetString
                           ("mensajeModificarContacto"), "mensajes");

            _vista.InformacionVisible2 = true;

            _vista.RbCampoBusqueda.ClearSelection();
        }

        /// <summary>
        /// Metodo para cambiar la vista 
        /// </summary>
        /// <param name="index">Numero de vista</param>

        public void CambiarVista(int index)
        {

            _vista.MultiViewConsultar.ActiveViewIndex = index;
        }

        /// <summary>
        /// Metodo para cargar los datos por pantalla una vez seleccionado el contacto
        /// </summary>
        /// <param name="usuario">Entidad Contacto con sus datos</param>

        private void CargarDatos(Core.LogicaNegocio.Entidades.Contacto contacto)
        {
            #region Validaciones 

            _vista.RequiredFieldValidator3.Visible = true;

            _vista.RequiredFieldValidator4.Visible = true;

            _vista.RequiredFieldValidator5.Visible = true;

            _vista.RequiredFieldValidator6.Visible = true;

            _vista.RequiredFieldValidator7.Visible = true;

            _vista.RequiredFieldValidator8.Visible = true;

            _vista.IdContactoH.Text = contacto.IdContacto.ToString();

            _vista.IdClienteH.Text = contacto.ClienteContac.IdCliente.ToString(); 

            #endregion 

            _vista.NombreC.Text = contacto.Nombre;

            _vista.ApellidoC.Text = contacto.Apellido;

            _vista.CargoC.Text = contacto.Cargo;

            _vista.AreaC.Text = contacto.AreaDeNegocio;

            _vista.CodTelefonoC1.Text = contacto.TelefonoDeTrabajo.Codigoarea.ToString();
 
            _vista.TelefonoC1.Text = contacto.TelefonoDeTrabajo.Numero.ToString();

            for (int i = 0; i < 3; i++)
            {
                if (_vista.TipoTlfC1.Items[i].Value == contacto.TelefonoDeTrabajo.Tipo)
                {
                    _vista.TipoTlfC1.SelectedIndex = i; 

                }
            
            }
            
            //Si el contacto tiene mas de 1 tlf

            if (contacto.TelefonoDeCelular.Codigocel > 0)
            {
                _vista.CodTelefonoC2.Text = contacto.TelefonoDeCelular.Codigocel.ToString();

                _vista.TelefonoC2.Text = contacto.TelefonoDeCelular.Numero.ToString();

                for (int j = 0; j < 3; j++)
                {
                    if (_vista.TipoTlfC2.Items[j].Value == contacto.TelefonoDeCelular.Tipo)
                    {
                        _vista.TipoTlfC2.SelectedIndex = j;

                    }

                }
            }
            
            _vista.ClienteC.Text = contacto.ClienteContac.Nombre;
        }

        /// <summary>
        /// Método para limpiar el formulario
        /// </summary>
        
        private void LimpiarFormulario()
        {
            _vista.TextBoxNombre.Text = campoVacio;

            _vista.TextBoxApellido.Text = campoVacio;

            _vista.TextBoxCodTelefono.Text = campoVacio;

            _vista.TextBoxNumTelefono.Text = campoVacio;

            _vista.Valor.Text = campoVacio;

            _vista.RequiredFieldValidator.Visible = false;

            _vista.RequiredFieldValidator1.Visible = false;

            _vista.GetObjectContainerConsultaContacto.DataSource = "";

            _vista.InformacionVisible = false;

            _vista.InformacionVisible2 = false;

        }

        #region Radio Buttons

        /// <summary>
        /// Acción al seleccionar el radiobutton
        /// </summary>
        
        public void CampoBusqueda_Selected()
        {
            LimpiarFormulario();

            if (_vista.RbCampoBusqueda.SelectedValue == "1")
            {
                _vista.TextBoxNombre.Visible = true;

                _vista.TextBoxApellido.Visible = true;

                _vista.TextBoxCodTelefono.Visible = false;

                _vista.TextBoxNumTelefono.Visible = false;

                _vista.ClienteDdl.Visible = false;

                _vista.BotonBuscar.Visible = true;

                _vista.NombreContacto.Visible = true;

                _vista.ApellidoContacto.Visible = true;

                _vista.CodigoTlf.Visible = false;

                _vista.Tlf.Visible = false;

                _vista.NombreCliente.Visible = false;

                _vista.Valor.Visible = false;
            }

            if (_vista.RbCampoBusqueda.SelectedValue == "2")
            {
                _vista.TextBoxNombre.Visible = false;

                _vista.TextBoxApellido.Visible = false;

                _vista.TextBoxCodTelefono.Visible = true;

                _vista.TextBoxNumTelefono.Visible = true;

                _vista.BotonBuscar.Visible = true;

                _vista.ClienteDdl.Visible = false;

                _vista.NombreContacto.Visible = false;

                _vista.ApellidoContacto.Visible = false;

                _vista.CodigoTlf.Visible = true;

                _vista.Tlf.Visible = true;

                _vista.NombreCliente.Visible = false;

                _vista.Valor.Visible = false;

                _vista.RequiredFieldValidator.Visible = true;

                _vista.RequiredFieldValidator1.Visible = true;
            }

            if (_vista.RbCampoBusqueda.SelectedValue == "3")
            {
                _vista.TextBoxNombre.Visible = false;

                _vista.TextBoxApellido.Visible = false;

                _vista.TextBoxCodTelefono.Visible = false;

                _vista.TextBoxNumTelefono.Visible = false;

                _vista.Valor.Visible = true;

                _vista.BotonBuscar.Visible = true;

                _vista.NombreContacto.Visible = false;

                _vista.ApellidoContacto.Visible = false;

                _vista.CodigoTlf.Visible = false;

                _vista.Tlf.Visible = false;

                _vista.NombreCliente.Visible = true;

                _vista.GetObjectContainerConsultaContacto.DataSource = "";
            }

        }

        #endregion 

        #region Buscar

        /// <summary>
        /// Acción del Botón Buscar
        /// </summary>

        public void OnBotonBuscar()
        {
            _vista.GetObjectContainerConsultaContacto.DataSource = "";

            bool imprime = true; 

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
                    listContac.Clear();

                    listContac = ConsultarContactoNombreApellido(contacto);

                    _vista.InformacionVisible = false;
                }

                //Consulta por número de tlf

                if (_vista.RbCampoBusqueda.SelectedValue == "2")
                {
                    if ((_vista.TextBoxCodTelefono.Text != "") &&
                        (_vista.TextBoxNumTelefono.Text != ""))
                    {
                        contacto.TelefonoDeTrabajo.Codigoarea = int.Parse(_vista.TextBoxCodTelefono.Text);

                        contacto.TelefonoDeTrabajo.Numero = int.Parse(_vista.TextBoxNumTelefono.Text);

                        listContac.Clear();

                        IList<Core.LogicaNegocio.Entidades.Contacto> aux =
                                                        new List<Core.LogicaNegocio.Entidades.Contacto>();

                        aux.Add(ConsultarContactoXTelefono(contacto));

                        if ((aux[0].TelefonoDeTrabajo.Codigoarea > 0) && (aux[0].TelefonoDeTrabajo.Numero > 0))
                        {
                            listContac = aux;
                        
                        }

                        _vista.InformacionVisible = false;
                    }

                    else
                    {
                        _vista.RequiredFieldValidator.Visible = true;

                        _vista.RequiredFieldValidator1.Visible = true;

                        imprime = false;

                    }
                }

                //Consulta por cliente

                if (_vista.RbCampoBusqueda.SelectedValue == "3")
                {

                    Core.LogicaNegocio.Entidades.Cliente cliente = new Core.LogicaNegocio.Entidades.Cliente();
                    
                    cliente.Nombre = _vista.Valor.Text;

                    IList<Core.LogicaNegocio.Entidades.Cliente> listaCliente = ConsultarClienteNombre(cliente);
                    for (int i = 0; i < listaCliente.Count; i++)
                    {
                        contacto.ClienteContac = listaCliente[i];

                        for (int j = 0; j < ConsultarContactoXCliente(contacto).Count; j++)
                        {
                            listContac.Add(ConsultarContactoXCliente(contacto)[j]);
                        }
                    }

                    _vista.InformacionVisible = false;

                }

                if (listContac.Count == 1)
                {
                    CargarDatos(listContac[0]);

                    CambiarVista(1);
                }
                else if (listContac.Count > 1)
                {
                    _vista.GetObjectContainerConsultaContacto.DataSource = listContac;

                    _vista.GetObjectContainerConsultaContacto.DataBind();
                }
                else
                {
                    if (imprime == true)
                    {
                        _vista.PintarInformacion(ManagerRecursos.GetString
                        ("MensajeConsulta"), "mensajes");
                        _vista.InformacionVisible = true;
                    }
                }

            }

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

            }

        }

        #endregion 

        /// <summary>
        /// Método que redirecciona al usuario a la página default de consulta
        /// </summary>

        public void OnBotonCancelar()
        {
            _vista.CambiarPagina();
        }

        /// <summary>
        /// Método de Consulta una vez seleccionado el contacto 
        /// </summary>
        /// <param name="idContacto">Id del contacto</param>

        public void uxObjectConsultaContactoSelecting(string idContacto)
        {
            Core.LogicaNegocio.Entidades.Contacto contacto = new Core.LogicaNegocio.Entidades.Contacto();

            Core.LogicaNegocio.Entidades.Contacto contacto2 = new Core.LogicaNegocio.Entidades.Contacto();

            contacto.IdContacto = int.Parse(idContacto);

            contacto2 = ConsultarContactoxId(contacto);

            CargarDatos(contacto2);

            CambiarVista(1);

        }

        #endregion

        #region Comandos

        /// <summary>
        /// Método para el comando ConsultarContactoxId
        /// </summary>
        /// <param name="entidad">Entidad comando a consultar (por Id)</param>
        /// <returns>Lista de contacto que cumplan con el parámetro de búsqueda</returns>

        public Core.LogicaNegocio.Entidades.Contacto ConsultarContactoxId
                                                (Core.LogicaNegocio.Entidades.Contacto entidad)
        {
            Core.LogicaNegocio.Entidades.Contacto contacto1 = null;

            Core.LogicaNegocio.Comandos.ComandoContacto.ConsultarContactoxId comando;

            comando = FabricaComandosContacto.CrearComandoConsultarContactoxId(entidad);

            contacto1 = comando.Ejecutar();

            return contacto1;
        }


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

        /// <summary>
        /// Método para el comando ConsultarClientes
        /// </summary>
        /// <param name="entidad">Entidad comando a consultar (por cliente)</param>
        /// <returns>El cliente que cumpla con el criterio de búsqueda</returns>

        public IList<Core.LogicaNegocio.Entidades.Cliente>
                            ConsultarClienteNombre(Core.LogicaNegocio.Entidades.Cliente entidad)
        {
            IList<Core.LogicaNegocio.Entidades.Cliente> listaCliente = null;

            Core.LogicaNegocio.Comandos.ComandoCliente.ConsultarNombre comando;

            comando = FabricaComandosCliente.CrearComandoConsultarNombre(entidad);

            listaCliente = comando.ejecutar();

            return listaCliente;
        }

        /// <summary>
        /// Método para el comando ModificarContacto
        /// </summary>
        /// <param name="entidad">Entidad contacto a modificar</param>

        public void ModificarContacto (Core.LogicaNegocio.Entidades.Contacto entidad)
        {

            Core.LogicaNegocio.Comandos.ComandoContacto.ModificarContacto comando;

            comando = FabricaComandosContacto.CrearComandoModificarContacto(entidad);

            comando.Ejecutar();
        }

        #endregion
    }
    
}
