using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Comandos.ComandoCliente;


namespace Core.LogicaNegocio.Fabricas
{
    public class FabricaComandosCliente
    {
        public static Ingresar CrearComandoIngresar(Cliente cliente)
        {
            return new Ingresar(cliente);
        }
        public static Consultar CrearComandoConsultar()
        {
            return new Consultar();
        }



        public static ConsultarNombre CrearComandoConsultarNombre(Cliente cliente)
        {
            return new ConsultarNombre(cliente);
        }



        public static Modificar CrearComandoModificar(Cliente cliente)
        {
            return new Modificar(cliente);
        }

        public static ConsultarTodos CrearComandoConsultarTodos()
        {
            return new ConsultarTodos();
        }


        public static ConsultarRif CrearComandoConsultarRif(Cliente cliente)
        {
            return new ConsultarRif(cliente);
        }
    }
}
