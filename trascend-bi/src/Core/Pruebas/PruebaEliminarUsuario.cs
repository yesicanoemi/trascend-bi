using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;
using Core.LogicaNegocio.Fabricas;
using Core.LogicaNegocio.Comandos;
using NUnit.Framework;

namespace Core.Pruebas
{
    [TestFixture]
    class PruebaEliminarUsuario
    {
        [Test]
        public void TestEliminarUsuario()
        {
        /*    Usuario usuario = new Usuario();

            string Login = "usuario";
            string Status = "Inactivo";

            usuario.Login = Login;

            Core.LogicaNegocio.Entidades.Usuario user =
                                       new UsuarioSQLServer().VerificarUsuario(usuario);


            if (user.Login == "usuario")
            {
                usuario = user;
            }
            else
            {
                usuario = null;

            }

            Core.LogicaNegocio.Entidades.Usuario userEliminado =
            new UsuarioSQLServer().EliminarUsuario(usuario);

            Assert.AreEqual(Status, userEliminado.Status);*/


        }

    }
}
