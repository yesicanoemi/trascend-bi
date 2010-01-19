using System;
using System.Collections.Generic;
using System.Text;
using Core.LogicaNegocio.Comandos.ComandoUsuario;
using Core.LogicaNegocio.Entidades;


namespace Core.LogicaNegocio.Fabricas
{
	public class FabricaComandosUsuario
    {
        #region Metodos

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
        /// <returns>Comando Consultar de la entidad usuario</returns>

        public static ConsultarUsuarioStatus CrearComandoConsultarUsuarioStatus()
        {
            return new ConsultarUsuarioStatus();
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

        public static ConsultarPermisos CrearComandoConsultarPermisos(Usuario entidad)
        {
            return new ConsultarPermisos(entidad);
        }

        public static ModificarUsuario CrearComandoModificarUsuario (Usuario entidad)
        {
            return new ModificarUsuario(entidad);
        }
#endregion
	}
}
