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
    public class EliminarConsultarPorCI : Comando<Empleado>
    {
        private Empleado _empleado;
        private Empleado empleado;


        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public EliminarConsultarPorCI()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
        public EliminarConsultarPorCI(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            this.empleado = empleado;
        }

        #endregion

        #region Metodos
        
        public Empleado Ejecutar()
        {
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOEmpleado acceso = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOEmpleado();

            _empleado = acceso.EliminarConsultarPorTipoCedula(empleado);

            return _empleado;                                            
        
        }
        #endregion
    }
}