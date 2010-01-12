using System;
using System.Collections.Generic;
using System.Text;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos.SqlServer;

namespace Core.AccesoDatos.Fabricas
{
	
	public class FabricaDAOSQLServer
	{
		public static IDAOUsuario ObtenerDAOUsuario()
		{
			return new DAOUsuarioSQLServer();
		}

	}
}
