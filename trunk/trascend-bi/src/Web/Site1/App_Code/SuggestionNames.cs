using System;
using System.Collections;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using Core.LogicaNegocio.Entidades;
using Core.LogicaNegocio.Fabricas;
using Core.LogicaNegocio.Comandos;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Web.Script.Services;
using Core.AccesoDatos.Interfaces;
using Core.AccesoDatos;
using Core.AccesoDatos.Fabricas;

/// <summary>
/// Summary description for SuggestionNames
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class SuggestionNames : System.Web.Services.WebService
{

    public SuggestionNames()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public string[] GetSuggestionsClienteNombre(string prefixText, int count)
    {
        List<string> responses = new List<string>();

        Cliente cliente = new Cliente();

        cliente.Nombre = prefixText;

        Core.LogicaNegocio.Comandos.ComandoCliente.ConsultarNombre consultaCliente =
           Core.LogicaNegocio.Fabricas.FabricaComandosCliente.CrearComandoConsultarNombre(cliente);

           
            
           IList<Cliente> listaclientes = consultaCliente.ejecutar();


        foreach (Cliente cli in listaclientes)
        {
            responses.Add(cli.Nombre);
        }

        return responses.ToArray();
    }

}

