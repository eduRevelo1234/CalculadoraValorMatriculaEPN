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
    public partial class frmPago : Form
    {
        string numeroCedula;
        bool gratuidad;
        public frmPago(string numeroCedula, bool gratuidad)
        {
            this.numeroCedula = numeroCedula;
            this.gratuidad = gratuidad;
            InitializeComponent();
        }
        private void frmPago_Load(object sender, EventArgs e)
        {
            using (wcfPago2.Service1Client client = new wcfPago2.Service1Client())
            {
                try
                {
                    //Se obtiene la persona que ha creado el pago atravez del WCF
                    var persona = client.obtenerPersona(numeroCedula);
                    //Se obtiene el pago que ha creado el usuario atravez del WCF con du ID
                    var pago = client.obtenerPago(persona.idUsuario);
                    if (gratuidad == true)
                    {
                        if (pago.valorApagar <= 21)
                        {
                            //Se agregan los valores en los textbox
                            txtFactorR.Text = Convert.ToString(pago.factor);
                            txtFactorG.Text = Convert.ToString(pago.factor);
                            txtValorMatriculaG.Text = Convert.ToString(0);
                            txtValorMatriculaR.Text = Convert.ToString(pago.valorMatricula);
                            txtValorArancelR.Text = Convert.ToString(0);
                            txtValorArancelG.Text = Convert.ToString(0);
                            txtRecargo2daG.Text = Convert.ToString(0);
                            txtRecargo2daR.Text = Convert.ToString(0);
                            txtRecargo3raR.Text = Convert.ToString(0);
                            txtRecargo3raG.Text = Convert.ToString(0);
                            txtFeponG.Text = Convert.ToString(pago.fepon);
                            txtFeponR.Text = Convert.ToString(pago.fepon);
                            txtAdicionalesG.Text = Convert.ToString(0);
                            txtAdicionalesR.Text = Convert.ToString(0);
                            txtBancarioG.Text = Convert.ToString(pago.bancario);
                            txtBancarioR.Text = Convert.ToString(pago.bancario);
                            txtTotalG.Text = Convert.ToString(pago.valorApagar);
                            txtTotalR.Text = Convert.ToString(pago.valorMatricula + pago.valorApagar);
                            txtValorApagar.Text = Convert.ToString(pago.valorApagar);
                        }
                        else if (pago.valorApagar > 21)
                        {
                            //Se agregan los valores en los textbox
                            txtFactorR.Text = Convert.ToString(pago.factor);
                            txtFactorG.Text = Convert.ToString(pago.factor);
                            txtValorMatriculaG.Text = Convert.ToString(pago.valorMatricula);
                            txtValorMatriculaR.Text = Convert.ToString(pago.valorMatricula);
                            txtValorArancelR.Text = Convert.ToString(pago.valorArancel);
                            txtValorArancelG.Text = Convert.ToString(pago.valorArancel);
                            txtRecargo2daG.Text = Convert.ToString(pago.recargoRep2da);
                            txtRecargo2daR.Text = Convert.ToString(pago.recargoRep2da);
                            txtRecargo3raR.Text = Convert.ToString(pago.recargoRep3ra);
                            txtRecargo3raG.Text = Convert.ToString(pago.recargoRep3ra);
                            txtFeponG.Text = Convert.ToString(pago.fepon);
                            txtFeponR.Text = Convert.ToString(pago.fepon);
                            txtAdicionalesG.Text = Convert.ToString(0);
                            txtAdicionalesR.Text = Convert.ToString(0);
                            txtBancarioG.Text = Convert.ToString(pago.bancario);
                            txtBancarioR.Text = Convert.ToString(pago.bancario);
                            txtTotalG.Text = Convert.ToString(pago.valorApagar);
                            txtTotalR.Text = Convert.ToString(pago.valorApagar);
                            txtValorApagar.Text = Convert.ToString(pago.valorApagar);

                        }
                    }
                    else
                    {
                        //Se agregan los valores en los textbox
                        txtFactorR.Text = Convert.ToString(pago.factor);
                        txtFactorG.Text = Convert.ToString(pago.factor);
                        txtValorMatriculaG.Text = Convert.ToString(pago.valorMatricula);
                        txtValorMatriculaR.Text = Convert.ToString(pago.valorMatricula);
                        txtValorArancelR.Text = Convert.ToString(pago.valorArancel);
                        txtValorArancelG.Text = Convert.ToString(pago.valorArancel);
                        txtRecargo2daG.Text = Convert.ToString(pago.recargoRep2da);
                        txtRecargo2daR.Text = Convert.ToString(pago.recargoRep2da);
                        txtRecargo3raR.Text = Convert.ToString(pago.recargoRep3ra);
                        txtRecargo3raG.Text = Convert.ToString(pago.recargoRep3ra);
                        txtFeponG.Text = Convert.ToString(pago.fepon);
                        txtFeponR.Text = Convert.ToString(pago.fepon);
                        txtAdicionalesG.Text = Convert.ToString(0);
                        txtAdicionalesR.Text = Convert.ToString(0);
                        txtBancarioG.Text = Convert.ToString(pago.bancario);
                        txtBancarioR.Text = Convert.ToString(pago.bancario);
                        txtTotalG.Text = Convert.ToString(pago.valorApagar);
                        txtTotalR.Text = Convert.ToString(pago.valorApagar);
                        txtValorApagar.Text = Convert.ToString(pago.valorApagar);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Datos ingresados incorrecto");
                }
            }
        }
    }
}
