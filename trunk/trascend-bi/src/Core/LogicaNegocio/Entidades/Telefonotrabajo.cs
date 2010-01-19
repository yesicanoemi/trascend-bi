namespace Core.LogicaNegocio.Entidades
{
    using System;
    using System.Collections.Generic;
    using Core.LogicaNegocio.Fabricas;
    using Core.LogicaNegocio.Telefonos;

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

/*        public override Ingresar llenar(string cod, string num)
        {
            TelefonoTrabajo tele;
            Ingresar _telefono = FabricaTelefono.CrearTelefonoTrabajo(tele);
            try
            {
                tele.Codigocel=(int.Parse(cod));
                tele.Numero=(int.Parse(num));
            }
            catch (Exception)
            {
                throw (new ArgumentException("error en el formato del telefono"));
            }
            return _telefono;
        }
*/
    }
}