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


        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Consultar'.</summary>
        public Consultar()
        { }

        #endregion


        #region Metodos

        public IList<Cliente> ejecutar()
        {


            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOCliente bdcliente = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOCliente();
            IList<Cliente> clientes = new List<Cliente>();

            clientes = bdcliente.ConsultarTodos();

            return clientes;
        }
        #endregion
    }
}