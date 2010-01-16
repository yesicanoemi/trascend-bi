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
        public static ModificarGasto CrearComandoModificar(Gasto gasto)
        {
            return new ModificarGasto(gasto);
        }
        public static EliminarGasto CrearComandoEliminar(Gasto gasto)
        {
            return new EliminarGasto(gasto);
        }
        public static ConsultarGasto CrearComandoConsultar(Gasto gasto)
        {
            return new ConsultarGasto(gasto);
        }

     
    }
}
