using System;
using System.Collections.Generic;
using System.Text;
using Core.LogicaNegocio.Comandos.ComandoUsuario;
using Core.LogicaNegocio.Entidades;


namespace Core.LogicaNegocio.Fabricas
{

	public class FabricaComandosUsuario
	{

        /// <summary>
        /// Metodo que fabrica el comando 'ConsultarCredenciales' de la entidad usuario
        /// </summary>
        /// <param name="entidad">la entidad</param>
        /// <returns>el comando</returns>
	    public static ConsultarCredenciales CrearComandoConsultarCredenciales(Usuario entidad)
	    {
	        return new ConsultarCredenciales(entidad);
	    }

        public static ConsultarUsuario CrearComandoConsultarUsuario(Usuario entidad)
        {
            return new ConsultarUsuario(entidad);
        }
	}
}
