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
                                   
            cliente.Nombre = "Oh L0lz0r";
            
            cliente.Rif = "J-00006372-9";

            cliente.Telefono = new TelefonoTrabajo[3];

            cliente.Telefono[0] = new TelefonoTrabajo();

            cliente.Telefono[0].Codigoarea = 212;

            cliente.Telefono[0].Numero = 2350592;

            cliente.Telefono[0].Tipo = "Trabajo";

            cliente.Telefono[1] = new TelefonoTrabajo();

            cliente.Telefono[1].Codigoarea = 212;

            cliente.Telefono[1].Numero = 2350593;

            cliente.Telefono[1].Tipo = "Fax";

            cliente.Telefono[2] = new TelefonoTrabajo();

            cliente.Telefono[2].Codigoarea = 414;

            cliente.Telefono[2].Numero = 2350592;

            cliente.Telefono[2].Tipo = "Celular";

            #endregion

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOCliente acceso = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOCliente();

            cliente = acceso.Ingresar(cliente);
        }

        [Test]
        public void ConsultarClientesNombre()
        {
            Cliente cliente = new Cliente();            

            cliente.Nombre = "o";

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOCliente acceso = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOCliente();

            IList<Cliente> clientes = acceso.ConsultarNombre(cliente);

            foreach (Cliente clienteA in clientes)
            {
                Console.WriteLine(clienteA.Nombre);
            }
        }

        [Test]
        public void ConsultarTodos()
        {
            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOCliente acceso = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOCliente();

            IList<Cliente> clientes = acceso.ConsultarTodos();

            foreach (Cliente clienteA in clientes)
            {
                if (clienteA.Telefono[1] != null)
                    Console.WriteLine(clienteA.Telefono[1].Tipo);
            }
        }

        [Test]
        public void ModificarCliente()
        {
            Cliente cliente = new Cliente();

            #region carga de objeto cliente

            cliente.IdCliente = 6;

            cliente.AreaNegocio = "Reparaciones de Pocetas";

            cliente.Direccion = new Direccion();

            cliente.Direccion.Ciudad = "caracas";

            cliente.Direccion.Urbanizacion = "Los Ruices";

            cliente.Direccion.Avenida = "Avenida Francisco de Miranda";

            cliente.Direccion.Edif_Casa = "Piedra Gris";

            cliente.Direccion.Oficina = "14-c";

            cliente.Nombre = "Oh L0lz0r";

            cliente.Rif = "J-00006372-9";

            cliente.Telefono = new TelefonoTrabajo[3];

            cliente.Telefono[0] = new TelefonoTrabajo();

            cliente.Telefono[0].Codigoarea = 323;

            cliente.Telefono[0].Numero = 5555555;

            cliente.Telefono[0].Tipo = "Trabajo";

            cliente.Telefono[1] = new TelefonoTrabajo();

            cliente.Telefono[1].Codigoarea = 121;

            cliente.Telefono[1].Numero = 1231231;

            cliente.Telefono[1].Tipo = "Fax";

            cliente.Telefono[2] = new TelefonoTrabajo();

            cliente.Telefono[2].Codigoarea = 414;

            cliente.Telefono[2].Numero = 3213213;

            cliente.Telefono[2].Tipo = "Celular";

            #endregion

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOCliente acceso = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOCliente();

            cliente = acceso.Modificar(cliente);
        }

        [Test]
        public void EliminarCliente()
        {
            Cliente cliente = new Cliente();

            cliente.IdCliente = 6;

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOCliente acceso = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOCliente();

            cliente = acceso.EliminarCliente(cliente);
        }

        [Test]
        public void BuscarClienteRif()
        {
            Cliente cliente = new Cliente();

            cliente.Rif = "C03758493-1";

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOCliente acceso = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOCliente();

            cliente = acceso.ConsultarRif(cliente);

            Console.WriteLine(cliente.Nombre);
            
        }
    }
}
