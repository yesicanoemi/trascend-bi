using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.LogicaNegocio.Comandos.ComandoUsuario
{
    public class ConsultarUsuario : Comando<Core.LogicaNegocio.Entidades.Usuario>
    {
        private Core.LogicaNegocio.Entidades.Usuario usuario;

        #region Constructor

        /// <summary>Constructor de la clase 'CosultarCredenciales'.</summary>

        public ConsultarUsuario()
        { }

        public ConsultarUsuario(Core.LogicaNegocio.Entidades.Usuario usuario)
        {
            this.usuario = usuario;
        }

        #endregion

        #region Metodos

        /// <summary>Método que implementa la ejecución del comando 'CosultarCredenciales'.</summary>




        #endregion
    }
}
