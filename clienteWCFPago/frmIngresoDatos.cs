// ************************************************************************
// Proyecto 02
// Nombre:  Eduardo Revelo
//          Bryan Simbaña
// Fecha de entrega: 9/02/2020
//*************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clienteWCFPago
{
    public partial class frmIngresoDatos : Form
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
        //Para recibir los datos del formualrio
        Form1 frm1 = new Form1();
        public frmIngresoDatos(Form1 frm1)
        {
            this.frm1 = frm1;
            
            InitializeComponent();
        }

        private void frmIngresoDatos_Load(object sender, EventArgs e)
        {

            using (wcfPago2.Service1Client client = new wcfPago2.Service1Client())
            {
                numeroCedula = frm1.numeroCedula;
               
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
                catch (Exception ex)
                {
                    MessageBox.Show("Numero de cedula invalido");
                    frm1.Show();
                    this.Hide();
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
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
            if (rdbFeponSi.Checked == true)
            {
                fepon = 20;
            }
            else if (rdbFeponNO.Checked == true)
            {
                fepon = 0;
            }
            else
            {
                MessageBox.Show("Seleccione pago de fepon");
                
            }
            //Se revisa los radioButton para el calculo del pago si es con creditos o por horas
            if (rdbCreditos.Checked == true)
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
                        MessageBox.Show("Tiene que ingresar creditos");
                        throw x;
                    }
                    else if (creditos1ra + creditos2da + creditos3ra > 30)
                    {
                        MessageBox.Show("No puedo matricularse en mas de 30 creditos");
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
                    MessageBox.Show("Error");
                }

            }
            else if (rdbHoras.Checked == true)
            {
                Exception x = new Exception("datos ingresados incorrectos");
                try
                {
                    // se guarda lso datos ingresados en las variables 
                    creditos1ra = Convert.ToInt32(txtPrimera.Text) / 16;
                    creditos2da = Convert.ToInt32(txtSegunda.Text) / 16;
                    creditos3ra = Convert.ToInt32(txtTercera.Text) / 16;
                    //Se comprueba que los datos ingresados sean correctos
                    if (creditos1ra + creditos2da + creditos3ra == 0)
                    {
                        MessageBox.Show("Tiene que ingresar horas");
                        throw x;
                    }
                    else if (creditos1ra + creditos2da + creditos3ra > 30)
                    {
                        MessageBox.Show("No puede matricularse en mas de 480 horas");
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

                }

            }
            else
            {
                MessageBox.Show("Seleccione horas o creditos");
            }
            //Se envia el numero de cedula y el valor de gratuidad para mostrar los datos en el siguiente formulario
            frmPago frmPago = new frmPago(numeroCedula, gratuidad);
            //Se llama al siguiente formulario
            frmPago.Show();
            this.Hide();
        }
    }
}
