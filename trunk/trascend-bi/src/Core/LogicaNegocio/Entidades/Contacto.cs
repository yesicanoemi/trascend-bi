
namespace Core.LogicaNegocio.Entidades
{
    using System;
    using System.Collections.Generic;

    public class Contacto : Persona
    {
        private int _id;
        private int cedula;
        private string cargo;
        private string areaDeNegocio;
        private TelefonoCelular _telefonoCelular;
        private TelefonoTrabajo _telefonoTrabajo;
        private int _idCliente;


        public Contacto()
        {
            _telefonoCelular = new TelefonoCelular();
            _telefonoTrabajo = new TelefonoTrabajo();
        }

        public virtual int IdContacto
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public virtual int Cedula
        {
            get
            {
                return cedula;
            }

            set
            {
                cedula = value;
            }
        }


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

        public virtual TelefonoTrabajo TelefonoDeTrabajo
        {
            get { return _telefonoTrabajo; }
            set { _telefonoTrabajo = value; }
        }

        public virtual TelefonoCelular TelefonoDeCelular
        {
            get { return _telefonoCelular; }
            set { _telefonoCelular = value; }
        }

        public virtual int IdCliente
        {
            get
            {
                return _idCliente;
            }

            set
            {
                _idCliente = value;
            }
        }

    }
}