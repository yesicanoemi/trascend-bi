using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;


namespace Core.LogicaNegocio.Comandos.ComandoUsuario
{
    public class ConsultarUsuarioStatus : Comando<Core.LogicaNegocio.Entidades.Usuario>
    {
        #region Propiedades

        private Core.LogicaNegocio.Entidades.Usuario usuario;

        #endregion

        #region Constructor

        /// <summary>Constructor de la clase 'ConsultarUsuarioStatus'.</summary>

        public ConsultarUsuarioStatus()
        { }

        public ConsultarUsuarioStatus(Core.LogicaNegocio.Entidades.Usuario usuario)
        {
            this.usuario = usuario;
        }

        #endregion

        #region Metodos

        /// <summary>Método que implementa la ejecución del comando 'ConsultarUsuarioStatus'.
        /// </summary>

        public IList<Core.LogicaNegocio.Entidades.Usuario> Ejecutar()
        {

            UsuarioSQLServer bd = new UsuarioSQLServer();

            IList<Core.LogicaNegocio.Entidades.Usuario> _usuario = bd.ConsultarUsuarioStatus();

            return _usuario;
        }

        #endregion
    }
}
