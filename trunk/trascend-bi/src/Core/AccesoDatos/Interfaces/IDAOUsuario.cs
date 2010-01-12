using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Core.LogicaNegocio.Entidades;

namespace Core.AccesoDatos.Interfaces
{

	public interface IDAOUsuario
	{

	    Usuario ConsultarLoginPassword(Usuario usuario);

	}
}
