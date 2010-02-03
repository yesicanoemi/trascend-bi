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
    public class ELiminarConsultarPorNombre : Comando<Empleado>
    {
        private Empleado _empleado;

        private List<Empleado> _empleado2;

        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public ELiminarConsultarPorNombre()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
        public ELiminarConsultarPorNombre(Core.LogicaNegocio.Entidades.Empleado empleado)
        {
            _empleado = empleado;
        }

        #endregion

        #region Metodos
        public List<Empleado> Ejecutar()
        {
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOEmpleado acceso = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOEmpleado();

            _empleado2 = acceso.EliminarConsultarPorTipoNombre(_empleado);

            return _empleado2;
        }
        #endregion
    }
}
