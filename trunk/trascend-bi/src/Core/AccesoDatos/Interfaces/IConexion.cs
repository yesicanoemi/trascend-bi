using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Core.AccesoDatos.Interfaces
{
    /// <summary>
    /// Este es el contrato que deben cumplir las conexiones a la BD
    /// </summary>
    public interface IConexion
    {
        SqlConnection GetConnection();
    }
}
