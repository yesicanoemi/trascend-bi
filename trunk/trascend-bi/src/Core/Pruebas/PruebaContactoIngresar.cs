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
    class PrubaContacto
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
        public void IngresarContacto()
        {
            IList<Contacto> listContacto = new List<Contacto>();

            Contacto contacto = new Contacto();

            Contacto _contacto = new Contacto();

            Cliente cliente = new Cliente();

            string Nombre = "Juan";

            string Apellido = "Apellido";

            contacto.Nombre = Nombre;

            contacto.Apellido = Apellido;

            contacto.AreaDeNegocio = "Ventas";

            contacto.Cargo = "Secretario";

            contacto.TelefonoDeTrabajo.Numero = 7315797;

            contacto.TelefonoDeCelular.Numero = 7315797;

            contacto.TelefonoDeCelular.Codigocel = 0412;

            contacto.TelefonoDeTrabajo.Codigoarea = 212;

            cliente.Nombre = "Integra";

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOContacto acceso = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOContacto();

            _contacto = acceso.Ingresar(contacto);

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOContacto bd = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOContacto();

            listContacto = bd.ConsultarContactoNombreApellido(contacto);

            for (int i = 0; i < listContacto.Count; i++)
            {
                if ((listContacto[i].Nombre == Nombre) && (listContacto[i].Apellido == Apellido))
                {
                    contacto.Nombre = listContacto[i].Nombre;
                    contacto.Apellido = listContacto[i].Apellido;
                    i = listContacto.Count;
                }
                else
                {
                    contacto.Nombre = "null";
                    contacto.Apellido = "null";
                }
            }

            Assert.AreEqual(Nombre, contacto.Nombre);
            Assert.AreEqual(Apellido, contacto.Apellido);

        }

    }
}

