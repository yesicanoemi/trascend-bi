using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using NUnit.Framework;
using Core.LogicaNegocio.Fabricas;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;

namespace Core.Pruebas
{
    [TestFixture]
    class ReporteAnualPorPaquetesEmpleado
    {
        [Test]
        public void TestReporteCedula()
        {
            Empleado empleado = new Empleado();

            Empleado compraro = new Empleado();

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOEmpleado bdEmpleado = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOEmpleado();

            IDAOReporte bdReporte = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOReporte();

            empleado.Cedula = 9887667;

            empleado = bdEmpleado.ConsultarPorTipoCedula(empleado);

            compraro = bdReporte.ReporteAnualPorPaquetesEmpleadoId(empleado);

            Assert.AreEqual(empleado.Nombre, compraro.Nombre);
            Assert.AreEqual(empleado.Apellido, compraro.Apellido);
            Assert.AreEqual(60000.0, compraro.CargoEmpleado.SueldoMinimo);
            Assert.AreEqual(84000.0, compraro.CargoEmpleado.SueldoMaximo);
            Assert.AreEqual(empleado.Cargo, compraro.Cargo);
        }

        [Test]
        public void TestReporteNombre()
        {
            Empleado empleado = new Empleado();

            Empleado compraro = new Empleado();

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOEmpleado bdEmpleado = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOEmpleado();

            IDAOReporte bdReporte = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOReporte();

            empleado.Nombre = "Angelin";

            empleado = bdEmpleado.ConsultarPorTipoNombre(empleado)[0];

            compraro = bdReporte.ReporteAnualPorPaquetesEmpleadoId(empleado);

            Assert.AreEqual(empleado.Nombre, compraro.Nombre);
            Assert.AreEqual(empleado.Apellido, compraro.Apellido);
            Assert.AreEqual(60000.0, compraro.CargoEmpleado.SueldoMinimo);
            Assert.AreEqual(84000.0, compraro.CargoEmpleado.SueldoMaximo);
            Assert.AreEqual(empleado.Cargo, compraro.Cargo);
        }

    }
}
