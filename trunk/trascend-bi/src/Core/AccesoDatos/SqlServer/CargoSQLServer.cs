using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using Core.LogicaNegocio.Entidades;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Configuration;
using System.Xml;

namespace Core.AccesoDatos.SqlServer
{
    public class CargoSQLServer
    {

        #region Constructor
        public CargoSQLServer()
        {
        }
        #endregion

        #region Conexion
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

        /// <summary>
        /// Metodo para ingresar un cargo
        /// </summary>
        /// <param name="cargo">cargo que se va a ingresar</param>
        /// <returns></returns>
        public Boolean IngresarCargo(Cargo cargo)
        {
            //   Cargo _cargo = new Cargo();
            try
            {
                SqlParameter[] arParms = new SqlParameter[5];
                //Parametros
                arParms[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                arParms[0].Value = cargo.Nombre;
                arParms[1] = new SqlParameter("@Descripcion", SqlDbType.VarChar);
                arParms[1].Value = cargo.Descripcion;
                arParms[2] = new SqlParameter("@SueldoMinimo", SqlDbType.Float);
                arParms[2].Value = cargo.SueldoMinimo;
                arParms[3] = new SqlParameter("@SueldoMaximo", SqlDbType.Float);
                arParms[3].Value = cargo.SueldoMaximo;
                arParms[4] = new SqlParameter("@VigenciaAnual", SqlDbType.SmallDateTime);
                arParms[4].Value = cargo.Vigencia.ToString();
                int result = SqlHelper.ExecuteNonQuery(GetConnection(), "IngresarCargo", arParms);
            }
            catch (SqlException e)
            {
                return false;
                //System.Console.Write(e);
            }
            return true;
        }

        /// <summary>
        /// Metodo para consultar un cargo por su nombre
        /// </summary>
        /// <param name="cargo">Criterio de la busqueda</param>
        /// <returns>La informacion del cargo asociado al criterio</returns>
        public Entidad ConsultarCargo(Cargo cargo)
        {
            Cargo _cargo = new Cargo();

            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@NombreCargo", SqlDbType.VarChar);
                arParms[0].Value = cargo.Nombre;

                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(),
                                                "ConsultarCargo", arParms);

                if (reader.Read())
                {
                    _cargo.Id = int.Parse(reader["IdCargo"].ToString());
                    _cargo.Nombre = reader["Nombre"].ToString();
                    _cargo.Descripcion = reader["Descripcion"].ToString();
                    _cargo.SueldoMinimo = float.Parse(reader["SueldoMinimo"].ToString());
                    _cargo.SueldoMaximo = float.Parse(reader["SueldoMaximo"].ToString());
                    _cargo.Vigencia = DateTime.Parse(reader["VigenciaAnual"].ToString());
                }

                return _cargo;
            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            return _cargo;

        }

        /// <summary>
        /// Metodo para consultar todos los cargos del sistema
        /// </summary>
        /// <returns>Una IList de entidades que contienen todos los cargos</returns>
        public IList<Entidad> ConsultarCargos()
        {
            try
            {
                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(), "ConsultarCargos");
                Cargo cargo;
                IList<Entidad> listaCargos = null;

                while (reader.Read())
                {
                    cargo = new Cargo();
                    cargo.Id = (int)reader["IdCargo"];
                    cargo.Nombre = reader["Nombre"].ToString();
                    cargo.Descripcion = reader["Descripcion"].ToString();
                    cargo.SueldoMaximo = (float)reader["SueldoMaximo"];
                    cargo.SueldoMinimo = (float)reader["SueldoMinimo"];

                    listaCargos.Add(cargo);
                }
                return listaCargos;
            }
            catch (SqlException e)
            {
                return null;
            }
        
        }

        public Boolean EliminarCargo(Cargo cargo)
        {
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];
                //Parametros
                arParms[0] = new SqlParameter("@IdCargo", SqlDbType.VarChar);
                arParms[0].Value = cargo.Id;

                int result = SqlHelper.ExecuteNonQuery(GetConnection(), "EliminarCargo", arParms);
            }
            catch (SqlException e)
            {
                return false;
                //System.Console.Write(e);
            }
            return true;

        }

        public Boolean ModificarCargo(Cargo cargo)
        {
            return true;
        }


        #endregion
    
    }   
}
