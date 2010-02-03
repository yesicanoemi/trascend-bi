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
    public class Eliminar : Comando<Cliente>
    {
        private Cliente _cliente;

        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Eliminar'.</summary>
        public Eliminar()
        { }

        /// <summary>Constructor de la clase 'Eliminar'.</summary>
        /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
        public Eliminar(Cliente cliente)
        {
            this._cliente = cliente;
        }

        #endregion

        #region Metodos
        public Cliente Ejecutar()
        {
            Cliente cliente = new Cliente();
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOCliente acceso = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOCliente();

            cliente = acceso.EliminarCliente(_cliente);

            return cliente;
        }
        #endregion
    }
}
