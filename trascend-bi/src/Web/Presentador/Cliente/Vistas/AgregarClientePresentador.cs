using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.Web;
using System.Configuration;
using Presentador.Base;
using Presentador.Cliente.Vistas;
using Presentador.Cliente.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Fabricas;
using Core.LogicaNegocio.Comandos;
using Core.LogicaNegocio.Excepciones.Cliente.LogicaNegocio;


namespace Presentador.Cliente.Vistas
{
    public class AgregarClientePresentador : PresentadorBase
    {

        private IAgregarCliente _vista;
        private string campoVacio = "";
        string _RifAux;

        #region Constructor
        public AgregarClientePresentador(IAgregarCliente vista)
        {
            _vista = vista;
        }
        #endregion

        #region metodos

        public void IngersarCliente()
        {
            Core.LogicaNegocio.Entidades.Cliente cliente = new Core.LogicaNegocio.Entidades.Cliente();
            try
            {
                cliente.Direccion = new Direccion();

                cliente.Telefono = new TelefonoTrabajo[3];

                cliente.Telefono[0] = new TelefonoTrabajo();           
                cliente.Telefono[0].Codigoarea = int.Parse((string)_vista.CodigoTrabajoCliente.Text);
                cliente.Telefono[0].Numero = int.Parse((string)_vista.TelefonoTrabajoCliente.Text);
                cliente.Telefono[0].Tipo = "Trabajo";

                if (!_vista.CodCelular.Text.Equals("") && !_vista.TelefonoCelular.Text.Equals(""))
                {
                    cliente.Telefono[1] = new TelefonoTrabajo();
                    cliente.Telefono[1].Codigoarea = int.Parse((string)_vista.CodCelular.Text);
                    cliente.Telefono[1].Numero = int.Parse((string)_vista.TelefonoCelular.Text);
                    cliente.Telefono[1].Tipo = "Celular";
                }

                if (!_vista.CodFax.Text.Equals("") && !_vista.TelefonoFax.Text.Equals(""))
                {
                    cliente.Telefono[2] = new TelefonoTrabajo();
                    cliente.Telefono[2].Codigoarea = int.Parse((string)_vista.CodFax.Text);
                    cliente.Telefono[2].Numero = int.Parse((string)_vista.TelefonoFax.Text);
                    cliente.Telefono[2].Tipo = "Fax";
                }

                _RifAux = _vista.TipoRif.SelectedValue.ToString() + " - " +_vista.rifCliente.Text.ToString();
                
                cliente.Rif = _RifAux;
                
                cliente.Nombre = _vista.NombreCliente.Text;

                cliente.Direccion = new Core.LogicaNegocio.Entidades.Direccion();

                cliente.Direccion.Avenida = _vista.CalleAvenidaCliente.Text;

                cliente.Direccion.Urbanizacion = _vista.UrbanizacionCliente.Text;

                cliente.Direccion.Edif_Casa = _vista.EdificioCasaCliente.Text;

                cliente.Direccion.Oficina = _vista.PisoApartamentoCliente.Text;

                cliente.Direccion.Ciudad = _vista.CiudadCliente.Text;

                cliente.AreaNegocio = _vista.AreaNegocioCliente.Text;

                Ingresar(cliente);

                limpiarRegistro();
            }
            catch (WebException e)
            {
                _vista.Pintar(ManagerRecursos.GetString("codigoErrorWeb"),
                    ManagerRecursos.GetString("mensajeErrorWeb"), e.Source, e.Message + "\n " + e.StackTrace);
                _vista.DialogoVisible = true;

            }
            catch (AgregarClienteLNException e)
            {
                _vista.Pintar(ManagerRecursos.GetString("codigoErrorIngresar"),
                    ManagerRecursos.GetString("mensajeErrorIngresar"), e.Source, e.Message + "\n " + e.StackTrace);
                _vista.DialogoVisible = true;

            }
            catch (Exception e)
            {
                _vista.Pintar(ManagerRecursos.GetString("codigoErrorGeneral"),
                    ManagerRecursos.GetString("mensajeErrorGeneral"), e.Source, e.Message + "\n " + e.StackTrace);
                _vista.DialogoVisible = true;

            }

            _vista.PintarInformacion(ManagerRecursos.GetString("ClienteOperacionExitosa"), "confirmacion");
            _vista.InformacionVisible = true;

            limpiarRegistro();

        }


        public void limpiarRegistro()
        {
            _vista.AreaNegocioCliente.Text = campoVacio;
            _vista.CalleAvenidaCliente.Text = campoVacio;
            _vista.CiudadCliente.Text = campoVacio;
            _vista.EdificioCasaCliente.Text = campoVacio;
            _vista.NombreCliente.Text = campoVacio;
            _vista.PisoApartamentoCliente.Text = campoVacio;
            _vista.rifCliente.Text = campoVacio;
            _vista.UrbanizacionCliente.Text = campoVacio;
            _vista.TelefonoTrabajoCliente.Text = campoVacio;
            _vista.CodigoTrabajoCliente.Text = campoVacio;
            _vista.TelefonoCelular.Text = campoVacio;
            _vista.CodCelular.Text = campoVacio;
            _vista.TelefonoFax.Text = campoVacio;
            _vista.CodFax.Text = campoVacio;
        }
        #endregion

        #region Comando

        public void Ingresar(Core.LogicaNegocio.Entidades.Cliente cliente)
        {
            Core.LogicaNegocio.Comandos.ComandoCliente.Ingresar ingresar; //objeto del comando Ingresar.

            //fábrica que instancia el comando Ingresar.
            ingresar = Core.LogicaNegocio.Fabricas.FabricaComandosCliente.CrearComandoIngresar(cliente);

            ingresar.Ejecutar();

        }

        #endregion

    }

}

