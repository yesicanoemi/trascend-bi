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

        public InflacionCargoPresenter(IInflacionCargo laVista)
        {
            _vista = laVista;
            CargarTabla();
        }

        public void CargarTabla()
        {
  /*          CargoSQLServer bd = new CargoSQLServer();
            List<Core.LogicaNegocio.Entidades.Cargo> listaCargos = new List<Core.LogicaNegocio.Entidades.Cargo>();
            IList<Entidad> listaEntidades = bd.ConsultarCargos();
            Core.LogicaNegocio.Entidades.Cargo cargo; */

            Core.LogicaNegocio.Comandos.ComandoCargo.ConsultarTabla ComandoConsultarTabla;

            ComandoConsultarTabla = Core.LogicaNegocio.Fabricas.FabricaComandoCargo.CrearComandoConsultarTabla();

            List<Core.LogicaNegocio.Entidades.Cargo> listaCargos = ComandoConsultarTabla.Ejecutar();

            for (int i = 0; i < listaCargos.Count; i++)
            {
           //     cargo = (Core.LogicaNegocio.Entidades.Cargo)listaEntidades[i];
         //       cargo.SueldoMaximoConInflacion = cargo.SueldoMaximo * (1 + float.Parse(_vista.Inflacion.Text)/100);
           //     cargo.SueldoMinimoConInflacion = cargo.SueldoMinimo * (1 + float.Parse(_vista.Inflacion.Text)/100);
    //            listaCargos.Add(cargo);

                  listaCargos[i].SueldoMaximoConInflacion = listaCargos[i].SueldoMaximo * (1 + float.Parse(_vista.Inflacion.Text) / 100);
                  listaCargos[i].SueldoMinimoConInflacion = listaCargos[i].SueldoMinimo * (1 + float.Parse(_vista.Inflacion.Text) / 100);
            }

            _vista.TablaSueldos.DataSource = listaCargos;
            _vista.TablaSueldos.DataBind();
        }
    }
}
