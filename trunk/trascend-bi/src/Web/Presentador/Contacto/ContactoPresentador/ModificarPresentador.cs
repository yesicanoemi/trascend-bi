using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentador.Contacto.ContactoInterface;
using System.Web.UI.WebControls; // para la tabla dinamica, mudar cuando se ponga en comando
using System.Web.UI;

namespace Presentador.Contacto.ContactoPresentador
{
    public class ModificarPresentador
    {
        
            private IModificarContacto _vista;

            public ModificarPresentador(IModificarContacto vista)
            {
                _vista = vista;
            }
            public void Onclick()
            {
    //            string x=_vista.TextBoxNombre.Text;
    //            _vista.TextBoxNombre.Text = _vista.TextBoxApellido.Text;
    //            _vista.TextBoxApellido.Text = x;

             int numrows = 3;
             int numcells = 2;

            List<string> daList = new List<string>();
            daList.Add(_vista.TextBoxNombre.Text);
            daList.Add(_vista.TextBoxApellido.Text);
            daList.Add(_vista.TextBoxCedula.Text);

             for (int j = 0; j < numrows; j++)
             {
                 TableRow r = new TableRow();
                 for (int i = 0; i < numcells; i++)
                 {
                     TableCell c = new TableCell();
                     if (i==0)
                     {
                         c.Controls.Add(new LiteralControl("Nombre"));
                     }else
                     {
                        c.Controls.Add(new LiteralControl(daList[j]));
                     }
                     r.Cells.Add(c);
                 }
                 _vista.TablaResultados.Rows.Add(r);
             }

            }
        }
    
}
