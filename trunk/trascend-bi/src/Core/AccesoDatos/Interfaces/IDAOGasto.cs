using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;

namespace Core.AccesoDatos.Interfaces
{
    public interface IDAOGasto
    {

        Gasto IngresarGasto(Gasto gasto);

        Gasto IngresarGastoPropuesta(Gasto gasto);

        /// <summary>
        /// Firma del método Consultar Gasto,
        /// </summary>
        /// <param name="propuesta">Entidad con los datos del Gasto</param>
        /// <returns>Lista génerica con las entidades gastos consultadas</returns>
        IList<Gasto> ConsultarGasto(Gasto gasto);

        /// <summary>
        /// Firma del método Consultar Gasto,
        /// </summary>
        /// <param name="propuesta">Entidad con los datos del Gasto</param>
        /// <returns>Lista génerica con las entidades gastos consultadas</returns>
        IList<Gasto> ConsultarGastoPorTipo();

        IList<Gasto> ConsultarGastoPorPropuesta(Propuesta propuesta);

        IList<Gasto> ConsultarGastoPorFecha(Gasto gasto);

        IList<Gasto> ConsultarGastoPorEstado(Gasto gasto);

        Gasto EliminarGasto(Gasto gasto);

        Gasto ModificarGasto(Gasto gasto);


    }
}
