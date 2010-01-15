using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Contacto.ContactoInterface;
using System.Net;

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
            string x = _vista.TextBoxTelfCelular.Text;
            _vista.TextBoxTelfCelular.Text = _vista.TextBoxTelfOficina.Text;
            _vista.TextBoxTelfOficina.Text = _vista.TextBoxApellidoContacto.Text;
            _vista.TextBoxApellidoContacto.Text = _vista.TextBoxNombreContacto.Text;
            _vista.TextBoxNombreContacto.Text = x;
        }
        public void IngresarContacto()
        {
            Core.LogicaNegocio.Entidades.Contacto contacto = new Core.LogicaNegocio.Entidades.Contacto();
            try
            {
                contacto.Nombre = _vista.TextBoxNombreContacto.Text;
                contacto.Apellido = _vista.TextBoxApellidoContacto.Text;
                contacto.AreaDeNegocio = _vista.DropDownAreaNegocio.Text;
                contacto.Cargo = _vista.DropDownCargoContacto.Text;
 //               contacto.TelefonoDeCelular = _vista.TextBoxTelfCelular;
 //               contacto.TelefonoDeTrabajo = _vista.TextBoxTelfOficina;

 //               IngresarContacto(contacto);
            }
            catch (WebException e)
            {
                //Aqui se maneja la excepcion en caso de que de error la seccion Web
            }
        }
     }
    
}
