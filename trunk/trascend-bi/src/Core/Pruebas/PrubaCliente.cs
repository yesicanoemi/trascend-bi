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
            
            #region carga de objeto cliente

                cliente.AreaNegocio = "Comercio";
                
                cliente.Direccion.Avenida = "Avenida Francisco de Miranda";
                
                cliente.Direccion.Ciudad = "caracas";
                
                cliente.Telefono.Codigoarea = 212;
                                       
                cliente.Direccion.Edif_Casa = "Piedra Gris";
                
                cliente.Nombre = "Polar";
                
                cliente.Direccion.Piso_apto="14-c";
                
                cliente.Rif = "J-00006372-9";
                
                cliente.Telefono.Numero = 2350592;
                
                cliente.Direccion.Urbanizacion = "Los Ruices";
            #endregion

            Core.LogicaNegocio.Comandos.ComandoCliente.Ingresar ComandoIngresar;
            
            ComandoIngresar = FabricaComandosCliente.CrearComandoIngresar(cliente);

            ComandoIngresar.Ejecutar();
                
            
        }

     



    }
}
