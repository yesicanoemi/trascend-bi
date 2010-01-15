
namespace Core.LogicaNegocio.Entidades
{
    using System;
    using System.Collections.Generic;

    public class Cliente
    {

        private int rif;
        private string nombre;
        private string calle;
        private string avenida;
        private string urbanizacion;
        private string edificioCasa;
        private string pisoApartamento;
        private string ciudad;
        private string areaNegocio;


        public virtual int Rif
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

        public virtual string Calle
        {
            get
            {
                return calle;
            }

            set
            {
                calle = value;
            }
        }

        public virtual string Avenida
        {
            get
            {
                return avenida;
            }

            set
            {
                avenida = value;
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