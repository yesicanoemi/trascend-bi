

namespace Core.LogicaNegocio.Entidades
{
    using System;
    using System.Collections.Generic;

    public class Persona : Entidad
    {
       
        private string nombre;

        private string apellido;

        private bool estado = true;

        public virtual bool Estado 
        {
            get 
            {
                return estado;
            }
            set 
            
           {
               estado = value;
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

        public virtual string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }
    }
}
