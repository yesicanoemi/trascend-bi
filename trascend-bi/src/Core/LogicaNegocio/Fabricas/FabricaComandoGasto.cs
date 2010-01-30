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
        public static ConsultarGasto CrearComandoConsultar( int Opcion, string Parametro )
        {
            return new ConsultarGasto( Opcion, Parametro );
        }
        public static ConsultarGastoPorTipo CrearComandoConsultarPorTipo(IList<Gasto> listaGasto)
        {
            return new ConsultarGastoPorTipo(listaGasto);
        }
        public static ConsultarGastoPorPropuesta CrearComandoConsultarPorPropuesta(Propuesta propuesta)
        {
            return new ConsultarGastoPorPropuesta(propuesta);
        }
       /* public static ConsultarGastoPorPropuesta CrearComandoConsultarGasto(int Opcion, string Parametro)
        {
            return new ConsultarGastoPorPropuesta( Opcion , Parametro );
        }*/
        public static ConsultarGastoPorFecha CrearComandoConsultarPorFecha(Gasto gasto)
        {
            return new ConsultarGastoPorFecha(gasto);
        }
        public static ConsultarGastoPorEstado CrearComandoConsultarPorEstado(Gasto gasto)
        {
            return new ConsultarGastoPorEstado(gasto);
        }
    }
}
