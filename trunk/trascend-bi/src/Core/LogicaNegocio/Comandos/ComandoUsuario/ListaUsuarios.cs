using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.AccesoDatos.Fabricas;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;


namespace Core.LogicaNegocio.Comandos.ComandoUsuario
{
    public class ListaUsuarios : Comando<Core.LogicaNegocio.Entidades.Usuario>
    {
        private Core.LogicaNegocio.Entidades.Usuario usuario;

        #region Constructor


        public ListaUsuarios()
        { }

        
        public ListaUsuarios(Core.LogicaNegocio.Entidades.Usuario usuario)
        {
            this.usuario = usuario;
        }
        

        #endregion

        #region Metodos

        /// <summary>Método que implementa la ejecución del comando 'ListaUsuarios'.</summary>

        public IList<Core.LogicaNegocio.Entidades.Usuario> Ejecutar()
        {
            //Usuario _usuario;

            //UsuarioSQLServer bd = new UsuarioSQLServer();

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOUsuario iDAOUsuario = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOUsuario();

            IList<Core.LogicaNegocio.Entidades.Usuario> _usuario = iDAOUsuario.ListaUsuarios();

            return _usuario;
        }

        #endregion
    }
}