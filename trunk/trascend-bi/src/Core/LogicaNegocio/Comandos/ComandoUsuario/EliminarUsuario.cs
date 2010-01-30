﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.AccesoDatos.Fabricas;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;


namespace Core.LogicaNegocio.Comandos.ComandoUsuario
{
    public class EliminarUsuario : Comando<Core.LogicaNegocio.Entidades.Usuario>
    {
        private Core.LogicaNegocio.Entidades.Usuario usuario;

        #region Constructor

        /// <summary>Constructor de la clase 'EliminarUsuario'.</summary>

        public EliminarUsuario()
        { }

        public EliminarUsuario(Core.LogicaNegocio.Entidades.Usuario usuario)
        {
            this.usuario = usuario;
        }

        #endregion

        #region Metodos

        /// <summary>Método que implementa la ejecución del comando 'EliminarUsuario'.</summary>

        public Usuario Ejecutar()
        {
            Usuario _usuario;

//            UsuarioSQLServer bd = new UsuarioSQLServer();

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOUsuario iDAOUsuario = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOUsuario();

            _usuario = iDAOUsuario.EliminarUsuario(usuario);

            return _usuario;
        }

        #endregion
    }
}