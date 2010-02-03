﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Excepciones;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Configuration;
using System.Xml;
using System.Net;
using Core.LogicaNegocio.Excepciones.Empleados.AccesoDatos;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos.Fabricas;


namespace Core.AccesoDatos.SqlServer
{
    public class DAOEmpleadoSQLServer : IDAOEmpleado
    {
        IConexion _conexion = new FabricaConexion().getConexionSQLServer();

        #region Propiedades

        #endregion
        #region Constructor
        public DAOEmpleadoSQLServer()
        {
        }
        #endregion
        /* #region Conexion a Base de Datos
        private SqlConnection GetConnection()
        {
            XmlDocument xDoc = new XmlDocument();

            //La ruta del documento XML permite rutas relativas 
            //respecto del ejecutable!

            xDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "configuration.xml");

            XmlNodeList conexiones = xDoc.GetElementsByTagName("connection");

            string lista = conexiones[0].InnerText;
            SqlConnection connection = new SqlConnection(lista);
            connection.Open();

            return connection;
        }
        #endregion */

        #region Metodos

        public Empleado Ingresar(Empleado empleado)
        {
            Empleado _empleado = new Empleado();
            try
            {

                SqlParameter[] arParms = new SqlParameter[8];
                // Parametros 

                arParms[0] = new SqlParameter("@cedula", SqlDbType.Int);

                arParms[0].Value = empleado.Cedula;

                arParms[1] = new SqlParameter("@nombreEmpleado", SqlDbType.VarChar);

                arParms[1].Value = empleado.Nombre;

                arParms[2] = new SqlParameter("@apellidoEmpleado", SqlDbType.VarChar);

                arParms[2].Value = empleado.Apellido;

                arParms[3] = new SqlParameter("@numeroCta", SqlDbType.VarChar);

                arParms[3].Value = empleado.Cuenta;

                arParms[4] = new SqlParameter("@fechaNac", SqlDbType.SmallDateTime);

                arParms[4].Value = empleado.FechaNacimiento.ToShortDateString();

                arParms[5] = new SqlParameter("@estado", SqlDbType.Int);

                arParms[5].Value = empleado.Estado;

                arParms[6] = new SqlParameter("@sueldo", SqlDbType.Float);

                arParms[6].Value = empleado.SueldoBase;

                arParms[7] = new SqlParameter("@cargo", SqlDbType.Int);

                arParms[7].Value = empleado.Cargo;

                DbDataReader reader = SqlHelper.ExecuteReader
                    (_conexion.GetConnection(), "InsertarEmpleado", arParms);

                if (reader.Read())
                {
                    Direccion direccion;

                    InsertarDireccion(empleado, Int32.Parse(reader[0].ToString()));

                }
                else
                    throw new IngresarEmpleadoBDExepciones();

            }
            catch (SqlException e)
            {
                throw new IngresarEmpleadoBDExepciones
                    ("Error SQL Ingresando en la Base de datos", e);
            }
            catch (Exception e)
            {
                throw new IngresarEmpleadoBDExepciones("Error Ingresando Empledo", e);
            }

            return _empleado;

        }


        public void InsertarDireccion(Core.LogicaNegocio.Entidades.Empleado empleado, int id)
        {
            Direccion direccion = new Direccion();

            try
            {


                SqlParameter[] arParms = new SqlParameter[7];

                arParms[0] = new SqlParameter("@id", SqlDbType.Int);

                arParms[0].Value = id;

                arParms[1] = new SqlParameter("@avenida", SqlDbType.VarChar);

                arParms[1].Value = empleado.Direccion.Avenida;

                arParms[2] = new SqlParameter("@calle", SqlDbType.VarChar);

                arParms[2].Value = empleado.Direccion.Calle;

                arParms[3] = new SqlParameter("@ciudad", SqlDbType.VarChar);

                arParms[3].Value = empleado.Direccion.Ciudad;

                arParms[4] = new SqlParameter("@edif", SqlDbType.VarChar);

                arParms[4].Value = empleado.Direccion.Edif_Casa;

                arParms[5] = new SqlParameter("@piso", SqlDbType.VarChar);

                arParms[5].Value = empleado.Direccion.Piso_apto;

                arParms[6] = new SqlParameter("@urbanizacion", SqlDbType.VarChar);

                arParms[6].Value = empleado.Direccion.Urbanizacion;

                SqlHelper.ExecuteNonQuery
                    (_conexion.GetConnection(), "InsertarDireccionEmpleado", arParms);
            }

            catch (SqlException e)
            {
                throw new IngresarEmpleadoBDExepciones("Error SQL Ingresando en la Base de datos", e);
            }
            catch (Exception e)
            {
                throw new IngresarEmpleadoBDExepciones("Error Ingresando en Empleado en direccion", e);
            }



        }


        public int Modificar(Empleado empleado)
        {
            int resultado = 0;
            try
            {
                SqlParameter[] arParms = new SqlParameter[8];
                // Parametros 
                arParms[0] = new SqlParameter("@id", SqlDbType.Int);
                arParms[0].Value = empleado.Cedula;
                arParms[1] = new SqlParameter("@nombreEmpleado", SqlDbType.VarChar);
                arParms[1].Value = empleado.Nombre;
                arParms[2] = new SqlParameter("@apellidoEmpleado", SqlDbType.VarChar);
                arParms[2].Value = empleado.Apellido;
                arParms[3] = new SqlParameter("@numeroCta", SqlDbType.VarChar);
                arParms[3].Value = empleado.Cuenta;
                arParms[4] = new SqlParameter("@fechaNac", SqlDbType.SmallDateTime);
                arParms[4].Value = empleado.FechaNacimiento.ToShortDateString();
                arParms[5] = new SqlParameter("@sueldo", SqlDbType.VarChar);
                arParms[5].Value = empleado.SueldoBase;
                arParms[6] = new SqlParameter("@cargo", SqlDbType.Int);
                arParms[6].Value = empleado.Cargo;
                arParms[7] = new SqlParameter("@Estado", SqlDbType.Int);
                arParms[7].Value = empleado.Estado;
                resultado = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "ModificarEmpleado", arParms);
                ModificarDireccion(empleado);
                return resultado;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            return resultado;
        }


        public IList<Empleado> Consultar()
        {
            IList<Empleado> empleado = null;


            try
            {


                DbDataReader reader = SqlHelper.ExecuteReader
                    (_conexion.GetConnection(), "ConsultarEmpleados");

                while (reader.Read())
                {

                    Empleado _empleado = new Empleado();

                    _empleado.Nombre = (string)reader["nombre"];

                    empleado.Add(_empleado);
                }
            }
            catch (SqlException e)
            {
                throw new ConsultarEmpleadoBDException
                    ("Error SQL consultando empleado en la Base de datos", e);
            }
            catch (Exception e)
            {
                throw new ConsultarEmpleadoBDException("Error consultando Empledo", e);
            }


            return empleado;
        }

        public Core.LogicaNegocio.Entidades.Empleado ConsultarId
            (Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                Direccion dir = new Direccion();

                // Parametros 

                arParms[0] = new SqlParameter("@id", SqlDbType.Int);

                arParms[0].Value = empleado.Id;

                DbDataReader reader = SqlHelper.ExecuteReader
                    (_conexion.GetConnection(), "ConsultarNomEmpleadoCedula", arParms);

                if (reader.Read())
                {
                    empleado.Cedula = (int)reader["CIEmpleado"];

                    empleado.Nombre = (string)reader["Nombre"];

                    empleado.Apellido = (string)reader["Apellido"];

                    empleado.Cuenta = (string)reader["NumCuenta"];

                    empleado.FechaNacimiento = (DateTime)reader["FechaNac"];

                    empleado.Estado = (int)reader["Estado"];

                    empleado.Cargo = reader["IdCargo"].ToString();

                    empleado.SueldoBase = (float)reader["Sueldo"];
                }
                else

                    throw new ConsultarEmpleadoBDException();

                arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@idEmpleado", SqlDbType.Int);

                arParms[0].Value = empleado.Id;

                reader = SqlHelper.ExecuteReader
                    (_conexion.GetConnection(), "ConsultarDireccionEmpleado", arParms);

                if (reader.Read())
                {

                    dir.Avenida = (string)reader["Avenida"];

                    dir.Calle = (string)reader["Calle"];

                    dir.Ciudad = (string)reader["Ciudad"];

                    dir.Edif_Casa = (string)reader["EdifCasa"];

                    dir.Piso_apto = (string)reader["PisoApto"];

                    dir.Urbanizacion = (string)reader["Urbanizacion"];
                }
                else

                    throw new ConsultarEmpleadoBDException();

                empleado.Direccion = dir;
            }
            catch (SqlException e)
            {
                throw new IngresarEmpleadoBDExepciones
                    ("Error SQL Consultando el empleado en la Base de datos", e);
            }
            catch (Exception e)
            {
                throw new IngresarEmpleadoBDExepciones("Error consultando empleando", e);
            }


            return empleado;
        }



        public List<Empleado> ConsultarPorTipoNombre(Empleado emp)
        {
            List<Empleado> empleado = new List<Empleado>();

            try
            {


                SqlParameter[] arParms = new SqlParameter[1];



                arParms[0] = new SqlParameter("@nombre", SqlDbType.VarChar);
                arParms[0].Value = emp.Nombre;

                DbDataReader reader = SqlHelper.ExecuteReader
                    (_conexion.GetConnection(), "ConsultarEmpleadoNombre", arParms);
                int i = 0;

                while (reader.Read())
                {
                    Empleado _empleado = new Empleado();

                    Direccion _direccion = new Direccion();

                    _empleado.Id = (int)reader["IdEmpleado"];

                    _empleado.Cedula = (int)reader["CIEmpleado"];

                    _empleado.Nombre = (string)reader["Nombre"];

                    _empleado.Apellido = (string)reader["Apellido"];

                    _empleado.Cuenta = (string)reader["NumCuenta"];

                    _empleado.FechaNacimiento = (DateTime)reader["FechaNac"];

                    _empleado.Estado = (int)reader["Estado"];

                    _empleado.Cargo = (string)reader["Expr1"];

                    _direccion.Avenida = (string)reader["Avenida"];

                    _direccion.Calle = (string)reader["Calle"];

                    _direccion.Ciudad = (string)reader["Ciudad"];

                    _direccion.Edif_Casa = (string)reader["EdifCasa"];

                    _direccion.Piso_apto = (string)reader["PisoApto"];

                    _direccion.Urbanizacion = (string)reader["Urbanizacion"];

                    _empleado.Direccion = _direccion;

                    empleado.Insert(i, _empleado);
                    //empleado.Add(_empleado);
                    i++;
                }
            }
            catch (SqlException e)
            {
                throw new ConsultarEmpleadoBDException
                    ("Error consultando empleado por nombre en la Base de datos", e);
            }
            catch (Exception e)
            {
                throw new ConsultarEmpleadoBDException
                    ("Error consultando en la Base de datos", e);
            }

            return empleado;
        }

        public IList<string> ConsultarCargos()
        {
            List<string> cargo = new List<string>();

            try
            {

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarCargos2");

                while (reader.Read())
                {

                    cargo.Add((string)reader["Nombre"]);


                }

            }
            catch (SqlException e)
            {
                throw new ConsultarEmpleadoBDException
                    ("Error SQL consultando en la Base de datos", e);
            }
            catch (Exception e)
            {
                throw new ConsultarEmpleadoBDException("Error consulandto empleado", e);
            }

            return cargo;
        }

        public Empleado ConsultarPorTipoCedula(Empleado emp)
        {
            Empleado _empleado = new Empleado();

            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@ced", SqlDbType.Int);

                arParms[0].Value = emp.Cedula;

                DbDataReader reader = SqlHelper.ExecuteReader
                    (_conexion.GetConnection(), "ConsultarEmpleadoCI", arParms);

                if (reader.Read())
                {

                    Direccion _direccion = new Direccion();

                    _empleado.Id = (int)reader["IdEmpleado"];

                    _empleado.Cedula = (int)reader["CIEmpleado"];

                    _empleado.Nombre = (string)reader["Nombre"];

                    _empleado.Apellido = (string)reader["Apellido"];

                    _empleado.Cuenta = (string)reader["NumCuenta"];

                    _empleado.FechaNacimiento = (DateTime)reader["FechaNac"];

                    _empleado.Estado = (int)reader["Estado"];

                    _empleado.Cargo = (string)reader["Expr1"];

                    _direccion.Avenida = (string)reader["Avenida"];

                    _direccion.Calle = (string)reader["Calle"];

                    _direccion.Ciudad = (string)reader["Ciudad"];

                    _direccion.Edif_Casa = (string)reader["EdifCasa"];

                    _direccion.Piso_apto = (string)reader["PisoApto"];

                    _direccion.Urbanizacion = (string)reader["Urbanizacion"];

                    _empleado.Direccion = _direccion;

                }
            }
            catch (SqlException e)
            {
                throw new ConsultarEmpleadoBDException("Error  de SQl consultando empleado por cedula en la Base de datos", e);
            }
            catch (Exception e)
            {
                throw new ConsultarEmpleadoBDException("Error consultando empleado por cedula en la Base de datos", e);
            }

            return _empleado;
        }

        public IList<Empleado> ConsultarPorTipoCargo(Empleado emp)
        {
            List<Empleado> empleado = new List<Empleado>();

            try
            {

                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@cargo", SqlDbType.Int);

                arParms[0].Value = emp.CargoEmpleado.Id;

                DbDataReader reader = SqlHelper.ExecuteReader
                    (_conexion.GetConnection(), "ConsultarEmpleadoCargo", arParms);

                while (reader.Read())
                {

                    Empleado _empleado = new Empleado();

                    Direccion _direccion = new Direccion();

                    _empleado.Id = (int)reader["IdEmpleado"];

                    _empleado.Cedula = (int)reader["CIEmpleado"];

                    _empleado.Nombre = (string)reader["Nombre"];

                    _empleado.Apellido = (string)reader["Apellido"];

                    _empleado.Cuenta = (string)reader["NumCuenta"];

                    _empleado.FechaNacimiento = (DateTime)reader["FechaNac"];

                    _empleado.Estado = (int)reader["Estado"];

                    _empleado.Cargo = (string)reader["Expr1"];

                    _direccion.Avenida = (string)reader["Avenida"];

                    _direccion.Calle = (string)reader["Calle"];

                    _direccion.Ciudad = (string)reader["Ciudad"];

                    _direccion.Edif_Casa = (string)reader["EdifCasa"];

                    _direccion.Piso_apto = (string)reader["PisoApto"];

                    _direccion.Urbanizacion = (string)reader["Urbanizacion"];

                    _empleado.Direccion = _direccion;

                    empleado.Add(_empleado);
                }
            }
            catch (SqlException e)
            {
                throw new ConsultarEmpleadoBDException("Error SQL consultando en la Base de datos", e);
            }
            catch (Exception e)
            {
                throw new ConsultarEmpleadoBDException("Error consultando en la Base de datos", e);
            }

            return empleado;
        }

        public void ModificarDireccion(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            try
            {
                // Parametros 
                SqlParameter[] arParms = new SqlParameter[7];
                arParms[0] = new SqlParameter("@cedula", SqlDbType.Int);
                arParms[0].Value = empleado.Cedula;
                arParms[1] = new SqlParameter("@avenida", SqlDbType.VarChar);
                arParms[1].Value = empleado.Direccion.Avenida;
                arParms[2] = new SqlParameter("@calle", SqlDbType.VarChar);
                arParms[2].Value = empleado.Direccion.Calle;
                arParms[3] = new SqlParameter("@ciudad", SqlDbType.VarChar);
                arParms[3].Value = empleado.Direccion.Ciudad;
                arParms[4] = new SqlParameter("@edif", SqlDbType.VarChar);
                arParms[4].Value = empleado.Direccion.Edif_Casa;
                arParms[5] = new SqlParameter("@piso", SqlDbType.VarChar);
                arParms[5].Value = empleado.Direccion.Piso_apto;
                arParms[6] = new SqlParameter("@urbanizacion", SqlDbType.VarChar);
                arParms[6].Value = empleado.Direccion.Urbanizacion;
                SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "ModificarDireccion", arParms);
            }
            catch (SqlException e)
            {
                throw new Exception(e.ToString());
            }
        }

        public IList<Persona> ConsultarNombreApellido()
        {
            List<Persona> Empleados = new List<Persona>();

            try
            {

                DbDataReader conex = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultENC");

                while (conex.Read())
                {
                    Persona _persona = new Persona();

                    _persona.Nombre = (string)conex["Nombre"];

                    _persona.Apellido = (string)conex["Apellido"];

                    //_empleado.Cargo = (string)conex["Expr1"];

                    Empleados.Add(_persona);
                }

            }
            catch (SqlException e)
            {
                throw new ConsultarEmpleadoBDException("Error SQL consultando en la Base de datos", e);
            }
            catch (Exception e)
            {
                throw new ConsultarEmpleadoBDException("Error consultando en la Base de datos", e);
            }

            return Empleados;
        }

        public int EliminarEmpleado(Empleado emp)
        {
            int result = 0;

            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@id", SqlDbType.VarChar);
                arParms[0].Value = emp.Id;
                result = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "EliminarEmpleado", arParms);
            }
            catch (SqlException e)
            {
                throw new Core.LogicaNegocio.Excepciones.EliminarException("Error SQL al eliminar el cargo", e);
                //System.Console.Write(e);
            }
            catch (Exception e)
            {
                throw new Core.LogicaNegocio.Excepciones.EliminarException("Error al eliminar el cargo", e);
            }
            return result;
        }

        /*public Empleado ConsultarCargoNuevo(Cargo entidad)
        {
            Empleado _empleado = new Empleado();

            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@NombreCargo", SqlDbType.VarChar);
                arParms[0] = entidad.Nombre;

                DbDataReader reader = SqlHelper.ExecuteNonQuery
                    (_conexion.GetConnection(), "ConsultarCargoNuevo", arParms);

               if(reader.Read())
                {
                    _empleado.Cargo = (string)reader["Idcargo"];
                                
                }

               return _empleado;

            }
            catch (SqlException e)
            {
                throw new Exception(e.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }*/


        public Empleado ConsultarPorCodigo(Empleado emp)
        {
            Empleado _empleado = new Empleado();

            //_empleado.SueldoBase = float.Parse(reader["SueldoBase"].ToString());// (float)reader["SueldoBase"];


            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@Id", SqlDbType.Int);

                arParms[0].Value = emp.Id;

                DbDataReader reader = SqlHelper.ExecuteReader
                    (_conexion.GetConnection(), "ConsultarEmpleadoCodigo", arParms);

                if (reader.Read())
                {

                    Direccion _direccion = new Direccion();

                    EstadoEmpleado _estadoEmpleado = new EstadoEmpleado();

                    Cargo _cargo = new Cargo();

                    _empleado.Cedula = (int)reader["CIEmpleado"];

                    _empleado.Nombre = (string)reader["Nombre"];

                    _empleado.Apellido = (string)reader["Apellido"];

                    _empleado.Cuenta = (string)reader["NumCuenta"];

                    _empleado.FechaNacimiento = (DateTime)reader["FechaNac"];

                    _empleado.SueldoBase = float.Parse(reader["SueldoBase"].ToString());
                    //(float)reader["SueldoBase"];


                    _estadoEmpleado.Nombre = (string)reader["EstadoEmpleado"];

                    _cargo.Nombre = (string)reader["Expr1"];

                    _direccion.Avenida = (string)reader["Avenida"];

                    _direccion.Calle = (string)reader["Calle"];

                    _direccion.Ciudad = (string)reader["Ciudad"];

                    _direccion.Edif_Casa = (string)reader["EdifCasa"];

                    _direccion.Piso_apto = (string)reader["PisoApto"];

                    _direccion.Urbanizacion = (string)reader["Urbanizacion"];

                    _empleado.Direccion = _direccion;

                    _empleado.EstadoEmpleado = _estadoEmpleado;

                    _empleado.CargoEmpleado = _cargo;

                }
            }
            catch (SqlException e)
            {
                throw new ConsultarEmpleadoBDException("Error SQL consultando en la Base de datos", e);
            }
            catch (Exception e)
            {
                throw new ConsultarEmpleadoBDException("Error consultando en la Base de datos", e);
            }

            return _empleado;
        }

        public int ConsultarCedula(int _cedula)
        {
            int valor = 0;

            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@ced", SqlDbType.Int);

                arParms[0].Value = _cedula;

                DbDataReader reader = SqlHelper.ExecuteReader
                    (_conexion.GetConnection(), "ConsultarCedula", arParms);

                if (reader.Read())
                {

                    valor = (int)reader["contador"];
                }
            }
            catch (SqlException e)
            {
                throw new ConsultarEmpleadoBDException("Error  de SQl consultando empleado por cedula en la Base de datos", e);
            }
            catch (Exception e)
            {
                throw new ConsultarEmpleadoBDException("Error consultando empleado por cedula en la Base de datos", e);
            }

            return valor;

        }


        public Empleado EliminarConsultarPorTipoCedula(Empleado emp)
        {
            SqlParameter[] arParms = new SqlParameter[1];

            Empleado _empleado = new Empleado();

            arParms[0] = new SqlParameter("@ced", SqlDbType.Int);
            arParms[0].Value = emp.Cedula;

            DbDataReader reader = SqlHelper.ExecuteReader
                (_conexion.GetConnection(), "EliminarConsultarEmpleadoCI", arParms);

            if (reader.Read())
            {

                Direccion _direccion = new Direccion();

                _empleado.Id = (int)reader["IdEmpleado"];

                _empleado.Cedula = (int)reader["CIEmpleado"];

                _empleado.Nombre = (string)reader["Nombre"];

                _empleado.Apellido = (string)reader["Apellido"];

                _empleado.Cuenta = (string)reader["NumCuenta"];

                _empleado.FechaNacimiento = (DateTime)reader["FechaNac"];

                _empleado.Estado = (int)reader["Estado"];

                _empleado.Cargo = (string)reader["Expr1"];

                _direccion.Avenida = (string)reader["Avenida"];

                _direccion.Calle = (string)reader["Calle"];

                _direccion.Ciudad = (string)reader["Ciudad"];

                _direccion.Edif_Casa = (string)reader["EdifCasa"];

                _direccion.Piso_apto = (string)reader["PisoApto"];

                _direccion.Urbanizacion = (string)reader["Urbanizacion"];

                _empleado.Direccion = _direccion;

            }

            return _empleado;
        }


        public List<Empleado> EliminarConsultarPorTipoNombre(Empleado emp)
        {
            List<Empleado> empleado = new List<Empleado>();

            SqlParameter[] arParms = new SqlParameter[1];



            arParms[0] = new SqlParameter("@nombre", SqlDbType.VarChar);
            arParms[0].Value = emp.Nombre;

            DbDataReader reader = SqlHelper.ExecuteReader
                (_conexion.GetConnection(), "ELiminarConsultarPorNombre", arParms);
            int i = 0;

            while (reader.Read())
            {
                Empleado _empleado = new Empleado();

                Direccion _direccion = new Direccion();

                _empleado.Id = (int)reader["IdEmpleado"];

                _empleado.Cedula = (int)reader["CIEmpleado"];

                _empleado.Nombre = (string)reader["Nombre"];

                _empleado.Apellido = (string)reader["Apellido"];

                _empleado.Cuenta = (string)reader["NumCuenta"];

                _empleado.FechaNacimiento = (DateTime)reader["FechaNac"];

                _empleado.Estado = (int)reader["Estado"];

                _empleado.Cargo = (string)reader["Expr1"];

                _direccion.Avenida = (string)reader["Avenida"];

                _direccion.Calle = (string)reader["Calle"];

                _direccion.Ciudad = (string)reader["Ciudad"];

                _direccion.Edif_Casa = (string)reader["EdifCasa"];

                _direccion.Piso_apto = (string)reader["PisoApto"];

                _direccion.Urbanizacion = (string)reader["Urbanizacion"];

                _empleado.Direccion = _direccion;

                empleado.Insert(i, _empleado);
                //empleado.Add(_empleado);
                i++;
            }
            return empleado;
        }

        public IList<Empleado> EliminarConsultarPorTipoCargo(Empleado emp)
        {
            List<Empleado> empleado = new List<Empleado>();



            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@cargo", SqlDbType.Int);

            arParms[0].Value = emp.CargoEmpleado;

            DbDataReader reader = SqlHelper.ExecuteReader
                (_conexion.GetConnection(), "EliminarConsultarEmpleadoCargo", arParms);

            while (reader.Read())
            {

                Empleado _empleado = new Empleado();

                Direccion _direccion = new Direccion();

                _empleado.Id = (int)reader["IdEmpleado"];

                _empleado.Cedula = (int)reader["CIEmpleado"];

                _empleado.Nombre = (string)reader["Nombre"];

                _empleado.Apellido = (string)reader["Apellido"];

                _empleado.Cuenta = (string)reader["NumCuenta"];

                _empleado.FechaNacimiento = (DateTime)reader["FechaNac"];

                _empleado.Estado = (int)reader["Estado"];

                _empleado.Cargo = (string)reader["Expr1"];

                _direccion.Avenida = (string)reader["Avenida"];

                _direccion.Calle = (string)reader["Calle"];

                _direccion.Ciudad = (string)reader["Ciudad"];

                _direccion.Edif_Casa = (string)reader["EdifCasa"];

                _direccion.Piso_apto = (string)reader["PisoApto"];

                _direccion.Urbanizacion = (string)reader["Urbanizacion"];

                _empleado.Direccion = _direccion;

                empleado.Add(_empleado);
            }
            return empleado;
        }


        /*Descripcion: Consultar los diferentes estados de los usuarios(Activos, Inactivo, etc) 
              * que existente en la tabla EstadoEmpleado
              *Consulta el Store procedure ConsultarEstado
              */

        public IList<EstadoEmpleado> ConsultarTodosEstadosEmpleado()
        {
            IList<EstadoEmpleado> estado = new List<EstadoEmpleado>();
            DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarEstado");
            while (reader.Read())
            {
                EstadoEmpleado estadoempleado = new EstadoEmpleado();
                estadoempleado.Nombre = (string)reader["Nombre"];
                estadoempleado.IdEstadoEmpleado = (int)reader["ID"];
                estado.Add(estadoempleado);
            }


            return estado;
        }


        #endregion
    }
}