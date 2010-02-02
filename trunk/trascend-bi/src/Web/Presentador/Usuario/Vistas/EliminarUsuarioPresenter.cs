using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Usuario.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Fabricas;
using Core.LogicaNegocio.Comandos.ComandoUsuario;
using System.Net;
using System.Collections;
using Presentador.Base;
using System.Resources;
using Core.LogicaNegocio.Excepciones;
using Presentador.Aplicacion;

namespace Presentador.Usuario.Vistas
{
    public class EliminarUsuarioPresenter : PresentadorBase
    {
        #region Propiedades

        private IEliminarUsuario _vista;
        private const int _TamanoLista = 8;

        #endregion

        #region Constructor
        public EliminarUsuarioPresenter()
        { }
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

        public void CampoBusqueda_Selected()
        {
            if (_vista.RbCampoBusqueda.SelectedValue == "1")
            {
                _vista.Login.Visible = true;

                _vista.NombreUsuarioLabel.Visible = true;

                _vista.StatusDdL.Visible = false;

                _vista.StatusDdLLabel.Visible = false;

                _vista.BotonBuscar.Visible = true;

                // _vista.ValidarNombreVacio.Visible = true;

                _vista.ValidarNoSeleccion.Visible = false;

                _vista.InformacionVisibleBotonAceptar = false;

                //_vista.AsteriscoLogin.Visible = true;

                _vista.AsteriscoStatus.Visible = false;

                _vista.GetObjectContainerConsultaEliminarUsuario.DataSource = "";
            }

            if (_vista.RbCampoBusqueda.SelectedValue == "2")
            {
                _vista.Login.Visible = false;

                _vista.NombreUsuarioLabel.Visible = false;

                _vista.StatusDdL.Visible = true;

                _vista.StatusDdLLabel.Visible = true;

                _vista.BotonBuscar.Visible = true;

                //_vista.ValidarNombreVacio.Visible = true;

                _vista.ValidarNoSeleccion.Visible = true;

                _vista.InformacionVisibleBotonAceptar = false;

                // _vista.AsteriscoLogin.Visible = false;

                _vista.AsteriscoStatus.Visible = true;

                _vista.GetObjectContainerConsultaEliminarUsuario.DataSource = "";
            }

        }

        /// <summary>
        /// Acción del botón buscar
        /// </summary>

        public void OnBotonBuscar()
        {
            _vista.InformacionVisibleBotonAceptar = false;

            Core.LogicaNegocio.Entidades.Usuario user = new Core.LogicaNegocio.Entidades.Usuario();

            IList<Core.LogicaNegocio.Entidades.Usuario> listado = ConsultarUsuario(user);


            IList<Core.LogicaNegocio.Entidades.Usuario> listadoActivo =
                                                new List<Core.LogicaNegocio.Entidades.Usuario>();

            IList<Core.LogicaNegocio.Entidades.Usuario> listadoInactivo =
                                                new List<Core.LogicaNegocio.Entidades.Usuario>();

            user.Login = _vista.Login.Text;

            try
            {
                if ((_vista.RbCampoBusqueda.SelectedValue == "1") && (user.Login != ""))
                {

                    listado = ConsultarUsuario(user);

                    if (listado.Count > 0)
                    {
                        _vista.InformacionVisible = false;

                        _vista.GetObjectContainerConsultaEliminarUsuario.DataSource = listado;

                    }
                    else
                    {
                        _vista.PintarInformacion(ManagerRecursos.GetString
                                                            ("MensajeConsulta"), "mensajes");
                        _vista.InformacionVisible = true;

                    }
                }
                else if ((_vista.RbCampoBusqueda.SelectedValue == "1") && (user.Login == ""))
                {
                    listado = ConsultarUsuarioTodos();
                    if (listado.Count > 0)
                    {
                        _vista.InformacionVisible = false;

                        _vista.GetObjectContainerConsultaEliminarUsuario.DataSource = listado;

                    }
                    else
                    {
                        _vista.PintarInformacion(ManagerRecursos.GetString
                                                            ("MensajeConsulta"), "mensajes");
                        _vista.InformacionVisible = true;

                    }

                }

                if (_vista.RbCampoBusqueda.SelectedValue == "2")
                {
                    user.Status = _vista.StatusDdL.Text;

                    if ((listado.Count > 0) && (user.Status == "Activo"))
                    {
                        for (int i = 0; i < listado.Count; i++)
                        {
                            if (listado[i].Status == "Activo")
                            {
                                listadoActivo.Add(listado[i]);
                            }
                        }

                        _vista.InformacionVisible = false;

                        _vista.GetObjectContainerConsultaEliminarUsuario.DataSource = listadoActivo;
                    }

                   /* else if ((listado.Count > 0) && (user.Status == "Inactivo"))
                    {
                        for (int i = 0; i < listado.Count; i++)
                        {
                            if (listado[i].Status == "Inactivo")
                            {
                                listadoInactivo.Add(listado[i]);
                            }
                        }

                        _vista.InformacionVisible = false;

                        
                        _vista.GetObjectContainerConsultaEliminarUsuario.DataSource = listadoInactivo;

                    }*/

                    
                }
                if ((listadoInactivo.Count == 0) && (listadoActivo.Count == 0)
                   && (_vista.RbCampoBusqueda.SelectedValue != "1"))
                {
                    _vista.PintarInformacion(ManagerRecursos.GetString
                                                            ("MensajeConsulta"), "mensajes");
                    _vista.InformacionVisible = true;


                }

            }
            catch (WebException e)
            {
               
                _vista.PintarInformacion(ManagerRecursos.GetString
                    ("mensajeErrorWeb"),"mensajes");
                _vista.InformacionVisible = true;

            }
            catch (ConsultarException e)
            {
                _vista.PintarInformacion(ManagerRecursos.GetString
                    ("mensajeErrorConsultar"), "mensajes");
                _vista.InformacionVisible = true;

            }
            catch (Exception e)
            {
                _vista.PintarInformacion
                    (ManagerRecursos.GetString("mensajeErrorGeneral"), "mensajes");
                _vista.InformacionVisible = true;

            }

        }

        /// <summary>
        /// Método para seleccionar el valor de una fila del GridView
        /// </summary>
        /// <param name="index">El indice de cada fila del GridView</param>

        public void uxObjectConsultaEliminarUsuarioSelecting(string login)
        {

            Core.LogicaNegocio.Entidades.Usuario usuario = new Core.LogicaNegocio.Entidades.Usuario();

            Core.LogicaNegocio.Entidades.Usuario user = new Core.LogicaNegocio.Entidades.Usuario();

            usuario.Login = login;

            user = VerificarUsuario(usuario);

            if ((user != null) && (user.Status == "Activo"))
            {
                user.Status = "Inactivo";

                EliminarUsuario(user);

                CambiarVista(0);

                _vista.PintarInformacionBotonAceptar(ManagerRecursos.GetString
                                ("mensajeUsuarioEliminado"), "mensajes");
                _vista.InformacionVisibleBotonAceptar = true;

                _vista.GetObjectContainerConsultaEliminarUsuario.DataSource = "";


            }

            else
            {
                _vista.PintarInformacionBotonAceptar(ManagerRecursos.GetString
                                ("mensajeUsuarioInactivo"), "mensajes");
                _vista.InformacionVisibleBotonAceptar = true;

            }
            //CambiarVista(1);

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


        /// <summary>
        /// Método para el comando ConsultarUsuarioTodos
        /// </summary>
        /// <param name="entidad">Entidad Permiso a consultar (depende del usuario selecc)</param>
        /// <returns>Lista de permisos que posea el usuario</returns>

        public IList<Core.LogicaNegocio.Entidades.Usuario> ConsultarUsuarioTodos()
        {

            IList<Core.LogicaNegocio.Entidades.Usuario> usuario1 = null;

            Core.LogicaNegocio.Comandos.ComandoUsuario.ConsultarUsuarioTodos comando;

            comando = FabricaComandosUsuario.CrearComandoConsultarUsuarioTodos();

            usuario1 = comando.Ejecutar();

            return usuario1;
        }


        /// <summary>
        /// Método para el comando VerificarUsuario
        /// </summary>
        /// <param name="entidad">Entidad del usuario a consultar (depende del usuario selecc)</param>
        /// <returns>Lista de usuarios 'Activos'</returns>
        /// 
        public Core.LogicaNegocio.Entidades.Usuario VerificarUsuario
                (Core.LogicaNegocio.Entidades.Usuario entidad)
        {

            Core.LogicaNegocio.Entidades.Usuario usuario1 = null;

            Core.LogicaNegocio.Comandos.ComandoUsuario.VerificarUsuario comando;

            comando = FabricaComandosUsuario.CrearComandoVerificarUsuario(entidad);

            usuario1 = comando.Ejecutar();

            return usuario1;
        }


        /// <summary>
        /// Método para el comando Eliminar
        /// </summary>
        /// <param name="entidad">Entidad usuario</param>
        /// 

        public Core.LogicaNegocio.Entidades.Usuario EliminarUsuario
                (Core.LogicaNegocio.Entidades.Usuario entidad)
        {

            Core.LogicaNegocio.Entidades.Usuario usuario1 = null;

            Core.LogicaNegocio.Comandos.ComandoUsuario.EliminarUsuario comando;

            comando = FabricaComandosUsuario.CrearComandoEliminarUsuario(entidad);

            usuario1 = comando.Ejecutar();

            return usuario1;
        }


        private IDefaultPresenter vistadefault;

        private DefaultPresenter _presentadorDefault = new DefaultPresenter();

        public void sesionTerminada()
        {
            vistadefault.PintarInformacion(ManagerRecursos.GetString
                              ("mensajeSesionTerminada"), "mensajes");
            vistadefault.InformacionVisible = true;
            // _presentadorDefault.sesionTerminada();
        }


        /// <summary>
        /// Método para el comando Consultar IdPermiso
        /// </summary>
        /// <param name="entidad">Entidad permiso</param>
        /// 

        public Core.LogicaNegocio.Entidades.Permiso ConsultarIdPermiso()
        {

            Core.LogicaNegocio.Entidades.Permiso permiso1 = null;

            Core.LogicaNegocio.Entidades.Permiso permiso2 = new Permiso();

            permiso2.Permisos = "Eliminar Usuarios";

            Core.LogicaNegocio.Comandos.ComandoUsuario.ConsultarIdPermiso comando;

            comando = FabricaComandosUsuario.CrearComandoConsultarIdPermiso(permiso2);

            permiso1 = comando.Ejecutar();

            return permiso1;
        }
        #endregion
    }
}