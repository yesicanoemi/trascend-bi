using System;
using System.Collections.Generic;
using System.Text;
using Core.LogicaNegocio.Comandos.ComandoUsuario;
using Core.LogicaNegocio.Entidades;


namespace Core.LogicaNegocio.Fabricas
{
    public class FabricaComandosUsuario
    {
        #region Métodos

        /// <summary>
        /// Metodo que fabrica el comando 'ConsultarCredenciales' de la entidad Usuario
        /// </summary>
        /// <param name="entidad">Entidad Usuario con los datos</param>
        /// <returns>Comando ConsultarCredenciales de la entidad Usuario</returns>

        public static ConsultarCredenciales CrearComandoConsultarCredenciales(Usuario entidad)
        {
            return new ConsultarCredenciales(entidad);
        }

        /// <summary>
        /// Metodo que fabrica el comando "ConsultarUsuario" de la entidad Usuario
        /// </summary>
        /// <param name="empleado">Entidad Usuario con los datos</param>
        /// <returns>Comando Consultar de la entidad usuario</returns>

        public static ConsultarUsuario CrearComandoConsultarUsuario(Usuario entidad)
        {
            return new ConsultarUsuario(entidad);
        }

        /// <summary>
        /// Metodo que fabrica el comando "ConsultarUsuarioStatus" de la entidad Usuario
        /// </summary>
        /// <param name="empleado">Entidad Usuario con los datos</param>
        /// <returns>Comando ConsultarUsuariosStatus</returns>

        public static ConsultarUsuarioStatus CrearComandoConsultarUsuarioStatus()
        {
            return new ConsultarUsuarioStatus();
        }

        /// <summary>
        /// Metodo que fabrica el comando "ConsultarPermisos" de la entidad Usuario
        /// </summary>
        /// <param name="entidad">Entidad usuario</param>
        /// <returns>Comando ConsultarPermisos</returns>

        public static ConsultarPermisos CrearComandoConsultarPermisos(Usuario entidad)
        {
            return new ConsultarPermisos(entidad);
        }

        /// <summary>
        ///  Metodo que fabrica el comando "ModificarUsuario" de la entidad Usuario
        /// </summary>
        /// <param name="entidad">Entidad Usuario</param>
        /// <returns>Comando ModificarUsuario</returns>

        public static ModificarUsuario CrearComandoModificarUsuario(Usuario entidad)
        {
            return new ModificarUsuario(entidad);
        }

        /// <summary>
        /// Metodo que fabrica el comando "AgregarUsuario" de la entidad Usuario
        /// </summary>
        /// <param name="entidad">Entidad Usuario</param>
        /// <returns>Comando AgregarUsuario</returns>

        public static AgregarUsuario CrearComandoAgregarUsuario(Usuario entidad)
        {
            return new AgregarUsuario(entidad);
        }


        public static VerificarUsuario CrearComandoVerificarUsuario(Usuario entidad)
        {
            return new VerificarUsuario(entidad);
        }

        public static ListaUsuarios CrearComandoListaUsuarios(Usuario entidad)
        {
            return new ListaUsuarios(entidad);
        }

        public static EliminarUsuario CrearComandoEliminarUsuario(Usuario entidad)
        {
            return new EliminarUsuario(entidad);
        }

        /// <summary>
        /// Metodo que fabrica el comando "ConsultarEmpleadoConUsuario" de la entidad Usuario
        /// </summary>
        /// <param name="entidad">Entidad Usuario</param>
        /// <returns>Comando ConsultarEmpleadoConUsuario</returns>

        public static ConsultarEmpleadoConUsuario CrearComandoConsultarEmpleadoConUsuario(Empleado entidad)
        {
            return new ConsultarEmpleadoConUsuario(entidad);
        }

        #endregion
    }
}
