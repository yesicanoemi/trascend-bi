using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Comandos.ComandoContacto;

namespace Core.LogicaNegocio.Fabricas
{
    public class FabricaComandosContacto
    {
       public static Ingresar CrearComandoIngresar(Contacto contacto)
        {
            return new Ingresar(contacto);
        }
        public static  Consultar CrearComandoConsultar(IList<Contacto> contacto, string Nombre, string Apellido,
            int codigo, int numero, int flag)
        {
            return new Consultar(contacto, Nombre, Apellido, codigo, numero, flag);
        }
        public static Eliminar CrearComandoEliminar(Contacto contacto)
        {
            return new Eliminar(contacto);
        }
        public static Modificar CrearComandoModificar(Contacto contacto1,Contacto contacto2)
        {
            return new Modificar(contacto1,contacto2);
        } 


    }
}