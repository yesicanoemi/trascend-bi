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
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;

namespace Core.Pruebas
{
    [TestFixture]
    class PruebaCliente
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

            cliente.Direccion = new Direccion();

            cliente.Direccion.Ciudad = "caracas";

            cliente.Direccion.Urbanizacion = "Los Ruices";
            
            cliente.Direccion.Avenida = "Avenida Francisco de Miranda";
            
            cliente.Direccion.Edif_Casa = "Piedra Gris";

            cliente.Direccion.Oficina = "14-c";

            cliente.Telefono = new TelefonoTrabajo();
            
            cliente.Telefono.Codigoarea = 212;

            cliente.Telefono.Numero = 2350592;

            cliente.Telefono.Tipo = "Local";
                                   
            cliente.Nombre = "aaaaaaaaaaaaaaa";
            
            cliente.Rif = "J-00006372-9";

            #endregion

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOCliente acceso = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOCliente();

            cliente = acceso.Ingresar(cliente);
        }

        [Test]
        public void ConsultarClientesNombre()
        {
            Cliente cliente = new Cliente();            

            cliente.Nombre = "a";

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOCliente acceso = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOCliente();

            IList<Cliente> clientes = acceso.ConsultarNombre(cliente);

            foreach (Cliente clienteA in clientes)
            {
                Console.WriteLine(cliente.Nombre);
            }
        }
    }
}
