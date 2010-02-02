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
            Factura facturaNueva = new Factura();
            factura.Numero = 1;

            Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarxFacturaID ComandoConsulta;
            ComandoConsulta = Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarxFacturaID(factura);
            facturaNueva = ComandoConsulta.Ejecutar();

            Assert.AreNotEqual(factura, new Factura());
        }


        [Test]
        public void TestConsultarFacturasNomPro()
        {
            Propuesta propuesta = new Propuesta();
            propuesta.Titulo = "Automatizacion de la Certificacion de Empleados";

            Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarxNomPro ComandoConsulta;
            ComandoConsulta = Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarxNomPro(propuesta);



            IList<Factura> facturas = ComandoConsulta.Ejecutar();
            Assert.AreNotEqual(facturas.ElementAt(0), new Factura());
        }

       

       
        

        

        [Test]
        public void Test1IngresarFactura()
        {
            Factura factura = new Factura();
            IList<Propuesta> propuestas;

            propuestas = new DAOPropuestaSQLServer().ConsultarPropuestaNueva(1,"Automatizacion de la Certificacion de Empleados");

            factura.Titulo = "Prueba Ingresar";
            factura.Descripcion = "Esto es una Prueba de Ingresar";
            factura.Procentajepagado = 1;
            factura.Fechapago = DateTime.Now;
            factura.Fechaingreso = DateTime.Now;
            factura.Estado = "Por Cobrar";
            factura.Prop = propuestas.ElementAt(0);
            Core.LogicaNegocio.Comandos.ComandoFactura.Ingresar ComandoIngresar;
            ComandoIngresar = Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoIngresar(factura);
            ComandoIngresar.Ejecutar();

            Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarxNomPro ComandoConsulta;
            ComandoConsulta = Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarxNomPro(propuestas.ElementAt(0));
            IList<Factura> listaFactura = ComandoConsulta.Ejecutar();

            
            Assert.AreEqual(listaFactura.ElementAt(listaFactura.Count - 1).Titulo,"Prueba Ingresar");
        }

        [Test]
        public void Test3Saldar()
        {
            Propuesta propuesta = new Propuesta();
            propuesta.Titulo = "Automatizacion de la Certificacion de Empleados";

            Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarxNomPro ComandoConsulta;
            ComandoConsulta = Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarxNomPro(propuesta);
            IList<Factura> listaFactura = ComandoConsulta.Ejecutar();

            listaFactura.ElementAt(listaFactura.Count - 1).Estado = "Cobrada";

            Core.LogicaNegocio.Comandos.ComandoFactura.Saldar ComandoSaldar;
            ComandoSaldar = Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoSaldar
                (listaFactura.ElementAt(listaFactura.Count -1).Numero,listaFactura.ElementAt(listaFactura.Count-1).Estado);
            ComandoSaldar.Ejecutar();

            listaFactura = null;
            listaFactura = ComandoConsulta.Ejecutar();

            Assert.AreEqual(listaFactura.ElementAt(listaFactura.Count - 1).Estado, "Cobrada");
        }


        [Test]
        public void Test2Anular()
        {
            Propuesta propuesta = new Propuesta();

            propuesta.Titulo = "Automatizacion de la Certificacion de Empleados";


            Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarxNomPro ComandoConsulta;
            ComandoConsulta = Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarxNomPro(propuesta);
            IList<Factura> listaFactura = ComandoConsulta.Ejecutar();

            Core.LogicaNegocio.Comandos.ComandoFactura.Anular ComandoAnular;
            ComandoAnular = Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoAnular(listaFactura.ElementAt(listaFactura.Count - 1).Numero);
            ComandoAnular.Ejecutar();

            listaFactura = ComandoConsulta.Ejecutar();
            Assert.AreEqual(listaFactura.ElementAt(listaFactura.Count - 1).Estado, "Anulada");

            new DAOFacturaSQLServer().ModificarEstadoFactura(listaFactura.ElementAt(listaFactura.Count - 1).Numero, "Por Cobrar");

        }

        
    }
}
