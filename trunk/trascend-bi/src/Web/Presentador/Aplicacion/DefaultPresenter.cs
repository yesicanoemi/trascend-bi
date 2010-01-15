﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Fabricas;

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
            Core.LogicaNegocio.Entidades.Usuario user = new Core.LogicaNegocio.Entidades.Usuario();

            user.Login = _vista.Login.Text;

            user.Password = _vista.Password.Text;

            user = ConsultarCredenciales(user);

            if (user.Status == "activo")
            {

                _vista.IngresarSistema();

            }

            else
            {
                //Mensaje de error al usuario
            }

        }

        public Core.LogicaNegocio.Entidades.Usuario ConsultarCredenciales(Core.LogicaNegocio.Entidades.Usuario entidad)
        {

            Core.LogicaNegocio.Entidades.Usuario usuario1 = null;

            Core.LogicaNegocio.Comandos.ComandoUsuario.ConsultarCredenciales comando;

            comando = FabricaComandosUsuario.CrearComandoConsultarCredenciales(entidad);

            usuario1 = comando.Ejecutar();

            return usuario1;
        }

    }
}