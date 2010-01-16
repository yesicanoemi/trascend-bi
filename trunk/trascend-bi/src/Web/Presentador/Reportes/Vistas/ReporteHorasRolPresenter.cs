using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Reportes.Contrato;
using Core.LogicaNegocio.Fabricas;
namespace Presentador.Reportes.Vistas
{
    public class ReporteHorasRolPresenter
    {
        private IReporteHorasRol _vista;
        private IList<string> empleado;
        #region Constructor
        public ReporteHorasRolPresenter()
        {

        }
        public ReporteHorasRolPresenter(IReporteHorasRol vista)
        {
            _vista = vista;
        }

        #endregion

        #region Metodos

        public void BuscaRol()
        {

            empleado = BuscarRoles();
            int i = 0;

            for (i = 0; i < empleado.Count; i++)
            {
                _vista.SeleccionRol.Items.Add(empleado.ElementAt(i));
                i++;
            }
            _vista.SeleccionRol.DataBind();
            _vista.SeleccionRol.Visible = true;

        }
        public void ContarHoras()
        {
            int i = 0;
            int horas = 0;

            for (i = 0; i < empleado.Count; i++)
            {
                if (empleado.ElementAt(i).Equals(_vista.SeleccionRol.SelectedItem.Text))
                {
                    i++;
                    horas = horas + Convert.ToInt32(empleado.ElementAt(i));
                }
                
            }
            _vista.LabelHoras.Text = horas.ToString();
            _vista.LabelHoras.Visible = true;
            _vista.LabelTextoHoras.Visible = true;
            _vista.SeleccionRol.Visible = false;
        
        }

        public IList<string> BuscarRoles()
        {
            Core.LogicaNegocio.Comandos.ComandoReporte.ConsultaRol consultar;
            consultar = FabricaComandosReporte.CrearComandoConsultarRol(empleado);
            empleado = consultar.Ejecutar();
            return empleado;
        }

        #endregion
    }
}
