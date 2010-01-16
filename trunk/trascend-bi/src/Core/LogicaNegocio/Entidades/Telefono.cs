namespace Core.LogicaNegocio.Entidades
{
    using System;
    using System.Collections.Generic;
    using Core.LogicaNegocio.Telefonos;

    public abstract class Telefono
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

    //    public abstract Ingresar llenar(string cod,string nom);

    }
}