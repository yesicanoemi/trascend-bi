﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Propuesta.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Fabricas;

namespace Presentador.Propuesta.Vistas
{
    public class ConsultarPropuestaPresentador
    {
        private IConsultarPropuesta _vista;
        private IList<Core.LogicaNegocio.Entidades.Propuesta> propuesta;

        #region Constructor
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
            #region AtributosDeLaPagina

            if (_vista.opcion.SelectedIndex == 0)
            {

                _vista.opcion.Visible          = false;
                _vista.LabelTipoC.Visible      = false;
                _vista.SeleccionOpcion.Visible = true;
                _vista.LabelSelec.Visible      = true;

            }

            if (_vista.opcion.SelectedIndex == 1)
            {
 
                _vista.opcion.Visible          = false;
                _vista.SeleccionOpcion.Visible = true;

            }

            if (_vista.opcion.SelectedIndex == 2)
            {
                //uxTitulo.Text = "Opcion 2";
                //uxSeleccion.Visible = true;
                //uxBotonAceptar2.Visible = true;
                //uxBotonAceptar.Visible = false;
                //uxTitulo.Visible = false;
            }
            #endregion

            #region SolicitudServicios

            if (_vista.opcion.SelectedIndex == 0) // Seleccion Cliente
            {
                //_propuesta.
                // _presenter.BuscarPorTitulo();

            }

            if (_vista.opcion.SelectedIndex == 1)// Seleccion Titulo
            {
                int i = 0;
                propuesta =  BuscarPorTitulo();
                for (i = 0; i < propuesta.Count; i++)
                {
                    _vista.SeleccionOpcion.Items.Add(propuesta.ElementAt(i).Titulo);
                    
                }
                _vista.SeleccionOpcion.DataBind();
            }

            if (_vista.opcion.SelectedIndex == 2)// Seleccion Fecha
            {

            }

            #endregion
        }

        /// <summary>
        /// Metodo que ejcuta la Accion de realizar la consulta por parámetro indicado
        /// y presenta la propuesta seleccionada
        /// </summary>
        public void BotonAccionConsulta ()
        {
            #region Atributos de la Pagina
                #region Activar Campos
                    _vista.LabelCarg.Visible = true;
                    _vista.LabelCargP.Visible = true;
                    _vista.LabelEquip.Visible = true;
                    _vista.LabelEquipP.Visible = true;
                    _vista.LabelFechaFi.Visible = true;
                    _vista.LabelFechaFiP.Visible = true;
                    _vista.LabelFechaI.Visible = true;
                    _vista.LabelFechaIP.Visible = true;
                    _vista.LabelFFirm.Visible = true;
                    _vista.LabelFFirmP.Visible = true;
                    _vista.LabelMont.Visible = true;
                    _vista.LabelMontP.Visible = true;
                    _vista.LabelRecep.Visible = true;
                    _vista.LabelRecepP.Visible = true;
                    _vista.LabelT.Visible = true;
                    _vista.LabelTotalHoras.Visible = true;
                    _vista.LabelTotalHorasP.Visible = true;
                    _vista.LabelTP.Visible = true;
                    _vista.LabelV.Visible = true;
                    _vista.LabelVP.Visible = true;
                #endregion
                #region Desactivar Campos
                    _vista.opcion.Visible = false;
                    _vista.SeleccionOpcion.Visible = false;
                #endregion

            #endregion

            #region Solicitud Servicio
            
            int i = 0;
            propuesta = BuscarPorTitulo();
            for (i = 0; i < propuesta.Count; i++)
            {
                if(propuesta.ElementAt(i).Titulo.Equals(_vista.SeleccionOpcion.SelectedItem.Text))
                {
                   // Se Llenan Los Campos
                    _vista.LabelCargP.Text = propuesta.ElementAt(i).CargoReceptor;
                    //_vista.LabelEquipP.Text = propuesta.ElementAt(i).EquipoTrabajo;
                    _vista.LabelFechaFiP.Text =  propuesta.ElementAt(i).FechaFin.ToString();
                    _vista.LabelFechaIP.Text  =  propuesta.ElementAt(i).FechaInicio.ToString();
                    _vista.LabelFFirmP.Text   =  propuesta.ElementAt(i).FechaFirma.ToString();
                    _vista.LabelMontP.Text    =  propuesta.ElementAt(i).MontoTotal.ToString();
                    _vista.LabelRecepP.Text   =  propuesta.ElementAt(i).NombreReceptor;
                    _vista.LabelTotalHorasP.Text = propuesta.ElementAt(i).TotalHoras.ToString();
                    _vista.LabelTP.Text = propuesta.ElementAt(i).Titulo;
                    _vista.LabelVP.Text = propuesta.ElementAt(i).Version;
                    
                }
            }

            #endregion
        }

        /// <summary>
        /// Metodo que busca las propuestas
        /// </summary>
        /// <returns>devuelve objeto de tipo lista de propuestas</returns>
        public IList<Core.LogicaNegocio.Entidades.Propuesta> BuscarPorTitulo()
        {
     
            Core.LogicaNegocio.Comandos.ComandoPropuesta.Consultar consultar;

            consultar = FabricaComandosPropuesta.CrearComandoConsultar( propuesta );

            propuesta = consultar.Ejecutar();

            return propuesta;

        }
        #endregion
    }
}