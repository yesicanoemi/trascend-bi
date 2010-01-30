namespace Core.LogicaNegocio.Entidades
{
    using System;
    using System.Collections.Generic;
    using Core.LogicaNegocio.Fabricas;
    using Core.LogicaNegocio.Telefonos;

    public class TelefonoCelular: Telefono
    {
        private int codigocel;
        
        private string tipo;

        public virtual int Codigocel
        {
            get
            {
                return codigocel;
            }

            set
            {
                codigocel = value;
            }
        }

        public virtual string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

    }
}