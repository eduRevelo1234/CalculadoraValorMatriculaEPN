// ************************************************************************
// Proyecto 02
// Nombre:  Eduardo Revelo
//          Bryan Simbaña
// Fecha de entrega: 9/02/2020
//*************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto02_EduardoR_BryanS
{
    //Formulario web de inicio que se usa para verificar al usuario para que pueda ingresar a calcular el costo de su matricula 
    public partial class frmInicio : System.Web.UI.Page
    {
        string numeroCedula;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Se hace el llamdo al servicio WCF creando un nuevo cliente
                using (wcfPago2.Service1Client client = new wcfPago2.Service1Client())
                {
                Exception exep = new Exception("Numero de cedula invalido");
                    try
                    {
                    //Se comprueba que los datos ingresados no esten vacios
                    if (txtNumeroDeCedula.Text == "")
                    {
                        throw exep;
                    }
                    //se usa el cleinte para obtener una persoan usanddo el servicio WCF con el metodo obtener persona
                    var persona = client.obtenerPersona(txtNumeroDeCedula.Text);
                        numeroCedula = persona.numeroCedula;
                    if(persona.quintil == 0)
                    {
                        throw exep;
                    }
                     //Si no hay errores se llama al siguiente formulario y se manda como atributo el numero de cedula ingresado 
                        Session["numeroCedula"] = numeroCedula;
                        Response.Redirect("frmIngresoDatos.aspx");
                    
                        
                    }
                    catch(Exception ex)
                    {
                        Response.Write("<script>window.alert('Datos ingresados incorrectos o no tiene un quintil calculado');</script>");
                    }
                }              
        }
    }
}