using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoCliente
{
    public class ConsultarParametroNombre : Comando<Cliente>
    {
        private Cliente _cliente;
        private IList<Cliente> _cliente2;

        #region Constructor

           
            public ConsultarParametroNombre()
            { }

           

            public ConsultarParametroNombre(Cliente cliente)
            {
                _cliente = cliente;
            }
            
            public ConsultarParametroNombre(IList<Cliente> cliente)
            {
                _cliente2 = cliente;
            }

        
        #endregion


        #region Metodos

           public IList<Cliente> ejecutar(Cliente entidad)
        {
            Core.AccesoDatos.SqlServer.DAOClienteSQLServer acceso = 
                new Core.AccesoDatos.SqlServer.DAOClienteSQLServer();

            _cliente2 = acceso.ConsultarParamtroNombre(entidad);

            return _cliente2;


        }
        #endregion
    }
}