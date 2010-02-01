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

        #region Métodos



        #region Ingresar

        /// <summary>
        /// Metodo para insertar un Contacto
        /// </summary>
        /// <param name="usuario">Objeto Contacto</param>
        /// <returns></returns>

        public Contacto Ingresar(Contacto contacto)
        {
            Contacto _contacto = new Contacto();
            try
            {
                
                
                SqlParameter[] arParms = new SqlParameter[10];
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
                
                arParms[8] = new SqlParameter("@IdCliente", SqlDbType.Int);
                arParms[8].Value = contacto.ClienteContac.IdCliente;
                arParms[9] = new SqlParameter("@ID", SqlDbType.Int);
                arParms[9].Value = 0;
                int result = SqlHelper.ExecuteNonQuery(_conexion.GetConnection(),"InsertarContacto", arParms);
            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            return _contacto;

        }


        /// <summary>
        /// Metodo para consultar un Cliente
        /// </summary>
        /// <param name="usuario">Objeto Cliente</param>
        /// <returns></returns>




        #endregion 

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

                    _contacto.ClienteContac = new Cliente();

                    _contacto.Nombre = (string)reader.GetValue(0);

                    _contacto.Apellido = (string)reader.GetValue(1);

                    _contacto.AreaDeNegocio = (string)reader.GetValue(2);

                    _contacto.Cargo = (string)reader.GetValue(3);

                    _contacto.TelefonoDeTrabajo.Codigoarea = (int)reader.GetValue(4);

                    _contacto.TelefonoDeTrabajo.Numero = (int)reader.GetValue(5);

                    _contacto.TelefonoDeTrabajo.Tipo = (string)reader.GetValue(6);

                    _contacto.ClienteContac.Nombre = (string)reader.GetValue(7);

                    _contacto.IdContacto = (int)reader.GetValue(8);

                    _contacto.ClienteContac.IdCliente = (int)reader.GetValue(9);
                  
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

                    _contacto.ClienteContac = new Cliente();

                    _contacto.Nombre = (string)reader.GetValue(0);

                    _contacto.Apellido = (string)reader.GetValue(1);

                    _contacto.AreaDeNegocio = (string)reader.GetValue(2);

                    _contacto.Cargo = (string)reader.GetValue(3);

                    _contacto.TelefonoDeTrabajo.Codigoarea = (int)reader.GetValue(4);

                    _contacto.TelefonoDeTrabajo.Numero = (int)reader.GetValue(5);

                    _contacto.TelefonoDeTrabajo.Tipo = (string)reader.GetValue(6);

                    _contacto.ClienteContac.Nombre = (string)reader.GetValue(7);

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

                arParms[0] = new SqlParameter("@IdCliente", SqlDbType.Int);

                arParms[0].Value = entidad.ClienteContac.IdCliente;

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                                        "ConsultarContactoXCliente_3", arParms);

                while (reader.Read())
                {
                    Contacto _contacto = new Contacto();

                    _contacto.ClienteContac = new Cliente();

                    _contacto.Nombre = (string)reader.GetValue(0);

                    _contacto.Apellido = (string)reader.GetValue(1);

                    _contacto.AreaDeNegocio = (string)reader.GetValue(2);

                    _contacto.Cargo = (string)reader.GetValue(3);

                    _contacto.TelefonoDeTrabajo.Codigoarea = (int)reader.GetValue(4);

                    _contacto.TelefonoDeTrabajo.Numero = (int)reader.GetValue(5);

                    _contacto.TelefonoDeTrabajo.Tipo = (string)reader.GetValue(6);

                    _contacto.ClienteContac.Nombre = (string)reader.GetValue(7);

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

        #region ConsultarContactoxId

        public Contacto ConsultarContactoxId(Contacto entidad)
        {
            Contacto contacto = new Contacto();

            Contacto _contacto = new Contacto();

            IList<Core.LogicaNegocio.Entidades.TelefonoTrabajo> tlf =
                                            new List<Core.LogicaNegocio.Entidades.TelefonoTrabajo>();

            try
            {
                //Parametros de busqueda

                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@IdContacto", SqlDbType.VarChar);

                arParms[0].Value = entidad.IdContacto;

                DbDataReader reader = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                                        "ConsultarTelefonoxId_3", arParms);

                while (reader.Read())
                {
                    TelefonoTrabajo _tlf = new TelefonoTrabajo ();

                    _tlf.Codigoarea = (int)reader.GetValue(0);

                    _tlf.Numero = (int)reader.GetValue(1);

                    _tlf.Tipo = (string)reader.GetValue(2);

                    tlf.Add(_tlf);

                }

                if (tlf.Count > 0)
                {
                    _contacto.TelefonoDeTrabajo.Codigoarea = tlf[0].Codigoarea;

                    _contacto.TelefonoDeTrabajo.Numero = tlf[0].Numero;

                    _contacto.TelefonoDeTrabajo.Tipo = tlf[0].Tipo;

                    if (tlf.Count > 1)
                    {
                        _contacto.TelefonoDeCelular.Codigocel = tlf[1].Codigoarea;

                        _contacto.TelefonoDeCelular.Numero = tlf[1].Numero;

                        _contacto.TelefonoDeCelular.Tipo = tlf[1].Tipo;
                    }
                }

                SqlParameter[] arParms2 = new SqlParameter[1];

                arParms2[0] = new SqlParameter("@IdContacto", SqlDbType.VarChar);

                arParms2[0].Value = entidad.IdContacto;

                DbDataReader reader2 = SqlHelper.ExecuteReader(_conexion.GetConnection(),
                                        "ConsultarContactoxId_3", arParms2);

                while (reader2.Read())
                {
                    _contacto.ClienteContac = new Cliente();

                    _contacto.Nombre = (string)reader2.GetValue(0);

                    _contacto.Apellido = (string)reader2.GetValue(1);

                    _contacto.AreaDeNegocio = (string)reader2.GetValue(2);

                    _contacto.Cargo = (string)reader2.GetValue(3);

                    _contacto.ClienteContac.Nombre = (string)reader2.GetValue(4);

                    _contacto.IdContacto = (int)reader2.GetValue(5);

                    _contacto.ClienteContac.IdCliente = (int)reader2.GetValue(6);

                }

                contacto = _contacto;
                
                return contacto;

            }

            catch (SqlException e)
            {

            }

            return contacto;

        }
        #endregion

        #endregion

        #region Eliminar

        public void Eliminar(Contacto contacto)
        {
            try
            {
                SqlParameter[] arParms = new SqlParameter[1]; 
                
                arParms[0] = new SqlParameter("@IdContacto", SqlDbType.Int);

                arParms[0].Value = contacto.IdContacto;

                SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), 
                                                        "EliminarTelefonosContacto_3", arParms);

                SqlHelper.ExecuteNonQuery(_conexion.GetConnection(), 
                                                        "EliminarContacto_3", arParms);

            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }
        }
   
        #endregion

        #region Modificar

        public void ModificarContacto(Contacto contacto)
        {
            try
            {
                SqlParameter[] arParms = new SqlParameter[6];

                arParms[0] = new SqlParameter("@IdContacto", SqlDbType.Int);

                arParms[0].Value = contacto.IdContacto;

                arParms[1] = new SqlParameter("@IdCliente", SqlDbType.Int);

                arParms[1].Value = contacto.ClienteContac.IdCliente;

                arParms[2] = new SqlParameter("@Area", SqlDbType.VarChar);

                arParms[2].Value = contacto.AreaDeNegocio;

                arParms[3] = new SqlParameter("@Cargo", SqlDbType.VarChar);

                arParms[3].Value = contacto.Cargo;

                arParms[4] = new SqlParameter("@Apellido", SqlDbType.VarChar);

                arParms[4].Value = contacto.Apellido;

                arParms[5] = new SqlParameter("@Nombre", SqlDbType.VarChar);

                arParms[5].Value = contacto.Nombre;

                //Modificar el contacto en la BD 

                SqlHelper.ExecuteNonQuery(_conexion.GetConnection(),
                                                        "ModificarContacto_3", arParms);

                //Eliminar los tlf que tiene el contacto a modificar

                SqlParameter[] arParms2 = new SqlParameter[1];

                arParms2[0] = new SqlParameter("@IdContacto", SqlDbType.Int);

                arParms2[0].Value = contacto.IdContacto;

                SqlHelper.ExecuteNonQuery(_conexion.GetConnection(),
                                                        "EliminarTelefonosContacto_3", arParms2);

                //Ingresar nuevos tlf a la BD

                SqlParameter[] arParms3 = new SqlParameter[4];

                arParms3[0] = new SqlParameter("@IdContacto", SqlDbType.Int);

                arParms3[0].Value = contacto.IdContacto;

                arParms3[1] = new SqlParameter("@Codigo", SqlDbType.Int);

                arParms3[1].Value = contacto.TelefonoDeTrabajo.Codigoarea;

                arParms3[2] = new SqlParameter("@Numero", SqlDbType.Int);

                arParms3[2].Value = contacto.TelefonoDeTrabajo.Numero;

                arParms3[3] = new SqlParameter("@Tipo", SqlDbType.Int);

                if (contacto.TelefonoDeTrabajo.Tipo == "Trabajo")
                {
                    arParms3[3].Value = 1;
                }

                if (contacto.TelefonoDeTrabajo.Tipo == "Celular")
                {
                    arParms3[3].Value = 2;
                }

                if (contacto.TelefonoDeTrabajo.Tipo == "Fax")
                {
                    arParms3[3].Value = 3;
                }
                
                //Si el contacto posee más de 1 tlf 

                if ((contacto.TelefonoDeCelular.Codigocel > 0) && (contacto.TelefonoDeCelular.Numero > 0))
                {

                    SqlParameter[] arParms4 = new SqlParameter[4];

                    arParms4[0] = new SqlParameter("@IdContacto", SqlDbType.Int);

                    arParms4[0].Value = contacto.IdContacto;

                    arParms4[1] = new SqlParameter("@Codigo", SqlDbType.Int);

                    arParms4[1].Value = contacto.TelefonoDeCelular.Codigocel;

                    arParms4[2] = new SqlParameter("@Numero", SqlDbType.Int);

                    arParms4[2].Value = contacto.TelefonoDeCelular.Numero;

                    arParms4[3] = new SqlParameter("@Tipo", SqlDbType.Int);

                    if (contacto.TelefonoDeCelular.Tipo == "Trabajo")
                    {
                        arParms4[3].Value = 1;
                    }

                    if (contacto.TelefonoDeCelular.Tipo == "Celular")
                    {
                        arParms4[3].Value = 2;
                    }

                    if (contacto.TelefonoDeCelular.Tipo == "Fax")
                    {
                        arParms4[3].Value = 3;
                    }

                    SqlHelper.ExecuteNonQuery(_conexion.GetConnection(),
                                                       "ModificarTelefonosContacto_3", arParms4);
                }

                SqlHelper.ExecuteNonQuery(_conexion.GetConnection(),
                                                        "ModificarTelefonosContacto_3", arParms3);

            }

            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            
        }
        #endregion

        #endregion
    }
}

