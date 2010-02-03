using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using NUnit.Framework;
using Core.LogicaNegocio.Fabricas;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;
namespace Core.Pruebas
{
    [TestFixture]
    class PruebaContactoModificar
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
        public void TestContactoModificar()
        {
            Contacto comparar = new Contacto();

            Contacto contacto = new Contacto();

            contacto.ClienteContac = new Cliente();

            contacto.IdContacto = 6;

            contacto.ClienteContac.IdCliente = 2;

            contacto.AreaDeNegocio = "Informatica";

            contacto.Cargo = "Gerente";

            contacto.Apellido = "Rojas";

            contacto.Nombre = "Dina";

            contacto.TelefonoDeTrabajo.Codigoarea = 212;

            contacto.TelefonoDeTrabajo.Numero = 8112211;

            contacto.TelefonoDeTrabajo.Tipo = "Trabajo";

            contacto.TelefonoDeCelular.Codigocel = 414;

            contacto.TelefonoDeCelular.Numero = 8113311;

            contacto.TelefonoDeCelular.Tipo = "Celular";

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOContacto bd = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOContacto();

            bd.ModificarContacto(contacto);

            comparar = bd.ConsultarContactoxId(contacto);

            Assert.AreEqual(comparar.Nombre, contacto.Nombre);
            Assert.AreEqual(comparar.Apellido, contacto.Apellido);
            Assert.AreEqual(comparar.AreaDeNegocio, contacto.AreaDeNegocio);
            Assert.AreEqual(comparar.Cargo, contacto.Cargo);
            Assert.AreEqual(comparar.TelefonoDeTrabajo.Codigoarea, contacto.TelefonoDeCelular.Codigocel);
            Assert.AreEqual(comparar.TelefonoDeTrabajo.Numero, contacto.TelefonoDeCelular.Numero);
            Assert.AreEqual(comparar.TelefonoDeTrabajo.Tipo, contacto.TelefonoDeCelular.Tipo);

        }
    }
}
