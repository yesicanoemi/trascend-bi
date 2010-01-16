using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Telefonos;

namespace Core.LogicaNegocio.Fabricas
{
    public class FabricaTelefono
    {
                

        public static Ingresar CrearTelefonoCelular(TelefonoCelular telefonocel)
        {
            
            return new Ingresar(telefonocel);
        }
        public static Ingresar CrearTelefonoTrabajo(TelefonoTrabajo telefonotrabajo)
        {
            return new Ingresar(telefonotrabajo) ;
        }


        internal static TelefonoCelular CrearTelefonoCelular()
        {
            throw new NotImplementedException();
        }
    }
}