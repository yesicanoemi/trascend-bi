﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;
using Core.AccesoDatos.Fabricas;

namespace Core.LogicaNegocio.Comandos.ComandoEmpleado
{
    public class ConsultarPorCodigo : Comando<Empleado>
    {
        private Empleado _empleado;
        private Empleado empleado;


        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public ConsultarPorCodigo()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
        public ConsultarPorCodigo(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            this.empleado = empleado;
        }

        #endregion

        #region Metodos
        
        public Empleado Ejecutar()
        {
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOEmpleado acceso = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOEmpleado();                        
            
            _empleado = acceso.ConsultarPorCodigo(empleado);

            return _empleado;                                            
        
        }
        #endregion
    }
}