using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using Presentador.Cliente.ClientePresentador;
using Presentador.Cliente.Vistas;
using Presentador.Cliente.Contrato;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.Fabricas;
using Core.LogicaNegocio.Comandos;


namespace Presentador.Cliente.Vistas
{
    public class AgregarClientePresentador
    {
        
            private IAgregarCliente _vista;
            private string campoVacio = "";

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
                    cliente.Rif = _vista.rifCliente.Text;
                    cliente.Nombre = _vista.NombreCliente.Text;
                    cliente.CalleAvenidad = _vista.CalleAvenidaCliente.Text;
                    cliente.Urbanizacion = _vista.UrbanizacionCliente.Text;
                    cliente.EdificioCasa = _vista.EdificioCasaCliente.Text;
                    cliente.PisoApartamento = _vista.PisoApartamentoCliente.Text;
                    cliente.Ciudad = _vista.CiudadCliente.Text;
                    cliente.AreaNegocio = _vista.AreaNegocioCliente.Text;
                    cliente.TelefonoTrabajo = _vista.TelefonoTrabajoCliente.Text;
                    cliente.CodigoTrabajo = _vista.CodigoTrabajoCliente.Text;
                    Ingresar(cliente);
                    limpiarRegistro();
                    
                    
                    
                    

                    
                }
                catch(WebException e)
                {

                }

            }
            public void limpiarRegistro ()
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
                                    
        }

            #endregion
            #region Comando

        public void Ingresar(Core.LogicaNegocio.Entidades.Cliente cliente)
        {
            Core.LogicaNegocio.Comandos.ComandoCliente.Ingresar ingresar;
            
            ingresar= Core.LogicaNegocio.Fabricas.FabricaComandosCliente.CrearComandoIngresar(cliente);

            ingresar.Ejecutar();

        }

        #endregion
            
        }
       
    }

