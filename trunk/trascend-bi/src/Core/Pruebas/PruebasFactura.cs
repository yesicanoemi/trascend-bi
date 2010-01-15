using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using NUnit.Framework;


namespace Core.Pruebas
{
    [TestFixture]
    class PruebasFactura
    {
        [SetUp()]
        public void Init()
        {
            // some code here, that need to be run
            // at the start of every test case.
        }

        [TearDown()]
        public void Clean()
        {
            // code that will be called after each Test case
        }

        [Test]
        public void TestConsultarFacturaID()
        {
            Factura factura = new Factura();
            factura.Numero = 1;
            factura = new FacturaSQLServer().ConsultarFacturaID(factura);
            Assert.AreNotEqual(factura, new Factura());
            Assert.AreEqual(factura.Procentajepagado, 20);
        }

        [Test]
        public void TestConsultarFacturasNomPro()
        {
            Propuesta propuesta = new Propuesta();
            propuesta.Titulo = "Automatizacion del Modulo de Ventas";
            IList<Factura> facturas = new FacturaSQLServer().ConsultarFacturasNomPro(propuesta);
            Assert.AreEqual(facturas.Count, 2);
        }
    }
}
