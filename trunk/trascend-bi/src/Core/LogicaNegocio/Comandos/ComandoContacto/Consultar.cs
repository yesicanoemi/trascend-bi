using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.LogicaNegocio.Entidades;
using Core.AccesoDatos.SqlServer;

namespace Core.LogicaNegocio.Comandos.ComandoContacto
{
    public class Consultar : Comando<Contacto>
    {
        private IList<Contacto> _contactos;
    //    private Contacto _contacto;
        private string _nombre;
        private string _apellido;
        private int _cod;
        private int _num;
        private int _flag;

        #region Constructor
        public Consultar()
        {
        }

        public Consultar(IList<Contacto> contactos,string nombre, string apellido, int codigo, int numero, int trueno)
        {
            _contactos = contactos;
            _nombre = nombre;
            _apellido = apellido;
            _cod = codigo;
            _num = numero;
            _flag = trueno;
        }

        public virtual IList<Contacto> ListaContactos
        {
            get { return _contactos; }
     //       set { _contactos = value; }
        }

        #endregion

        #region Metodos

        public IList<Contacto> Ejecutar()
        {
            DAOContactoSQLServer bd = new DAOContactoSQLServer();
            _contactos = new List<Contacto>(); //bd..Consultar(_nombre,_apellido,_cod,_num,_flag);
            return _contactos;
        }

        #endregion
    }
}