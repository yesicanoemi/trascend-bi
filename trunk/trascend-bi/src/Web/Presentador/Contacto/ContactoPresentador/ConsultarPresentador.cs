using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Contacto.ContactoInterface;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentador.Contacto.ContactoPresentador
{
    public class ConsultarPresentador
    {
        
            private IConsultarContacto _vista;

            public ConsultarPresentador(IConsultarContacto vista)
            {
                _vista = vista;
            }
            public void Onclick()
            {
                string Lnombre = " ";
                string Lapellido = " ";
                string LcodTelf = "0";
                string LnumTelf = "0";

                int flag = 0;
                if (_vista.CheckBoxNombre.Checked)
                {
                    flag = flag + 100;
                    Lnombre = _vista.TextBoxNombre.Text;
                }
                if (_vista.CheckBoxApellido.Checked)
                {
                    flag = flag + 10;
                    Lapellido = _vista.TextBoxApellido.Text;
                }
                if (_vista.CheckBoxTelefono.Checked)
                {
                    flag = flag + 1;
                    LcodTelf = _vista.TextBoxCodTelefono.Text;
                    LnumTelf = _vista.TextBoxNumTelefono.Text;
                }

                IList<Core.LogicaNegocio.Entidades.Contacto> ListaContactosTemp= new List<Core.LogicaNegocio.Entidades.Contacto>();

                IList<Core.LogicaNegocio.Entidades.Contacto> ListaContactos =
                    Consultar(ListaContactosTemp, Lnombre, Lapellido, int.Parse(LcodTelf),
                        int.Parse(LnumTelf), flag);

   //             _vista.TablaResultados = DibujarTablaContacto(ListaContactos);


                /////////////////////////////////////////


                if (ListaContactos.Count > 0)
                {
                    TableRow r = new TableRow();
                    TableCell c = new TableCell();
                    c.Controls.Add(new LiteralControl("ID"));
                    r.Cells.Add(c);
                    c = new TableCell();
                    c.Controls.Add(new LiteralControl("Nombre"));
                    r.Cells.Add(c);
                    c = new TableCell();
                    c.Controls.Add(new LiteralControl("Apellido"));
                    r.Cells.Add(c);
                    c = new TableCell();
                    c.Controls.Add(new LiteralControl("Cargo"));
                    r.Cells.Add(c);
                    c = new TableCell();
                    c.Controls.Add(new LiteralControl("Area de Negocio"));
                    r.Cells.Add(c);
                    c = new TableCell();
                    c.Controls.Add(new LiteralControl("Telefono Celular"));
                    r.Cells.Add(c);
                    c = new TableCell();
                    c.Controls.Add(new LiteralControl("Telefono Local"));
                    r.Cells.Add(c);
                    _vista.TablaResultados.Rows.Add(r);
                    int indice = 0;
                    int numcells = 7;
                    foreach (Core.LogicaNegocio.Entidades.Contacto X in ListaContactos)
                    {
                        indice++;
                        r = new TableRow();
                        for (int i = 0; i < numcells; i++)
                        {
                            c = new TableCell();
                            switch (i)
                            {
                                case 0:
                                    c.Controls.Add(new LiteralControl(indice.ToString()));
                                    break;
                                case 1:
                                    c.Controls.Add(new LiteralControl(X.Nombre));
                                    break;
                                case 2:
                                    c.Controls.Add(new LiteralControl(X.Apellido));
                                    break;
                                case 3:
                                    c.Controls.Add(new LiteralControl(X.Cargo));
                                    break;
                                case 4:
                                    c.Controls.Add(new LiteralControl(X.AreaDeNegocio));
                                    break;
                                case 5:
                                    c.Controls.Add(new LiteralControl("(" + X.TelefonoDeCelular.Codigocel.ToString() + ")"
                                        + X.TelefonoDeCelular.Numero.ToString() + " "));
                                    break;
                                case 6:
                                    c.Controls.Add(new LiteralControl("(" + X.TelefonoDeTrabajo.Codigoarea.ToString() + ")"
                                        + X.TelefonoDeTrabajo.Numero.ToString() + " "));
                                    break;

                            }
                            r.Cells.Add(c);
                        }
                        _vista.TablaResultados.Rows.Add(r);
                    }
                }

                /////////////////////////////////////////





       }

            public IList<Core.LogicaNegocio.Entidades.Contacto>
                Consultar(IList<Core.LogicaNegocio.Entidades.Contacto> _contacto, string nombre, string apellido,
                int codigo, int numero, int flag)
            {
                Core.LogicaNegocio.Comandos.ComandoContacto.Consultar consulta;

                //fábrica que instancia el comando Ingresar.
                consulta = Core.LogicaNegocio.Fabricas.FabricaComandosContacto.CrearComandoConsultar
                    (_contacto,nombre,apellido,codigo,numero,flag);

  
                //ejecuta el comando.
                consulta.Ejecutar();

                return consulta.ListaContactos;
            }
        // REVISAR POR QUE NO FUNCIONA AL HACERLO POR EL METODO!

   /*         public static Table DibujarTablaContacto(IList<Core.LogicaNegocio.Entidades.Contacto> contactos)
            {
                Table Tabla = new Table();
                if (contactos.Count > 0)
                {
                    TableRow r = new TableRow();
                    TableCell c = new TableCell();
                    c.Controls.Add(new LiteralControl("ID"));
                    c.Controls.Add(new LiteralControl("Nombre"));
                    c.Controls.Add(new LiteralControl("Apellido"));
                    c.Controls.Add(new LiteralControl("Cargo"));
                    c.Controls.Add(new LiteralControl("Area de Negocio"));
                    c.Controls.Add(new LiteralControl("Telefono Celular"));
                    c.Controls.Add(new LiteralControl("Telefono Local"));
                    r.Cells.Add(c);
                    Tabla.Rows.Add(r);
                    int indice = 0;
                    int numcells = 7;
                    foreach (Core.LogicaNegocio.Entidades.Contacto X in contactos)
                    {
                        indice++;
                        r = new TableRow();
                        for (int i = 0; i < numcells; i++)
                        {
                            c = new TableCell();
                            switch (i)
                            {
                                case 0:
                                    c.Controls.Add(new LiteralControl(indice.ToString()));
                                    break;
                                case 1:
                                    c.Controls.Add(new LiteralControl(X.Nombre));
                                    break;
                                case 2:
                                    c.Controls.Add(new LiteralControl(X.Apellido));
                                    break;
                                case 3:
                                    c.Controls.Add(new LiteralControl(X.Cargo));
                                    break;
                                case 4:
                                    c.Controls.Add(new LiteralControl(X.AreaDeNegocio));
                                    break;
                                case 5:
                                    c.Controls.Add(new LiteralControl("(" + X.TelefonoDeCelular.Codigocel.ToString() + ")"
                                        + X.TelefonoDeCelular.Numero.ToString()));
                                    break;
                                case 6:
                                    c.Controls.Add(new LiteralControl("(" + X.TelefonoDeTrabajo.Codigoarea.ToString() + ")"
                                        + X.TelefonoDeTrabajo.Numero.ToString()));
                                    break;

                            }
                            r.Cells.Add(c);
                        }
                        Tabla.Rows.Add(r);
                    }
                }
                return Tabla;
            }
    */    }
    
}
