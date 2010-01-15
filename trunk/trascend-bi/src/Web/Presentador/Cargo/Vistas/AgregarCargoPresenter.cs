using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Cargo.Contrato;
using Core.LogicaNegocio;


namespace Presentador.Cargo.Vistas
{
    public class AgregarCargoPresenter
    {
        private IAgregarCargo _vista;
        //private CargoController _controlador;

        public AgregarCargoPresenter(IAgregarCargo laVista)
        {
            _vista = laVista;
        }

        public void IngresarCargo()
        {
            Core.LogicaNegocio.Entidades.Cargo cargo = new Core.LogicaNegocio.Entidades.Cargo();
            
            cargo.Nombre = _vista.NombreCargo.Text;
            cargo.Descripcion = _vista.DescripcionCargo.Text;
            cargo.SueldoMinimo = float.Parse(_vista.SueldoMinimo.Text);
            cargo.SueldoMaximo = float.Parse(_vista.SueldoMaximo.Text);
            //cargo.Vigencia = _vista.VigenciaSueldo.Date;
            

            Core.LogicaNegocio.Comandos.ComandoCargo.Ingresar ComandoIngresar;

            ComandoIngresar = Core.LogicaNegocio.Fabricas.FabricaComandoCargo.CrearComandoIngresar( cargo );

            ComandoIngresar.Ejecutar();


        }
    }
}
