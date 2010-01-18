﻿using System;
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

        #region Constructor

        public UsuarioSQLServer()
        {
        }

        #endregion

        #region Conexion a la Base de Datos
     
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

        #endregion

        #region Metodos

        #region ConsultarCredenciales

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
                //Parametros de busqueda

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

            }
            return _usuario;

        }


        #endregion

        #region ConsultarUsuario

        /// <summary>
        /// Metodo para consultar el usuario por "Login"
        /// </summary>
        /// <param name="usuario">Criterio de busqueda</param>
        /// <returns>Usuario(s) que coincidan con el criterio</returns>


        public IList<Core.LogicaNegocio.Entidades.Usuario> ConsultarUsuario(Usuario entidad)
        {
            IList<Core.LogicaNegocio.Entidades.Usuario> usuario = 
                                            new List<Core.LogicaNegocio.Entidades.Usuario>();

            try
            {
                //Parametros de busqueda

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

            }

            return usuario;

        }

        #endregion

        #region ConsultarUsuarioStatus

        /// <summary>
        /// Metodo para consultar todos los usuarios
        /// </summary>
        /// <returns>Usuario(s) del sistema</returns>


        public IList<Core.LogicaNegocio.Entidades.Usuario> ConsultarUsuarioStatus()
        {
            IList<Core.LogicaNegocio.Entidades.Usuario> usuario =
                                            new List<Core.LogicaNegocio.Entidades.Usuario>();

            try
            {

                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(),
                                        "ConsultarUsuarioTodos");

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

            }

            return usuario;

        }

        #endregion

        #region ModificarUsuario

        /// <summary>
        /// Metodo para modificar los permisos de usuarios
        /// </summary>

        public void ModificarUsuario(Usuario usuario)
        {
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@LoginUsuario", SqlDbType.VarChar);

                arParms[0].Value = usuario.Login;

                SqlHelper.ExecuteNonQuery(GetConnection(),
                                        "EliminarPermisos", arParms);


                SqlParameter[] arParmsAgregarPermisos = new SqlParameter[2];

                arParmsAgregarPermisos[0] = new SqlParameter("@LoginUsuario", SqlDbType.VarChar);

                arParmsAgregarPermisos[0].Value = usuario.Login;

                arParmsAgregarPermisos[1] = new SqlParameter("@IdPermiso", SqlDbType.VarChar);

                
                for (int i = 0; i < usuario.PermisoUsu.Count; i++)
                {
                    arParmsAgregarPermisos[1].Value = usuario.PermisoUsu[i].IdPermiso;

                    SqlHelper.ExecuteNonQuery(GetConnection(),
                                            "AgregarPermisoUsuario", arParmsAgregarPermisos);
                }

            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }

        }

        #endregion  

        #region ConsultarPermisos

        /// <summary>
        /// Método para consultar los permisos de usuarios
        /// </summary>
        /// <param name="entidad">Entidad Usuario</param>
        /// <returns>Lista de permisos del usuario a consultar</returns>
        
        public IList<Core.LogicaNegocio.Entidades.Permiso> ConsultarPermisos(Usuario entidad)
        {

            IList<Core.LogicaNegocio.Entidades.Permiso> permiso = new List<Core.LogicaNegocio.Entidades.Permiso>();

            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@LoginUsuario", SqlDbType.VarChar);

                arParms[0].Value = entidad.Login;

                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(),
                                        "ConsultarPermisos", arParms);

                while (reader.Read())
                {
                    Permiso _permiso = new Permiso();

                    _permiso.IdPermiso = (int)reader["IdPermiso"];

                    permiso.Add(_permiso);
                }

                return permiso;

            }

            catch (SqlException e)
            {
                System.Console.Write(e);
            }

            return permiso;

        }

        #endregion  
        
        #region AgregarUsuario

        /// <summary>
        /// Método para agregar los usuarios a la bd
        /// </summary>
        /// <param name="usuario">Entidad usuario a registrar</param>

        public void AgregarUsuario(Usuario usuario)
        {
            try
            {
                #region Busca el Id del empleado

                SqlParameter[] arParmsIdEmp = new SqlParameter[1];

                arParmsIdEmp[0] = new SqlParameter("@CIEmpleado", SqlDbType.Int);

                arParmsIdEmp[0].Value = usuario.IdUsuario;

                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(),
                                        "BuscarIDEmpleado", arParmsIdEmp);

                while (reader.Read())
                {
                    usuario.IdUsuario = (int)reader["IdEmpleado"];
                }

                #endregion

                #region Agregar Usuario en la bd

                SqlParameter[] arParms = new SqlParameter[4];

                arParms[0] = new SqlParameter("@LoginUsuario", SqlDbType.VarChar);

                arParms[0].Value = usuario.Login;

                arParms[1] = new SqlParameter("@Password", SqlDbType.VarChar);

                arParms[1].Value = usuario.Password;

                arParms[2] = new SqlParameter("@Status", SqlDbType.VarChar);

                arParms[2].Value = "Activo";

                arParms[3] = new SqlParameter("@IdEmpleado", SqlDbType.Int);

                arParms[3].Value = usuario.IdUsuario;

                SqlHelper.ExecuteNonQuery(GetConnection(),
                                        "AgregarUsuario", arParms);
                #endregion

                #region Agregar Permisos al usuario registrado

                SqlParameter[] arParmsAgregarPermisos = new SqlParameter[2];

                arParmsAgregarPermisos[0] = new SqlParameter("@LoginUsuario", SqlDbType.VarChar);

                arParmsAgregarPermisos[0].Value = usuario.Login;

                arParmsAgregarPermisos[1] = new SqlParameter("@IdPermiso", SqlDbType.VarChar);


                for (int i = 0; i < usuario.PermisoUsu.Count; i++)
                {
                    arParmsAgregarPermisos[1].Value = usuario.PermisoUsu[i].IdPermiso;

                    SqlHelper.ExecuteNonQuery(GetConnection(),
                                            "AgregarPermisoUsuario", arParmsAgregarPermisos);
                }
                #endregion

            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }

        }

        #endregion



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
