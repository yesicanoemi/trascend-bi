using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Contacto.ContactoInterface;
using System.Net;
using Core.LogicaNegocio.Fabricas;
using Core.LogicaNegocio.Entidades;

namespace Presentador.Contacto.ContactoPresentador
{
    public class AgregarPresentador
    {
        
        private IAgregarContacto _vista;

        public AgregarPresentador(IAgregarContacto vista)
        {
            _vista = vista;
        }
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

                //   int idCliente = 0;
                //   idCliente = contacto.ClienteContac.IdCliente; 
                //if (idCliente!=0)

                Ingresar(contacto);
            }
            catch (WebException)
            {
                //Aqui se maneja la excepcion en caso de que de error la seccion Web
            }
        }

        public void Ingresar(Core.LogicaNegocio.Entidades.Contacto _contacto)
        {
            Core.LogicaNegocio.Comandos.ComandoContacto.Ingresar ingresar;

            //fábrica que instancia el comando Ingresar.

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

     }
    
}
