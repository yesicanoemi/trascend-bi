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
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos.Fabricas;
using Core.LogicaNegocio.Excepciones.Usuario.AccesoDatos;

namespace Core.AccesoDatos.SqlServer
{
    class DAOUsuarioSQLServer : IDAOUsuario
    {


        IConexion _conexion = new FabricaConexion().getConexionSQLServer();

        #region Constructor

        public DAOUsuarioSQLServer()
        {
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

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                                        "ConsultarCredenciales", arParms);

                if (reader.Read())
                {
                    _usuario.Status = (string)reader["Status"];

                    _usuario.Login = (string)reader["LoginUsuario"];

                    _usuario.IdUsuario = (int)reader["IdUsuario"];
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

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                                        "ConsultarUsuario", arParms);

                while (reader.Read())
                {
                    Usuario _usuario = new Usuario();

                    _usuario.Login = (string)reader["LoginUsuario"];

                    _usuario.Nombre = (string)reader["Nombre"];

                    _usuario.Apellido = (string)reader["Apellido"];

                    _usuario.Status = (string)reader["Status"];

                    _usuario.IdUsuario = (int)reader["IdUsuario"];

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

                arParms[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);

                arParms[0].Value = usuario.IdUsuario;

                /* DbDataReader readerN1 = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                        "EliminarPermisos", arParms);*/
                SqlHelper.ExecuteNonQuery(_conexion.GetConnection(),
                                        "EliminarPermisos", arParms);


                SqlParameter[] arParmsAgregarPermisos = new SqlParameter[2];

                arParmsAgregarPermisos[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);

                arParmsAgregarPermisos[0].Value = usuario.IdUsuario;

                arParmsAgregarPermisos[1] = new SqlParameter("@IdPermiso", SqlDbType.Int);


                for (int i = 0; i < usuario.PermisoUsu.Count; i++)
                {
                    arParmsAgregarPermisos[1].Value = usuario.PermisoUsu[i].IdPermiso;

                    SqlHelper.ExecuteNonQuery(_conexion.GetConnection(),
                                            "AgregarPermisoUsuario", arParmsAgregarPermisos);
                    /* DbDataReader readerN2 = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                       "AgregarPermisoUsuario", arParmsAgregarPermisos);*/
                }

                SqlParameter[] arParmsStatus = new SqlParameter[2];

                arParmsStatus[0] = new SqlParameter("@LoginUsuario", SqlDbType.VarChar);

                arParmsStatus[0].Value = usuario.Login;

                arParmsStatus[1] = new SqlParameter("@Status", SqlDbType.VarChar);

                arParmsStatus[1].Value = usuario.Status;


                SqlHelper.ExecuteNonQuery(_conexion.GetConnection(),
                                        "ModificarStatusUsuario", arParmsStatus);

                /* DbDataReader readerN3 = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                "ModificarStatusUsuario", arParmsStatus);*/

            }
            catch (SqlException e)
            {
                throw new ModificarUsuarioBDExcepciones("Error Modificando en la base de datos", e);
            }
            catch (Exception e)
            {
                throw new ModificarUsuarioBDExcepciones("Error Modificando usuario", e);
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

                arParms[0] = new SqlParameter("@IdUsuario", SqlDbType.VarChar);

                arParms[0].Value = entidad.IdUsuario;

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
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
           
                #region Busca el Id del empleado
                try
                {


                    SqlParameter[] arParmsIdEmp = new SqlParameter[1];

                    arParmsIdEmp[0] = new SqlParameter("@CIEmpleado", SqlDbType.Int);

                    arParmsIdEmp[0].Value = usuario.Cedula;

                    DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                                            "BuscarCIEmpleado", arParmsIdEmp);

                    while (reader.Read())
                    {
                        usuario.Id = (int)reader["IdEmpleado"];
                    }


                }
                catch(SqlException e)
                {
                    throw new ConsultarUsuarioBDExcepciones("Error consultando empleado", e);
                }
                #endregion

                #region Agregar Usuario en la bd
                try
                {


                    SqlParameter[] arParms = new SqlParameter[4];

                    arParms[0] = new SqlParameter("@LoginUsuario", SqlDbType.VarChar);

                    arParms[0].Value = usuario.Login;

                    arParms[1] = new SqlParameter("@Password", SqlDbType.VarChar);

                    arParms[1].Value = usuario.Password;

                    arParms[2] = new SqlParameter("@Status", SqlDbType.VarChar);

                    arParms[2].Value = "Activo";

                    arParms[3] = new SqlParameter("@IdEmpleado", SqlDbType.Int);

                    arParms[3].Value = usuario.Id;

                    DbDataReader readerN = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                        "AgregarUsuario", arParms);
                    /*SqlHelper.ExecuteNonQuery(_conexion.GetConnection(),
                                            "AgregarUsuario", arParms);*/

                }
                catch (SqlException e)
                {
                    //System.Console.Write(e);
                    throw new AgregarUsuarioBDExcepciones("Error agregando en la base de datos", e);
                }
                catch (Exception e)
                {

                    throw new AgregarUsuarioBDExcepciones("Error agregando usuario", e);
                }
                #endregion

                #region ConsultarUsuario agregado


                SqlParameter[] arParms1 = new SqlParameter[1];

                arParms1[0] = new SqlParameter("@LoginUsuario", SqlDbType.VarChar);

                arParms1[0].Value = usuario.Login;

                DbDataReader reader1 = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                                        "ConsultarUsuario", arParms1);

                IList<Usuario> usuario2 = new List<Usuario>();

                while (reader1.Read())
                {
                    Usuario _usuario = new Usuario();

                    _usuario.IdUsuario = (int)reader1["IdUsuario"];

                    usuario2.Add(_usuario);
                }




                #endregion

                #region Agregar Permisos al usuario registrado

                try
                {

                    SqlParameter[] arParmsAgregarPermisos = new SqlParameter[2];

                    arParmsAgregarPermisos[0] = new SqlParameter("@IdUsuario", SqlDbType.VarChar);

                    arParmsAgregarPermisos[0].Value = usuario2[0].IdUsuario;

                    arParmsAgregarPermisos[1] = new SqlParameter("@IdPermiso", SqlDbType.Int);


                    for (int i = 0; i < usuario.PermisoUsu.Count; i++)
                    {
                        arParmsAgregarPermisos[1].Value = usuario.PermisoUsu[i].IdPermiso;
                        DbDataReader readerN1 = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                                           "AgregarPermisoUsuario", arParmsAgregarPermisos);

                        /*SqlHelper.ExecuteNonQuery(_conexion.GetConnection(),
                                                "AgregarPermisoUsuario", arParmsAgregarPermisos);*/
                    }
                }
                catch (SqlException e)
                {
                    //System.Console.Write(e);
                    throw new AgregarPermisosBDExcepciones("Error agregando en la base de datos", e);
                }
                catch (Exception e)
                {

                    throw new AgregarPermisosBDExcepciones("Error agregando permisos de usuario", e);
                }
                #endregion
        }

        #endregion

        #region ConsultarEmpleadoConUsuario

        /// <summary>
        /// Metodo para consultar el usuario por "Login"
        /// </summary>
        /// <param name="usuario">Criterio de busqueda</param>
        /// <returns>Usuario(s) que coincidan con el criterio</returns>


        public IList<Core.LogicaNegocio.Entidades.Empleado> ConsultarEmpleadoConUsuario(Empleado entidad)
        {
            IList<Core.LogicaNegocio.Entidades.Empleado> empleado =
                                            new List<Core.LogicaNegocio.Entidades.Empleado>();

            try
            {
                //Parametros de busqueda
                #region Busca el Id del empleado

                SqlParameter[] arParmsIdEmp = new SqlParameter[1];

                arParmsIdEmp[0] = new SqlParameter("@CIEmpleado", SqlDbType.Int);

                arParmsIdEmp[0].Value = entidad.Cedula;

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                                        "BuscarCIEmpleado", arParmsIdEmp);

                while (reader.Read())
                {
                    entidad.Id = (int)reader["IdEmpleado"];
                }

                #endregion


                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@IdEmpleado", SqlDbType.Int);

                arParms[0].Value = entidad.Id;

                DbDataReader reader2 = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                                        "ConsultarEmpleadoConUsuario", arParms);

                while (reader2.Read())
                {
                    Empleado _empleado = new Empleado();

                    _empleado.Id = (int)reader2["IdEmpleado"];

                    empleado.Add(_empleado);
                }

                return empleado;

            }

            catch (SqlException e)
            {

            }

            return empleado;

        }

        #endregion

        #region ConsultarEmpleadoConUsuario

        /// <summary>
        /// Metodo para consultar el usuario por "Login"
        /// </summary>
        /// <param name="usuario">Criterio de busqueda</param>
        /// <returns>Usuario(s) que coincidan con el criterio</returns>


        public IList<Core.LogicaNegocio.Entidades.Empleado> ConsultarEmpleadoSinUsuario(Empleado entidad)
        {
            List<Empleado> empleado = new List<Empleado>();
            try
            {

                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@nombre", SqlDbType.VarChar);
                arParms[0].Value = "%" + entidad.Nombre + "%";

                DbDataReader reader = SqlHelper.ExecuteReader
                    (_conexion.GetConnection(), "ConsultarEmpleadoSinUsuario", arParms);
                while (reader.Read())
                {
                    Empleado _empleado = new Empleado();

                    _empleado.Cedula = (int)reader["CIEmpleado"];
                    _empleado.Nombre = (string)reader["Nombre"];
                    _empleado.Apellido = (string)reader["Apellido"];
                    _empleado.Cuenta = (string)reader["NumCuenta"];
                    _empleado.FechaNacimiento = (DateTime)reader["FechaNac"];

                    empleado.Add(_empleado);
                }
            }

            catch (SqlException e)
            {

            }

            return empleado;

        }

        #endregion

        #region ConsultarListaUsuariosActivos
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

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
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

        #endregion

        #region VerificarLoginUsuario

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

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
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

        #endregion

        #region EliminarUsuario

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

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
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
                //System.Console.Write(e);
                throw new EliminarUsuarioBDExcepciones("Error elimnando en la base de datos", e);
            }
            catch (Exception e)
            {

                throw new EliminarUsuarioBDExcepciones("Error eliminando usuario", e);
            }
            return _usuario;

        }

        #endregion

        #region ConsultarUsuarioTodos

        /// <summary>
        /// Metodo que trae todos los usuarios del sistema
        /// </summary>
        /// <param name="usuario">Usuario que inicia sesion</param>
        /// <returns>Lista de Usuarios</returns>

        public IList<Usuario> ConsultarUsuarioTodos()
        {
            IList<Core.LogicaNegocio.Entidades.Usuario> usuario =
                                             new List<Core.LogicaNegocio.Entidades.Usuario>();

            try
            {

                SqlParameter[] arParms = new SqlParameter[2];
                // Parametros
                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                "ConsultarUsuarioTodos");

                while (reader.Read())
                {
                    Usuario _usuario = new Usuario();

                    _usuario.Login = (string)reader["LoginUsuario"];

                    _usuario.Nombre = (string)reader["Nombre"];

                    _usuario.Apellido = (string)reader["Apellido"];

                    _usuario.Status = (string)reader["Status"];

                    _usuario.IdUsuario = (int)reader["IdUsuario"];

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

        #endregion

        #region ConsultarIdPermiso

        /// <summary>
        /// Método para consultar los permisos de usuarios
        /// </summary>
        /// <param name="entidad">Entidad Usuario</param>
        /// <returns>Lista de permisos del usuario a consultar</returns>

        public Core.LogicaNegocio.Entidades.Permiso ConsultarIdPermiso(Permiso permiso)
        {

            Permiso _permiso = new Permiso();

            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@NombreUsuario", SqlDbType.VarChar);

                arParms[0].Value = permiso.Permisos;

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                                        "ConsultarIdPermiso", arParms);

                while (reader.Read())
                {


                    _permiso.IdPermiso = (int)reader["IdPermiso"];

                    //permiso1(_permiso);
                }

                return _permiso;

            }

            catch (SqlException e)
            {
                System.Console.Write(e);
            }

            return permiso;

        }

        #endregion

        #endregion


    }
}