﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoCliente
{
    public class Modificar : Comando<Cliente>
    {
        private Cliente cliente;

        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public Modificar()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
        public Modificar(Cliente cliente)
        {
            this.cliente = cliente;
        }

        #endregion

        #region Metodos
        public void Ejecutar()
        {
            int _resultado = 0;
            DAOClienteSQLServer bd = new DAOClienteSQLServer();
            _resultado = bd.Modificar(cliente);
        }
        #endregion
    }
}