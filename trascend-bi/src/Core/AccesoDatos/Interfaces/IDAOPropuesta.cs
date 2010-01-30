using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;

namespace Core.AccesoDatos.Interfaces
{
    public interface IDAOPropuesta
    {
        Propuesta IngresarPropuesta(Propuesta propuesta, IList<string[]> listaequipo);

        IList<Propuesta> ConsultarPropuesta(int estado);

        IList<Propuesta> ConsultarPropuestaNueva(int Opcion, string parametro);

        IList<Propuesta> ConsultarPropuestaOrdenadoPorEmision();

        IList<string> ListaEliminar(List<string> ListaRecibida);

        IList<Propuesta> ConsultarPropuestaAModificar();

        Propuesta ModificarPropuesta(Propuesta PropuestaRecibida);

        //este es un cambio para mejorar el idaoPropuesta
    }
}
