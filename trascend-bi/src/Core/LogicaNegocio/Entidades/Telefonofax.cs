namespace Core.LogicaNegocio.Entidades
{
    using System;
    using System.Collections.Generic;
    using Core.LogicaNegocio.Fabricas;
    using Core.LogicaNegocio.Telefonos;

    public class TelefonoFax : Telefono
    {
        private int codigofax;

        private string tipo;

        public virtual int Codigofax
        {
            get
            {
                return codigofax;
            }

            set
            {
                codigofax = value;
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