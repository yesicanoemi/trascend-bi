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
    public class PruebasCargo
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
        public void PruebaAIngresarCargo()
        {
            Cargo cargo = new Cargo();
            cargo.Nombre = "Probador BD";
            cargo.Descripcion = "Esto es una prueba";
            cargo.SueldoMinimo = 9000;
            cargo.SueldoMaximo = 10000;
            cargo.Vigencia = DateTime.Today;
            Core.LogicaNegocio.Comandos.ComandoCargo.Ingresar comandoIngresar;
            comandoIngresar = FabricaComandoCargo.CrearComandoIngresar( cargo );
            comandoIngresar.Ejecutar();
            Core.LogicaNegocio.Comandos.ComandoCargo.Consultar comandoBusqueda =
                                                    FabricaComandoCargo.CrearComandoConsultar(cargo);
            Assert.AreEqual(comandoBusqueda.Ejecutar().Descripcion, "Esto es una prueba");
        }


        [Test]
        public void PruebaBConsultarCargo()
        {
            Cargo cargo = new Cargo();
            cargo.Nombre = "Probador BD";
            Core.LogicaNegocio.Comandos.ComandoCargo.Consultar comandoBusqueda =
                                                    FabricaComandoCargo.CrearComandoConsultar(cargo);
            Assert.AreEqual(comandoBusqueda.Ejecutar().SueldoMinimo, 9000);

        }
       
        [Test]
        public void PruebaCModificarCargo()
        {
            Cargo cargo1 = new Cargo();
            Cargo cargo2;
            cargo1.Nombre = "Probador BD";
            Core.LogicaNegocio.Comandos.ComandoCargo.Consultar comandoBusqueda =
                                                    FabricaComandoCargo.CrearComandoConsultar(cargo1);
            cargo2 = comandoBusqueda.Ejecutar();
            Assert.AreNotEqual(cargo2, new Cargo());
            cargo2.Descripcion = "El Probador fue probado";
            Core.LogicaNegocio.Comandos.ComandoCargo.Modificar comandoModificar = 
                                                    FabricaComandoCargo.CrearComandoModificar(cargo2);
            comandoModificar.Ejecutar();
            
            Assert.AreEqual(comandoBusqueda.Ejecutar().Descripcion,"El Probador fue probado" );
   
        }

        [Test]
        public void PruebaDListaCargos()
        {
            List<Cargo> listaCargo = new List<Cargo>();
            Core.LogicaNegocio.Comandos.ComandoCargo.ConsultarTabla comandoConsultar =
                                                    FabricaComandoCargo.CrearComandoConsultarTabla();
            listaCargo = comandoConsultar.Ejecutar();
            Assert.AreEqual(listaCargo.ElementAt(listaCargo.Count - 1).Nombre, "Probador BD");
        }


        [Test]
        public void PruebaEEliminarCargo()
        {
            Cargo cargo = new Cargo();
            cargo.Nombre = "Probador BD";
            Core.LogicaNegocio.Comandos.ComandoCargo.Consultar comandoBusqueda =
                                                    FabricaComandoCargo.CrearComandoConsultar(cargo);

            Core.LogicaNegocio.Comandos.ComandoCargo.Eliminar comandoEliminar;
            comandoEliminar = FabricaComandoCargo.CrearComandoEliminar(comandoBusqueda.Ejecutar());
            comandoEliminar.Ejecutar();
            Assert.AreEqual(comandoBusqueda.Ejecutar().Nombre, null);


        }
        
       
    }
}
