
namespace Core.LogicaNegocio.Entidades
{
    using System;
    using System.Collections.Generic;

    public class Contacto : Persona
    {

        
        private string cargo;
        private string areaDeNegocio;
        private float sueldoBase;
 //       private DateTime fechaNacimiento;
 //       private DateTime fechaIngreso;
 //       private DateTime fechaEgreso;
 //       private string estado;



        public virtual string Cargo
        {
            get
            {
                return cargo;
            }

            set
            {
                cargo = value;
            }
        }

        public virtual string AreaDeNegocio
        {
            get
            {
                return areaDeNegocio;
            }

            set
            {
                areaDeNegocio = value;
            }
        }

    }
}