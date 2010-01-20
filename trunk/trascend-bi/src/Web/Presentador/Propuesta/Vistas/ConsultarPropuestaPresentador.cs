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
            _vista.ObtenerValorMuestra.DataSource = propuesta;
            _vista.GridPropuesta.Visible = false;

           
        }

        /// <summary>
        /// Metodo que busca las propuestas
        /// </summary>
        /// <returns>devuelve objeto de tipo lista de propuestas</returns>
        public IList<Core.LogicaNegocio.Entidades.Propuesta> BuscarPorTitulo(string estado)
        {
            
            Core.LogicaNegocio.Comandos.ComandoPropuesta.ConsultarProyecto consultar;

            consultar = FabricaComandosPropuesta.CrearComandoConsultarProyecto( estado );

            propuesta = consultar.Ejecutar();
            
            return propuesta;

        }

        public void AccionBusqueda()
        {
                string opciont = _vista.ListOpcion.SelectedItem.Value;
                int Opcion = Convert.ToInt32(opciont);
                string Parametro = _vista.TextParametro.Text;
                propuesta = LlenarListaParametro(Opcion, Parametro);   
            if(propuesta!=null)
            {
                _vista.ObtenerValorDataSource.DataSource = propuesta;
            }
            _vista.ListOpcion.Visible = false;
            _vista.TextParametro.Visible = false;
        }

        private IList<Core.LogicaNegocio.Entidades.Propuesta>
            LlenarListaParametro(int Opcion , string parametro)
        {
            Core.LogicaNegocio.Comandos.ComandoPropuesta.Consultar consultar;
            consultar = FabricaComandosPropuesta.CrearComandoConsultar(Opcion, parametro);
            propuesta = consultar.Ejecutar();
            return propuesta;
        }

        

        #endregion
    }
}
