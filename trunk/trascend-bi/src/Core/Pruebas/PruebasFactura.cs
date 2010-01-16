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
            Assert.AreEqual(factura.Titulo, "Pago de la primera cuota");
            Assert.AreEqual(factura.Prop.Id, 1);
        }

        [Test]
        public void ConsultarPropuesta()
        {
            IList<Propuesta> propuestas = new PropuestaSQLServer().ConsultarPropuesta();
            Assert.AreEqual(propuestas[0].Titulo,"Automatizacion del Modulo de Ventas");
        }

        [Test]
        public void TestConsultarFacturasNomPro()
        {
            Propuesta propuesta = new Propuesta();
            propuesta.Titulo = "Automatizacion del Modulo de Ventas";
            IList<Factura> facturas = new FacturaSQLServer().ConsultarFacturasNomPro(propuesta);
            Assert.AreEqual(facturas.Count, 3);
        }

        [Test]
        public void TestConsultarFacturasIDPro()  
        {
            Propuesta propuesta = new Propuesta();
            propuesta.Id = 1;
            IList<Factura> facturas = new FacturaSQLServer().ConsultarFacturasIDPro(propuesta);
            Assert.AreEqual(facturas.Count, 3);
        }

        [Test]
        public void TestIngresarFactura()
        {
            Factura factura = new Factura();
            factura.Numero = 0;
            factura.Titulo = "Pago de la enesima cuota LULZ!!!";
            factura.Descripcion = "Imaginate tu!";
            factura.Procentajepagado = 1.3f;
            factura.Fechapago = DateTime.Now;
            factura.Fechaingreso = DateTime.Now;
            factura.Estado = "Pagado";
            factura.Prop = new Propuesta();
            factura.Prop.Id = 1;
            Assert.AreNotEqual(factura,new Factura());
        }
    }
}
