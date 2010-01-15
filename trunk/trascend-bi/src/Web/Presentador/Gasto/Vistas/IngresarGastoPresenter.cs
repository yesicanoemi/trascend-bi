using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Empleado.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Fabricas;
using Core.LogicaNegocio.Comandos;
using System.Net;
namespace Presentador.Gasto.Vistas
{
    public class IngresarGastoPresenter
    {
        #region Constructor

        #endregion

        #region Evento

        public void ingresarGasto()
        {
            Core.LogicaNegocio.Entidades.Gasto gasto= new Core.LogicaNegocio.Entidades.Gasto();

            gasto.Codigo = 3;
            gasto.Descripcion = "describiendo";
            gasto.Estado = "Gastado";
            gasto.FechaGasto = DateTime.Now;
            gasto.FechaIngreso = DateTime.Now;
            gasto.Monto = 12;
            gasto.Tipo = "almuerzo";

            Ingresar(gasto);

        }

        #endregion

        #region Comando
        public void Ingresar(Core.LogicaNegocio.Entidades.Gasto gasto)
        {
            Core.LogicaNegocio.Comandos.ComandoGasto.IngresarGasto ingresar; //objeto del comando Ingresar.

            //fábrica que instancia el comando Ingresar.
            ingresar = Core.LogicaNegocio.Fabricas.FabricaComandoGasto.CrearComandoIngresar(gasto);

            //try
            //{    
            //ejecuta el comando.
            ingresar.Ejecutar();
        }
        #endregion


    }
}
