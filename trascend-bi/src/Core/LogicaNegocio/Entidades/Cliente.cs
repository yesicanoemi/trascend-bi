
namespace Core.LogicaNegocio.Entidades
{
    using System;
    using System.Collections.Generic;

    public class Cliente
    {
        private int idCliente;
        private string rif;
        private string nombre;
        private TelefonoTrabajo[] telefono = new TelefonoTrabajo[3];
        private Direccion direccion;
        private string areaNegocio;

        private IList<Contacto> contacto;

        public virtual int IdCliente
        {
            get
            {
                return idCliente;
            }

            set
            {
                idCliente = value;
            }
        }

        public virtual string Rif
        {
            get
            {
                return rif;
            }

            set
            {
                rif = value;
            }
        }

        public virtual string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public virtual string AreaNegocio
        {
            get
            {
                return areaNegocio;
            }

            set
            {
                areaNegocio = value;
            }
        }

        public virtual Direccion Direccion
        {
            get
            {
                return direccion;
            }
            set
            {
                direccion = value;
            }
        }

        public virtual IList<Contacto> Contacto // es una lista de contacto no un string
        {
            get
            {
                return contacto;
            }

            set
            {
                contacto = value;
            }
        }

        public virtual TelefonoTrabajo[] Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }






    }
}