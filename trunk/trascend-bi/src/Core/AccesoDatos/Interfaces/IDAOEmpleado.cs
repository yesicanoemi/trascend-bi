using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;

namespace Core.AccesoDatos.Interfaces
{
    public interface IDAOEmpleado
    {

        Empleado Ingresar(Empleado empleado);

        void InsertarDireccion(Core.LogicaNegocio.Entidades.Empleado empleado, int id);

        IList<Empleado> Consultar();

        Core.LogicaNegocio.Entidades.Empleado ConsultarId(Core.LogicaNegocio.Entidades.Empleado empleado);

        int Modificar(Empleado empleado);

        List<Empleado> ConsultarPorTipoNombre(Empleado emp);

        IList<string> ConsultarCargos();

        Empleado ConsultarPorTipoCedula(Empleado emp);

        IList<Empleado> ConsultarPorTipoCargo(Empleado emp);

        void ModificarDireccion(Core.LogicaNegocio.Entidades.Empleado empleado);

        IList<Persona> ConsultarNombreApellido();

        int EliminarEmpleado(Empleado emp);

        Empleado ConsultarPorCodigo(Empleado emp);


        IList<EstadoEmpleado> ConsultarTodosEstadosEmpleado();


        int ConsultarCedula(int _cedula);


        Empleado EliminarConsultarPorTipoCedula(Empleado emp);

        List<Empleado> EliminarConsultarPorTipoNombre(Empleado emp);

        IList<Empleado> EliminarConsultarPorTipoCargo(Empleado emp);



        //sEmpleado ConsultarCargoNuevo(Cargo entidad);

    }
}
