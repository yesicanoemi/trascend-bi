using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Empleado.Contrato;

namespace Presentador.Empleado.Vistas
{
    public class AgregarEmpleadoPresenter
    {
        private IAgregarEmpleado _vista;
        private EmpleadoController _controller;

        public AgregarEmpleadoPresenter(IAgregarEmpleado vista)
        {
            _vista = vista;
            _controller = new EmpleadoController();
        }

        #region Manejo de Eventos
        public void IngresarEmpleado()
        {

        }
        #endregion
    }
}
