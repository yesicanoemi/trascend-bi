using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoEmpleado
{
    public class ConsultarCargo : Comando<Empleado>
    {
        private IList<string> _cargo;

        #region Constructor

        /// <summary>Constructor por defecto de la clase 'Ingresar'.</summary>
        public ConsultarCargo()
        { }

        /// <summary>Constructor de la clase 'Ingresar'.</summary>
        /// <param name="urbanizador">Entidad sobre la cual se aplicará el comando.</param>
        public ConsultarCargo(IList<string> cargo)
        {
            _cargo = cargo;
        }

        #endregion

        #region Metodos
        public IList<string> Ejecutar()
        {
            DAOEmpleadoSQLServer acceso = new DAOEmpleadoSQLServer();
            _cargo = acceso.ConsultarCargos();

            return _cargo;
        }
        #endregion
    }
}