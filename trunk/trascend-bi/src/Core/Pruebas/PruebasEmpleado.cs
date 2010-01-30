using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Fabricas;

namespace Core.Pruebas
{
    [TestFixture]
    public class PruebasEmpleado
    {
        [SetUp()]
        public void Init()
        {
        }

        [TearDown()]
        public void Clean()
        {
        }

        [Test]
        public void PruebaAIngresarEmpleado()
        {
            IList<Empleado> lista = new List<Empleado>();
            Empleado empleado = new Empleado();
            empleado.Nombre = "Probador BD";
            empleado.Apellido = "Probador";
            empleado.FechaNacimiento = DateTime.Now;
            empleado.Cargo = "1";
            empleado.Cedula = 1111111;
            empleado.Cuenta = "123123";
            empleado.Estado = "Activo";
            empleado.SueldoBase = float.MinValue;
            empleado.Direccion = new Direccion();
            empleado.Direccion.Avenida = "prueba";
            empleado.Direccion.Calle = " c prueba";
            empleado.Direccion.Ciudad = "ciu prueba";
            empleado.Direccion.Edif_Casa = "edif prueba";
            empleado.Direccion.Piso_apto = "p prueba";
            empleado.Direccion.Urbanizacion = "u prueba";
            Core.LogicaNegocio.Comandos.ComandoEmpleado.Ingresar comandoIngresar;
            comandoIngresar = FabricaComandosEmpleado.CrearComandoIngresar(empleado);
            comandoIngresar.Ejecutar();
            Core.LogicaNegocio.Comandos.ComandoEmpleado.ConsultarPorNombre comandoBusqueda =
                                                    FabricaComandosEmpleado.CrearComandoConsultarPorNombre(empleado);
            lista = comandoBusqueda.Ejecutar();
            Assert.AreEqual(lista[0].Nombre, "Probador BD");
            Assert.AreEqual(lista[0].Direccion.Avenida, "prueba");
        }
        [Test]
        public void PruebaAModificarEmpleado()
        {
            IList<Empleado> _lista = new List<Empleado>();
            IList<Empleado> lista = new List<Empleado>();
            Empleado empleado = new Empleado();
            empleado.Nombre = "jose";
            Core.LogicaNegocio.Comandos.ComandoEmpleado.ConsultarPorNombre comandoBusqueda = FabricaComandosEmpleado.CrearComandoConsultarPorNombre(empleado);
            _lista = comandoBusqueda.Ejecutar();
            empleado.Id = 6;
            empleado.Nombre = "Probador BD";
            empleado.Apellido = "Probador";
            empleado.FechaNacimiento = DateTime.Now;
            empleado.Cargo = "1";
            empleado.Cedula = 1111111;
            empleado.Cuenta = "123123";
            empleado.Estado = "Activo";
            empleado.SueldoBase = float.MinValue;
            empleado.Direccion = new Direccion();
            empleado.Direccion.Avenida = "prueba";
            empleado.Direccion.Calle = " c prueba";
            empleado.Direccion.Ciudad = "ciu prueba";
            empleado.Direccion.Edif_Casa = "edif prueba";
            empleado.Direccion.Piso_apto = "p prueba";
            empleado.Direccion.Urbanizacion = "u prueba";
            Core.LogicaNegocio.Comandos.ComandoEmpleado.Modificar comandoModificar;
            comandoModificar = FabricaComandosEmpleado.CrearComandoModificar(empleado);
            comandoModificar.Ejecutar();
            comandoBusqueda = FabricaComandosEmpleado.CrearComandoConsultarPorNombre(empleado);
            lista = comandoBusqueda.Ejecutar();
            Assert.AreNotEqual(lista[0].Nombre, _lista[0].Nombre);
            Assert.AreEqual(lista[0].Nombre, "Probador BD");
            Assert.AreNotEqual(lista[0].Direccion.Avenida, _lista[0].Direccion.Avenida);
            Assert.AreEqual(lista[0].Direccion.Avenida, "prueba");
        }
    }
}
