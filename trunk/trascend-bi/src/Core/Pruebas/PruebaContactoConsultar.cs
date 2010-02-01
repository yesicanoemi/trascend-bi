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
    class PruebaContactoConsultar
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

        /// <summary>
        /// Prueba para consultar por nombre y apellido del contacto
        /// </summary>
        
        [Test]
        public void TestContactoConsultarNombreApellido()
        {
            Contacto contacto = new Contacto();

            contacto.ClienteContac = new Cliente();

            IList<Contacto> listContacto = new List<Contacto>();

            string Nombre = "Jorge";

            string Apellido = "Perez";

            contacto.Nombre = "or";

            contacto.Apellido = "er";

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOContacto bd = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOContacto();

            listContacto =  bd.ConsultarContactoNombreApellido(contacto);

            for (int i = 0; i < listContacto.Count; i++)
            {
                if ((listContacto[i].Nombre == Nombre)&&(listContacto[i].Apellido == Apellido))
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

        /// <summary>
        /// Prueba para consultar el contacto por cliente
        /// </summary>
        
        [Test]
        public void TestContactoConsultarXCliente()
        {
            Contacto contacto = new Contacto();

            contacto.ClienteContac = new Cliente();

            IList<Contacto> listContacto = new List<Contacto>();

            string Nombre = "Jorge";

            string Apellido = "Perez";

            string Cliente = "JL Sistemas";

            int IdCliente = 1;

            contacto.ClienteContac.IdCliente = IdCliente;

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOContacto bd = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOContacto();

            listContacto = bd.ConsultarContactoXCliente(contacto);

            for (int i = 0; i < listContacto.Count; i++)
            {
                if ((listContacto[i].Nombre == Nombre)&&(listContacto[i].Apellido == Apellido)
                    && (listContacto[i].ClienteContac.Nombre == Cliente))
                {
                    contacto.Nombre = listContacto[i].Nombre;
                    contacto.Apellido = listContacto[i].Apellido;
                    contacto.ClienteContac.Nombre = listContacto[i].ClienteContac.Nombre;
                    i = listContacto.Count;
                }
                else
                {
                    contacto.Nombre = "null";
                    contacto.Apellido = "null";
                    contacto.ClienteContac.Nombre = "null";
                }
            }

            Assert.AreEqual(Nombre, contacto.Nombre);
            Assert.AreEqual(Apellido, contacto.Apellido);
            Assert.AreEqual(Cliente, contacto.ClienteContac.Nombre);
        }

        /// <summary>
        /// Prueba para consultar por teléfono del contacto
        /// </summary>

        [Test]
        public void TestContactoConsultarXTelefono()
        {
            Contacto contacto = new Contacto();

            contacto.ClienteContac = new Cliente();

            Contacto ContactoCmp = new Contacto();

            string Nombre = "Jorge";

            string Apellido = "Perez";

            int Codigo = 416;

            int Numero = 6647382;

            contacto.TelefonoDeTrabajo.Codigoarea = Codigo;

            contacto.TelefonoDeTrabajo.Numero = Numero; 

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOContacto bd = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOContacto();

            ContactoCmp = bd.ConsultarContactoXTelefono(contacto);

            if ((ContactoCmp.Nombre == Nombre) && (ContactoCmp.Apellido == Apellido)
                    && (ContactoCmp.TelefonoDeTrabajo.Codigoarea == Codigo) 
                    && (ContactoCmp.TelefonoDeTrabajo.Numero == Numero))
            {
                contacto.Nombre = ContactoCmp.Nombre;
                contacto.Apellido = ContactoCmp.Apellido;
                contacto.TelefonoDeTrabajo.Codigoarea = ContactoCmp.TelefonoDeTrabajo.Codigoarea;
                contacto.TelefonoDeTrabajo.Numero = ContactoCmp.TelefonoDeTrabajo.Numero;
                
            }
            else
            {
                contacto.Nombre = "null";
                contacto.Apellido = "null";
                contacto.TelefonoDeTrabajo.Codigoarea = 0;
                contacto.TelefonoDeTrabajo.Numero = 0;
            }
            

            Assert.AreEqual(Nombre, contacto.Nombre);
            Assert.AreEqual(Apellido, contacto.Apellido);
            Assert.AreEqual(Codigo, contacto.TelefonoDeTrabajo.Codigoarea);
            Assert.AreEqual(Numero, contacto.TelefonoDeTrabajo.Numero);
        }

        /// <summary>
        /// Prueba para consultar el contacto por Id
        /// </summary>

        [Test]
        public void TestContactoConsultarXId()
        {
            Contacto contacto = new Contacto();

            Contacto ContactoCmp = new Contacto();

            string Nombre = "Jorge";

            string Apellido = "Perez";

            int IdContacto = 1;

            contacto.IdContacto = IdContacto;

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOContacto bd = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOContacto();

            ContactoCmp = bd.ConsultarContactoxId(contacto);

            if ((ContactoCmp.Nombre == Nombre) && (ContactoCmp.Apellido == Apellido)
                    && (ContactoCmp.IdContacto == IdContacto))
            {
                contacto.Nombre = ContactoCmp.Nombre;
                contacto.Apellido = ContactoCmp.Apellido;
                contacto.IdContacto = ContactoCmp.IdContacto;

            }
            else
            {
                contacto.Nombre = "null";
                contacto.Apellido = "null";
                contacto.IdContacto = 0;
            }


            Assert.AreEqual(Nombre, contacto.Nombre);
            Assert.AreEqual(Apellido, contacto.Apellido);
            Assert.AreEqual(IdContacto, contacto.IdContacto);
        } 

    }
}
