using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;


namespace Core.LogicaNegocio.Comandos.ComandoUsuario
{
    public class ConsultarCredenciales : Comando<Usuario>
    {
        #region Propiedades

        private Core.LogicaNegocio.Entidades.Usuario usuario;

        #endregion

        #region Constructor

        /// <summary>Constructor de la clase 'CosultarCredenciales'.</summary>
       
        public ConsultarCredenciales()
        { }

        public ConsultarCredenciales(Core.LogicaNegocio.Entidades.Usuario usuario)
        {
            this.usuario = usuario;
        }

        #endregion

        #region Metodos

        /// <summary>Método que implementa la ejecución del comando 'CosultarCredenciales'.</summary>
    
        public Usuario Ejecutar()
        {
            Usuario _usuario;
         
            UsuarioSQLServer bd = new UsuarioSQLServer();
            
            _usuario = bd.ConsultarCredenciales(usuario);
            
            return _usuario;
        }


        #endregion
    }
}
