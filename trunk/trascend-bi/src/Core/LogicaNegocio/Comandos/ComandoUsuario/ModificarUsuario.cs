using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoUsuario
{
    public class ModificarUsuario : Comando<Core.LogicaNegocio.Entidades.Usuario>
    {
        #region Propiedades

        private Core.LogicaNegocio.Entidades.Usuario usuario;

        #endregion

        #region Constructor

        /// <summary>Constructor de la clase 'ModificarUsuario'.</summary>

        public ModificarUsuario()
        { }

        public ModificarUsuario(Core.LogicaNegocio.Entidades.Usuario usuario)
        {
            this.usuario = usuario;
        }

        #endregion

        #region Métodos

        /// <summary>Método que implementa la ejecución del comando 'ModificarUsuario'.</summary>

        public void Ejecutar()
        {

            UsuarioSQLServer bd = new UsuarioSQLServer();

            bd.ModificarUsuario(usuario);

        }

        #endregion
    }
}