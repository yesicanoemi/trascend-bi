using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

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
                DAOClienteSQLServer acceso = new DAOClienteSQLServer();

                _cliente2 = acceso.ConsultarNombre();
                
                return _cliente2;
            }
        #endregion
    }
}