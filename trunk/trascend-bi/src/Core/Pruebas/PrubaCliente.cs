using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using NUnit.Framework;
using Core.LogicaNegocio.Excepciones;
using Core.LogicaNegocio.Excepciones.Facturas.AccesoDatos;
using Core.LogicaNegocio.Fabricas;

namespace Core.Pruebas
{
    [TestFixture]
    class PrubaCliente
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
        public void IngresarCliente()
        {
            Cliente cliente = new Cliente();
            
            cliente.AreaNegocio = "Otros";
            
            cliente.CalleAvenidad = "Avenida Francisco de Miranda";
            
            cliente.Ciudad = "caracas";
            
            cliente.CodigoTrabajo = "212";
                                   
            cliente.EdificioCasa = "Piedra Gris";
            
            cliente.Nombre = "Polar";
            
            cliente.PisoApartamento="14-c";
            
            cliente.Rif = "J-00006372-9";
            
            cliente.TelefonoTrabajo = "2350592";
            
            cliente.Urbanizacion = "Los Ruices";
            
            Core.LogicaNegocio.Comandos.ComandoCliente.Ingresar ComandoIngresar;
            
            ComandoIngresar = FabricaComandosCliente.CrearComandoIngresar(cliente);

            ComandoIngresar.Ejecutar();
                
            
        }

       /*[Test]
        public void ConsultarCliente()
        {
            Cliente cliente = new Cliente();

            cliente.Nombre = "Polar";

            //Core.LogicaNegocio.Comandos.ComandoCliente.ConsultarNombre
        }*/




    }
}
