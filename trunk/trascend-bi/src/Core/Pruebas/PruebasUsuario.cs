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
    class PruebasUsuario
    {
        [Test]
        public void TestConsultarUsuario()
        {
            Usuario usuario = new Usuario();

            string Login = "usuario";

            usuario.Login = Login;

            IList<Core.LogicaNegocio.Entidades.Usuario> listadoUsuarios = 
                                    new UsuarioSQLServer().ConsultarUsuario(usuario);

            for (int i = 0; i < listadoUsuarios.Count; i++)
            {
                if (listadoUsuarios[i].Login == "usuario")
                {
                    usuario = listadoUsuarios[i];
                }
                else
                {
                    usuario = null;

                }  
            }

            Assert.AreEqual(Login,usuario.Login);
        }
    }
}
