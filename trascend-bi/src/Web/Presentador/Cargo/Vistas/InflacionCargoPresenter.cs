using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Cargo.Contrato;
using Core.LogicaNegocio.Entidades;
using System.Data;
using Core.AccesoDatos.SqlServer;
using Core.LogicaNegocio.Entidades;

namespace Presentador.Cargo.Vistas
{
    public class InflacionCargoPresenter
    {

        private IInflacionCargo _vista;

        /// <summary>
        /// Constructor del Presentador de la pagina de Inflacion
        /// </summary>
        /// <param name="laVista">La vista de la interfaz</param>
        public InflacionCargoPresenter(IInflacionCargo laVista)
        {
            _vista = laVista;
            CargarTabla();
        }

        #region Métodos
        /// <summary>
        /// Metodo para cargar los elementos de la tabla
        /// </summary>
        public void CargarTabla()
        {
            Core.LogicaNegocio.Comandos.ComandoCargo.ConsultarTabla ComandoConsultarTabla;

            ComandoConsultarTabla = Core.LogicaNegocio.Fabricas.FabricaComandoCargo.CrearComandoConsultarTabla();

            List<Core.LogicaNegocio.Entidades.Cargo> listaCargos = ComandoConsultarTabla.Ejecutar();

            for (int i = 0; i < listaCargos.Count; i++)
            {
                  listaCargos[i].SueldoMaximoConInflacion = listaCargos[i].SueldoMaximo * (1 + float.Parse(_vista.Inflacion.Text) / 100);
                  listaCargos[i].SueldoMinimoConInflacion = listaCargos[i].SueldoMinimo * (1 + float.Parse(_vista.Inflacion.Text) / 100);
            }

            _vista.TablaSueldos.DataSource = listaCargos;
            _vista.TablaSueldos.DataBind();
        }
        #endregion
    }
}
