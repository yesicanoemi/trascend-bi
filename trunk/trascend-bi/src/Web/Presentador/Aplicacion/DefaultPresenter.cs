using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Fabricas;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Web.SessionState;
using System.Net;
using Presentador.Base;
using System.Resources;


namespace Presentador.Aplicacion
{
    public class DefaultPresenter : PresentadorBase
    {
        #region Propiedades

        public Core.LogicaNegocio.Entidades.Usuario SesionUsuario;

        #endregion

        #region Constructor

        private IDefaultPresenter _vista;

        public DefaultPresenter(IDefaultPresenter vista)
        {
            _vista = vista;

        }

        #endregion

        #region Métodos

        /// <summary>
        /// Metodo para ingresar al sistema al darle click a aceptar
        /// </summary>

        public void OnBotonAceptar()
        {
            Core.LogicaNegocio.Entidades.Usuario user = new Core.LogicaNegocio.Entidades.Usuario();

            user.Login = _vista.Login.Text;

            user.Password = _vista.Password.Text;

            user = ConsultarCredenciales(user);

            IList<Core.LogicaNegocio.Entidades.Permiso> listadoPermiso = ConsultarPermisos(user);

            user.PermisoUsu = listadoPermiso;

            if ((user != null) && (user.Status == "Activo"))
            {
                _vista.Sesion["SesionUsuario"] = user;

                SesionUsuario = (Core.LogicaNegocio.Entidades.Usuario)_vista.Sesion["SesionUsuario"];

                _vista.IngresarSistema();
            }

            else
            {
                _vista.PintarInformacion(ManagerRecursos.GetString
                                            ("MensajeCredenciales"), "mensajes");

            }

        }

        #endregion

        #region Comandos

        /// <summary>
        /// Metodo que consulta las credenciales del usuario que ha iniciado sesion
        /// </summary>
        /// <param name="entidad">el usuario que ingreso sus datos</param>
        /// <returns>el usuario si se encuentra en la bd</returns>

        public Core.LogicaNegocio.Entidades.Usuario
                        ConsultarCredenciales(Core.LogicaNegocio.Entidades.Usuario entidad)
        {

            Core.LogicaNegocio.Entidades.Usuario usuario1 = null;

            Core.LogicaNegocio.Comandos.ComandoUsuario.ConsultarCredenciales comando;

            comando = FabricaComandosUsuario.CrearComandoConsultarCredenciales(entidad);

            usuario1 = comando.Ejecutar();

            return usuario1;
        }


        /// <summary>
        /// Método para el comando ConsultarPermisos
        /// </summary>
        /// <param name="entidad">Entidad Permiso a consultar (depende del usuario selecc)</param>
        /// <returns>Lista de permisos que posea el usuario</returns>

        public IList<Core.LogicaNegocio.Entidades.Permiso> ConsultarPermisos
                                            (Core.LogicaNegocio.Entidades.Usuario entidad)
        {

            IList<Core.LogicaNegocio.Entidades.Permiso> permiso1 = null;

            Core.LogicaNegocio.Comandos.ComandoUsuario.ConsultarPermisos comando;

            comando = FabricaComandosUsuario.CrearComandoConsultarPermisos(entidad);

            permiso1 = comando.Ejecutar();

            return permiso1;
        }

        #endregion

    }
}
