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
    public class ConsultarEmpleadoConUsuario : Comando<Core.LogicaNegocio.Entidades.Usuario>
    {
        #region Propiedades

        private Core.LogicaNegocio.Entidades.Empleado empleado;

        #endregion

        #region Constructor

        /// <summary>Constructor de la clase 'ConsultarEmpleadoConUsuario'.</summary>

        public ConsultarEmpleadoConUsuario()
        { }

        public ConsultarEmpleadoConUsuario(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            this.empleado = empleado;
        }

        #endregion

        #region Metodos

        /// <summary>Método que implementa la ejecución del comando 'ConsultarEmpleadoConUsuario'.</summary>

        public IList<Core.LogicaNegocio.Entidades.Empleado> Ejecutar()
        {

            //UsuarioSQLServer bd = new UsuarioSQLServer();

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOUsuario iDAOUsuario = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOUsuario();

            IList<Empleado> _empleado = iDAOUsuario.ConsultarEmpleadoConUsuario(empleado);

          //  IList<Core.LogicaNegocio.Entidades.Empleado> _empleado = bd.ConsultarEmpleadoConUsuario(empleado);

            return _empleado;
        }

        #endregion
    }
}