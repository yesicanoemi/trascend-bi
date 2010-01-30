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
                if (_vista.CheckBoxFax.Checked)
                {
                    contacto.TelefonoDeTrabajo.Tipo = "Fax";
                }
                else
                {
                    contacto.TelefonoDeTrabajo.Tipo = "Trabajo";
                }

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

            Core.LogicaNegocio.Comandos.ComandoCliente.Consultar ConsultarClientes;
            IList<Core.LogicaNegocio.Entidades.Cliente> Clientes = new List<Core.LogicaNegocio.Entidades.Cliente>();
            ConsultarClientes = Core.LogicaNegocio.Fabricas.FabricaComandosCliente.CrearComandoConsultar();
            Clientes = ConsultarClientes.ejecutar();

            ingresar = Core.LogicaNegocio.Fabricas.FabricaComandosContacto.CrearComandoIngresar
                (_contacto,Clientes.ElementAt(_vista.DropDownClientes.SelectedIndex).IdCliente);

            //try
            //{    
            //ejecuta el comando.
            ingresar.Ejecutar();
        }

        public void LlenarClientes()
        {
            Core.LogicaNegocio.Comandos.ComandoCliente.Consultar ConsultarClientes;
            IList<Core.LogicaNegocio.Entidades.Cliente> Clientes = new List<Core.LogicaNegocio.Entidades.Cliente>();
            ConsultarClientes = Core.LogicaNegocio.Fabricas.FabricaComandosCliente.CrearComandoConsultar();
            Clientes=ConsultarClientes.ejecutar();
            int i=0;
            while (i<Clientes.Count())
            {
                _vista.DropDownClientes.Items.Add(Clientes.ElementAt(i).Nombre);
                i++;
            }
        }
     }
    
}
