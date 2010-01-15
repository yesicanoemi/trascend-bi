using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Comandos.ComandoContacto;

namespace Core.LogicaNegocio.Fabricas
{
    public class FabricaTelefono
    {
                

        public static TelefonoCelular CrearTelefonoCelular(TelefonoCelular telefonocel)
        {
            
            return telefonocel= new TelefonoCelular();
        }
        public static TelefonoTrabajo CrearTelefonoTrabajo(TelefonoTrabajo telefonotrabajo)
        {
            return telefonotrabajo = new TelefonoTrabajo();
        }
   
    }
}