﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoEmpleado
{
    public class ConsultarPorCI : Comando<Empleado>
    {
        private Empleado _empleado;
        private Empleado empleado;


        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public ConsultarPorCI()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
        public ConsultarPorCI(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            this.empleado = empleado;
        }

        #endregion

        #region Metodos
        public Empleado Ejecutar()
        {
            DAOEmpleadoSQLServer acceso = new DAOEmpleadoSQLServer();
            _empleado = acceso.ConsultarPorTipoCedula(empleado);

            return _empleado;
        }
        #endregion
    }
}