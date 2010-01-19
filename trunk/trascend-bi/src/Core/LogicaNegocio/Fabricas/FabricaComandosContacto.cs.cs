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
        public static  Consultar CrearComandoConsultar(Contacto contacto)
        {
            return new Consultar();
        }
        public static Eliminar CrearComandoEliminar(Contacto contacto)
        {
            return new Eliminar(contacto);
        }
        public static Modificar CrearComandoModificar(Contacto contacto)
        {
            return new Modificar(contacto);
        } 


    }
}