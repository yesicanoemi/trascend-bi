using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Propuesta.Contrato;


namespace Presentador.Propuesta.Vistas
{
    public class AgregarPropuestaPresenter
    {
        private IAgregarPropuesta _vista;


        public AgregarPropuestaPresenter(IAgregarPropuesta vista)
        {
            _vista = vista;

        }


        public void IngresarPropuesta()
        {

        }
    }
}
