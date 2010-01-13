using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace Core.AccesoDatos.SqlServer
{
    public class EmpleadoSQLServer
    {
        #region Propiedades
        private string connectionStr = "Data Source=MCDOHL-PC\\SQLEXPRESS;Initial Catalog=DSUProof;Integrated Security=true";
        #endregion
        #region Constructor
        public EmpleadoSQLServer()
        {
        }
        #endregion 

        private SqlConnection GetConnection(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            return connection;
        }

        #region Metodos
        public Empleado Ingresar(Empleado empleado)
        {
            Empleado _empleado = new Empleado();
            try
            {

                SqlParameter[] arParms = new SqlParameter[1];
                // @ProductID Input Parameter 
                // assign value = 1
                arParms[0] = new SqlParameter("@dina", SqlDbType.Int);
                arParms[0].Value = 1;
                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(connectionStr), "ObtenerNombre");
                if (reader.Read())
                {
                    _empleado.Cedula = (int)reader["dina"];
                }
                return _empleado;
            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            return _empleado;

        }
        #endregion
    }
}
