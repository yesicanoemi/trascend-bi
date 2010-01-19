using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Contacto.ContactoInterface;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Presentador.Contacto.ContactoPresentador
{
    public class EliminarPresentador
    {

        private IEliminarContacto _vista;
    //    private IList<Core.LogicaNegocio.Entidades.Contacto> _ListaContactos;

        public EliminarPresentador(IEliminarContacto vista)
        {
            _vista = vista;
        }

        public void OnClickBusqueda()
        {

            #region busqueda

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

            #endregion 

            IList<Core.LogicaNegocio.Entidades.Contacto> NvaListaContactos = new List<Core.LogicaNegocio.Entidades.Contacto>(); 
            
            NvaListaContactos= Consultar(NvaListaContactos, Lnombre, Lapellido, int.Parse(LcodTelf), int.Parse(LnumTelf), flag);

            if (int.Parse(_vista.TextBoxBusqueda.Text)>=0 &&
                int.Parse(_vista.TextBoxBusqueda.Text)<=NvaListaContactos.Count)
            {
                CambiarVista(1);
                _vista.LabelConfirmar.Text = NvaListaContactos.ElementAt(int.Parse(_vista.TextBoxBusqueda.Text)-1).Nombre +
                    " " + NvaListaContactos.ElementAt(int.Parse(_vista.TextBoxBusqueda.Text)-1).Apellido;
            }
        }

        public void onClickConfirmar()
        {
            Eliminar();
            CambiarVista(0);
        }

        public void Eliminar()
        {
            #region busqueda

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

            #endregion 

            IList<Core.LogicaNegocio.Entidades.Contacto> NvaListaContactos = new List<Core.LogicaNegocio.Entidades.Contacto>();

            NvaListaContactos = Consultar(NvaListaContactos, Lnombre, Lapellido, int.Parse(LcodTelf), int.Parse(LnumTelf), flag);

            Core.LogicaNegocio.Comandos.ComandoContacto.Eliminar eliminacion;

            //fábrica que instancia el comando Eliminar.

            eliminacion = Core.LogicaNegocio.Fabricas.FabricaComandosContacto.
                CrearComandoEliminar(NvaListaContactos.ElementAt(int.Parse(_vista.TextBoxBusqueda.Text)-1));


            //ejecuta el comando.
            eliminacion.Ejecutar();
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

            IList<Core.LogicaNegocio.Entidades.Contacto> ListaContactosTemp = new List<Core.LogicaNegocio.Entidades.Contacto>();

            IList<Core.LogicaNegocio.Entidades.Contacto> ListaContactos =
                Consultar(ListaContactosTemp, Lnombre, Lapellido, int.Parse(LcodTelf),
                    int.Parse(LnumTelf), flag);



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
            MostrarBusqueda();

        }

        public IList<Core.LogicaNegocio.Entidades.Contacto>
        Consultar(IList<Core.LogicaNegocio.Entidades.Contacto> _contacto, string nombre, string apellido,
        int codigo, int numero, int flag)
        {
            Core.LogicaNegocio.Comandos.ComandoContacto.Consultar consulta;

            //fábrica que instancia el comando Ingresar.
            consulta = Core.LogicaNegocio.Fabricas.FabricaComandosContacto.CrearComandoConsultar
                (_contacto, nombre, apellido, codigo, numero, flag);


            //ejecuta el comando.
            consulta.Ejecutar();

            return consulta.ListaContactos;
        }

        public void MostrarBusqueda()
        {
            _vista.TablaResultados.Visible = true;
            _vista.TextBoxBusqueda.Visible = true;
            _vista.BotonBuscar.Visible = true;
            _vista.LabelBuscar.Visible = true;
        }

        public void OcultarBusqueda()
        {
            _vista.TablaResultados.Visible = false;
            _vista.TextBoxBusqueda.Visible = false;
            _vista.BotonBuscar.Visible = false;
            _vista.LabelBuscar.Visible = false;
        }

        public void CambiarVista(int indice)
        {
            _vista.MultiViewEliminar.ActiveViewIndex = indice;
        }
    }

}
