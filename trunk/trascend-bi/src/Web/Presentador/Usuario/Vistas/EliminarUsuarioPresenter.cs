using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;
using Presentador.Usuario.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Fabricas;
using Presentador.Base;
using System.Resources;
using Core.LogicaNegocio.Excepciones;
using System.Net;
using System.Collections;

namespace Presentador.Usuario.Vistas
{
    public class EliminarUsuarioPresenter: PresentadorBase
    {
        #region Propiedades
        
        private IEliminarUsuario _vista;
        private const int _TamanoLista = 8;
        
        #endregion

        #region Constructor

        public EliminarUsuarioPresenter(IEliminarUsuario vista)
        {
            _vista = vista;

        }

        #endregion

        #region metodos
        
        /// <summary>
        /// Método para cambiar la vista del MultiView
        /// </summary>
        /// <param name="index">Número de la vista sig</param>

        public void CambiarVista(int index)
        {

            _vista.MultiViewEliminar.ActiveViewIndex = index;
        }

        /// <summary>
        /// Acción del botón buscar
        /// </summary>

        public void OnBotonBuscar()
        {

            Core.LogicaNegocio.Entidades.Usuario user = new Core.LogicaNegocio.Entidades.Usuario();

            user.Login = _vista.Login.Text;

            IList<Core.LogicaNegocio.Entidades.Usuario> listado = ConsultarUsuario(user);


            try
            {

                if (listado.Count > 0)
                {

                    _vista.GetObjectContainerConsultaEliminarUsuario.DataSource = listado;

                }

                else
                {
                    _vista.PintarInformacion(ManagerRecursos.GetString
                                                ("MensajeConsulta"), "mensajes");
                    _vista.InformacionVisible = true;
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

        public void uxObjectConsultaEliminarUsuarioSelecting(string Login)
        {
            Core.LogicaNegocio.Entidades.Usuario user = new Core.LogicaNegocio.Entidades.Usuario();

            user.Login = Login;

            IList<Core.LogicaNegocio.Entidades.Usuario> listado = ConsultarUsuario(user);

            IList<Core.LogicaNegocio.Entidades.Permiso> listadoPermiso = ConsultarPermisos(listado[0]);

            EliminarUsuario();
            //CargarCheckBox(listadoPermiso);

            //CargarDatos(listado[0]);

            CambiarVista(1);

        }

        /// <summary>
        /// Consulta los usuarios en la bd
        /// </summary>
        /// <param name="entidad">Entidad usuario</param>
        /// <returns>Entidad usuario</returns>
        public IList<Core.LogicaNegocio.Entidades.Usuario> ConsultarUsuario
                                    (Core.LogicaNegocio.Entidades.Usuario entidad)
        {

            IList<Core.LogicaNegocio.Entidades.Usuario> usuario1 = null;

            Core.LogicaNegocio.Comandos.ComandoUsuario.ConsultarUsuario comando;

            comando = FabricaComandosUsuario.CrearComandoConsultarUsuario(entidad);

            usuario1 = comando.Ejecutar();

            return usuario1;
        }

        /// <summary>
        /// Consultar los permisos de un determinado usuario
        /// </summary>
        /// <param name="entidad">Entidad usuario</param>
        /// <returns>Lista de permisos</returns>

        public IList<Core.LogicaNegocio.Entidades.Permiso> ConsultarPermisos
                                    (Core.LogicaNegocio.Entidades.Usuario entidad)
        {

            IList<Core.LogicaNegocio.Entidades.Permiso> permiso1 = null;

            Core.LogicaNegocio.Comandos.ComandoUsuario.ConsultarPermisos comando;

            comando = FabricaComandosUsuario.CrearComandoConsultarPermisos(entidad);

            permiso1 = comando.Ejecutar();

            return permiso1;
        }


        public void EliminarUsuario()
        {
            Core.LogicaNegocio.Entidades.Usuario user = new Core.LogicaNegocio.Entidades.Usuario();

            user.Login = _vista.Login.Text;

            user = VerificarUsuario(user);

            if ((user != null) && (user.Status == "Activo"))
            {
                user.Status = "Inactivo";
                user = EliminarUsuario(user);
                _vista.PintarInformacionBotonAceptar(ManagerRecursos.GetString
                                ("mensajeUsuarioEliminado"), "mensajes");
                _vista.InformacionVisibleBotonAceptar = true;
            }

            else
            {
                //  _vista.Mensaje("El usuario ya se encuentra inactivo");
            }


        }



        /*public void CargarUsuarios()
        {
            Core.LogicaNegocio.Entidades.Usuario user = new Core.LogicaNegocio.Entidades.Usuario();
            IList<Core.LogicaNegocio.Entidades.Usuario> listaUsuarios;

            listaUsuarios = ListarUsuarios(user);

            _vista.UsuarioEliminar.Items.Clear();
            _vista.UsuarioEliminar.Items.Add(" -- ");
            _vista.UsuarioEliminar.Items[0].Value = "0";
            _vista.UsuarioEliminar.DataSource = listaUsuarios;
            _vista.UsuarioEliminar.DataValueField = "Login";
            _vista.UsuarioEliminar.DataTextField = "login";
            _vista.UsuarioEliminar.DataBind();

        }*/



        public IList<Core.LogicaNegocio.Entidades.Usuario>
            ListarUsuarios(Core.LogicaNegocio.Entidades.Usuario entidad)
        {

            IList<Core.LogicaNegocio.Entidades.Usuario> usuario1 = null;

            Core.LogicaNegocio.Comandos.ComandoUsuario.ListaUsuarios comando;

            comando = FabricaComandosUsuario.CrearComandoListaUsuarios(entidad);

            usuario1 = comando.Ejecutar();

            return usuario1;
        }



        public Core.LogicaNegocio.Entidades.Usuario VerificarUsuario
                (Core.LogicaNegocio.Entidades.Usuario entidad)
        {

            Core.LogicaNegocio.Entidades.Usuario usuario1 = null;

            Core.LogicaNegocio.Comandos.ComandoUsuario.VerificarUsuario comando;

            comando = FabricaComandosUsuario.CrearComandoVerificarUsuario(entidad);

            usuario1 = comando.Ejecutar();

            return usuario1;
        }



        public Core.LogicaNegocio.Entidades.Usuario EliminarUsuario
                (Core.LogicaNegocio.Entidades.Usuario entidad)
        {

            Core.LogicaNegocio.Entidades.Usuario usuario1 = null;

            Core.LogicaNegocio.Comandos.ComandoUsuario.EliminarUsuario comando;

            comando = FabricaComandosUsuario.CrearComandoEliminarUsuario(entidad);

            usuario1 = comando.Ejecutar();

            return usuario1;
        }

        #endregion
    }
}