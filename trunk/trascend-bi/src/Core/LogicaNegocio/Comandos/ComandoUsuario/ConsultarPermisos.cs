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

        #region Propiedades

        private Core.LogicaNegocio.Entidades.Usuario usuario;

        #endregion
  
        #region Constructor

        /// <summary>Constructor de la clase 'ConsultarPermisos'.</summary>

        public ConsultarPermisos()
        { }

        public ConsultarPermisos(Core.LogicaNegocio.Entidades.Usuario usuario)
        {
            this.usuario = usuario;
        }

        #endregion

        #region Métodos

        /// <summary>Método que implementa la ejecución del comando 'ConsultarPermisos'.</summary>

        public IList<Core.LogicaNegocio.Entidades.Permiso> Ejecutar()
        {

            UsuarioSQLServer bd = new UsuarioSQLServer();

            IList<Core.LogicaNegocio.Entidades.Permiso> _permiso = bd.ConsultarPermisos(usuario);

            return _permiso;
        }

        #endregion
    }
}
