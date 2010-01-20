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
            Contacto contacto = new Contacto();

            contacto.Nombre = "Claudio";

            contacto.Apellido = "Melcon";

            contacto.AreaDeNegocio = "Informatica";

            contacto.Cargo = "Presidente";

            contacto.TelefonoDeTrabajo.Numero = 7315797;

            contacto.TelefonoDeCelular.Numero = 7315797;

            contacto.TelefonoDeCelular.Codigocel = 0412;

            contacto.TelefonoDeTrabajo.Codigoarea = 212;

            contacto.TelefonoDeTrabajo.Tipo = "Trabajo";

            int id = 2;

            Core.LogicaNegocio.Comandos.ComandoContacto.Ingresar ComandoContacto;

            ComandoContacto = FabricaComandosContacto.CrearComandoIngresar(contacto, id);

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
