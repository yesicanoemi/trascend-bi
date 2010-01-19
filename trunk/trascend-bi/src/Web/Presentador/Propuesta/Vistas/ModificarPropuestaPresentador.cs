using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Propuesta.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Fabricas;

namespace Presentador.Propuesta.Vistas
{

    public class ModificarPropuestaPresentador
    {

        private IModificarPropuesta _vista;
        private IList<Core.LogicaNegocio.Entidades.Propuesta> propuesta;

        #region Constructor

        public ModificarPropuestaPresentador(IModificarPropuesta vista)
        {

            _vista = vista;

        }

        #endregion

        #region Metodos

        public void BotonSeleccionTipo()
        {
            if (_vista.opcion.SelectedIndex == 0)
            {

                _vista.opcion.Visible = false;
                _vista.LabelTipoC.Visible = false;
                _vista.SeleccionOpcion.Visible = true;
                _vista.LabelSelec.Visible = true;

            }

            if (_vista.opcion.SelectedIndex == 1)
            {

                _vista.opcion.Visible = false;
                _vista.SeleccionOpcion.Visible = true;

            }

            #region SolicitudServicios
            if (_vista.opcion.SelectedIndex == 0) // PROPUESTAS EN ESPERA 
            {

                int i = 0;
                propuesta = BuscarPropuestasEnEspera();
                for (i = 0; i < propuesta.Count; i++)
                {

                    _vista.SeleccionOpcion.Items.Add(propuesta.ElementAt(i).Titulo);

                }
                _vista.SeleccionOpcion.DataBind();
            }

        }
            #endregion

        /// <summary>
        /// Metodo que ejcuta la Accion de realizar la consulta por parámetro indicado
        /// y presenta la propuesta seleccionada
        /// </summary>
        public void BotonAccionConsulta()
        {
            #region Atributos de la Pagina
            #region Activar Campos
            _vista.LabelCarg.Visible = true;
            _vista.LabelEquip.Visible = true;
            _vista.LabelFechaFi.Visible = true;
            _vista.LabelFechaI.Visible = true;
            _vista.LabelFFirm.Visible = true;
            _vista.LabelMont.Visible = true;
            _vista.LabelRecep.Visible = true;
            _vista.LabelT.Visible = true;
            _vista.LabelTotalHoras.Visible = true;
            _vista.LabelV.Visible = true;
            _vista.TextBoxCargP.Visible = true;
            _vista.TextBoxFechaFiP.Visible = true;
            _vista.TextBoxFechaIP.Visible = true;
            _vista.TextBoxFFirmP.Visible = true;
            _vista.TextBoxMontP.Visible = true;
            _vista.TextBoxRecepP.Visible = true;
            _vista.TextBoxTotalHorasP.Visible = true;
            _vista.TextBoxTP.Visible = true;
            _vista.TextBoxVP.Visible = true;
            _vista.ListaEmpleados.Visible = true;

            #endregion

            #region Desactivar Campos
            _vista.opcion.Visible = false;
            _vista.SeleccionOpcion.Visible = false;
            #endregion
            #endregion

            #region Solicitud Servicio
            if (_vista.opcion.SelectedIndex == 0) // ES BUSQUEDA DE PROPUESTAS EN ESPERA
            {
                #region Propuestas En Espera
                int i = 0;
                int j = 0;
                propuesta = BuscarPropuestasEnEspera();
                for (i = 0; i < propuesta.Count; i++)
                {
                    if (propuesta.ElementAt(i).Titulo.Equals(_vista.SeleccionOpcion.SelectedItem.Text))
                    {

                        _vista.TextBoxCargP.Text = propuesta.ElementAt(i).CargoReceptor;
                        //_vista.LabelEquipP.Text    = propuesta.ElementAt(i).EquipoTrabajo;
                        _vista.TextBoxFechaFiP.Text = propuesta.ElementAt(i).FechaFin.ToString();
                        _vista.TextBoxFechaIP.Text = propuesta.ElementAt(i).FechaInicio.ToString();
                        _vista.TextBoxFFirmP.Text = propuesta.ElementAt(i).FechaFirma.ToString();
                        _vista.TextBoxMontP.Text = propuesta.ElementAt(i).MontoTotal.ToString();
                        _vista.TextBoxRecepP.Text = propuesta.ElementAt(i).NombreReceptor;
                        _vista.TextBoxTotalHorasP.Text = propuesta.ElementAt(i).TotalHoras.ToString();
                        _vista.TextBoxTP.Text = propuesta.ElementAt(i).Titulo;
                        _vista.TextBoxVP.Text = propuesta.ElementAt(i).Version;

                        for (j = 0; j < propuesta.ElementAt(i).EquipoTrabajo.Count; j++)
                        {
                            _vista.ListaEmpleados.Items.Add(propuesta.ElementAt(i).EquipoTrabajo.ElementAt(j).Nombre);
                        }
                    }
                }
                #endregion
            }
        }

        public void LimpiarRegistros()
        {

            _vista.TextBoxVP.Text = "";

            _vista.TextBoxFFirmP.Text = "";

            _vista.TextBoxFechaIP.Text = "";

            _vista.TextBoxFechaFiP.Text = "";

            _vista.TextBoxMontP.Text = "";

            _vista.TextBoxTotalHorasP.Text = "";
        }

        public void AgregarVersion()
        {
            Core.LogicaNegocio.Entidades.Propuesta propuesta = new Core.LogicaNegocio.Entidades.Propuesta();

            propuesta.Version = _vista.TextBoxVP.Text;

            propuesta.FechaFirma = Convert.ToDateTime(_vista.TextBoxFFirmP);

            propuesta.FechaInicio = Convert.ToDateTime(_vista.TextBoxFechaIP.Text);

            propuesta.FechaFin = Convert.ToDateTime(_vista.TextBoxFechaFiP.Text);

            propuesta.MontoTotal = float.Parse(_vista.TextBoxMontP.Text);

            propuesta.TotalHoras = int.Parse(_vista.TextBoxTotalHorasP.Text);

            propuesta = AgregarVersionPropuesta(propuesta);

            LimpiarRegistros();
        }


            #endregion

        /// <summary>
        /// Metodo que busca las propuestas activas y que tengan versiones En espera.
        /// pero solo se trae la ultima version de las propuestas
        /// </summary>
        /// <returns>devuelve objeto de tipo lista de propuestas</returns>
        public IList<Core.LogicaNegocio.Entidades.Propuesta> BuscarPropuestasEnEspera()
        {
            Core.LogicaNegocio.Comandos.ComandoPropuesta.ConsultarPropuestasModificar consultar;

            consultar = FabricaComandosPropuesta.CrearComandoConsultarPropuestasModificar(propuesta);

            propuesta = consultar.Ejecutar();

            return propuesta;
        }


        public Core.LogicaNegocio.Entidades.Propuesta AgregarVersionPropuesta(Core.LogicaNegocio.Entidades.Propuesta propuesta)
        {
            Core.LogicaNegocio.Comandos.ComandoPropuesta.ModificarPropuesta ModificarP;

            ModificarP = Core.LogicaNegocio.Fabricas.FabricaComandosPropuesta.CrearComandoModificarPropuesta(propuesta);

            return ModificarP.Ejecutar();

        }

        #endregion
    }
}
