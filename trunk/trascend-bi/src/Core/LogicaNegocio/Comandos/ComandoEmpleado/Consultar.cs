﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoEmpleado
{
    public class Consultar : Comando<Empleado>
    {
        private Empleado empleado;
        private IList<Empleado> _empleado2;

        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public Consultar()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
        public Consultar(IList<Empleado> empleado)
        {
            _empleado2 = empleado;
        }

        #endregion

        #region Metodos
        public IList<Empleado> Ejecutar()
        {
            EmpleadoSQLServer acceso = new EmpleadoSQLServer();
            _empleado2 = acceso.ConsultarPorTipoNombre();

            return _empleado2;
        }
        #endregion
    }
}
