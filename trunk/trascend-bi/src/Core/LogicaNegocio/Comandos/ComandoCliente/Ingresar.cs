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
    public class Ingresar : Comando<Cliente>
    {
        private Cliente _cliente;

        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public Ingresar()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
        public Ingresar(Cliente cliente)
        {
            this._cliente = cliente;
        }

        #endregion

        #region Metodos
        public Cliente Ejecutar()
        {
            _cliente2 = new Cliente();

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOCliente acceso = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOCliente();

            _cliente2 = acceso.Ingresar(_cliente);

            return _cliente2;
        }
        #endregion
    }
}
