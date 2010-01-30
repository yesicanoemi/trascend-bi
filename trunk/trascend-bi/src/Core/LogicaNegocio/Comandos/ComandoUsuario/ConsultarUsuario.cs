using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.AccesoDatos;
using Core.AccesoDatos.Interfaces;

namespace Core.LogicaNegocio.Comandos.ComandoUsuario
{
    public class ConsultarUsuario : Comando<Core.LogicaNegocio.Entidades.Usuario>
    {
        #region Propiedades

        private Core.LogicaNegocio.Entidades.Usuario usuario;

        #endregion

        #region Constructor

        /// <summary>Constructor de la clase 'CosultarUsuario'.</summary>

        public ConsultarUsuario()
        { }

        public ConsultarUsuario(Core.LogicaNegocio.Entidades.Usuario usuario)
        {
            this.usuario = usuario;
        }

        #endregion

        #region Metodos

        /// <summary>Método que implementa la ejecución del comando 'CosultarUsuarios'.</summary>

        public IList<Core.LogicaNegocio.Entidades.Usuario> Ejecutar()
        {
            

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOUsuario iDAOUsuario = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOUsuario();

            IList<Core.LogicaNegocio.Entidades.Usuario> _usuario = iDAOUsuario.ConsultarUsuario(usuario);

            return _usuario;
        }

        #endregion
    }
}
