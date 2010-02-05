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
    class PruebaEmpleadoIngresar
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
        public void IngresarEmpleado()
        {
            Empleado empleado = new Empleado();

            #region carga de objeto cliente

            empleado.Apellido = "Bracho";

            empleado.Cargo = "Desarrollador";

            //empleado.

            empleado.Direccion = new Direccion();

            empleado.Direccion.Ciudad = "caracas";

            empleado.Direccion.Urbanizacion = "Los Ruices";

            empleado.Direccion.Avenida = "Avenida Francisco de Miranda";

            empleado.Direccion.Edif_Casa = "Piedra Gris";

            empleado.Direccion.Oficina = "14-c";

            empleado.Nombre = "El guevo Erecto";

            /*empleado.Rif = "J-00006372-9";

            empleado.Telefono = new TelefonoTrabajo[3];

            empleado.Telefono[0] = new TelefonoTrabajo();

            empleado.Telefono[0].Codigoarea = 212;

            empleado.Telefono[0].Numero = 2350592;

            empleado.Telefono[0].Tipo = "Trabajo";

            empleado.Telefono[1] = new TelefonoTrabajo();

            empleado.Telefono[1].Codigoarea = 212;

            empleado.Telefono[1].Numero = 2350593;

            empleado.Telefono[1].Tipo = "Fax";

            empleado.Telefono[2] = new TelefonoTrabajo();

            empleado.Telefono[2].Codigoarea = 414;

            empleado.Telefono[2].Numero = 2350592;

            empleado.Telefono[2].Tipo = "Celular";*/

            #endregion

            /*FabricaDAO.EnumFabrica = EnumFabrica.SqlServer;

            IDAOCliente acceso = FabricaDAO.ObtenerFabricaDAO().ObtenerDAOCliente();

            cliente = acceso.Ingresar(cliente);*/
        }
    }
}
