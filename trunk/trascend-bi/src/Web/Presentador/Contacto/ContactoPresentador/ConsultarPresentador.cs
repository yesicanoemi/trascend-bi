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
                int flag = 0;
                if (_vista.CheckBoxNombre.Checked)
                {
                    flag = flag + 100;
                }
                if (_vista.CheckBoxApellido.Checked)
                {
                    flag = flag + 10;
                }
                if (_vista.CheckBoxTelefono.Checked)
                {
                    flag = flag + 1;
                }
                /*8888888888888888888888888*/


                List<string> daList = new List<string>();
                daList.Add(_vista.TextBoxNombre.Text);
                daList.Add(_vista.TextBoxApellido.Text);
                daList.Add("("+_vista.TextBoxCodTelefono.Text+")"+_vista.TextBoxNumTelefono.Text);


                int numrows = 3;
                int numcells = 2;

                for (int j = 0; j < numrows; j++)
                {
                    TableRow r = new TableRow();
                    for (int i = 0; i < numcells; i++)
                    {
                        TableCell c = new TableCell();
                        if (i == 0)
                        {
                            c.Controls.Add(new LiteralControl("Nombre"));
                        }
                        else
                        {
                            c.Controls.Add(new LiteralControl(daList[j]));
                        }
                        r.Cells.Add(c);
                    }
                    _vista.TablaResultados.Rows.Add(r);
                }
                /*8888888888888888888888888*/
            }
        }
    
}
