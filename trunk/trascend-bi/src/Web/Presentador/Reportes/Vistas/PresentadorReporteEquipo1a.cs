using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Reportes.Contrato;

namespace Presentador.Reportes.Vistas
{
    public class PresentadorReporteEquipo1a
    {
        private IReporteEquipo1a _vista;
        private IList<Core.LogicaNegocio.Entidades.Empleado> ListaEmpleados;
        private IList<Core.LogicaNegocio.Entidades.Cargo> ListaData;

        public PresentadorReporteEquipo1a (IReporteEquipo1a vista)
        {
            _vista = vista;
        }

        public void Onclick()
        {
            string data = _vista.TextBoxBusqueda.Text;
            string tipo = _vista.RadioButton.Text;

            Core.LogicaNegocio.Comandos.ComandoReporte.ConsultaEmpleadoPaquete consulta;

            //fábrica que instancia el comando Ingresar.
            consulta = Core.LogicaNegocio.Fabricas.FabricaComandosReporte.CrearComandoEmpleadoPaquete(data,tipo);


            //ejecuta el comando.
            ListaEmpleados = consulta.Ejecutar();

            Core.LogicaNegocio.Comandos.ComandoReporte.ConsultaEmpleadoPaqueteDat datos;

            //fábrica que instancia el comando Ingresar.
            datos = Core.LogicaNegocio.Fabricas.FabricaComandosReporte.CrearComandoEmpleadoPaqueteDat(data,tipo);


            //ejecuta el comando.
            ListaData = datos.Ejecutar();
        }
    }
}
