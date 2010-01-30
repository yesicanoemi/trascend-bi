using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentador.Cliente.Vistas;
using Presentador.Cliente.Contrato;
using Core.LogicaNegocio.Entidades;
using Microsoft.Practices.Web.UI.WebControls;

public partial class Paginas_Clientes_ConsultarClientes : PaginaBase, IConsultarCliente
{
    private ConsultarClientePresentador _presentador;

   // private Cliente _cliente;

    #region propiedades 

    private int width;

    public void Pintar(string codigo, string mensaje, string actor, string detalles)
    {
        uxDialogoError.Pintar(codigo, mensaje, actor, detalles);
    }

    public bool DialogoVisible
    {
        get { return uxDialogoError.Visible; }
        set { uxDialogoError.Visible = value; }
    }

    public DetailsView MuestraCliente
    {
        get { return uxMuestraCliente; }
        set { uxMuestraCliente = value; }
    }

    public DetailsView MuestraDireccion
    {
        get { return uxMuestraDireccion; }
        set { uxMuestraDireccion = value; }
    }

    public TextBox Valor
    {
        get { return uxValor; }
        set { uxValor = value; }
    }

    public ObjectContainerDataSource GetObjectContainerConsultaCliente
    {
        get { return uxObjectConsultaCliente; }
        set { uxObjectConsultaCliente = value; }
    }

    public ObjectContainerDataSource GetObjectContainerConsultaDireccion
    {
        get { return uxObjectConsultaDireccion; }
        set { uxObjectConsultaDireccion = value; }
    }


    public ObjectContainerDataSource GetObjectContainerConsultaTelefono
    {
        get { return uxObjectConsultaTelefono; }
        set { uxObjectConsultaTelefono = value; }
    }
    public MultiView MultiViewConsulta
    {
        get { return uxMultiViewConsultar; }
        set { uxMultiViewConsultar = value; }
    }
    public DropDownList opcion
    {
        get { return opcion1; }
        set { opcion1 = value; }
    }
  

    #endregion
   
    protected void Page_Load(object sender, EventArgs e)
    {
        width = 0;
    }

    protected void Page_Init(object sender, EventArgs e)
    {
       #region Permisologia
        Core.LogicaNegocio.Entidades.Usuario usuario =
                                (Core.LogicaNegocio.Entidades.Usuario)Session[SesionUsuario];

        bool permiso = false;

        for (int i = 0; i < usuario.PermisoUsu.Count; i++)
        {
            if (usuario.PermisoUsu[i].IdPermiso == 6)
            {
                i = usuario.PermisoUsu.Count;

                _presentador = new ConsultarClientePresentador(this);

                permiso = true;

            }
        }

        if (permiso == false)
        {
            Response.Redirect(paginaSinPermiso);
        }
        #endregion                
    }


    protected void uxBotonAceptar_Click(object sender, EventArgs e)
    {
        
        _presentador.BotonSeleccionTipo();
    }
   
    protected void opcion1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void uxMuestra_SelectedIndexChanged(object sender, GridViewSelectEventArgs e)
    {
        //_presentador.metodoEnPresendator(int.Parse(uxMuestra.DataKeys[e.NewSelectedIndex].Value.ToString()));
    
    }

   /* protected void uxTablaClientes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            string s = e.Row.DataItem.ToString();

            if (s.Length > width)
            {
                width = s.Length;
                
           //     uxMuestra.Rows[0].ItemStyle.Width = s.Length;
             //   uxMuestra.Rows[0].ItemStyle.Wrap = false;
            }
        }

        if (e.Row.RowIndex % 2 == 0)
            e.Row.BackColor = System.Drawing.Color.FromName("#FFFFCC");
    }

    */

    protected void uxValor_TextChanged(object sender, EventArgs e)
    {

    }
}

