using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Comandos.ComandoGasto;

namespace Core.LogicaNegocio.Fabricas
{
    public class FabricaComandoGasto
    {
        public static IngresarGasto CrearComandoIngresar(Gasto gasto)
        {
            return new IngresarGasto(gasto);
        }
    }
}
