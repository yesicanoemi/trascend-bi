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
        private Cliente cliente;

        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public Consultar()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
        public Consultar(Cliente cliente)
        {
            this.cliente = cliente;
        }

        #endregion


        #region Metodos

        /// <summary>Método que implementa la ejecución del comando 'CosultarClientes'.</summary>
        /*
                public Cliente Ejecutar()
                {
                    Cliente _cliente;

                     UsuarioSQLServer bd = new UsuarioSQLServer();

                    _cliente = bd.ConsultarCliente(cliente);

                    return _cliente; 

                }
                */

        #endregion
    }
}