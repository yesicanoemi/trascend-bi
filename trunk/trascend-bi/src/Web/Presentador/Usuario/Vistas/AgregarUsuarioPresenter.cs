﻿using System;
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

namespace Presentador.Usuario.Vistas
{
    public class AgregarUsuarioPresenter : PresentadorBase
    {
        #region Propiedades

        private IAgregarUsuario _vista;

        private const int _TamañoLista = 8;

        #endregion

        #region Constructor

        public AgregarUsuarioPresenter(IAgregarUsuario vista)
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
            _vista.MultiViewAgregar.ActiveViewIndex = index;
        }

        /// <summary>
        /// Carga los datos del empleado consultado por pantalla
        /// </summary>
        /// <param name="empleado">Entidad empleado</param>

        private void CargarDatos(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            _vista.CedulaEmp.Text = empleado.Cedula.ToString();

            _vista.NombreEmp.Text = empleado.Nombre;

            _vista.ApellidoEmp.Text = empleado.Apellido;

            _vista.StatusEmp.Text = empleado.Estado;
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

            for (int j = 0; j < _TamañoLista; j++)
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
            Core.LogicaNegocio.Entidades.Empleado empleado =
                                    new Core.LogicaNegocio.Entidades.Empleado();

            empleado.Apellido = _vista.EmpleadoBuscar.Text;

            IList<Core.LogicaNegocio.Entidades.Empleado> listado = ConsultarEmpleado(empleado);

            try
            {
                if (listado.Count > 0)
                {

                    _vista.GetObjectContainerConsultaEmpleado.DataSource = listado;

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
        /// Consultar el empleado al que se le desea asignar usuario
        /// </summary>
        /// <param name="entidad">Entidad empleado</param>
        /// <returns>Entidad empleado</returns>

        public IList<Core.LogicaNegocio.Entidades.Empleado> ConsultarEmpleado
                                            (Core.LogicaNegocio.Entidades.Empleado entidad)
        {

            Core.LogicaNegocio.Entidades.Empleado emplea1 = new Core.LogicaNegocio.Entidades.Empleado();
            Core.LogicaNegocio.Entidades.Empleado emplea2 = new Core.LogicaNegocio.Entidades.Empleado();


            IList<Core.LogicaNegocio.Entidades.Empleado> entidad1 =
                                            new List<Core.LogicaNegocio.Entidades.Empleado>();

            emplea1.Cedula = 18612200;
            emplea1.Apellido = "Trejo";
            emplea1.Nombre = "Daniel";
            emplea1.Estado = "Activo";

            entidad1.Add(emplea1);

            emplea2.Cedula = 16460698;
            emplea2.Apellido = "Rojas";
            emplea2.Nombre = "Dina";
            emplea2.Estado = "Activo";

            entidad1.Add(emplea2);

            return entidad1;
        }

        /// <summary>
        /// Consultar el empleado al que se le desea asignar usuario
        /// </summary>
        /// <param name="entidad">Entidad empleado</param>
        /// <returns>Entidad empleado</returns>

        public IList<Core.LogicaNegocio.Entidades.Empleado> ConsultarEmpleadoConUsuario
                                            (Core.LogicaNegocio.Entidades.Empleado entidad)
        {
            IList<Core.LogicaNegocio.Entidades.Empleado> empleado = null;

            Core.LogicaNegocio.Comandos.ComandoUsuario.ConsultarEmpleadoConUsuario comando;

            comando = FabricaComandosUsuario.CrearComandoConsultarEmpleadoConUsuario(entidad);

            empleado = comando.Ejecutar();

            return empleado;

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
        /// Método para agregar usuarios
        /// </summary>
        /// <param name="entidad">Entidad usuario</param>

        private void AgregarUsuario(Core.LogicaNegocio.Entidades.Usuario entidad)
        {
            Core.LogicaNegocio.Comandos.ComandoUsuario.AgregarUsuario comando;

            comando = FabricaComandosUsuario.CrearComandoAgregarUsuario(entidad);

            comando.Ejecutar();
        }

        /// <summary>
        /// Al seleccionar un empleado de la tabla
        /// </summary>
        /// <param name="cedulaI">Cédula del empleado</param>

        public void uxObjectConsultaUsuarioSelecting(string cedulaI)
        {
            Core.LogicaNegocio.Entidades.Empleado empleado =
                                                new Core.LogicaNegocio.Entidades.Empleado();

            empleado.Cedula = Int32.Parse(cedulaI);

            IList<Core.LogicaNegocio.Entidades.Empleado> empleado1 =
                                                    ConsultarEmpleadoxCedula(empleado);

            empleado = null;

            empleado = empleado1[0];

            CargarDatos(empleado);

            CambiarVista(1);

        }


        /// <summary>
        /// Este metodo esta haciendo suplencia al supuesto procedimiento de consultarEmpleadoxCedula
        /// </summary>
        /// <param name="empleado">Entidad empleado</param>
        /// <returns>Entidad empleado</returns>

        private IList<Core.LogicaNegocio.Entidades.Empleado>
                    ConsultarEmpleadoxCedula(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            IList<Core.LogicaNegocio.Entidades.Empleado> emplea =
                                    new List<Core.LogicaNegocio.Entidades.Empleado>();

            empleado.Cedula = 18512200;

            empleado.Apellido = "trejo";

            empleado.Nombre = "daniel";

            empleado.Estado = "Activo";

            emplea.Add(empleado);

            return emplea;
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

        /// <summary>
        /// Método para el comando ConsultarUsuario
        /// </summary>
        /// <param name="entidad">Entidad Usuario a consultar (por nombre de usuario)</param>
        /// <returns>Lista de usuarios que cumplan con el parámetro de búsqueda</returns>

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
        /// Acción del botón Aceptar
        /// </summary>

        public void OnBotonAceptar()
        {
            Core.LogicaNegocio.Entidades.Usuario usuario = new Core.LogicaNegocio.Entidades.Usuario();

            Core.LogicaNegocio.Entidades.Empleado empleado = new Core.LogicaNegocio.Entidades.Empleado();


            usuario.PermisoUsu = ModificarCheckBoxReporte(_vista.CBLReporte);

            usuario.PermisoUsu = UnirPermisos(ModificarCheckBox(_vista.CBLAgregar),usuario.PermisoUsu);

            usuario.PermisoUsu =
                UnirPermisos(ModificarCheckBox(_vista.CBLConsultar), usuario.PermisoUsu);

            usuario.PermisoUsu =
                UnirPermisos(ModificarCheckBox(_vista.CBLModificar), usuario.PermisoUsu);

            usuario.PermisoUsu =
                UnirPermisos(ModificarCheckBox(_vista.CBLEliminar), usuario.PermisoUsu);

            usuario.Login = _vista.NombreUsuario.Text;

            usuario.Password = _vista.ContrasenaUsuario.Text;

            usuario.Cedula = int.Parse(_vista.CedulaEmp.Text);

            empleado.Cedula = int.Parse(_vista.CedulaEmp.Text);

            if (ConsultarEmpleadoConUsuario(empleado).Count == 0)
            {

                if (ConsultarUsuario(usuario).Count == 0)
                {
                    AgregarUsuario(usuario);

                    _vista.PintarInformacionBotonAceptar(ManagerRecursos.GetString
                                ("mensajeUsuarioAgregado"), "mensajes");
                    _vista.InformacionVisibleBotonAceptar = true;

                }
                else
                {
                    _vista.PintarInformacionBotonAceptar(ManagerRecursos.GetString
                                ("mensajeUsuarioExiste"), "mensajes");
                    _vista.InformacionVisibleBotonAceptar = true;

                }
            }
            else
            {
                _vista.PintarInformacionBotonAceptar(ManagerRecursos.GetString
                                ("mensajeEmpleadoTieneUsuario"), "mensajes");
                _vista.InformacionVisibleBotonAceptar = true;
            }

        }

        #endregion

    }
}
