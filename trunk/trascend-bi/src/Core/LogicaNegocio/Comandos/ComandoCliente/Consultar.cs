using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;
using Core.AccesoDatos.Fabricas;

namespace Core.LogicaNegocio.Comandos.ComandoCliente
{
    public class Consultar : Comando<Cliente>
    {
        private Cliente _cliente;
        private IList<Cliente> _cliente2;

        #region Constructor

           
            public Consultar()
            { }

           

            public Consultar(Cliente cliente)
            {
                _cliente = cliente;
            }
            
            public Consultar(IList<Cliente> cliente)
            {
                _cliente2 = cliente;
            }

        
        #endregion


        #region Metodos

            public IList<Cliente> ejecutar()
            {

                ////Se define el enum para saber con que fabrica concreta se va a trabajar
                //FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

                ////Se instancia la fabrica; se crea
                //IFabricaDAO iFabrica = FabricaDAO.ObtenerFabricaDAO();

                ////Se instancia los metodos definidos en interfaz DAO de cliente
                //IDAOCliente iDAOCliente = iFabrica.ConsultarNombre();

                ////DAOClienteSQLServer hereda de IDAOCliente
                //_cliente2 = iDAOCliente.ConsultarNombre();

                IDAOCliente acceso = FabricaDAO.ObtenerFabricaDAO("SQLServer").ObtenerDAOCliente();

                _cliente2 = acceso.ConsultarNombre();
                
                return _cliente2;
            }
        #endregion
    }
}