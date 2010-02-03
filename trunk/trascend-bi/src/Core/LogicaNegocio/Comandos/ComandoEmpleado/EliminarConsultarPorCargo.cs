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
    public class EliminarConsultarPorCargo : Comando<Empleado>
    {
        private Empleado empleado;
        private IList<Empleado> _empleado2;

        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public EliminarConsultarPorCargo()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
        public EliminarConsultarPorCargo(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            this.empleado = empleado;
        }

        #endregion

        #region Metodos
        public IList<Empleado> Ejecutar()
        {
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOEmpleado acceso = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOEmpleado();

            _empleado2 = acceso.EliminarConsultarPorTipoCargo(empleado);

            return _empleado2;

            
        }
        #endregion
    }
}