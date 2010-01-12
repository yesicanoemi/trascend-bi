using System.Web;
using Castle.DynamicProxy;
using Castle.Core;
using Core.AccesoDatos.Interfaces;
using Core.LogicaNegocio.Entidades;
using Iesi.Collections;
using log4net;
using NHibernate.Cfg;
using NHibernate;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System;
using NHibernate.Criterion;
//using Core.LogicaNegocio.Excepciones;
using Core.AccesoDatos.SqlServer.Criterio;
using Core.LogicaNegocio;


namespace Core.AccesoDatos.SqlServer
{
	/// <summary>
	/// Clase pública 'DAOUsuarioSQLServer'.
	/// Define al objeto DAO para la entidad empresa para una
	/// Base de DAtos SQLServer.
	/// <autor>TRASCEND NC Software Evolution.</autor>
	/// </summary>
	public class DAOUsuarioSQLServer : IDAOUsuario
	{

		#region Variables

		/// <summary>Variable que guarda la sesión de NHibernate.</summary>
		ISession sessionNH;
        /// <summary>Variable que guarda la transacción. </summary>
        ITransaction transaccion;

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor por defecto de la clase 'DAOUsuarioSQLServer'.
		/// Se genera una sesión de NHibernate.
		/// </summary>
		public DAOUsuarioSQLServer()
		{
			
		}

		#endregion

        /// <summary>Método para consultar los datos de un usuario en la BD.</summary>
        /// <param name="entidad">Entidad con los datos del usuario.</param>
        /// <returns>Entidades usuario con los datos consultados.</returns>
        public Usuario ConsultarLoginPassword(Usuario entidad)
        {
            //almacena el criterio de la búsqueda.
            ICriteria consultarLoginPassword = null;

            //almacena la entidad usuario que resulta de la consulta.
            Usuario usuario1 = null;

            //lista de entidades.
            IList<Usuario> usuarios = null;

            try
            {
                //sessionNH = HttpContext.Current.Items["NHibernateSession"] as ISession;
                //se crea el criterio para la búsqueda.
                consultarLoginPassword = sessionNH.CreateCriteria(typeof(Usuario));

                //criterio = new CriterioUsuario();
                consultarLoginPassword = CriterioUsuario.CriterioConsultarLoginPassword(entidad, consultarLoginPassword);

                //se lista el resultado.
                usuarios = consultarLoginPassword.List<Usuario>();

                //entidad.
                if (usuarios.Count > 0) usuario1 = usuarios[0];
            }
            catch (HibernateException e)
            {
               // throw new ConsultarException("Error de Hibernate Consultando Datos", e);
            }

            //retorna la lista con los resultados de las entidades obtenidas.
            return usuario1;
        }

	}
}
