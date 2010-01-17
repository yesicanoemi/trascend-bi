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
            CargoSQLServer bd = new CargoSQLServer();
            List<Core.LogicaNegocio.Entidades.Cargo> listaCargos = new List<Core.LogicaNegocio.Entidades.Cargo>();
            IList<Entidad> listaEntidades = bd.ConsultarCargos();

            for (int i = 0; i < listaEntidades.Count; i++)
            {
                listaCargos.Add((Core.LogicaNegocio.Entidades.Cargo)listaEntidades[i]);
            }

            _vista.TablaSueldos.DataSource = listaCargos;
            _vista.TablaSueldos.DataBind();
        }
    }
}
