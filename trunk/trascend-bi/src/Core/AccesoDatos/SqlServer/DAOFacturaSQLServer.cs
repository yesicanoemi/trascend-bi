using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.AccesoDatos.Interfaces;
using Core.LogicaNegocio.Entidades;
using System.Collections.Generic;

namespace Core.AccesoDatos.SqlServer
{
    class DAOFacturaSQLServer : IDAOFactura
    {
        public Factura IngresarFactura(Factura factura)
        {
            return new Factura(); //por ahora
        }

        public IList<Factura> ConsultarFacturas()
        {
            return new List<Factura>();
        }

        public Factura ConsultarFacturaID(Factura factura)
        {            
            try
            {
                SqlParameter[] arParms = new SqlParameter[1];

                arParms[0] = new SqlParameter("@NumeroFactura", SqlDbType.VarChar);

                arParms[0].Value = "%" + factura.Numero + "%";

                DbDataReader reader = SqlHelper.ExecuteReader(GetConnection(),
                                        "ConsultarFacturaID", arParms);

                if (reader.Read())
                {
                    factura.Numero = (int)reader["NumeroFactura"];

                    factura.Titulo = (string)reader["Titulo"];

                    factura.Descripcion = (string)reader["Descripcion"];

                    factura.Procentajepagado = (string)reader["Porcentaje"];

                    factura.Fechapago = (DateTime)reader["Fecha"];

                    factura.Fechaingreso = (DateTime)reader["FechaIngreso"];

                    factura.Estado = (string)reader["Estado"];

                    factura.Prop.Id = (int)reader["IdPropuesta"];
                }

                return factura;
            }
            catch (SqlException e)
            {
                System.Console.Write(e);
            }
            return _factura;        
        }
    }
}
