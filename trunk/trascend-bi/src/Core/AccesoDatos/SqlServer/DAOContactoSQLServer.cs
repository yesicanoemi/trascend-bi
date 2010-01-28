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
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos.Fabricas;


namespace Core.AccesoDatos.SqlServer
{
    public class DAOContactoSQLServer: IDAOContacto
    {
        #region Propiedades
        IConexion _conexion = new FabricaConexion().getConexionSQLServer();


        #endregion
        #region Constructor
        public DAOContactoSQLServer()
        {

        }
        #endregion

        /*
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
        */

        #region Metodos
        public Contacto Ingresar(Contacto contacto,int idCliente)
        {
            Contacto _contacto = new Contacto();
            try
            {
                
                
                SqlParameter[] arParms = new SqlParameter[11];
                // Parametros 
                arParms[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                arParms[0].Value = contacto.Nombre;
                arParms[1] = new SqlParameter("@Apellido", SqlDbType.VarChar);
                arParms[1].Value = contacto.Apellido;
                arParms[2] = new SqlParameter("@AreaNegocio", SqlDbType.VarChar);
                arParms[2].Value = contacto.AreaDeNegocio;
                arParms[3] = new SqlParameter("@Cargo", SqlDbType.VarChar);
                arParms[3].Value = contacto.Cargo;
                arParms[4] = new SqlParameter("@TelefonoTrabajo", SqlDbType.Int);
                arParms[4].Value = contacto.TelefonoDeTrabajo.Numero;
                arParms[5] = new SqlParameter("@TelefonoCelular", SqlDbType.Int);
                arParms[5].Value = contacto.TelefonoDeCelular.Numero;
                arParms[6] = new SqlParameter("@CodigoCel", SqlDbType.Int);
                arParms[6].Value = contacto.TelefonoDeCelular.Codigocel;
                arParms[7] = new SqlParameter("@CodigoArea", SqlDbType.Int);
                arParms[7].Value = contacto.TelefonoDeTrabajo.Codigoarea;
                arParms[8] = new SqlParameter("@Tipo", SqlDbType.VarChar);
                arParms[8].Value = contacto.TelefonoDeTrabajo.Tipo;
                arParms[9] = new SqlParameter("@IdCliente", SqlDbType.Int);
                arParms[9].Value = idCliente;
                arParms[10] = new SqlParameter("@ID", SqlDbType.Int);
                arParms[10].Value = 0;
                int result = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(),"InsertarContacto", arParms);
            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            return _contacto;

        }


    

        #region ConsultarContacto

        /// <summary>
        /// Metodo para consultar el Contacto
        /// </summary>
        /// <param name="usuario">Criterio de busqueda</param>
        /// <returns>Usuario(s) que coincidan con el criterio</returns>

        #region ConsultarContactoNombreApellido_3
        public IList<Contacto> ConsultarContactoNombreApellido(Contacto entidad)
        {
            IList<Contacto> contacto = new List<Contacto>();

            try
            {
                //Parametros de busqueda

                SqlParameter[] arParms = new SqlParameter[2];

                arParms[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);

                arParms[0].Value = "%" + entidad.Nombre + "%";

                arParms[1] = new SqlParameter("@Apellido", SqlDbType.VarChar);

                arParms[1].Value = "%" + entidad.Apellido + "%";

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                                        "ConsultarContactoNombreApellido_3", arParms);

                while (reader.Read())
                {
                    Contacto _contacto = new Contacto();

                    _contacto.Nombre = (string)reader.GetValue(0);

                    _contacto.Apellido = (string)reader.GetValue(1);

                    _contacto.AreaDeNegocio = (string)reader.GetValue(2);

                    _contacto.Cargo = (string)reader.GetValue(3);

                    _contacto.TelefonoDeTrabajo.Codigoarea = (int)reader.GetValue(4);

                    _contacto.TelefonoDeTrabajo.Numero = (int)reader.GetValue(5);

                    _contacto.TelefonoDeTrabajo.Tipo = (string)reader.GetValue(6);

                    _contacto.IdCliente = (int)reader.GetValue(7);

                    _contacto.IdContacto = (int)reader.GetValue(8);
                  
                    contacto.Add(_contacto);
                }

                return contacto;

            }

            catch (SqlException e)
            {

            }

            return contacto;

        }
        #endregion

        #region ConsultarContactoXTelefono_3
        public Contacto ConsultarContactoXTelefono(Contacto entidad)
        {
            Contacto contacto = new Contacto();

            try
            {
                //Parametros de busqueda

                SqlParameter[] arParms = new SqlParameter[2];

                arParms[0] = new SqlParameter("@CodigoArea", SqlDbType.Int);

                arParms[0].Value = entidad.TelefonoDeTrabajo.Codigoarea;

                arParms[1] = new SqlParameter("@Numero", SqlDbType.VarChar);

                arParms[1].Value = entidad.TelefonoDeTrabajo.Numero;

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                                        "ConsultarContactoXTelefono_3", arParms);

                while (reader.Read())
                {
                    Contacto _contacto = new Contacto();

                    _contacto.Nombre = (string)reader.GetValue(0);

                    _contacto.Apellido = (string)reader.GetValue(1);

                    _contacto.AreaDeNegocio = (string)reader.GetValue(2);

                    _contacto.Cargo = (string)reader.GetValue(3);

                    _contacto.TelefonoDeTrabajo.Codigoarea = (int)reader.GetValue(4);

                    _contacto.TelefonoDeTrabajo.Numero = (int)reader.GetValue(5);

                    _contacto.TelefonoDeTrabajo.Tipo = (string)reader.GetValue(6);

                    _contacto.IdCliente = (int)reader.GetValue(7);

                    _contacto.IdContacto = (int)reader.GetValue(8);

                    contacto = _contacto;
                }

                return contacto;

            }

            catch (SqlException e)
            {

            }

            return contacto;

        }
        #endregion

        #region ConsultarContactoXCliente_3
        public IList<Contacto> ConsultarContactoXCliente(Contacto entidad)
        {
            IList<Contacto> contacto = new List<Contacto>();

            try
            {
                //Parametros de busqueda

                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@NombreCliente", SqlDbType.Int);

                arParms[0].Value = entidad.IdCliente;

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                                        "ConsultarContactoXCliente_3", arParms);

                while (reader.Read())
                {
                    Contacto _contacto = new Contacto();

                    _contacto.Nombre = (string)reader.GetValue(0);

                    _contacto.Apellido = (string)reader.GetValue(1);

                    _contacto.AreaDeNegocio = (string)reader.GetValue(2);

                    _contacto.Cargo = (string)reader.GetValue(3);

                    _contacto.TelefonoDeTrabajo.Codigoarea = (int)reader.GetValue(4);

                    _contacto.TelefonoDeTrabajo.Numero = (int)reader.GetValue(5);

                    _contacto.TelefonoDeTrabajo.Tipo = (string)reader.GetValue(6);

                    _contacto.IdCliente = (int)reader.GetValue(7);

                    _contacto.IdContacto = (int)reader.GetValue(8);

                    contacto.Add(_contacto);
                }

                return contacto;

            }

            catch (SqlException e)
            {

            }

            return contacto;

        }
        #endregion

        #endregion

        #region no tocar
        public void Eliminar(Contacto contacto)
        {
            Contacto _contacto = new Contacto();
            try
            {


                SqlParameter[] arParms = new SqlParameter[11];
                // Parametros 
                arParms[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                arParms[0].Value = contacto.Nombre;
                arParms[1] = new SqlParameter("@Apellido", SqlDbType.VarChar);
                arParms[1].Value = contacto.Apellido;
                arParms[2] = new SqlParameter("@AreaNegocio", SqlDbType.VarChar);
                arParms[2].Value = contacto.AreaDeNegocio;
                arParms[3] = new SqlParameter("@Cargo", SqlDbType.VarChar);
                arParms[3].Value = contacto.Cargo;
                arParms[4] = new SqlParameter("@TelefonoTrabajo", SqlDbType.Int);
                arParms[4].Value = contacto.TelefonoDeTrabajo.Numero;
                arParms[5] = new SqlParameter("@TelefonoCelular", SqlDbType.Int);
                arParms[5].Value = contacto.TelefonoDeCelular.Numero;
                arParms[6] = new SqlParameter("@CodigoCel", SqlDbType.Int);
                arParms[6].Value = contacto.TelefonoDeCelular.Codigocel;
                arParms[7] = new SqlParameter("@CodigoArea", SqlDbType.Int);
                arParms[7].Value = contacto.TelefonoDeTrabajo.Codigoarea;
                arParms[8] = new SqlParameter("@Tipo", SqlDbType.VarChar);
                arParms[8].Value = contacto.TelefonoDeTrabajo.Tipo;
                arParms[9] = new SqlParameter("@IdCliente", SqlDbType.Int);
                arParms[9].Value = 1;
                arParms[10] = new SqlParameter("@ID", SqlDbType.Int);
                arParms[10].Value = 0;
                int result = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "EliminarContacto", arParms);
            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }
        }
   

         public void Modificar(Contacto contacto1,Contacto contacto2)
        {
            int resultado = 0;
            try
            {
                SqlParameter[] arParms = new SqlParameter[19];
                // Parametros 

                arParms[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                arParms[0].Value = contacto1.Nombre;
                arParms[1] = new SqlParameter("@Apellido", SqlDbType.VarChar);
                arParms[1].Value = contacto1.Apellido;
                arParms[2] = new SqlParameter("@AreaNegocio", SqlDbType.VarChar);
                arParms[2].Value = contacto1.AreaDeNegocio;
                arParms[3] = new SqlParameter("@Cargo", SqlDbType.VarChar);
                arParms[3].Value = contacto1.Cargo;
                arParms[4] = new SqlParameter("@TelefonoTrabajo", SqlDbType.Int);
                arParms[4].Value = contacto1.TelefonoDeTrabajo.Numero;
                arParms[5] = new SqlParameter("@TelefonoCelular", SqlDbType.Int);
                arParms[5].Value = contacto1.TelefonoDeCelular.Numero;
                arParms[6] = new SqlParameter("@CodigoCel", SqlDbType.Int);
                arParms[6].Value = contacto1.TelefonoDeCelular.Codigocel;
                arParms[7] = new SqlParameter("@CodigoArea", SqlDbType.Int);
                arParms[7].Value = contacto1.TelefonoDeTrabajo.Codigoarea;
                arParms[8] = new SqlParameter("@Tipo", SqlDbType.VarChar);
                arParms[8].Value = contacto1.TelefonoDeTrabajo.Tipo;
                arParms[9] = new SqlParameter("@ID", SqlDbType.Int);
                arParms[9].Value = 0;
                arParms[10] = new SqlParameter("@NombreM", SqlDbType.VarChar);
                arParms[10].Value = contacto2.Nombre;
                arParms[11] = new SqlParameter("@ApellidoM", SqlDbType.VarChar);
                arParms[11].Value = contacto2.Apellido;
                arParms[12] = new SqlParameter("@AreaNegocioM", SqlDbType.VarChar);
                arParms[12].Value = contacto2.AreaDeNegocio;
                arParms[13] = new SqlParameter("@CargoM", SqlDbType.VarChar);
                arParms[13].Value = contacto2.Cargo;
                arParms[14] = new SqlParameter("@TelefonoTrabajoM", SqlDbType.Int);
                arParms[14].Value = contacto2.TelefonoDeTrabajo.Numero;
                arParms[15] = new SqlParameter("@TelefonoCelularM", SqlDbType.Int);
                arParms[15].Value = contacto2.TelefonoDeCelular.Numero;
                arParms[16] = new SqlParameter("@CodigoCelM", SqlDbType.Int);
                arParms[16].Value = contacto2.TelefonoDeCelular.Codigocel;
                arParms[17] = new SqlParameter("@CodigoAreaM", SqlDbType.Int);
                arParms[17].Value = contacto2.TelefonoDeTrabajo.Codigoarea;
                arParms[18] = new SqlParameter("@TipoM", SqlDbType.VarChar);
                arParms[18].Value = contacto2.TelefonoDeTrabajo.Tipo;
                resultado = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), "ModificarContacto", arParms);
                
            }
            catch (SqlException )
            {

            }
           
        }
        #endregion


        #endregion


    }
}

