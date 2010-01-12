using System.Web;
//using Core.AccesoDatos.Interfaces;
//using Core.AccesoDatos.Fabricas;
using Core.LogicaNegocio.Entidades;


namespace Core.LogicaNegocio.Comandos.ComandoUsuario
{
    public class ConsultarCredenciales : Comando<Usuario>
    {
        private Usuario usuario;

        #region Constructor

        /// <summary>Constructor de la clase 'CosultarCredenciales'.</summary>
       
        public ConsultarCredenciales()
        { }

        public ConsultarCredenciales(Usuario usuario)
        {
            this.usuario = usuario;
        }

        #endregion

        #region Metodos

        /// <summary>M�todo que implementa la ejecuci�n del comando 'CosultarCredenciales'.</summary>
       
        /* Desarrollo 3 en prueba
        
        public Usuario Ejecutar()
        {
            Usuario entidad = null;
            //Objeto DAO.
            IDAOUsuario daoUsuario;

            //f�brica que instancia el DAO para usuario.
            daoUsuario = FabricaDAOSQLServer.ObtenerDAOUsuario();
            //invoca el m�todo ingresar del DAO de usuario.
            entidad = daoUsuario.ConsultarLoginPassword(usuario);
            //Retorna el Usuario que ha ingresado sesion
            return entidad;
        }
        
        */
        #endregion
    }
}
