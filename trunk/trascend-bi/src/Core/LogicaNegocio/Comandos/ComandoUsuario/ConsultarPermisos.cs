using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoUsuario
{
    public class ConsultarPermisos: Comando<Core.LogicaNegocio.Entidades.Usuario>
    {
        private Core.LogicaNegocio.Entidades.Usuario usuario;

        #region Constructor

        /// <summary>Constructor de la clase 'CosultarCredenciales'.</summary>

        public ConsultarPermisos()
        { }

        public ConsultarPermisos(Core.LogicaNegocio.Entidades.Usuario usuario)
        {
            this.usuario = usuario;
        }

        #endregion

        #region Metodos

        /// <summary>Método que implementa la ejecución del comando 'CosultarUsuarios'.</summary>

        public IList<Core.LogicaNegocio.Entidades.Permiso> Ejecutar()
        {
            //Usuario _usuario;

            UsuarioSQLServer bd = new UsuarioSQLServer();

            IList<Core.LogicaNegocio.Entidades.Permiso> _permiso = bd.ConsultarPermisos(usuario);

            return _permiso;
        }

        #endregion
    }
}
