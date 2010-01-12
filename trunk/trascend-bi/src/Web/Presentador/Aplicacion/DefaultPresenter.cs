using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presentador.Aplicacion
{
    public class DefaultPresenter
    {
        private IDefaultPresenter _vista;
        public DefaultPresenter(IDefaultPresenter vista)
        {
            _vista = vista;
        
        }
        public void OnBotonAceptar()
        {
            /* Se implementara cuando la BD este lista 
             
             Usuario user = new Usuario();

             user.Login = _vista.Login.Text;

             user.Password = _vista.Password.Text;

             user = ConsultarCredenciales(user);
         
             if (user != null)
             {
             
                 _vista.IngresarSistema();
             
             }
            
             else
             {
                //Mensaje de error al usuario
             }
            
             */

            _vista.IngresarSistema();
        
        }

        /* Desarrollo 3 en prueba
       
        public Usuario ConsultarCredenciales(Usuario entidad)
        {

            Usuario usuario1 = null;

            ConsultarCredenciales comando;

            comando = FabricaComandosUsuario.CrearComandoConsultarCredenciales(entidad);

            usuario1 = comando.Ejecutar();

            return usuario1;
        }
        */
    }
}
