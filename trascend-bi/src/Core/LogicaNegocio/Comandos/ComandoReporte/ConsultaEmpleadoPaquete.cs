using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;


namespace Core.LogicaNegocio.Comandos.ComandoReporte
{
    public class ConsultaEmpleadoPaquete
    {
        private string _data;
        private string _tipo;

        #region Constructor
        public ConsultaEmpleadoPaquete(string data, string tipo)
        {
            _data = data;
            _tipo = tipo;
        }
        #endregion

        #region Metodos
        public IList<Empleado> Ejecutar()
        {
            ReporteSQLServer empleado = new ReporteSQLServer();
            
            IList<Empleado> Empleados;
            IList<Cargo> Cargos;

            if (_tipo=="Cedula")
            {
                Empleados= empleado.ConsultaEmpleadosCIEmp(_data);
    //            Cargos= empleado.ConsultaEmpleadosCICar(_data);
            }else
            {
                Empleados= empleado.ConsultaEmpleadosNombreEmp(_data);
    //            Cargos= empleado.ConsultaEmpleadosNombreCar(_data);
            }
            return Empleados;
        }
        #endregion
    }
}
