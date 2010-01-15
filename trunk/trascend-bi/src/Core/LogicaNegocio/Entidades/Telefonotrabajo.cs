namespace Core.LogicaNegocio.Entidades
{
    using System;
    using System.Collections.Generic;

    public class TelefonoTrabajo: Telefono
    {

        private int codigoArea;
        private string tipo;


        public virtual int Codigoarea
        {
            get
            {
                return codigoArea;
            }

            set
            {
                codigoArea = value;
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