using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.Web.UI.WebControls;
using Presentador.Usuario.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Fabricas;


namespace Presentador.Usuario.Vistas
{
    public class ModificarUsuarioPresenter
    {
        #region Propieddaes

        private IModificarUsuario _vista;

        private const int _TamañoLista = 8;

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
                _vista.DLStatusUsuario.Enabled = false;
                _vista.DLStatusUsuario.Items.Add("Inactivo");
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
                for (int j = 0; j < _TamañoLista; j++)
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
        /// Acción del botón buscar
        /// </summary>

        public void OnBotonBuscar()
        {

            Core.LogicaNegocio.Entidades.Usuario user = new Core.LogicaNegocio.Entidades.Usuario();

            user.Login = _vista.NombreUsuario.Text;

            IList<Core.LogicaNegocio.Entidades.Usuario> listado = ConsultarUsuario(user);

            if (listado != null)
            {

                _vista.GetObjectContainerConsultaModificarUsuario.DataSource = listado;

            }

            else
            {
                //Mensaje de error al usuario
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

            user = null;

            user = listado[0];

            IList<Core.LogicaNegocio.Entidades.Permiso> listadoPermiso = ConsultarPermisos(user);

            CargarCheckBox(listadoPermiso);

            CargarDatos(user);

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

            usuario.PermisoUsu = ModificarCheckBox(_vista.CBLAgregar);

            usuario.PermisoUsu =
                        UnirPermisos(ModificarCheckBox(_vista.CBLConsultar), usuario.PermisoUsu);

            usuario.PermisoUsu =
                        UnirPermisos(ModificarCheckBox(_vista.CBLModificar), usuario.PermisoUsu);

            usuario.PermisoUsu =
                        UnirPermisos(ModificarCheckBox(_vista.CBLEliminar), usuario.PermisoUsu);

            usuario.Login = _vista.NombreUsu.Text;

            usuario.Status = _vista.DLStatusUsuario.SelectedItem.Text;

            ModificarUsuario(usuario);



        }

        #endregion

    }
}