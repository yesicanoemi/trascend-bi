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
            Core.LogicaNegocio.Entidades.Contacto contacto = new Core.LogicaNegocio.Entidades.Contacto();

            IList<Core.LogicaNegocio.Entidades.Contacto> listContac = 
                                                        new List<Core.LogicaNegocio.Entidades.Contacto>();

            //Llena el objeto contacto con los datos de la consulta

            contacto.Nombre = _vista.TextBoxNombre.Text;

            contacto.Apellido = _vista.TextBoxApellido.Text;

            contacto.TelefonoDeTrabajo.Codigoarea = int.Parse(_vista.TextBoxCodTelefono.Text);

            contacto.TelefonoDeTrabajo.Numero = int.Parse(_vista.TextBoxNumTelefono.Text);

            contacto.IdCliente = int.Parse(_vista.ClienteDdl.Text);

            try
            {
                //Consulta por nombre y apellido

                if ((_vista.RbCampoBusqueda.SelectedValue == "1") && 
                    ((contacto.Nombre != "") || (contacto.Apellido != "")))
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
                        listContac = null;

                        listContac = ConsultarContactoXTelefono(contacto);

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
                    listContac = ConsultarContactoXCliente(contacto);

                    //_vista.InformacionVisible = false;

                }

                if (listContac.Count > 0)
                {
                    //_vista.InformacionVisible = false;

                    _vista.GetObjectContainerConsultaContacto.DataSource = listContac;

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

        public IList<Core.LogicaNegocio.Entidades.Contacto> ConsultarContactoXTelefono
                                                (Core.LogicaNegocio.Entidades.Contacto entidad)
        {
            IList<Core.LogicaNegocio.Entidades.Contacto> contacto1 = null;

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
