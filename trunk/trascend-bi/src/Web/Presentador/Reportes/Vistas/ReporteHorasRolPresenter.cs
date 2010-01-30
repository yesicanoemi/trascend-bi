using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Reportes.Contrato;
using Core.LogicaNegocio.Fabricas;
using System.Net;
namespace Presentador.Reportes.Vistas
{
    public class ReporteHorasRolPresenter
    {
        private IReporteHorasRol _vista;
        private IList<string> empleado;
        private string _rol;
        private int _Horas;
        
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
            try
            {
                string anio = _vista.SeleccionAnio.Text;
                string ConstFechaI = "01/01/" + anio;
                string ConstFechaF = "31/12/" + anio;
                DateTime FechaI = Convert.ToDateTime(ConstFechaI);
                DateTime FechaF = Convert.ToDateTime(ConstFechaF);
               
                
                empleado = BuscarRoles(FechaI, FechaF);
                
                int i = 0;

                for ( i = 0; i < empleado.Count; i++ )
                    {
                        _vista.SeleccionRol.Items.Add( empleado.ElementAt(i) );
                    }

                _vista.SeleccionRol.DataBind();
                _vista.SeleccionRol.Visible = true;
            }
            catch (WebException e)
            { 
                //EXCECION WEB
            }

        }
        public void ContarHoras()
        {
            try
            {
                int i = 0;
                int horas = 0;
                _rol = _vista.SeleccionRol.SelectedItem.Text;
                horas = SumaHora( _rol );

                _vista.LabelHoras.Text         = horas.ToString();
                _vista.LabelHoras.Visible      = true;
                _vista.LabelTextoHoras.Visible = true;
                _vista.SeleccionRol.Visible    = false;
            }
            catch ( WebException e )
            { 
                //EXCEPCION WEB
            }
        }

        public IList<string> BuscarRoles(DateTime FechaI, DateTime FechaF)
        {
            Core.LogicaNegocio.Comandos.ComandoReporte.ConsultaRol consultar;
            consultar = FabricaComandosReporte.CrearComandoConsultarRol(FechaI,FechaF);
            empleado = consultar.Ejecutar();
            return empleado;
        }
        public int SumaHora( string rol )
        {
            Core.LogicaNegocio.Comandos.ComandoReporte.ConsultaHora consultar;
            consultar = FabricaComandosReporte.SumaHoraRol(rol);
            _Horas = consultar.Ejecutar();
            return _Horas;
        }

        #endregion
    }
}
