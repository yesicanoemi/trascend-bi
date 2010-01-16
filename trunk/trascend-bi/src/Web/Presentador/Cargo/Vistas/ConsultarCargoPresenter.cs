using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Cargo.Contrato;
using Core.LogicaNegocio.Entidades;

namespace Presentador.Cargo.Vistas
{
    public class ConsultarCargoPresenter
    {
        private IAgregarCargo _vista;
        private Core.LogicaNegocio.Entidades.Cargo cargoRetorno;

        //private CargoController _controlador;

        public ConsultarCargoPresenter(IAgregarCargo laVista)
        {
            _vista = laVista;
        }

        public void ConsultarCargo()
        {
            Core.LogicaNegocio.Entidades.Cargo cargo = new Core.LogicaNegocio.Entidades.Cargo();
            cargo.Nombre = _vista.NombreCargo.Text;

            Core.LogicaNegocio.Comandos.ComandoCargo.Consultar ComandoConsultar;

            ComandoConsultar = Core.LogicaNegocio.Fabricas.FabricaComandoCargo.CrearComandoConsultar( cargo );

            cargoRetorno = ComandoConsultar.Ejecutar();

            _vista.NombreCargo.Text = cargoRetorno.Nombre;
            _vista.DescripcionCargo.Text = cargoRetorno.Descripcion;
            _vista.SueldoMinimo.Text = cargoRetorno.SueldoMinimo.ToString();
            _vista.SueldoMaximo.Text = cargoRetorno.SueldoMaximo.ToString();
            _vista.VigenciaSueldo.Text = cargoRetorno.Vigencia.ToShortDateString().ToString();
        }

        public void EliminarCargo()
        {
            
            Core.LogicaNegocio.Comandos.ComandoCargo.Eliminar ComandoEliminar;

            ComandoEliminar = Core.LogicaNegocio.Fabricas.FabricaComandoCargo.CrearComandoEliminar( cargoRetorno );

            ComandoEliminar.Ejecutar();
            

        }

        public void ModificarCargo()
        {

            Core.LogicaNegocio.Entidades.Cargo cargo = new Core.LogicaNegocio.Entidades.Cargo();

            cargo.Nombre = _vista.NombreCargo.Text;
            cargo.Descripcion = _vista.DescripcionCargo.Text;
            cargo.SueldoMinimo = float.Parse(_vista.SueldoMinimo.Text);
            cargo.SueldoMaximo = float.Parse(_vista.SueldoMaximo.Text);
            cargo.Vigencia = DateTime.Parse(_vista.VigenciaSueldo.Text);

            Core.LogicaNegocio.Comandos.ComandoCargo.Modificar ComandoModificar;

            ComandoModificar = Core.LogicaNegocio.Fabricas.FabricaComandoCargo.CrearComandoModificar( cargo );

            ComandoModificar.Ejecutar();

        }
    
    }
}
