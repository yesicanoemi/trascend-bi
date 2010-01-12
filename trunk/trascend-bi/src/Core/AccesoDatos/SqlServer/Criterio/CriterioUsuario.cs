using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using Core.LogicaNegocio.Entidades;
using NHibernate.Criterion;

namespace Core.AccesoDatos.SqlServer.Criterio
{

    public class CriterioUsuario
    {
     

        /// <summary>
        /// Metodo estatico que forma el criterio de la consulta
        /// para 'Consultar' del DAO de 'Usuario'.
        /// </summary>
        /// <param name="entidad">Entidad usuario con los datos.</param>
        /// <param name="criterio">Criterio de busqueda.</param>
        /// <returns>Criterio con los datos para la busqueda.</returns>
        /// 
        public static ICriteria CriterioConsultarLoginPassword( Usuario entidad, ICriteria criterio )
        {
            if (entidad.Login != null && entidad.Password != null)
            {
                criterio.Add(Expression.Eq("Login", entidad.Login));
                criterio.Add(Expression.Eq("Password", entidad.Password));
            }

            return criterio;
        }
    }
}
