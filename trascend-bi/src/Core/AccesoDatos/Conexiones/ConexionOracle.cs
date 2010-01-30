using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.AccesoDatos.Interfaces;
using System.Data.SqlClient;

namespace Core.AccesoDatos.Conexiones
{
    public class ConexionOracle : IConexion
    {
        public SqlConnection GetConnection()
        {
            return null;
        }
    }
}
