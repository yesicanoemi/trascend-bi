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
     /*       string x = _vista.TextBoxTelfCelular.Text;
            _vista.TextBoxTelfCelular.Text = _vista.TextBoxTelfOficina.Text;
            _vista.TextBoxTelfOficina.Text = _vista.TextBoxApellidoContacto.Text;
            _vista.TextBoxApellidoContacto.Text = _vista.TextBoxNombreContacto.Text;
            _vista.TextBoxNombreContacto.Text = x; */

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
                    contacto.TelefonoDeTrabajo.Tipo = "Oficina";
                }

                Ingresar(contacto);
            }
            catch (WebException e)
            {
                //Aqui se maneja la excepcion en caso de que de error la seccion Web
            }
        }

        public void Ingresar(Core.LogicaNegocio.Entidades.Contacto _contacto)
        {
            Core.LogicaNegocio.Comandos.ComandoContacto.Ingresar ingresar;

            //fábrica que instancia el comando Ingresar.
            ingresar = Core.LogicaNegocio.Fabricas.FabricaComandosContacto.CrearComandoIngresar(_contacto);

            //try
            //{    
            //ejecuta el comando.
            ingresar.Ejecutar();
        }
     }
    
}
