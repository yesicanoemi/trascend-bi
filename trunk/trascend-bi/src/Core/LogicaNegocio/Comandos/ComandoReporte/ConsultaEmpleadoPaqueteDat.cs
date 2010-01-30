using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;


namespace Core.LogicaNegocio.Comandos.ComandoReporte
{
    public class ConsultaEmpleadoPaqueteDat
    {
        private string _data;
        private string _tipo;

        #region Constructor
        public ConsultaEmpleadoPaqueteDat(string data, string tipo)
        {
            _data = data;
            _tipo = tipo;
        }
        #endregion

        #region Metodos
        public IList<Cargo> Ejecutar()
        {
            ReporteSQLServer empleado = new ReporteSQLServer();
            
            IList<Empleado> Empleados;
            IList<Cargo> Cargos;

            if (_tipo=="Cedula")
            {
     //           Empleados= empleado.ConsultaEmpleadosCIEmp(_data);
                Cargos= empleado.ConsultaEmpleadosCICar(_data);
            }else
            {
      //          Empleados= empleado.ConsultaEmpleadosNombreEmp(_data);
                Cargos= empleado.ConsultaEmpleadosNombreCar(_data);
            }
            return Cargos;
        }
        #endregion
    }
}
