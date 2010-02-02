
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
        private int estatus;
        /*private string calleAvenidad;
        private string urbanizacion;
        private string edificioCasa;
        private string pisoApartamento;
        private string ciudad;
        private string areaNegocio;*/    //informacion de direccion
        //private string telefonoTrabajo; //informacion de telefono
        //private string codigoTrabajo;   //informacion de teleofnos
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

        public virtual int Estatus
        {
            get
            {
                return estatus;
            }

            set
            {
                estatus = value;
            }
        }
        


        /* public virtual string CalleAvenidad
        {
            get
            {
                return calleAvenidad;
            }

            set
            {
                calleAvenidad = value;
            }
        }

        

        public virtual string Urbanizacion
        {
            get
            {
                return urbanizacion;
            }

            set
            {
                urbanizacion = value;
            }
        }

        public virtual string EdificioCasa
        {
            get
            {
                return edificioCasa;
            }

            set
            {
                edificioCasa = value;
            }
        }
        public virtual string PisoApartamento
        {
            get
            {
                return pisoApartamento;
            }

            set
            {
                pisoApartamento = value;
            }
        }
        public virtual string Ciudad
        {
            get
            {
                return ciudad;
            }

            set
            {
                ciudad = value;
            }
        }*/             

        /*public virtual string TelefonoTrabajo
        {
            get
            {
                return telefonoTrabajo;
            }

            set
            {
                telefonoTrabajo = value;
            }
        }

        public virtual string CodigoTrabajo
        {
            get
            {
                return codigoTrabajo;
            }

            set
            {
                codigoTrabajo = value;
            }
        }*/
  
    }
}