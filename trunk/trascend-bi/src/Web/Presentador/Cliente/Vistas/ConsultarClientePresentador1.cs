using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Cliente.Contrato;
using Core.LogicaNegocio.Fabricas;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Comandos.ComandoCliente;

namespace Presentador.Cliente.Vistas
{
    /*public class ConsultarClientePresentador
    {

        private IConsultarCliente _vista;
        private IList<Core.LogicaNegocio.Entidades.Cliente> cliente;

        #region constructor
        public ConsultarClientePresentador()
        { }
        #endregion
             
        public ConsultarClientePresentador(IConsultarCliente vista)
        {
            _vista = vista;
        }
        
        public void Onclick()
        {
        
        }

        public int opcionBusqueda()
        {
            return _vista.opcion.SelectedIndex;
        }


        public void BotonSeleccionTipo()
        {
                _vista.opcion.Visible = false;
                _vista.TipoConsulta.Visible = false;
                _vista.Seleccion.Visible = true;
                _vista.SeleccionOpcion.Visible= true;
                _vista.SeleccionAreaCliente.Visible = false;
                _vista.SeleccionArea.Visible = false;

                #region SolicitudServicios

                    if (_vista.opcion.SelectedIndex == 0) // Nombre de cliente
                    {
                        #region buscar por nombre
                            int i = 0;
                            
                            cliente = BuscarNombre(); //busco todo los nombres de cliente

                           /* for (i = 0; i < cliente.Count; i++)
                            {

                                _vista.SeleccionOpcion.Items.Add(cliente.ElementAt(i).Nombre);

                            }

                           // _vista.SeleccionOpcion.DataBind();
                      
                    }
                    
                   

                    if (_vista.opcion.SelectedIndex == 1) // Area de Negcocio
                    {
                        #region area de negocio
                            
                            int i = 0;
                            
                            cliente = BuscarPorAreaNegocio();
                            
                           /* for (i = 0; i < cliente.Count; i++)
                            {                                
                                _vista.SeleccionOpcion.Items.Add(cliente.ElementAt(i).AreaNegocio);

                            }
                            
                            _vista.SeleccionOpcion.DataBind();
                        
                        #endregion
                    }

                             
                
            

           
        }

        public void BotonAccionConsulta()
        {
            #region activar Campos

           /* _vista.AreaNegocio.Visible = true;
            _vista.AreaNegocioCliente.Visible = true;
            _vista.CalleAvenida.Visible = true;
            _vista.CalleAvenidaCliente.Visible = true;
            _vista.Ciudad.Visible = true;
            _vista.CiudadCliente.Visible = true;
            _vista.CodTelefonoCliente.Visible = true;
            _vista.Contacto.Visible = true;
            _vista.ContactoCliente.Visible = true;
            _vista.EdificioCasa.Visible = true;
            _vista.EdificioCasaCliente.Visible = true;
            _vista.Nombre.Visible = true;
            _vista.NombreCliente.Visible = true;            
            _vista.PisoApartamento.Visible = true;
            _vista.PisoApartamentoCliente.Visible = true;
            _vista.Rif.Visible = true;
            _vista.RifCliente.Visible = true;                        
            _vista.Telefono.Visible = true;
            _vista.TelefonoCliente.Visible = true;
            //_vista.TipoConsulta.Visible = true;
            _vista.Urbanizacion.Visible = true;
            _vista.UrbanizacionCliente.Visible = true;
            

            #endregion

            #region campos desactivados
            _vista.opcion.Visible = false;
          /*  _vista.SeleccionOpcion.Visible = false;
            _vista.TipoConsulta.Visible = false;
            _vista.SeleccionAreaCliente.Visible = false;
            _vista.SeleccionArea.Visible = false;
            
            
            #endregion

           
                #region busuqueda por nombre

              /*  int i = 0;
                int j = 0;
                cliente = BuscarNombre();
                for (i = 0; i < cliente.Count; i++ )
                {
                    if (cliente.ElementAt(i).Nombre.Equals(_vista.SeleccionAreaCliente.SelectedItem.Text))
                    {
                        
                        _vista.AreaNegocioCliente.Text = cliente.ElementAt(i).AreaNegocio;

                        _vista.CalleAvenidaCliente.Text = cliente.ElementAt(i).CalleAvenidad;

                        _vista.CiudadCliente.Text = cliente.ElementAt(i).Ciudad;

                        _vista.CodTelefonoCliente.Text = cliente.ElementAt(i).CodigoTrabajo;


                        _vista.EdificioCasaCliente.Text = cliente.ElementAt(i).EdificioCasa;

                        _vista.NombreCliente.Text = cliente.ElementAt(i).Nombre;

                        _vista.PisoApartamentoCliente.Text = cliente.ElementAt(i).PisoApartamento;

                        _vista.RifCliente.Text = cliente.ElementAt(i).Rif;

                        _vista.TelefonoCliente.Text = cliente.ElementAt(i).TelefonoTrabajo;

                        _vista.UrbanizacionCliente.Text = cliente.ElementAt(i).Urbanizacion;

                        _vista.CodTelefonoCliente.Text = cliente.ElementAt(i).CodigoTrabajo;


                        for (j = 0; j < cliente.ElementAt(i).Contacto.Count; j++ )
                        {
                            _vista.ContactoCliente.Items.Add
                           
                           (string.Concat(cliente.ElementAt(i).Contacto.ElementAt(j).Nombre + ", ", 
                           cliente.ElementAt(i).Contacto.ElementAt(j).Apellido));

                        }                          
                    }

                }
                #endregion
            

            
        }

        

        public void BotonSeleccionCliente()
        {
            #region area de negocio
                    
                    _vista.opcion.Visible = false;

                    _vista.TipoConsulta.Visible = false;

                    _vista.Seleccion.Visible = false;

                    _vista.SeleccionOpcion.Visible = false;

                    _vista.SeleccionAreaCliente.Visible = true;

                    _vista.SeleccionArea.Visible = true;

                    int i = 0;

            cliente = BuscarNombre();

            for (i = 0; i < cliente.Count; i++)
            {
                if (cliente.ElementAt(i).AreaNegocio.Equals(_vista.SeleccionOpcion.SelectedItem.Text))
                {
                    _vista.SeleccionAreaCliente.Items.Add(cliente.ElementAt(i).Nombre);
                }

            }

            _vista.SeleccionAreaCliente.DataBind();

            #endregion
        }
       
        public IList<Core.LogicaNegocio.Entidades.Cliente> BuscarNombre()
        {
            Core.LogicaNegocio.Comandos.ComandoCliente.Consultar consultar;
           
            consultar = FabricaComandosCliente.CrearComandoConsultar(cliente);
            
            cliente = consultar.ejecutar();
            
            return cliente;

        }
        
        public IList<Core.LogicaNegocio.Entidades.Cliente> BuscarPorAreaNegocio()
        {
            #region logica

                Core.LogicaNegocio.Comandos.ComandoCliente.ConsultarAreaNegocio consultar;

                consultar = FabricaComandosCliente.CrearComandoConsultarAreaNegocio(cliente);

                cliente = consultar.Ejecutar();
                
                return cliente;
            
            #endregion
        }

        public void BotonAccionConsultaNombre()
        {
            #region activar Campos

           /* _vista.AreaNegocio.Visible = true;
            _vista.AreaNegocioCliente.Visible = true;
            _vista.CalleAvenida.Visible = true;
            _vista.CalleAvenidaCliente.Visible = true;
            _vista.Ciudad.Visible = true;
            _vista.CiudadCliente.Visible = true;
            _vista.CodTelefonoCliente.Visible = true;
            _vista.Contacto.Visible = true;
            _vista.ContactoCliente.Visible = true;
            _vista.EdificioCasa.Visible = true;
            _vista.EdificioCasaCliente.Visible = true;
            _vista.Nombre.Visible = true;
            _vista.NombreCliente.Visible = true;
            _vista.PisoApartamento.Visible = true;
            _vista.PisoApartamentoCliente.Visible = true;
            _vista.Rif.Visible = true;
            _vista.RifCliente.Visible = true;
            _vista.Telefono.Visible = true;
            _vista.TelefonoCliente.Visible = true;
            //_vista.TipoConsulta.Visible = true;
            _vista.Urbanizacion.Visible = true;
            _vista.UrbanizacionCliente.Visible = true;


            #endregion

            #region campos desactivados
            _vista.opcion.Visible = false;
            _vista.SeleccionOpcion.Visible = false;
            _vista.TipoConsulta.Visible = false;
            _vista.Seleccion.Visible = false;
            _vista.SeleccionAreaCliente.Visible = false;
            _vista.SeleccionArea.Visible = false;


            #endregion


            #region busuqueda por nombre

            int i = 0;
            int j = 0;
            cliente = BuscarNombre();
            for (i = 0; i < cliente.Count; i++)
            {
                if (cliente.ElementAt(i).Nombre.Equals(_vista.SeleccionOpcion.SelectedItem.Text))
                {

                    _vista.AreaNegocioCliente.Text = cliente.ElementAt(i).AreaNegocio;

                    _vista.CalleAvenidaCliente.Text = cliente.ElementAt(i).CalleAvenidad;

                    _vista.CiudadCliente.Text = cliente.ElementAt(i).Ciudad;

                    _vista.CodTelefonoCliente.Text = cliente.ElementAt(i).CodigoTrabajo;


                    _vista.EdificioCasaCliente.Text = cliente.ElementAt(i).EdificioCasa;

                    _vista.NombreCliente.Text = cliente.ElementAt(i).Nombre;

                    _vista.PisoApartamentoCliente.Text = cliente.ElementAt(i).PisoApartamento;

                    _vista.RifCliente.Text = cliente.ElementAt(i).Rif;

                    _vista.TelefonoCliente.Text = cliente.ElementAt(i).TelefonoTrabajo;

                    _vista.UrbanizacionCliente.Text = cliente.ElementAt(i).Urbanizacion;

                    _vista.CodTelefonoCliente.Text = cliente.ElementAt(i).CodigoTrabajo;


                    for (j = 0; j < cliente.ElementAt(i).Contacto.Count; j++)
                    {
                        _vista.ContactoCliente.Items.Add

                       (string.Concat(cliente.ElementAt(i).Contacto.ElementAt(j).Nombre + ", ",
                       cliente.ElementAt(i).Contacto.ElementAt(j).Apellido));

                    }
                }

            }
            #endregion



        }
        public void CambiarVista(int index)
        {
            _vista.MultiViewConsulta.ActiveViewIndex = index;


        }
            
    }*/

}
