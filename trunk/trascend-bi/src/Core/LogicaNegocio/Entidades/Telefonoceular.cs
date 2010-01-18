namespace Core.LogicaNegocio.Entidades
{
    using System;
    using System.Collections.Generic;
    using Core.LogicaNegocio.Fabricas;
    using Core.LogicaNegocio.Telefonos;

    public class TelefonoCelular: Telefono
    {

        private int codigocel;
       



        public virtual int Codigocel
        {
            get
            {
                return codigocel;
            }

            set
            {
                codigocel = value;
            }
        }

  /*      public override Ingresar llenar(string cod, string num)
        {
            TelefonoCelular _cel;
            Ingresar _ingresar= FabricaTelefono.CrearTelefonoCelular(_cel);
            try
            {
                _cel.Codigocel=int.Parse(cod);
                _cel.Numero=int.Parse(num);
            }
            catch (Exception)
            {
                throw(new ArgumentException("Los telefonos solo pueden tener caracteres numéricos"));
            }
            return _ingresar;
        }
*/
       

    }
}