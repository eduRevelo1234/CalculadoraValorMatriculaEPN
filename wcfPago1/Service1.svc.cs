// ************************************************************************
// Proyecto 02
// Nombre:  Eduardo Revelo
//          Bryan Simbaña
// Fecha de entrega: 9/02/2020
//*************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace wcfPago1
{
    
    //Se define la clase service que define la implementacion de las operaciones de la interfaz
    public class Service1 : IService1
    {
        //Se agrega la clase BD para hacer las consultas con la base de datos usando LINQ
        bd_Pago bd = new bd_Pago();
        bd_Pago bd1 = new bd_Pago();
        //Se difine una clase Pago para crear la clase
        tbl_Pago pago;

        double valorArancelfinal;
        //Metodo para obtener pago ingresando el id de la persona de la base de datos usando una consulta sql mediante LINQ 
        public tbl_Pago obtenerPago(int id)
        {
            var pagox = (from iter in bd.pago
                         where iter.idUsuario == id
                         select iter).FirstOrDefault();
            return pagox;
        }
        //Metodo para obtener usuario ingresando el numero de cedula de la persona, de la base de datos usando una consulta sql mediante LINQ 
        public tbl_Usuario obtenerPersona(string cedula)
        {
            var usuraio = (from iter in bd.usuario
                           where iter.numeroCedula == cedula
                           select iter).FirstOrDefault();
            return usuraio;
        }
        //Metodo para obtener usuario ingresando el id de la persona, de la base de datos usando una consulta sql mediante LINQ 
        public tbl_Usuario obtenerPersonaConCI(int id)
        {

            var usuraio = (from iter in bd.usuario
                           where iter.idUsuario == id
                           select iter).FirstOrDefault();
            return usuraio;
        }
        //Metodo para obtener el valor del arancel que le corresponde mediante su quintil
        public double obtenerAranceles(int personaQuintil)
        {
            if (personaQuintil == 1)

            {
                return 152.23;
            }
            else if (personaQuintil == 2)
            {
                return 304.45;
            }
            else if (personaQuintil == 3)
            {
                return 456.68;
            }
            else if (personaQuintil == 4)
            {
                return 608.91;
            }
            else if (personaQuintil == 5)
            {
                return 761.14;
            }
            else
            {
                return 0;
            }
        }
        //Metodo para obtener el valor de la matricula que le corresponde mediante su quintil
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
        //Metodo para obtener el valor del factor que le corresponde mediante su quintil
        public double obtenerFactor(int personaQuintil)
        {
            if (personaQuintil == 1)
            {
                return 0.31714;
            }
            else if (personaQuintil == 2)
            {
                return 0.63428;
            }
            else if (personaQuintil == 3)
            {
                return 0.95142;
            }
            else if (personaQuintil == 4)
            {
                return 1.26856;
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
        //Metodo para crear un pago y guardarlo en la base de datos con una consulta SQL usando LINQ, se crea el pago con los datos ingresados por el cliente
        public bool crearPago(int creditos1ra, int creditos2da, int creditos3ra, double factor, double valorMatricula, double valorArancel, double recargoRep2da, double recargaRep3ra, double fepon, int id)
        {
            double pagox;
            try
            {
                //Si no tiene creditos de segunda y tercera el pago sera 0 o 20 dependiendo si el cliente a decidido pagar fepon o no 
                if(creditos3ra==0 && creditos2da==0)
                {
                    valorArancelfinal = 0;
                    if(fepon == 0)
                    {
                        pagox = 0;
                    }
                    else
                    {
                         pagox = fepon + 1;
                    }
                    
                    pago = new tbl_Pago(creditos1ra, creditos2da, creditos3ra, factor, valorMatricula, valorArancelfinal, recargoRep2da, recargaRep3ra, fepon, 0, 1, pagox, id);

                }
                //Si se tiene menos de 10 creditos matriculados se pierde la gratuidad y el pago sera total
                else if(creditos1ra+creditos2da+creditos3ra < 10)
                {
                    valorArancelfinal = valorArancel * (creditos1ra + creditos2da + creditos3ra) / 30;
                     pagox = valorMatricula + valorArancelfinal + recargoRep2da + recargaRep3ra + fepon + 1;
                    pago = new tbl_Pago(creditos1ra, creditos2da, creditos3ra, factor, valorMatricula, valorArancelfinal, recargoRep2da, recargaRep3ra, fepon, 0, 1, pagox, id);
                }
                //si se tiene creditos de segunda y tercera, se procede a cobrar por estos creditos
                else
                {
                    valorArancelfinal = valorArancel * (creditos2da + creditos3ra) / 30;
                     pagox = valorMatricula + valorArancelfinal + recargoRep2da + recargaRep3ra + fepon;
                    pago = new tbl_Pago(creditos1ra, creditos2da, creditos3ra, factor, valorMatricula, valorArancelfinal, recargoRep2da, recargaRep3ra, fepon, 0, 1, pagox, id);

                }
                //Se guardo el pago en la base 
                bd.pago.InsertOnSubmit(pago);
                bd.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        //Metodo para obtener pago ingresando el id de la persona de la base de datos usando una consulta sql mediante LINQ  
        public tbl_Pago obtenerPago2(int id)
        {   
            var pagox = (from iter in bd1.pago
                         where iter.creditos1ra == id
                         select iter).FirstOrDefault();
            return pagox;
        }
    }
}
