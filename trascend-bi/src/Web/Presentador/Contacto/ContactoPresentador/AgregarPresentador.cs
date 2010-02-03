using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Contacto.ContactoInterface;
using System.Net;
using Core.LogicaNegocio.Excepciones;
using System.Resources;
using Core.LogicaNegocio.Fabricas;
using Core.LogicaNegocio.Entidades;
using Presentador.Base;

namespace Presentador.Contacto.ContactoPresentador
{
    public class AgregarPresentador: PresentadorBase
    {
        #region Propiedades

        private IAgregarContacto _vista;

        #endregion

        #region Constructor

        public AgregarPresentador(IAgregarContacto vista)
        {
            _vista = vista;
        }

        #endregion

        #region Metodos

        public void Onclick()
        {
            IngresarContacto();
        }
        public void IngresarContacto()
        {
            Core.LogicaNegocio.Entidades.Contacto contacto = new Core.LogicaNegocio.Entidades.Contacto();
            Core.LogicaNegocio.Entidades.Cliente cliente = new Core.LogicaNegocio.Entidades.Cliente();
         

            try
            {
                contacto.Nombre = _vista.TextBoxNombreContacto.Text;
                contacto.Apellido = _vista.TextBoxApellidoContacto.Text;
                contacto.AreaDeNegocio = _vista.TextBoxAreaNegocio.Text;
                contacto.Cargo = _vista.TextBoxCargoContacto.Text;
                contacto.TelefonoDeCelular.Codigocel = int.Parse(_vista.TextBoxCodCelular.Text);
                contacto.TelefonoDeCelular.Numero = int.Parse(_vista.TextBoxTelfCelular.Text);
                contacto.TelefonoDeTrabajo.Numero = int.Parse(_vista.TextBoxTelfOficina.Text);
                contacto.TelefonoDeTrabajo.Codigoarea = int.Parse(_vista.TextBoxCodOficina.Text);

              
                cliente.Nombre = _vista.Valor.Text;

                IList<Core.LogicaNegocio.Entidades.Cliente> listaCliente = ConsultarClienteNombre(cliente);

                contacto.ClienteContac = listaCliente[0];

                Ingresar(contacto);
            }
            catch (WebException e)
            {

                _vista.Pintar(ManagerRecursos.GetString("codigoErrorWeb"),
                    ManagerRecursos.GetString("mensajeErrorWeb"), e.Source, e.Message +
                                                                "\n " + e.StackTrace);
                _vista.DialogoVisible = true;

            }
            catch (ConsultarException e)
            {
                _vista.Pintar(ManagerRecursos.GetString("codigoErrorConsultar"),
                    ManagerRecursos.GetString("mensajeErrorConsultar"), e.Source, e.Message +
                                                                "\n " + e.StackTrace);
                _vista.DialogoVisible = true;

            }
            catch (Exception e)
            {
                _vista.Pintar(ManagerRecursos.GetString("codigoErrorGeneral"),
                    ManagerRecursos.GetString("mensajeErrorGeneral"), e.Source, e.Message +
                                                                "\n " + e.StackTrace);
                _vista.DialogoVisible = true;

            }
        }

        #endregion

        #region Comandos

        public void Ingresar(Core.LogicaNegocio.Entidades.Contacto _contacto)
        {
            bool imprime = true;
            Core.LogicaNegocio.Comandos.ComandoContacto.Ingresar ingresar;

            Core.LogicaNegocio.Comandos.ComandoContacto.ConsultarContactoNombreApellido ConsultarContacto;

             IList<Core.LogicaNegocio.Entidades.Contacto> Contactos = 
                 new List<Core.LogicaNegocio.Entidades.Contacto>();

             ConsultarContacto= Core.LogicaNegocio.Fabricas.FabricaComandosContacto.
                 CrearComandoConsultarContactoNombreApellido(_contacto);

             Contactos = ConsultarContacto.Ejecutar();

             if (Contactos.Count == 0)
             {

                 ingresar = Core.LogicaNegocio.Fabricas.FabricaComandosContacto.CrearComandoIngresar(_contacto);

                 ingresar.Ejecutar();

                 if (imprime == true)
                 {
                     _vista.PintarInformacion(ManagerRecursos.GetString
                     ("MensajeContactoAgregado"), "mensajes");
                     _vista.InformacionVisible = true;
                 }

             }

             else
             {
                 if (imprime == true)
                 {
                     _vista.PintarInformacion2(ManagerRecursos.GetString
                     ("MensajeContactoExistente"), "mensajes");
                     _vista.InformacionVisible2 = true;
                 }

             }
        }


        public IList<Core.LogicaNegocio.Entidades.Cliente>
                            ConsultarClienteNombre(Core.LogicaNegocio.Entidades.Cliente entidad)
        {
            IList<Core.LogicaNegocio.Entidades.Cliente> listaCliente = null;

            Core.LogicaNegocio.Comandos.ComandoCliente.ConsultarNombre comando;

            comando = FabricaComandosCliente.CrearComandoConsultarNombre(entidad);

            listaCliente = comando.ejecutar();

            return listaCliente;
        }

        #endregion
    }

}
