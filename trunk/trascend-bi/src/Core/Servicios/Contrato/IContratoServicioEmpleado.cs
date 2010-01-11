using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;

namespace Core.Servicios.Contrato
{
    public interface IContratoServicioEmpleado
    {
        /// <summary>Firma del método Ingresar, ingresa un urbanizador.</summary>
        /// <param name="entidad">Entidad con los datos del urbanizador.</param>
        Empleado Ingresar(Empleado entidad);
    }
}
