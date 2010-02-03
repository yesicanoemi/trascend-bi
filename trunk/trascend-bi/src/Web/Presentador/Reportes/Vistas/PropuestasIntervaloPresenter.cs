using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Comandos.ComandoPropuesta;
using Presentador.Reportes.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Excepciones;

namespace Presentador.Reportes.Vistas
{
    public class PropuestasIntervaloPresenter
    {

        private IPropuestaIntervalo _vista;

        #region Constructor

        public PropuestasIntervaloPresenter(IPropuestaIntervalo vista)
        {
            _vista = vista;
            
        }

        #endregion

        public void CargarGrid()
        {
            _vista.Grid.DataSource = null;

            _vista.Grid.DataBind();

            IList<Core.LogicaNegocio.Entidades.Propuesta> lista = GetPropuestasIntervalo(Convert.ToDateTime(_vista.FechaInicio.Text), Convert.ToDateTime(_vista.FechaFin.Text));

       

           if (lista != null)
               {
               
                    _vista.Grid.DataSource = lista;

                    _vista.Grid.DataBind();
                }

                
            }
       


        #region Metodos

        public IList<Core.LogicaNegocio.Entidades.Propuesta> GetPropuestasIntervalo(DateTime inicio, DateTime fin)
        {

            IList<Core.LogicaNegocio.Entidades.Propuesta> PropuestasBuenas = new List<Core.LogicaNegocio.Entidades.Propuesta>();

            try
            {
                Core.LogicaNegocio.Comandos.ComandoFactura.ConsultarPropuestas comandoConsulta =
                    Core.LogicaNegocio.Fabricas.FabricaComandosFactura.CrearComandoConsultarPropuestas();

                IList<Core.LogicaNegocio.Entidades.Propuesta> ListaPropuestas = comandoConsulta.Ejecutar();

                foreach (Core.LogicaNegocio.Entidades.Propuesta PropuestaAux in ListaPropuestas)
                {
                    if (PropuestaAux.FechaInicio.CompareTo(inicio) >= 0)
                    {
                        if (PropuestaAux.FechaInicio.CompareTo(fin) <= 0)
                        {
                            PropuestaAux.NombreReceptor += PropuestaAux.ApellidoReceptor;
                            PropuestasBuenas.Add(PropuestaAux);
                        }
                    }
                }

                if (PropuestasBuenas.Count == 0)
                    throw new ConsultarException("No existen propuestas en los rangos ingresados");
            }
            catch (ConsultarException e)
            {
                _vista.Pintar(e.Message);
                _vista.MensajeVisible = true;
            }
            catch (Exception e)
            {
                _vista.Pintar(e.Message);
                _vista.MensajeVisible = true;
            }

            return PropuestasBuenas;
        }

        public string FormatearFechaParaMostrar(DateTime fecha)
        {
            return fecha.ToShortDateString();
        }

        #endregion
    }
}
