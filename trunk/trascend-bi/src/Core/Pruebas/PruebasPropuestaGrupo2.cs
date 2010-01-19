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
    class PruebasPropuestaGrupo2
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
        public void TestConsultarPropuestaAprobada()
        {
            string estado = "Aprobada";
            IList<Propuesta> propuesta;
            propuesta = new PropuestaSQLServer().ConsultarPropuesta( estado );
            Assert.AreEqual( propuesta.Count, 1 );
        }

        [Test]
        public void TestEliminarPropuesta()
        {
            string estado = "Automatizacion de la Certificacion de Empleados";
            IList<string> propuesta;
            List<string> parametro = new List<string>();
            parametro.Add(estado);
            propuesta = new PropuestaSQLServer().ListaEliminar( parametro );
            Assert.AreEqual( parametro.Count, 1 );
        }

        [Test]
        public void TestConsultarGastoxFecha()
        {
            Gasto gasto = new Gasto();
            DateTime fechai = Convert.ToDateTime("01/01/2010");
            DateTime fechaf = Convert.ToDateTime("30/01/2010");
            IList<Gasto> gastos = new ReporteSQLServer().ConsultarGastoFecha(fechai, fechaf);
            Assert.AreEqual(gastos.Count, 1);
        }

    }
}
