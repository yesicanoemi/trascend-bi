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
        public void PruebaConsultarCargo()
        {
            Cargo cargo = new Cargo();
            cargo.Nombre = "Analista";
            Core.LogicaNegocio.Comandos.ComandoCargo.Consultar comandoBusqueda = 
                                                    FabricaComandoCargo.CrearComandoConsultar(cargo);
            Assert.AreEqual(comandoBusqueda.Ejecutar().SueldoMinimo,2000);
           
        }

    }
}
