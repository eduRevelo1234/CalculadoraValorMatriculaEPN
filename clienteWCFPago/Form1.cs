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
    public partial class Form1 : Form
    {
        public string numeroCedula;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            frmIngresoDatos frm2 = new frmIngresoDatos(this);
            //Se hace el llamdo al servicio WCF creando un nuevo cliente
            using (wcfPago2.Service1Client client = new wcfPago2.Service1Client())
            {
                
                try
                {

                    Exception exep = new Exception("Numero de cedula invalido");
                    //Se comprueba que los datos ingresados no esten vacios
                    if (txtNumeroDeCedula.Text == "")
                    {
                        throw exep;
                    }
                    //se usa el cleinte para obtener una persoan usanddo el servicio WCF con el metodo obtener persona
                    var persona = client.obtenerPersona(txtNumeroDeCedula.Text);
                    numeroCedula = persona.numeroCedula;
                    MessageBox.Show(numeroCedula);
                    if (persona.quintil == 0)
                    {
                        throw exep;
                    }
                    //Si no hay errores se llama al siguiente formulario y se manda como atributo el numero de cedula ingresado 
                    frm2.Show();
                    this.Hide();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Datos ingresados incorrectos o no tiene un quintil calculado");

                }
            }
        }
    }
}
