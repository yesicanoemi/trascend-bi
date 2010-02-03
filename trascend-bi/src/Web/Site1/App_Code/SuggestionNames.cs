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
//[System.Web.Script.Services.ScriptService]
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



    [WebMethod]
    public string[] GetSuggestionsClienteRif(string prefixText, int count)
    {
        List<string> responses = new List<string>();

        Cliente cliente = new Cliente();

        cliente.Rif = prefixText;

        Core.LogicaNegocio.Comandos.ComandoCliente.ConsultarRif consultaCliente =
           Core.LogicaNegocio.Fabricas.FabricaComandosCliente.CrearComandoConsultarRif(cliente);



        IList<Cliente> listaclientes = consultaCliente.ejecutar();


        foreach (Cliente cli in listaclientes)
        {
            responses.Add(cli.Rif);
        }

        return responses.ToArray();
    }

    //AutoCompleteExtender para los empleados que se le van asignar nombre de usuario y clave
    [WebMethod]
    public string[] GetSuggestionsEmpleadoNombreSinUsuario(string prefixText, int count)
    {
        List<string> responses = new List<string>();

        Empleado empleado = new Empleado();

        empleado.Nombre = prefixText;

        Core.LogicaNegocio.Comandos.ComandoUsuario.ConsultarEmpleadoSinUsuario comando =
        Core.LogicaNegocio.Fabricas.FabricaComandosUsuario.CrearComandoConsultarEmpleadoSinUsuario(empleado);

       
        IList<Empleado> listaEmpleados = comando.Ejecutar();


        foreach (Empleado _empleado in listaEmpleados)
        {
            responses.Add(_empleado.Nombre);
        }

        return responses.ToArray();
    }

    [WebMethod]
    public string[] GetSuggestionsFacturaPropuesta(string prefixText, int count)
    {
        List<string> responses = new List<string>();

        Propuesta propuesta = new Propuesta();

        propuesta.Titulo = prefixText;

        Core.LogicaNegocio.Comandos.ComandoPropuesta.Consultar comando = 
            FabricaComandosPropuesta.CrearComandoConsultar(1, propuesta.Titulo);

        IList<Propuesta> propuestas = comando.Ejecutar();

        foreach (Propuesta prop in propuestas)
        {
            responses.Add(prop.Titulo);
        }
        return responses.ToArray();
    }

}

