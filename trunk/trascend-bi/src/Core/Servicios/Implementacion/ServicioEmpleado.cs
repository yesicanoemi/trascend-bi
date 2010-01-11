using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Servicios.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Comandos.ComandoEmpleado;
using Core.LogicaNegocio.Fabricas;

namespace Core.Servicios.Implementacion
{
    public class ServicioEmpleado : IContratoServicioEmpleado
    {
        public Empleado Ingresar(Empleado empleado)
        {
            Ingresar ingresar;
            ingresar = FabricaComandosEmpleado.CrearComandoIngresar(empleado);
            return ingresar.Ejecutar();
        }
    }
}
