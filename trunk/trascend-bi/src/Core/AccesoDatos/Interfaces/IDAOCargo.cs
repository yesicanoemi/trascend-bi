using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;

namespace Core.AccesoDatos.Interfaces
{
    public interface IDAOCargo
    {
        /// <summary>
        /// Ingresa un cargo en el sistema
        /// </summary>
        /// <param name="cargo">Cargo a ingresar</param>
        void IngresarCargo(Cargo cargo);

        /// <summary>
        /// Metodo para consultar un cargo por su nombre
        /// </summary>
        /// <param name="cargo">Criterio de la busqueda</param>
        /// <returns>La informacion del cargo asociado al criterio</returns>
        Entidad ConsultarCargo(Cargo cargo);

        /// <summary>
        /// Metodo para consultar todos los cargos del sistema
        /// </summary>
        /// <returns>Una IList de entidades que contienen todos los cargos</returns>
        IList<Entidad> ConsultarCargos();
    }
}
