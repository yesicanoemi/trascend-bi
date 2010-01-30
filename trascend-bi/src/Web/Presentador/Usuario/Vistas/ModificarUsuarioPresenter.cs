﻿using System;
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
    public class ModificarUsuarioPresenter : PresentadorBase
    {
        #region Propieddaes

        private IModificarUsuario _vista;

        private const int _TamanoLista = 8;

        #endregion

        #region Constructor

        public ModificarUsuarioPresenter(IModificarUsuario vista)
        {
            _vista = vista;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método para cambiar la vista del MultiView
        /// </summary>
        /// <param name="index">Número de la vista sig</param>

        public void CambiarVista(int index)
        {

            _vista.MultiViewModificar.ActiveViewIndex = index;
        }

        /// <summary>
        /// Carga los datos del usuario consultado por pantalla
        /// </summary>
        /// <param name="empleado">Entidad usuario</param>

        private void CargarDatos(Core.LogicaNegocio.Entidades.Usuario usuario)
        {
            _vista.NombreUsu.Text = usuario.Login;

            _vista.NombreEmp.Text = usuario.Nombre;

            _vista.ApellidoEmp.Text = usuario.Apellido;

            _vista.DLStatusUsuario.Items.Add(usuario.Status);

            if (usuario.Status == "Activo")
            {
                _vista.DLStatusUsuario.Items.Add("Inactivo");
                _vista.DLStatusUsuario.Enabled = false;
            }
            else
            {
                _vista.DLStatusUsuario.Items.Add("Activo");
            }
        }

        /// <summary>
        /// Carga los checkbox que posee el usuario
        /// </summary>
        /// <param name="CBL">Lista de permisos del usuario</param>

        private void CargarCheckBox(IList<Core.LogicaNegocio.Entidades.Permiso> permiso)
        {
            for (int i = 0; i < permiso.Count; i++)
            {
                for (int j = 0; j < _TamanoLista; j++)
                {
                    //Revisa el CheckBoxList de Agregar
                    if (_vista.CBLAgregar.Items[j].Value == permiso[i].IdPermiso.ToString())
                    {
                        _vista.CBLAgregar.Items[j].Selected = true;
                    }
                    //Revisa el CheckBoxList de Consultar
                    if (_vista.CBLConsultar.Items[j].Value == permiso[i].IdPermiso.ToString())
                    {
                        _vista.CBLConsultar.Items[j].Selected = true;
                    }
                    //Revisa el CheckBoxList de Modificar
                    if (_vista.CBLModificar.Items[j].Value == permiso[i].IdPermiso.ToString())
                    {
                        _vista.CBLModificar.Items[j].Selected = true;
                    }
                    //Revisa el CheckBoxList de Eliminar
                    if (_vista.CBLEliminar.Items[j].Value == permiso[i].IdPermiso.ToString())
                    {
                        _vista.CBLEliminar.Items[j].Selected = true;
                    }


                    for (int k = 0; k < 13; k++)
                    {
                        //Revisa el CheckBoxList de Reportes
                        if (_vista.CBLReporte.Items[k].Value == permiso[i].IdPermiso.ToString())
                        {
                            _vista.CBLReporte.Items[k].Selected = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Modifica los checkbox que cambia el usuario
        /// </summary>
        /// <param name="CBL">Lista de checkbox cargada con los permisos</param>
        /// <returns>Nuevos permisos</returns>

        private IList<Core.LogicaNegocio.Entidades.Permiso>
                            ModificarCheckBox(System.Web.UI.WebControls.CheckBoxList CBL)
        {
            IList<Core.LogicaNegocio.Entidades.Permiso> _permiso =
                            new List<Core.LogicaNegocio.Entidades.Permiso>();

            for (int j = 0; j < _TamanoLista; j++)
            {
                if (CBL.Items[j].Selected == true)
                {
                    Core.LogicaNegocio.Entidades.Permiso permiso = new Permiso();

                    permiso.IdPermiso = Int32.Parse(CBL.Items[j].Value);

                    _permiso.Add(permiso);
                }
            }
            return _permiso;
        }


        /// <summary>
        /// Modifica los checkbox de reportes que cambia el usuario
        /// </summary>
        /// <param name="CBL">Lista de checkbox de reporte cargada con los permisos</param>
        /// <returns>Nuevos permisos</returns>

        private IList<Core.LogicaNegocio.Entidades.Permiso>
                                ModificarCheckBoxReporte(System.Web.UI.WebControls.CheckBoxList CBL)
        {
            IList<Core.LogicaNegocio.Entidades.Permiso> _permiso =
                                new List<Core.LogicaNegocio.Entidades.Permiso>();

            for (int j = 0; j < 13; j++)
            {
                if (CBL.Items[j].Selected == true)
                {
                    Core.LogicaNegocio.Entidades.Permiso permiso = new Permiso();

                    permiso.IdPermiso = Int32.Parse(CBL.Items[j].Value);

                    _permiso.Add(permiso);
                }
            }
            return _permiso;
        }


        /// <summary>
        /// Acción del botón buscar
        /// </summary>

        public void OnBotonBuscar()
        {

            Core.LogicaNegocio.Entidades.Usuario user = new Core.LogicaNegocio.Entidades.Usuario();

            user.Login = _vista.NombreUsuario.Text;

            IList<Core.LogicaNegocio.Entidades.Usuario> listado = ConsultarUsuario(user);


            try
            {

                if (listado.Count > 0)
                {

                    _vista.GetObjectContainerConsultaModificarUsuario.DataSource = listado;

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
        /// Modificar al usuario
        /// </summary>
        /// <param name="entidad">Entidad usuario</param>

        private void ModificarUsuario(Core.LogicaNegocio.Entidades.Usuario entidad)
        {

            Core.LogicaNegocio.Comandos.ComandoUsuario.ModificarUsuario comando;

            comando = FabricaComandosUsuario.CrearComandoModificarUsuario(entidad);

            comando.Ejecutar();
        }

        /// <summary>
        /// Al seleccionar un usuario de la tabla
        /// </summary>
        /// <param name="cedulaI">Login del usuario</param>

        public void uxObjectConsultaModificarUsuarioSelecting(string login)
        {
            Core.LogicaNegocio.Entidades.Usuario user = new Core.LogicaNegocio.Entidades.Usuario();

            user.Login = login;

            IList<Core.LogicaNegocio.Entidades.Usuario> listado = ConsultarUsuario(user);

            IList<Core.LogicaNegocio.Entidades.Permiso> listadoPermiso = ConsultarPermisos(listado[0]);

            CargarCheckBox(listadoPermiso);

            CargarDatos(listado[0]);

            CambiarVista(1);

        }

        /// <summary>
        /// Método para unir las distintas listas de checkbox
        /// </summary>
        /// <param name="permiso">Lista de permisos</param>
        /// <param name="_permiso">Lista de permisos</param>
        /// <returns>La nueva lista de permisos unida</returns>

        private IList<Core.LogicaNegocio.Entidades.Permiso>
                        UnirPermisos(IList<Core.LogicaNegocio.Entidades.Permiso> permiso,
                        IList<Core.LogicaNegocio.Entidades.Permiso> _permiso)
        {
            for (int i = 0; i < permiso.Count; i++)
            {
                _permiso.Add(permiso[i]);
            }

            return _permiso;
        }

        public void OnBotonAceptar()
        {
            Core.LogicaNegocio.Entidades.Usuario usuario = new Core.LogicaNegocio.Entidades.Usuario();

            usuario.PermisoUsu = ModificarCheckBoxReporte(_vista.CBLReporte);

            usuario.PermisoUsu = UnirPermisos(ModificarCheckBox(_vista.CBLAgregar),usuario.PermisoUsu);

            usuario.PermisoUsu =
                        UnirPermisos(ModificarCheckBox(_vista.CBLConsultar), usuario.PermisoUsu);

            usuario.PermisoUsu =
                        UnirPermisos(ModificarCheckBox(_vista.CBLModificar), usuario.PermisoUsu);

            usuario.PermisoUsu =
                        UnirPermisos(ModificarCheckBox(_vista.CBLEliminar), usuario.PermisoUsu);

            usuario.Login = _vista.NombreUsu.Text;

            usuario.Status = _vista.DLStatusUsuario.SelectedItem.Text;

            usuario.IdUsuario = ConsultarUsuario(usuario)[0].IdUsuario;

            ModificarUsuario(usuario);

            _vista.PintarInformacionBotonAceptar(ManagerRecursos.GetString
                                ("mensajeUsuarioModificado"), "mensajes");
            _vista.InformacionVisibleBotonAceptar = true;




        }

        #endregion

    }
}