using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using NUnit.Framework;
using Core.LogicaNegocio.Excepciones;
using Core.LogicaNegocio.Excepciones.Facturas.AccesoDatos;


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
            factura.Numero = 3;
            factura = new FacturaSQLServer().ConsultarFacturaID(factura);
            Assert.AreNotEqual(factura, new Factura());
            Assert.AreEqual(factura.Titulo, "Pago de la primera cuota");
            Assert.AreEqual(factura.Prop.Id, 1);
        }

        [Test]
        public void ConsultarPropuesta()
        {
            IList<Propuesta> propuestas = new PropuestaSQLServer().ConsultarPropuesta();
            Assert.AreEqual(propuestas[0].Titulo, "Automatizacion de la Certificacion de Empleados");
        }

        [Test]
        public void TestConsultarFacturasNomPro()
        {
            Propuesta propuesta = new Propuesta();
            propuesta.Titulo = "Automatizacion de la Certificacion de Empleados";
            IList<Factura> facturas = new FacturaSQLServer().ConsultarFacturasNomPro(propuesta);
            Assert.AreEqual(facturas.Count, 5);
        }

        [Test]
        public void TestConsultarFacturasNomProExceptionGenerica()
        {
            try
            {
                Propuesta propuesta = null;
                IList<Factura> facturas = new FacturaSQLServer().ConsultarFacturasNomPro(propuesta);
                Assert.AreEqual(facturas.Count, 0);
            }
            catch (ConsultarFacturaADException e)
            {
                Console.WriteLine("Exito: "+e.Message);
            }
            catch (Exception e)
            {
                Assert.Fail("Excepcion Equivocada");
            }
        }

        [Test]
        public void TestConsultarFacturasIDPro()  
        {
            Propuesta propuesta = new Propuesta();
            propuesta.Id = 1;
            IList<Factura> facturas = new FacturaSQLServer().ConsultarFacturasIDPro(propuesta);
            Assert.AreEqual(facturas.Count, 47);
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
            factura = new FacturaSQLServer().IngresarFactura(factura);
            Assert.AreNotEqual(factura,new Factura());
        }

        [Test]
        public void TestUpdate()
        {
            Factura factura = new Factura();
            factura.Numero = 1;
            factura = new FacturaSQLServer().UpdateFactura(factura);
            Assert.AreNotEqual(factura, new Factura());
        }
    }
}
