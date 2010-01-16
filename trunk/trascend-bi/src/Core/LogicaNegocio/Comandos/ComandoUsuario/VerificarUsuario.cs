using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoUsuario
{
    public class VerificarUsuario : Comando<Core.LogicaNegocio.Entidades.Usuario>
    {
        private Core.LogicaNegocio.Entidades.Usuario usuario;

        #region Constructor

        
        public VerificarUsuario()
        { }

        public VerificarUsuario(Core.LogicaNegocio.Entidades.Usuario usuario)
        {
            this.usuario = usuario;
        }

        #endregion

        #region Metodos

        /// <summary>Método que implementa la ejecución del comando 'VerificarUsuarios'.</summary>

        public Usuario Ejecutar()
        {
            Usuario _usuario;

            UsuarioSQLServer bd = new UsuarioSQLServer();

            _usuario = bd.VerificarUsuario(usuario);

            return _usuario;
        }

        #endregion
    }
}