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
    //Formulario usado para ingresar los datos de pago y usar el servicio wcf para guardarlo en la base de datos
    public partial class frmIngresoDatos : System.Web.UI.Page
    {
        //atributos usados para crear el pago
        string numeroCedula;
        int personaQuintil;
        double arancelTotal;
        double valorMatricula;
        double factor;
        double recargoRep2da;
        double recargoRep3ra;
        int creditos1ra;
        int creditos2da;
        int creditos3ra;
        double fepon;
        bool gratuidad;
        double pago;

        protected void Page_Load(object sender, EventArgs e)
        {

            numeroCedula = Convert.ToString(Session["numeroCedula"]);

            using (wcfPago2.Service1Client client = new wcfPago2.Service1Client())
            {
                //Se hace el llamdo al servicio WCF creando un nuevo cliente
                Exception exe = new Exception("calcular quintil");
                try
                {
                    //se usa el cliente para obtener una persona usanddo el servicio WCF con el metodo obtener persona
                    var persona = client.obtenerPersona(numeroCedula);
                    //Se comprubea que el quintil no este calculado
                    if (persona.quintil == 0)
                    {

                        throw exe;
                    }
                    else
                    {
                        //Se agrega los datos de la persona a los textbox
                        personaQuintil = persona.quintil;
                        txtNombre.Text = persona.nombre1Usuario;
                        txtNumeroCedula.Text = persona.numeroCedula;
                    }
                }
                catch(Exception ex)
                {
                    Response.Write("<script>window.alert('numero de cedula invalido');</script>");
                    Response.Redirect("frmInicio.aspx");
                }
            }     
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Se hace el llamdo al servicio WCF creando un nuevo cliente
            using (wcfPago2.Service1Client client = new wcfPago2.Service1Client())
            {
                //Se calcula los valores de factor, arancel y valorMatricula atravez de WCf usando los metodos obtenerFactor, obtenerArancel y obtenerMatricula 
                //Los cuales obtienen estos valores atravez del quintil que le corresponde a esa persona
                factor = client.obtenerFactor(personaQuintil);
                arancelTotal = client.obtenerAranceles(personaQuintil);
                valorMatricula = client.obtenerMatricula(personaQuintil);
               
            }
            //Se revise los radioButton para el pago de fepon
            if (RadioButtonList1.Items.FindByText("Si").Selected == true)
            {
                fepon = 20;
            }
            else if(RadioButtonList1.Items.FindByText("No").Selected == true)
            {
                fepon = 0;
            }
            else
            {
                Response.Write("<script>window.alert('Seleccione pago de fepon ');</script>");
            }
            //Se revisa los radioButton para el calculo del pago si es con creditos o por horas
            if (RadioButtonList2.Items.FindByText("Creditos").Selected == true)
            {
                Exception x = new Exception("datos ingresados incorrectos");
                try
                {
                    // se guarda lso datos ingresados en las variables 
                    creditos1ra = Convert.ToInt32(txtPrimera.Text);
                    creditos2da = Convert.ToInt32(txtSegunda.Text);
                    creditos3ra = Convert.ToInt32(txtTercera.Text);
                    //Se comprueba que los datos ingresados sean correctos
                    if (creditos1ra + creditos2da + creditos3ra == 0)
                    {
                        Response.Write("<script>window.alert('Tiene que ingresar creditos');</script>");
                        throw x;                       
                    }
                    else if (creditos1ra + creditos2da + creditos3ra > 30)
                    {
                        Response.Write("<script>window.alert('No puede matricularse en mas de 30 creditos');</script>");
                        throw x;
                    }
                    else
                    {
                        //Se revisa los creditos ingresados para calcular los recargos de repeticion y la gratuidad
                        if (creditos2da > 0 || creditos3ra > 0)
                        {
                            if (creditos2da > 0)
                            {
                                recargoRep2da = creditos2da * factor * 0.1;

                            }
                            else
                            {
                                recargoRep2da = 0;
                            }
                            if (creditos3ra > 0)
                            {
                                recargoRep3ra = creditos3ra * factor * 0.21;
                            }
                            else
                            {
                                recargoRep2da = 0;
                            }

                            gratuidad = true;
                        }
                        else if (creditos1ra + creditos2da + creditos3ra < 10)
                        {

                            gratuidad = false;
                        }
                        else
                        {
                            gratuidad = true;
                        }

                        //Se compara los datos ingresados y segun esto se envia al servicio WCF para crear el pago 
                        if (gratuidad == true && creditos2da == 0 && creditos3ra == 0)
                        {
                            // Se hace el llamdo al servicio WCF creando un nuevo cliente para crear un pago
                            using (wcfPago2.Service1Client client = new wcfPago2.Service1Client())
                            {
                                //Se obtiene la persona que va crear el pago
                                var persona = client.obtenerPersona(numeroCedula);
                                //Se crea al pago usando el metodo crear pago del wcf
                                bool respuesta = client.crearPago(creditos1ra, creditos2da, creditos3ra, factor, valorMatricula, arancelTotal, recargoRep2da, recargoRep3ra, fepon, persona.idUsuario);
                            }
                            pago = 0;
                        }
                        else if (gratuidad == true)
                        {
                            // Se hace el llamdo al servicio WCF creando un nuevo cliente para crear un pago
                            using (wcfPago2.Service1Client client = new wcfPago2.Service1Client())
                            {
                                //Se obtiene la persona que va crear el pago
                                var persona = client.obtenerPersona(numeroCedula);
                                //Se crea al pago usando el metodo crear pago del wcf
                                bool respuesta = client.crearPago(creditos1ra, creditos2da, creditos3ra, factor, valorMatricula, arancelTotal, recargoRep2da, recargoRep3ra, fepon, persona.idUsuario);
                            }
                        }
                        else
                        {
                            // Se hace el llamdo al servicio WCF creando un nuevo cliente para crear un pago
                            using (wcfPago2.Service1Client client = new wcfPago2.Service1Client())
                            {
                                //Se obtiene la persona que va crear el pago
                                var persona = client.obtenerPersona(numeroCedula);
                                //Se crea al pago usando el metodo crear pago del wcf
                                bool respuesta = client.crearPago(creditos1ra, creditos2da, creditos3ra, factor, valorMatricula, arancelTotal, recargoRep2da, recargoRep3ra, fepon, persona.idUsuario);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>window.alert('Error');</script>");
                }
                
            }
            else if (RadioButtonList2.Items.FindByText("Horas").Selected == true)
            {
                Exception x = new Exception("datos ingresados incorrectos");
                try
                {
                    // se guarda lso datos ingresados en las variables 
                    creditos1ra = Convert.ToInt32(txtPrimera.Text) / 16;
                    creditos2da = Convert.ToInt32(txtSegunda.Text) / 16;
                    creditos3ra = Convert.ToInt32(txtTercera.Text) / 16;
                    //Se comprueba que los datos ingresados sean correctos
                    Response.Write("<script>window.alert('Error');</script>");
                    if (creditos1ra + creditos2da + creditos3ra == 0)
                    {
                        Response.Write("<script>window.alert('Tiene que ingresar horas');</script>");
                        throw x;
                    }
                    else if (creditos1ra + creditos2da + creditos3ra > 30)
                    {
                        Response.Write("<script>window.alert('No puede matricularse en mas de 480 horas');</script>");
                        throw x;
                    }
                    else
                    {
                        //Se revisa los creditos ingresados para calcular los recargos de repeticion y la gratuidad
                        if (creditos2da > 0 || creditos3ra > 0)
                        {
                            if (creditos2da > 0)
                            {
                                recargoRep2da = creditos2da * factor * 0.1;
                            }
                            else
                            {
                                recargoRep2da = 0;
                            }
                            if (creditos3ra > 0)
                            {
                                recargoRep3ra = creditos3ra * factor * 0.21;
                            }
                            else
                            {
                                recargoRep2da = 0;
                            }

                            gratuidad = true;
                        }
                        else if (creditos1ra + creditos2da + creditos3ra < 10)
                        {

                            gratuidad = false;
                        }
                        else
                        {
                            gratuidad = true;
                        }
                        //Se compara los datos ingresados y segun esto se envia al servicio WCF para crear el pago 
                        if (gratuidad == true && creditos2da == 0 && creditos3ra == 0)
                        {
                            // Se hace el llamdo al servicio WCF creando un nuevo cliente para crear un pago
                            using (wcfPago2.Service1Client client = new wcfPago2.Service1Client())
                            {
                                //Se obtiene la persona que va crear el pago
                                var persona = client.obtenerPersona(numeroCedula);
                                //Se crea al pago usando el metodo crear pago del wcf
                                bool respuesta = client.crearPago(creditos1ra, creditos2da, creditos3ra, factor, valorMatricula, arancelTotal, recargoRep2da, recargoRep3ra, fepon, persona.idUsuario);
                            }
                            pago = 0;
                        }
                        else if (gratuidad == true)
                        {
                            // Se hace el llamdo al servicio WCF creando un nuevo cliente para crear un pago
                            using (wcfPago2.Service1Client client = new wcfPago2.Service1Client())
                            {
                                //Se obtiene la persona que va crear el pago
                                var persona = client.obtenerPersona(numeroCedula);
                                //Se crea al pago usando el metodo crear pago del wcf
                                bool respuesta = client.crearPago(creditos1ra, creditos2da, creditos3ra, factor, valorMatricula, arancelTotal, recargoRep2da, recargoRep3ra, fepon, persona.idUsuario);
                            }
                        }
                        else
                        {
                            // Se hace el llamdo al servicio WCF creando un nuevo cliente para crear un pago
                            using (wcfPago2.Service1Client client = new wcfPago2.Service1Client())
                            {
                                //Se obtiene la persona que va crear el pago
                                var persona = client.obtenerPersona(numeroCedula);
                                //Se crea al pago usando el metodo crear pago del wcf
                                bool respuesta = client.crearPago(creditos1ra, creditos2da, creditos3ra, factor, valorMatricula, arancelTotal, recargoRep2da, recargoRep3ra, fepon, persona.idUsuario);
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    
                }
               
            }
            else
            {
                Response.Write("<script>window.alert('Seleccione horas o creditos');</script>");
            }
            //Se envia el numero de cedula y el valor de gratuidad para mostrar los datos en el siguiente formulario
            Session["numeroCedula"] = numeroCedula;
            Session["gratuidad"] = gratuidad;
            //Se llama al siguiente formulario
            Response.Redirect("frmPago.aspx");
        }

        

        protected void txtPrimera_TextChanged(object sender, EventArgs e)
        {

        }
    }
}