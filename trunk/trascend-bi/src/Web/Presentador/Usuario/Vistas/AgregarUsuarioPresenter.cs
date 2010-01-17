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
    public class AgregarUsuarioPresenter
    {
        private IAgregarUsuario _vista;
        private const int _TamañoLista = 8;
       
        #region Constructor
        public AgregarUsuarioPresenter (IAgregarUsuario vista)
        {
            _vista = vista;
        }
        #endregion

        #region Metodos

        public void CambiarVista(int index)
        {

            _vista.MultiViewAgregar.ActiveViewIndex = index;
        }

        private void CargarDatos(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            _vista.CedulaEmp.Text = empleado.Cedula.ToString();

            _vista.NombreEmp.Text = empleado.Nombre;

            _vista.ApellidoEmp.Text = empleado.Apellido;

            _vista.StatusEmp.Text = empleado.Estado;
        }
       
        private IList<Core.LogicaNegocio.Entidades.Permiso> ModificarCheckBox(System.Web.UI.WebControls.CheckBoxList CBL)
        {
            IList<Core.LogicaNegocio.Entidades.Permiso> _permiso =
                new List<Core.LogicaNegocio.Entidades.Permiso>();
            //Core.LogicaNegocio.Entidades.Permiso permiso = new Permiso();

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
        
        public void OnBotonBuscar()
        {
            Core.LogicaNegocio.Entidades.Empleado empleado = new Core.LogicaNegocio.Entidades.Empleado();

            empleado.Apellido = _vista.EmpleadoBuscar.Text;

            IList<Core.LogicaNegocio.Entidades.Empleado> listado = ConsultarEmpleado(empleado);

            if (listado != null)
            {

                _vista.GetObjectContainerConsultaEmpleado.DataSource = listado;

            }

            else
            {
                //Mensaje de error al usuario
            }

        }

        public IList<Core.LogicaNegocio.Entidades.Empleado> ConsultarEmpleado
                (Core.LogicaNegocio.Entidades.Empleado entidad)
        {
            IList<Core.LogicaNegocio.Entidades.Empleado> entidad1 = new List<Core.LogicaNegocio.Entidades.Empleado>();
            //entidad1.Add(entidad);

            IList<Core.LogicaNegocio.Entidades.Empleado> empleado = null;

            Core.LogicaNegocio.Comandos.ComandoEmpleado.Consultar comando;

            comando = FabricaComandosEmpleado.CrearComandoConsultar(entidad1);

            empleado = comando.Ejecutar();

            return empleado;
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

        private void AgregarUsuario(Core.LogicaNegocio.Entidades.Usuario entidad)
        {
            Core.LogicaNegocio.Comandos.ComandoUsuario.AgregarUsuario comando;

            comando = FabricaComandosUsuario.CrearComandoAgregarUsuario(entidad);

           comando.Ejecutar();
        }

        public void uxObjectConsultaUsuarioSelecting(string cedulaI)
        {
            Core.LogicaNegocio.Entidades.Empleado empleado = new Core.LogicaNegocio.Entidades.Empleado();

            empleado.Cedula = Int32.Parse(cedulaI);

            IList<Core.LogicaNegocio.Entidades.Empleado> empleado1 =  ConsultarEmpleadoxCedula(empleado);

            empleado = null;

            empleado = empleado1[0];

            CargarDatos(empleado);

            CambiarVista(1);

        }


        /// <summary>
        /// Este metodo esta haciendo suplencia al supuesto procedimiento de consultarEmpleadoxCedula
        /// </summary>
        /// <param name="empleado"></param>
        /// <returns></returns>
        private IList<Core.LogicaNegocio.Entidades.Empleado> ConsultarEmpleadoxCedula(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            IList<Core.LogicaNegocio.Entidades.Empleado> emplea = new List<Core.LogicaNegocio.Entidades.Empleado>();
            empleado.Cedula = 18512200;
            empleado.Apellido = "trejo";
            empleado.Nombre = "daniel";
            empleado.Estado = "Activo";
            emplea.Add(empleado);

            return emplea;
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
            usuario.Login = _vista.NombreUsuario.Text;
            usuario.Password = _vista.ContrasenaUsuario.Text;
            usuario.IdUsuario = int.Parse(_vista.CedulaEmp.Text);
            AgregarUsuario(usuario);
            
            
            
        }
        #endregion

    }
}
