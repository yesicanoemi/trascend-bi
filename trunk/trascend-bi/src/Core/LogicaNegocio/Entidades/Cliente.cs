
namespace Core.LogicaNegocio.Entidades
{
    using System;
    using System.Collections.Generic;

    public class Cliente
    {

        private string rif;
        private string nombre;
        private string calleAvenidad;
        private string urbanizacion;
        private string edificioCasa;
        private string pisoApartamento;
        private string ciudad;
        private string areaNegocio;


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

        public virtual string CalleAvenidad
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
  
    }
}