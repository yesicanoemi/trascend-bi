using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Propuesta.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Fabricas;
using System.Net;
using Core.LogicaNegocio.Excepciones.Propuesta.LogicaNegocio;
namespace Presentador.Propuesta.Vistas
{
    public class ConsultarPropuestaPresentador
    {
        private IConsultarPropuesta _vista;
        private IList<Core.LogicaNegocio.Entidades.Propuesta> propuesta;

        #region Constructor
        public ConsultarPropuestaPresentador()
        {
        }

        public ConsultarPropuestaPresentador(IConsultarPropuesta vista)
        {
            _vista = vista;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que ejecuta la accion de Selección de tipo de Consulta
        /// </summary>
        public void BotonSeleccionTipo()
        {

            #region Atributos De La Pagina 2

            #endregion


            #region Solicitud Servicios


            #endregion
        }

        /// <summary>
        /// Metodo que ejcuta la Accion de realizar la consulta por parámetro indicado
        /// y presenta la propuesta seleccionada
        /// </summary>
        public void BotonAccionConsulta()
        {/*
            #region Atributos de la Pagina
            #region Activar Campos

            _vista.LabelCarg.Visible        = true;
            _vista.LabelCargP.Visible       = true;
            _vista.LabelEquip.Visible       = true;
            _vista.ListaEmpleados.Visible   = true;
            _vista.LabelFechaFi.Visible     = true;
            _vista.LabelFechaFiP.Visible    = true;
            _vista.LabelFechaI.Visible      = true;
            _vista.LabelFechaIP.Visible     = true;
            _vista.LabelFFirm.Visible       = true;
            _vista.LabelFFirmP.Visible      = true;
            _vista.LabelMont.Visible        = true;
            _vista.LabelMontP.Visible       = true;
            _vista.LabelRecep.Visible       = true;
            _vista.LabelRecepP.Visible      = true;
            _vista.LabelT.Visible           = true;
            _vista.LabelTP.Visible          = true;
            _vista.LabelV.Visible           = true;
            _vista.LabelVP.Visible          = true;

            #endregion
            
            #region Desactivar Campos

            _vista.opcion.Visible          = false;
            _vista.SeleccionOpcion.Visible = false;

            #endregion

            #endregion

            #region Solicitud Servicio



            if ( _vista.opcion.SelectedIndex == 0 ) // ES BUSQUEDA DE PROPUESTAS EN ESPERA
            {
                

                try
                {
                    string estado = "En Espera";
                    propuesta = BuscarPorTitulo(estado);
                    CargaDatosPagina( propuesta );  
                }
                catch (WebException e)
                {
                    throw new ConsultarPropuestaLogicaNException("Error en Capa de Negocio", e);
                }
                
            }



            if ( _vista.opcion.SelectedIndex == 1 ) // BUSQUEDA PROPUESTA APROBADA
            {
                try
                {
                    string estado = "Aprobada";
                    propuesta = BuscarPorTitulo(estado);
                    CargaDatosPagina(propuesta);
                }
                catch (WebException e)
                {
                    throw new ConsultarPropuestaLogicaNException("Error en Capa de Negocio", e);
                }
            }

            #region Otra Consulta
            if (_vista.opcion.SelectedIndex == 3) // ES RECHAZADA
            {
                try
                {
                    string estado = "Rechazada";
                    propuesta = BuscarPorTitulo(estado);
                    CargaDatosPagina(propuesta);
                }
                catch (WebException e)
                {
                    throw new ConsultarPropuestaLogicaNException("Error en Capa de Negocio", e);
                }
            }
            #endregion

            #endregion
        */
        }

        /// <summary>
        /// Método que se encarga de Dibujar en la página los resultados obtenidos
        /// </summary>
        public void CargaDatosPagina(int IdPropuesta)
        {
            int Opcion = 2;
            string parametro = Convert.ToString(IdPropuesta);
            propuesta = LlenarListaParametro(Opcion, parametro);

            _vista.LabelTP.Text = propuesta.ElementAt(0).Titulo;
            _vista.LabelVP.Text = propuesta.ElementAt(0).Version;
            _vista.LabelFFirmP.Text = propuesta.ElementAt(0).FechaFirma.ToString("MM/dd/yyyy");
            _vista.LabelRecepP.Text = propuesta.ElementAt(0).NombreReceptor + ' ' + propuesta.ElementAt(0).ApellidoReceptor;
            _vista.LabelCargP.Text = propuesta.ElementAt(0).CargoReceptor;
            _vista.LabelFechaIP.Text = propuesta.ElementAt(0).FechaInicio.ToString("MM/dd/yyyy");
            _vista.LabelFechaFiP.Text = propuesta.ElementAt(0).FechaFin.ToString("MM/dd/yyyy");
            _vista.LabelTotalHorasP.Text = string.Format("{0:n2}", propuesta.ElementAt(0).TotalHoras);
            _vista.LabelMontP.Text = string.Format("{0:n2}", propuesta.ElementAt(0).MontoTotal);

            for (int i = 0; i < propuesta.ElementAt(0).EquipoTrabajo.Count; i++)
                _vista.ListaEmpleados.Items.Add(propuesta.ElementAt(0).EquipoTrabajo.ElementAt(i).Nombre +
                    ' ' + propuesta.ElementAt(0).EquipoTrabajo.ElementAt(i).Apellido);
            _vista.MultiViewPropuestaC.ActiveViewIndex = 1;

            //_vista.ObtenerValorMuestra.DataSource = propuesta;
            //_vista.GridPropuesta.Visible = false;


        }

        /// <summary>
        /// Metodo que busca las propuestas
        /// </summary>
        /// <returns>devuelve objeto de tipo lista de propuestas</returns>
        public IList<Core.LogicaNegocio.Entidades.Propuesta> BuscarPorTitulo(int estado)
        {

            Core.LogicaNegocio.Comandos.ComandoPropuesta.ConsultarProyecto consultar;

            consultar = FabricaComandosPropuesta.CrearComandoConsultarProyecto(estado);

            propuesta = consultar.Ejecutar();

            return propuesta;

        }

        public void AccionBusqueda()
        {
            _vista.LabelVacioC.Visible = false;
            string opciont = _vista.ListOpcion.SelectedItem.Value;
            int Opcion = Convert.ToInt32(opciont);
            string Parametro;

            if (Opcion == 3)
                Parametro = _vista.TextParametroRif.Text;
            else
                Parametro = _vista.TextParametro.Text;
            
            propuesta = LlenarListaParametro(Opcion, Parametro);

            if (propuesta.Count > 0)
            {
                _vista.ObtenerValorDataSource.DataSource = propuesta;

            }
            else
            {
                _vista.ObtenerValorDataSource.DataSource = propuesta;
                _vista.LabelVacioC.Visible = true;
            }
            //_vista.ListOpcion.Visible = false;
            //_vista.TextParametro.Visible = false;
        }

        public IList<Core.LogicaNegocio.Entidades.Propuesta>
            LlenarListaParametro(int Opcion, string parametro)
        {
            Core.LogicaNegocio.Comandos.ComandoPropuesta.Consultar consultar;
            consultar = FabricaComandosPropuesta.CrearComandoConsultar(Opcion, parametro);
            propuesta = consultar.Ejecutar();
            return propuesta;
        }

        public void TipoBusqueda()
        {
            if (_vista.ListOpcion.SelectedValue == "3")
            {
                _vista.TextParametroRif.Visible = true;
                _vista.TextParametro.Visible = false;
            }
            if (_vista.ListOpcion.SelectedValue == "1")
            {
                _vista.TextParametro.Visible = true;
                _vista.TextParametroRif.Visible = false;
            }
            if (_vista.ListOpcion.SelectedValue == "4")
            {
                _vista.TextParametro.Visible = true;
                _vista.TextParametroRif.Visible = false;
            }
        }


        #endregion
    }
}
