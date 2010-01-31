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
    class PrubaModificar
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
        /*
        [Test]
        
        public void ModificarContacto()
        {
            Contacto contacto1 = new Contacto();
            Contacto contacto2 = new Contacto();

           
            contacto1.Nombre = "Claudio";

            contacto1.Apellido = "Melcon";

            contacto1.AreaDeNegocio = "Informatica";

            contacto1.Cargo = "Presidente";

            contacto1.TelefonoDeTrabajo.Numero = 7315797;

            contacto1.TelefonoDeCelular.Numero = 7315797;

            contacto1.TelefonoDeCelular.Codigocel = 0412;

            contacto1.TelefonoDeTrabajo.Codigoarea = 212;

            contacto1.TelefonoDeTrabajo.Tipo = "Trabajo";



            contacto2.Nombre = "Tony";

            contacto2.Apellido = "Suarez";

            contacto2.AreaDeNegocio = "Administracion";

            contacto2.Cargo = "Gerente";

            contacto2.TelefonoDeTrabajo.Numero = 6615995;

            contacto2.TelefonoDeCelular.Numero = 7316363;

            contacto2.TelefonoDeCelular.Codigocel = 0412;

            contacto2.TelefonoDeTrabajo.Codigoarea = 212;

            contacto2.TelefonoDeTrabajo.Tipo = "Fax";

            Core.LogicaNegocio.Comandos.ComandoContacto.Modificar ComandoContacto;

            ComandoContacto = FabricaComandosContacto.CrearComandoModificar(contacto1,contacto2);

            ComandoContacto.Ejecutar();


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
