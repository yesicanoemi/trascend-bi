using System;
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
    public class ConsultarCargoNuevo : Comando<Empleado>
    {
        private Cargo _cargo;

        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public ConsultarCargoNuevo()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
        public ConsultarCargoNuevo(Cargo cargo)
        {
            _cargo = cargo;
        }

        #endregion

        #region Metodos
        public Cargo Ejecutar()
        {
            Cargo cargo = null;

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOEmpleado acceso = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOEmpleado();

            //cargo = acceso.ConsultarCargoNuevo(_cargo);

            return cargo;
        }
        #endregion
    }
}

