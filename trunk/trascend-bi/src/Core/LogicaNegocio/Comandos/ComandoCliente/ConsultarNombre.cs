using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;

namespace Core.LogicaNegocio.Comandos.ComandoCliente
{
    class ConsultarNombre:Consultar
    {
        #region variables

        private Cliente _cliente;
        private IList<Cliente> _cliente2;
        
        #endregion
        #region constructor

        public ConsultarNombre(Cliente cliente)
        {
            _cliente = cliente;
        }

                
        #endregion
        #region metodo
        
        public IList<Cliente> ejecutar()
        {
            Core.AccesoDatos.SqlServer.DAOClienteSQLServer acceso = new Core.AccesoDatos.SqlServer.DAOClienteSQLServer();

            _cliente2 = acceso.ConsultarNombre(_cliente);
            return _cliente2;


        }
        #endregion

    }
}
