using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoCliente
{
    public class Ingresar : Comando<Cliente>
    {
        private Cliente cliente;

        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public Ingresar()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
        public Ingresar(Cliente cliente)
        {
            this.cliente = cliente;
        }

        #endregion

        #region Metodos
        public Cliente Ejecutar()
        {
            Cliente _cliente = null;
            DAOClienteSQLServer bd = new DAOClienteSQLServer();
            _cliente = bd.Ingresar(cliente);

            return _cliente;
        }
        #endregion
    }
}
