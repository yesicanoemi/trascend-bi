using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Configuration;
using System.Xml;

namespace Core.AccesoDatos.SqlServer
{
    class UsuarioSQLServer
    {
        #region Propiedades

        #endregion

        #region Constructor

        public UsuarioSQLServer()
        {
        }

        #endregion

        private SqlConnection GetConnection()
        {
            XmlDocument xDoc = new XmlDocument();

            xDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "configuration.xml");

            XmlNodeList conexiones = xDoc.GetElementsByTagName("connection");

            string lista = conexiones[0].InnerText;

            SqlConnection connection = new SqlConnection(lista);

            connection.Open();

            return connection;
        }

        #region Metodos


        /// <summary>
        /// Metodo que consulta el login y password de un usuario
        /// </summary>
        /// <param name="usuario">Usuario que inicia sesion</param>
        /// <returns>Estado del usuario ("Status")</returns>

        public Usuario ConsultarCredenciales(Usuario usuario)
        {
            Usuario _usuario = new Usuario();

            try
            {
                SqlParameter[] arParms = new SqlParameter[2];

                arParms[0] = new SqlParameter("@LoginUsuario", SqlDbType.VarChar);

                arParms[0].Value = usuario.Login;

                arParms[1] = new SqlParameter("@Password", SqlDbType.VarChar);

                arParms[1].Value = usuario.Password;

                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(),
                                        "ConsultarCredenciales", arParms);

                if (reader.Read())
                {
                    _usuario.Status = (string)reader["Status"];
                }

                return _usuario;
            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            return _usuario;

        }


        /// <summary>
        /// Metodo para consultar el usuario por "Login"
        /// </summary>
        /// <param name="usuario">Criterio de busqueda</param>
        /// <returns>Usuario(s) que coincidan con el criterio</returns>


        public IList<Core.LogicaNegocio.Entidades.Usuario> ConsultarUsuario(Usuario entidad)
        {
            //Usuario _usuario = new Usuario();
            IList<Core.LogicaNegocio.Entidades.Usuario> usuario = new List<Core.LogicaNegocio.Entidades.Usuario>();

            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@LoginUsuario", SqlDbType.VarChar);

                arParms[0].Value = "%" + entidad.Login + "%";

                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(),
                                        "ConsultarUsuario", arParms);

                while (reader.Read())
                {
                    Usuario _usuario = new Usuario();

                    _usuario.Login = (string)reader["LoginUsuario"];

                    _usuario.Nombre = (string)reader["Nombre"];

                    _usuario.Apellido = (string)reader["Apellido"];

                    _usuario.Status = (string)reader["Status"];

                    usuario.Add(_usuario);
                }

                return usuario;

            }

            catch (SqlException e)
            {
                System.Console.Write(e);
            }

            return usuario;

        }


        public void ModificarUsuario(Usuario usuario)
        {//aun le falta pasarle la lista de los permisos..

            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@LoginUsuario", SqlDbType.VarChar);

                arParms[0].Value = usuario.Login;

                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(),
                                        "ModificarUsuario", arParms);
            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }

        }



        /// <summary>
        /// Metodo para consultar todos los usuarios activos del sistema
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Usuarios del sistema</returns>


        public IList<Core.LogicaNegocio.Entidades.Usuario> ListaUsuarios()
        {
            
            IList<Core.LogicaNegocio.Entidades.Usuario> usuario = new List<Core.LogicaNegocio.Entidades.Usuario>();

            try
            {
                SqlParameter[] arParms = new SqlParameter[0];

                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(),
                                        "ListaUsuarios", arParms);

                while (reader.Read())
                {
                    Usuario _usuario = new Usuario();

                    _usuario.Login = (string)reader["LoginUsuario"];

                     usuario.Add(_usuario);
                }

                return usuario;

            }

            catch (SqlException e)
            {
                System.Console.Write(e);
            }

            return usuario;

        }



        /// <summary>
        /// Metodo para verificar que  el "Login" exista en el sistema
        /// </summary>
        /// <param name="usuario">Criterio de busqueda (Usuario)</param>
        /// <returns>Usuario que coincide con el criterio</returns>

        public Usuario VerificarUsuario(Usuario usuario)
        {
            Usuario _usuario = new Usuario();

            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@LoginUsuario", SqlDbType.VarChar);

                arParms[0].Value = usuario.Login;

                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(),
                                        "ConsultarUsuario", arParms);

                if (reader.Read())
                {
                    _usuario.Login = (string)reader["LoginUsuario"];

                    _usuario.Status = (string)reader["Status"];
                }

                return _usuario;
            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            return _usuario;

        }



        /// <summary>
        /// Metodo que actualiza el status de un usuario quedando inactivo
        /// </summary>
        /// <param name="usuario">Usuario que inicia sesion</param>
        /// <returns>Usuario inactivo</returns>

        public Usuario EliminarUsuario(Usuario usuario)
        {
            Usuario _usuario = new Usuario();
            try
            {

                SqlParameter[] arParms = new SqlParameter[2];
                // Parametros
                arParms[0] = new SqlParameter("@LoginUsuario", SqlDbType.VarChar);
                arParms[0].Value = usuario.Login;
                arParms[1] = new SqlParameter("@Status", SqlDbType.VarChar);
                arParms[1].Value = usuario.Status;

                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(),
                "EliminarUsuario", arParms);

                if (reader.Read())
                {
                    _usuario.Login = (string)reader["LoginUsuario"];

                    _usuario.Status = (string)reader["Status"];
                }

                return _usuario;

            }

            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            return _usuario;

        }

        #endregion

    }
}
