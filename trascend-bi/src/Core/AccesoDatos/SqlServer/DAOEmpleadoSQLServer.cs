using System;
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
using Core.LogicaNegocio.Excepciones.Propuesta.AccesoDatos;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos.Fabricas;


namespace Core.AccesoDatos.SqlServer
{
    public class DAOEmpleadoSQLServer: IDAOEmpleado
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
                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(), "InsertarEmpleado", arParms);
                if (reader.Read())
                {
                    InsertarDireccion(empleado, Int32.Parse(reader[0].ToString()));
                }
            }
            catch (SqlException e)
            {
                throw new IngresarException("Error ingresando en la base de datos",e);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            return _empleado;

        }
        public void InsertarDireccion (Core.LogicaNegocio.Entidades.Empleado empleado,int id)
        {
            try
            {
                 SqlParameter[] arParms = new SqlParameter[7];
                // Parametros 
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
                SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "InsertarDireccionEmpleado", arParms);
            }
            catch(SqlException e)
            {
                throw new Exception(e.ToString());
            }
        }
        public IList<Empleado> Consultar()
        {
            IList<Empleado> empleado = null;
            DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarEmpleados");
            while (reader.Read())
            {
                Empleado _empleado = new Empleado();
                _empleado.Nombre = (string)reader["nombre"];
                empleado.Add(_empleado);
            }
            return empleado;
        }

        public Core.LogicaNegocio.Entidades.Empleado ConsultarId(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];
                Direccion dir = new Direccion();
                // Parametros 
                arParms[0] = new SqlParameter("@id", SqlDbType.Int);
                arParms[0].Value = empleado.Id;
                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarNomEmpleadoCedula", arParms);
                if(reader.Read())
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
                arParms = new SqlParameter[1];
                arParms[0] = new SqlParameter("@idEmpleado", SqlDbType.Int);
                arParms[0].Value = empleado.Id;
                reader = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarDireccionEmpleado", arParms);
                if(reader.Read())
                {
                    dir.Avenida = (string)reader["Avenida"];
                    dir.Calle = (string)reader["Calle"];
                    dir.Ciudad = (string)reader["Ciudad"];
                    dir.Edif_Casa = (string)reader["EdifCasa"];
                    dir.Piso_apto = (string)reader["PisoApto"];
                    dir.Urbanizacion = (string)reader["Urbanizacion"];
                }
                empleado.Direccion = dir;
            }
            catch(SqlException e)
            {
                throw new Exception(e.ToString());
            }
            return empleado;
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
                arParms[5] = new SqlParameter("@estado", SqlDbType.VarChar);
                arParms[5].Value = empleado.Estado;
                arParms[6] = new SqlParameter("@sueldo", SqlDbType.VarChar);
                arParms[6].Value = empleado.Estado;
                arParms[7] = new SqlParameter("@cargo", SqlDbType.Int);
                arParms[7].Value = empleado.Cargo;
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

        public IList<Empleado> ConsultarPorTipoNombre(Empleado emp)
        {
            List<Empleado> empleado = new List<Empleado>();
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@nombre", SqlDbType.VarChar);
            arParms[0].Value = "%" + emp.Nombre + "%";

            DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarEmpleadoNombre", arParms);
            while (reader.Read())
            {
                Empleado _empleado = new Empleado();
                Direccion _direccion = new Direccion();
                //_empleado.Id = (int)reader["IdEmpleado"];
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

        public IList<string> ConsultarCargos()
        {
            List<string> cargo = new List<string>();
            DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarCargos2");
            while (reader.Read())
            {
                cargo.Add((string)reader["Nombre"]);
            }
            return cargo;
        }

        public Empleado ConsultarPorTipoCedula(Empleado emp)
        {
            SqlParameter[] arParms = new SqlParameter[1];
            Empleado _empleado = new Empleado();

            arParms[0] = new SqlParameter("@ced", SqlDbType.Int);
            arParms[0].Value = emp.Cedula;

            DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarEmpleadoCI", arParms);
            if (reader.Read())
            {
                Direccion _direccion = new Direccion();
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

        public IList<Empleado> ConsultarPorTipoCargo(Empleado emp)
        {
            List<Empleado> empleado = new List<Empleado>();
            SqlParameter[] arParms = new SqlParameter[1];

            arParms[0] = new SqlParameter("@cargo", SqlDbType.VarChar);
            arParms[0].Value = "%" + emp.Cargo + "%";

            DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarEmpleadoCargo", arParms);
            while (reader.Read())
            {
                Empleado _empleado = new Empleado();
                Direccion _direccion = new Direccion();
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
            catch(SqlException e)
            {
                throw new Exception (e.ToString());
            }
        }
        public IList<Persona> ConsultarNombreApellido()
        {
            List<Persona> Empleados = new List<Persona>();
            DbDataReader conex = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultENC");
            while (conex.Read())
            {
                Persona _persona = new Persona();
                
                _persona.Nombre = (string)conex["Nombre"];
                _persona.Apellido = (string)conex["Apellido"];
                //_empleado.Cargo = (string)conex["Expr1"];

                Empleados.Add(_persona);
            }
            return Empleados;
        }

        public int EliminarEmpleado(Empleado emp)
        {
            int result = 0;

            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@Cedula", SqlDbType.VarChar);
                arParms[0].Value = emp.Cedula;
                result = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "EliminarEmpleado", arParms);
            }
            catch (SqlException e)
            {
                throw new  Core.LogicaNegocio.Excepciones.EliminarException("Error SQL al eliminar el cargo", e);
                //System.Console.Write(e);
            }
            catch (Exception e)
            {
                throw new Core.LogicaNegocio.Excepciones.EliminarException("Error al eliminar el cargo", e);
            }
            return result;
        }
        #endregion
    }
}
