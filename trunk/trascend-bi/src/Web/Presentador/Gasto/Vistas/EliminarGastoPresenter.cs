using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Fabricas;
using Core.LogicaNegocio.Comandos;
using System.Net;
using Presentador.Gasto.Contrato;


namespace Presentador.Gasto.Vistas
{
    public class EliminarGastoPresenter
    {
        private IEliminarGasto _vista;


        #region Constructor
        public EliminarGastoPresenter(IEliminarGasto vista)
        {
            _vista = vista;
        }
        #endregion

        #region Limpieza de Pagina

        public void limpiar()
        {

        }

        #endregion

        #region Evento

        public void eliminarGasto()
        {
            Core.LogicaNegocio.Entidades.Gasto gasto = new Core.LogicaNegocio.Entidades.Gasto();

            //gasto.Codigo = _vista.DescripcionGasto.Text;

            Eliminar(gasto);

        }

        #endregion

        #region Comando
        public void Eliminar(Core.LogicaNegocio.Entidades.Gasto gasto)
        {
            Core.LogicaNegocio.Comandos.ComandoGasto.EliminarGasto eliminar; //objeto del comando Ingresar.

            //fábrica que instancia el comando Eliminar.
            eliminar = Core.LogicaNegocio.Fabricas.FabricaComandoGasto.CrearComandoEliminar(gasto);

            eliminar.Ejecutar();
            limpiar();
        }
        #endregion

    }
}
