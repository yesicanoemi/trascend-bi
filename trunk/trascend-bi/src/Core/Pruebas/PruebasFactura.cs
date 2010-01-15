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
        public void TestConsultarFactura()
        {
            Factura factura = new Factura();
            //FacturaSQLServer 
            Assert.AreNotEqual(factura, new Factura());
        }
        
    }
}
