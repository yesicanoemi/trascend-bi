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
using Core.LogicaNegocio.Excepciones;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos.Fabricas;

namespace Core.AccesoDatos.SqlServer
{
    public class CargoSQLServer : IDAOCargo
    {

        #region Constructor

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public CargoSQLServer()
        {
        }
        #endregion

        #region Conexion

        /// <summary>
        /// Llamado a la clase de conexion
        /// </summary>
        /// <returns>devuelve la conexion</returns>
        IConexion _conexion = new FabricaConexion().getConexionSQLServer();

        #endregion
        #region Metodos

        /// <summary>
        /// Metodo para ingresar un cargo
        /// </summary>
        /// <param name="cargo">cargo que se va a ingresar</param>
        /// <returns></returns>
        public void IngresarCargo(Cargo cargo)
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
                int result = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "IngresarCargo", arParms);
            }
            catch (SqlException e)
            {
                throw new IngresarException("Error SQL al ingresar el cargo", e);
                //System.Console.Write(e);
            }
            catch (Exception e)
            {
                throw new IngresarException("Error al ingresar el cargo", e);
            }
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

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
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

            }
            catch (SqlException e)
            {
                throw new ConsultarException("Error SQL al consultar un cargo", e);
            }
            catch (Exception e)
            {
                throw new ConsultarException("Error al consultar un cargo", e);
            }
                
            return _cargo;

        }

        /// <summary>
        /// Metodo para consultar todos los cargos del sistema
        /// </summary>
        /// <returns>Una IList de entidades que contienen todos los cargos</returns>
        public IList<Entidad> ConsultarCargos()
        {
            IList<Entidad> listaCargos = new List<Entidad>();
            try
            {
                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(), "ConsultarCargos");
                Cargo cargo;

                while (reader.Read())
                {
                    cargo = new Cargo();
                    cargo.Id = (int)reader["IdCargo"];
                    cargo.Nombre = reader["Nombre"].ToString();
                    cargo.Descripcion = reader["Descripcion"].ToString();
                    cargo.SueldoMaximo = float.Parse(reader["SueldoMaximo"].ToString());
                    cargo.SueldoMinimo = float.Parse(reader["SueldoMinimo"].ToString());

                    listaCargos.Add(cargo);
                }

            }
            catch (SqlException e)
            {
                throw new ConsultarException("Error SQL al consultar la lista de los cargos", e);
            }
            catch (Exception e)
            {
                throw new ConsultarException("Error al consultar la lista de los cargos", e);
            }

            return listaCargos;
        }

        /// <summary>
        /// Metodo que elimina de la BD un cargo
        /// </summary>
        /// <param name="IdCargo">Identificador del cargo</param>
        /// <returns>True si se elimino y false si hubo error</returns>
        public void EliminarCargo(int IdCargo)
        {
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];
                //Parametros
                arParms[0] = new SqlParameter("@IdCargo", SqlDbType.VarChar);
                arParms[0].Value = IdCargo;

                int result = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "EliminarCargo", arParms);
            }
            catch (SqlException e)
            {
                throw new EliminarException("Error SQL al eliminar el cargo", e);
                //System.Console.Write(e);
            }
            catch (Exception e)
            {
                throw new EliminarException("Error al eliminar el cargo", e);
            }

        }

        /// <summary>
        /// Metodo que modifica informacion de cargo
        /// </summary>
        /// <param name="cargo">El cargo con sus modificaciones</param>
        /// <returns>True si se modifico y false si hubo error</returns>
        public void ModificarCargo(Cargo cargo)
        {
            try
            {
                SqlParameter[] arParms = new SqlParameter[6];
                //Parametros
                arParms[0] = new SqlParameter("@IdCargo", SqlDbType.Int);
                arParms[0].Value = cargo.Id;
                arParms[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                arParms[1].Value = cargo.Nombre;
                arParms[2] = new SqlParameter("@Descripcion", SqlDbType.VarChar);
                arParms[2].Value = cargo.Descripcion;
                arParms[3] = new SqlParameter("@SueldoMinimo", SqlDbType.Float);
                arParms[3].Value = cargo.SueldoMinimo;
                arParms[4] = new SqlParameter("@SueldoMaximo", SqlDbType.Float);
                arParms[4].Value = cargo.SueldoMaximo;
                arParms[5] = new SqlParameter("@VigenciaAnual", SqlDbType.SmallDateTime);
                arParms[5].Value = cargo.Vigencia;

                int result = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "ModificarCargo", arParms);
            }
            catch (SqlException e)
            {
                throw new ModificarException("Error SQL al modificar el cargo", e);
                //System.Console.Write(e);
            }
            catch (Exception e)
            {
                throw new ModificarException("Error al modificar el cargo", e);
            }
        }


        #endregion
    
    }   
}
