﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;
using Core.AccesoDatos.Fabricas;

namespace Core.LogicaNegocio.Comandos.ComandoCliente
{
    public class Modificar : Comando<Cliente>
    {
        private Cliente _cliente;

        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Modificar'.</summary>
        public Modificar()
        { }

        /// <summary>Constructor de la clase 'Modificar'.</summary>
        public Modificar(Cliente cliente)
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

            cliente = acceso.Modificar(_cliente);

            return cliente;

        }
        #endregion
    }
}
