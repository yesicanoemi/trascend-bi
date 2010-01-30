using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos;
using Core.AccesoDatos.Interfaces;

namespace Core.LogicaNegocio.Comandos.ComandoCliente
{
    public class ConsultarNombre: Comando<Cliente>
    {
        #region variables

        private Cliente _cliente;

        
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
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;
            IList<Cliente> clientes = new List<Cliente>();
            IDAOCliente bdcliente = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOCliente();


         //   Core.AccesoDatos.SqlServer.DAOClienteSQLServer acceso = new Core.AccesoDatos.SqlServer.DAOClienteSQLServer();

            clientes = bdcliente.ConsultarNombre(_cliente);
            return clientes;


        }
        #endregion

    }
}
