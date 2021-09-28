using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfPago
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        bd_Pago bd = new bd_Pago();
        tbl_Pago pago;
      
        public tbl_Pago obtenerPago(string cedula)
        {
            var usuraio = (from iter in bd.usuario
                           where iter.numeroCedula == cedula
                           select iter).FirstOrDefault();
            var pago = (from iter in bd.pago
                        where iter.idUsuario == usuraio.idUsuario
                        select iter).FirstOrDefault();
            return pago;
        }

        public tbl_Usuario obtenerPersona(string cedula)
        {
            var usuraio = (from iter in bd.usuario
                           where iter.numeroCedula == cedula
                           select iter).FirstOrDefault();
            return usuraio;
        }

        public tbl_Usuario obtenerPersonaConCI(int id)
        {
            
            var usuraio = (from iter in bd.usuario
                           where iter.idUsuario == id
                           select iter).FirstOrDefault();
            return usuraio;
        }

       

        public double obtenerAranceles(int personaQuintil)
        {
            if (personaQuintil == 1)

            {
                ///quintilx.factor = 0.31714;
                //matricula = 15.22;
                return  152.23;
            }
            else if (personaQuintil == 2)
            {
                //factor = 0.63428;
                //matricula = 30.45;
                return 304.45;
            }
            else if (personaQuintil == 3)
            {
                // factor = 0.95142;
                // matricula = 45.67;
                return 456.68;
            }
            else if (personaQuintil == 4)
            {
                // factor = 1.26856;
                // matricula = 60.89;
                return 608.91;
            }
            else if (personaQuintil == 5)
            {
                //factor = 1.585700;
                //matricula = 76.11;
                return 761.14;
            }
            else
            {
                return 0;
            }
        }

        public quintilx obtenerArancel(int quintil)
        {
            throw new NotImplementedException();
        }

        public double obtenerMatricula(int personaQuintil)
        {
            if (personaQuintil == 1)

            {
                return 15.22;
            }
            else if (personaQuintil == 2)
            {
                return 30.45;
            }
            else if (personaQuintil == 3)
            {
                return 45.67;
            }
            else if (personaQuintil == 4)
            {
                return 60.89;
            }
            else if (personaQuintil == 5)
            {
                return 76.11;
            }
            else
            {
                return 0;
            }
        }

        public double obtenerFactor(int personaQuintil)
        {
            if (personaQuintil == 1)

            {
                return 0.31714;
            }
            else if (personaQuintil == 2)
            {
                return  0.63428;      
            }
            else if (personaQuintil == 3)
            {
                return 0.95142;
            }
            else if (personaQuintil == 4)
            {
                return  1.26856;
            }
            else if (personaQuintil == 5)
            {
                return 1.585700;
            }
            else
            {
                return 0;
            }
        }

        public bool crearPago(int creditos1ra, int creditos2da, int creditos3ra, double factor, double valorMatricula, double valorArancel, double recargoRep2da, double recargaRep3ra, double fepon, int id)
        {
            try
            {
                pago = new tbl_Pago(creditos1ra, creditos2da, creditos3ra, factor, valorMatricula, valorArancel, recargoRep2da, recargaRep3ra, fepon, 0, 1, id);
                bd.pago.InsertOnSubmit(pago);
                bd.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }
        
       /* public double obtenerPago(int creditos1ra, int creditos2da, int creditos3ra, double factor, double valorMatricula, double valorArancel, double recargoRep2da, double recargaRep3ra, double fepon)
        {
            throw new NotImplementedException();
        }*/
    }
}
