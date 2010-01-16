using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Empleado.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Fabricas;
using Core.LogicaNegocio.Comandos;
using System.Net;
using Presentador.Gasto.Contrato;
namespace Presentador.Gasto.Vistas
{
    public class IngresarGastoPresenter
    {
        private IIngresarGasto _vista;

        #region Constructor
        public IngresarGastoPresenter(IIngresarGasto vista)
        {
            _vista = vista;
        }
        #endregion

        #region Evento

        public void ingresarGasto()
        {
            Core.LogicaNegocio.Entidades.Gasto gasto = new Core.LogicaNegocio.Entidades.Gasto();

            gasto.Descripcion = _vista.DescripcionGasto.Text;
            gasto.Estado = _vista.EstadoGasto.Text;
            gasto.FechaGasto = Convert.ToDateTime(_vista.FechaGasto.Text);
            gasto.FechaIngreso = DateTime.Now;
            gasto.Monto = float.Parse(_vista.MontoGasto.Text);
            gasto.Tipo = _vista.TipoGasto.Text;
            if (_vista.PropuestaAsociada.Enabled)
                gasto.IdPropuesta = Int32.Parse(_vista.PropuestaAsociada.SelectedItem.Text);

            Ingresar(gasto);

        }

        #endregion

        #region Comando
        public void Ingresar(Core.LogicaNegocio.Entidades.Gasto gasto)
        {
            Core.LogicaNegocio.Comandos.ComandoGasto.IngresarGasto ingresar; //objeto del comando Ingresar.

            //fábrica que instancia el comando Ingresar.
            ingresar = Core.LogicaNegocio.Fabricas.FabricaComandoGasto.CrearComandoIngresar(gasto);

            ingresar.Ejecutar();
        }
        #endregion


    }
}
