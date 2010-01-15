namespace Core.LogicaNegocio.Entidades
{
    using System;
    using System.Collections.Generic;

    public class Telefono
    {


        private int numero;
        private string rifCliente;
        private string rifContacto;




        public virtual int Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }

        

        public virtual string Rifcliente
        {
            get
            {
                return rifCliente;
            }

            set
            {
                rifCliente = value;
            }
        }
        public virtual string Rifcontacto
        {
            get
            {
                return rifContacto;
            }

            set
            {
                rifContacto = value;
            }
        }

    }
}