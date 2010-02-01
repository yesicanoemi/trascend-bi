

namespace Core.LogicaNegocio.Entidades
{
    using System;
    using System.Collections.Generic;

    public class Direccion
    {
        private int idDireccion;
        private string calle;
        private string avenida;
        private string urbanizacion;
        private string edif_casa;
        private string oficina;
        private string piso_apto;
        private string ciudad;

        public virtual int IdDireccion
        {
            get { return idDireccion; }

            set { idDireccion = value; }
        
        }

        public virtual string Oficina
        {
            get
            {
                return oficina;
            }

            set
            {
                oficina = value;
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

         public virtual string Edif_Casa
        {
            get
            {
                return edif_casa;
            }

            set
            {
                edif_casa = value;
            }
        }
         public virtual string Piso_apto
         {
             get
             {
                 return piso_apto;
             }

             set
             {
                 piso_apto = value;
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



    }
}
