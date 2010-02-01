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
    public class ConsultarEmpleadoSinUsuario : Comando<Core.LogicaNegocio.Entidades.Usuario>
    {
        #region Propiedades

        private Core.LogicaNegocio.Entidades.Empleado empleado;

        #endregion

        #region Constructor

        /// <summary>Constructor de la clase 'ConsultarEmpleadoSinUsuario'.</summary>

        public ConsultarEmpleadoSinUsuario()
        { }

        public ConsultarEmpleadoSinUsuario(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            this.empleado = empleado;
        }

        #endregion

        #region Metodos

        /// <summary>Método que implementa la ejecución del comando 'ConsultarEmpleadoSinUsuario'.</summary>

        public IList<Core.LogicaNegocio.Entidades.Empleado> Ejecutar()
        {

            //UsuarioSQLServer bd = new UsuarioSQLServer();

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOUsuario iDAOUsuario = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOUsuario();

            IList<Empleado> _empleado = iDAOUsuario.ConsultarEmpleadoSinUsuario(empleado);

            //  IList<Core.LogicaNegocio.Entidades.Empleado> _empleado = bd.ConsultarEmpleadoConUsuario(empleado);

            return _empleado;
        }

        #endregion
    }
}
