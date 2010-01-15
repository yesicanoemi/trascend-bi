namespace Core.LogicaNegocio.Entidades
{
    using System;
    using System.Collections.Generic;

    public class TelefonoCelular: Telefono
    {

        private int codigocel;
       



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

       

    }
}