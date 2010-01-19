using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Comandos.ComandoPropuesta;
using Core.LogicaNegocio.Entidades;

namespace Core.LogicaNegocio.Fabricas
{
    /// <summary>
    /// Clase publica Fabrica Comando Propuesta
    /// Se definen los comandos de las propuestas
    /// </summary>
    public class FabricaComandosPropuesta
    {
        /// <summary>
        /// Método que fabrica el comando Ingresar de la entidad Propuesta
        /// </summary>
        /// <param name="entidad">Entidad propuesta con los datos de ingreso</param>
        /// <returns>Comando ingresar de la entidad propuesta</returns>
        public static Ingresar CrearComandoIngresar(Propuesta entidad)
        {
            return new Ingresar(entidad);
        }

        /// <summary>
        /// Metodo que fabrica el comando Consultar de la entidad Propuesta
        /// </summary>
        /// <param name="entidad">Entidad Propuesta con los datos de consulta</param>
        /// <returns>Comando Consultar de la entidad propuesta</returns>
        public static Consultar CrearComandoConsultar(IList<Propuesta> arreglo)
        {
            return new Consultar(arreglo);
        }

        public static ConsultarPropuestasxEmision CrearComandoConsultarPropuestasxEmision()
        {
            return new ConsultarPropuestasxEmision();
        }

        public static ConsultarEnEspera CrearComandoConsultarEspera(IList<Propuesta> arreglo)
        {
            return new ConsultarEnEspera(arreglo);
        }

        public static Eliminar CrearComandoEliminar(IList<string> lista)
        {
            return new Eliminar(lista);
        }

        public static ConsultarPropuestasModificar CrearComandoConsultarPropuestasModificar(IList<Propuesta> arreglo)
        {
            return new ConsultarPropuestasModificar(arreglo);
        }

        public static ModificarPropuesta CrearComandoModificarPropuesta(Propuesta entidad)
        {
            return new ModificarPropuesta(entidad);
        }

    }
}
