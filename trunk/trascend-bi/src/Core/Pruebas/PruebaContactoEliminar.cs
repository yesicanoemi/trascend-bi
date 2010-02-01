﻿using System;
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
    class PruebaContactoEliminar
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
        public void TestContactoEliminar()
        {
            Contacto contacto = new Contacto();

            Contacto comparar;

            FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOContacto bd = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOContacto();

            contacto.IdContacto = 7;

            bd.Eliminar(contacto);

            comparar = bd.ConsultarContactoxId(contacto);

            Assert.AreEqual(comparar.Nombre,null );
            Assert.AreEqual(comparar.Apellido, null);

        }
    }
}
