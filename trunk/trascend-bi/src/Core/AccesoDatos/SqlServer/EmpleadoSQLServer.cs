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
    public class EmpleadoSQLServer
    {
        #region Propiedades

        #endregion
        #region Constructor
        public EmpleadoSQLServer()
        {
        }
        #endregion 
        #region Conexion a Base de Datos
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
        #endregion
        #region Metodos
        public Empleado Ingresar(Empleado empleado)
        {
            Empleado _empleado = new Empleado();
            try
            {

                SqlParameter[] arParms = new SqlParameter[6];
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
                arParms[5] = new SqlParameter("@estado", SqlDbType.VarChar);
                arParms[5].Value = empleado.Estado;
                int result = SqlHelper.ExecuteNonQuery(GetConnection(), "InsertarEmpleado", arParms);
            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            return _empleado;

        }
        public int Modificar(Empleado empleado)
        {
            int resultado = 0;
            try
            {
                return resultado;
            }
            catch (SqlException e)
            {
            }
            return resultado;
        }
        #endregion
    }
}
