using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.AccesoDatos;
using Core.AccesoDatos.Fabricas;
using Core.AccesoDatos.Interfaces;

namespace Core.LogicaNegocio.Comandos.ComandoEmpleado
{
    public class ConsultarCedula:Comando<Empleado>
    {
        int _cedula;
        
        int _empleado;

        public ConsultarCedula()
        { }

        public ConsultarCedula(int cedula)
        {
            _cedula = cedula;
        }

        public int Ejecutar()
        {
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOEmpleado acceso = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOEmpleado();

            _empleado = acceso.ConsultarCedula(_cedula);

            return _empleado;

        }

    }
}
