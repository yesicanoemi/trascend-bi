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


namespace Presentador.Usuario.Vistas
{
    public class ModificarUsuarioPresenter
    {
        private IModificarUsuario _vista;

        #region Constructor
        public ModificarUsuarioPresenter(IModificarUsuario vista)
        {
            _vista = vista;
        }
        #endregion

        #region Metodos

        public void CambiarVista(int index)
        {

            _vista.MultiViewModificar.ActiveViewIndex = index;
        }

        private void CargarDatos(Core.LogicaNegocio.Entidades.Usuario usuario)
        {
            _vista.NombreUsu.Text = usuario.Login;

            _vista.NombreEmp.Text = usuario.Nombre;

            _vista.ApellidoEmp.Text = usuario.Apellido;

            _vista.UsuarioU.Text = usuario.Status;
        }

        private void CargarCheckBox(IList<Core.LogicaNegocio.Entidades.Permiso> permiso)
        {   //for para agregar
            for (int i = 0; i < permiso.Count; i++)
            {
                for (int j = 0; j < 8; j++)
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

        private IList<Core.LogicaNegocio.Entidades.Permiso> ModificarCheckBox(System.Web.UI.WebControls.CheckBoxList CBL)
        {
            IList<Core.LogicaNegocio.Entidades.Permiso> _permiso =
                new List<Core.LogicaNegocio.Entidades.Permiso>();
            Core.LogicaNegocio.Entidades.Permiso permiso = new Permiso();
            for (int j = 0; j < 6; j++)
            {
                if (CBL.Items[j].Selected == true)
                {
                    permiso.IdPermiso = Int32.Parse(CBL.Items[j].Value);

                    _permiso.Add(permiso);
                }
            }
            return _permiso;
        }
        
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

        public IList<Core.LogicaNegocio.Entidades.Usuario> ConsultarUsuario
                (Core.LogicaNegocio.Entidades.Usuario entidad)
        {

            IList<Core.LogicaNegocio.Entidades.Usuario> usuario1 = null;

            Core.LogicaNegocio.Comandos.ComandoUsuario.ConsultarUsuario comando;

            comando = FabricaComandosUsuario.CrearComandoConsultarUsuario(entidad);

            usuario1 = comando.Ejecutar();

            return usuario1;
        }

        public IList<Core.LogicaNegocio.Entidades.Permiso> ConsultarPermisos
                (Core.LogicaNegocio.Entidades.Usuario entidad)
        {

            IList<Core.LogicaNegocio.Entidades.Permiso> permiso1 = null;

            Core.LogicaNegocio.Comandos.ComandoUsuario.ConsultarPermisos comando;

            comando = FabricaComandosUsuario.CrearComandoConsultarPermisos(entidad);

            permiso1 = comando.Ejecutar();

            return permiso1;
        }

        private void ModificarUsuario (Core.LogicaNegocio.Entidades.Usuario entidad)
        {


            Core.LogicaNegocio.Comandos.ComandoUsuario.ModificarUsuario comando;

            comando = FabricaComandosUsuario.CrearComandoModificarUsuario(entidad);

           comando.Ejecutar();
        }

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

        private IList<Core.LogicaNegocio.Entidades.Permiso> UnirPermisos(IList<Core.LogicaNegocio.Entidades.Permiso> permiso, IList<Core.LogicaNegocio.Entidades.Permiso>  _permiso)
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
            usuario.PermisoUsu = UnirPermisos(ModificarCheckBox(_vista.CBLConsultar), usuario.PermisoUsu);
            usuario.PermisoUsu = UnirPermisos(ModificarCheckBox(_vista.CBLModificar),usuario.PermisoUsu);
            usuario.PermisoUsu = UnirPermisos(ModificarCheckBox(_vista.CBLEliminar), usuario.PermisoUsu);
            usuario.Login = _vista.NombreUsu.Text;
            ModificarUsuario(usuario);
            
        }
        #endregion

    }
}