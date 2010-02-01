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
    public class ConsultarIdPermiso : Comando<Core.LogicaNegocio.Entidades.Permiso>
    {
        #region Propiedades

        private Core.LogicaNegocio.Entidades.Permiso permiso;

        #endregion

        #region Constructor

        /// <summary>Constructor de la clase 'ConsultarIdPermiso'.</summary>

        public ConsultarIdPermiso()
        { }

        public ConsultarIdPermiso(Core.LogicaNegocio.Entidades.Permiso permiso)
        {
            this.permiso = permiso;
        }

        #endregion

        #region Métodos

        /// <summary>Método que implementa la ejecución del comando 'ConsultarIdPermiso'.</summary>

        public Core.LogicaNegocio.Entidades.Permiso Ejecutar()
        {

            //UsuarioSQLServer bd = new UsuarioSQLServer();

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOUsuario iDAOUsuario = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOUsuario();

            Core.LogicaNegocio.Entidades.Permiso _permiso = iDAOUsuario.ConsultarIdPermiso(permiso);

            return _permiso;
        }

        #endregion
    }
}
