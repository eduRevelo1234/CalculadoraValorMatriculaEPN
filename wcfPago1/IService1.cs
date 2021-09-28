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
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace wcfPago1
{
    //Definicion de la interfaz del servicio de pago que sera consumido por el formulario Web
    //Aqui se definen todas las operaciones de servicio
    [ServiceContract]
    public interface IService1
    {
        //metodo que permitira obtener pago ingresando un id
        [OperationContract]
        tbl_Pago obtenerPago(int id);
        //metodo que permitira obtener pago ingresando un id
        [OperationContract]
        tbl_Pago obtenerPago2(int id);
        //metodo para obtener una persona ingresando un nuemro de cedula
        [OperationContract]
        tbl_Usuario obtenerPersona(string cedula);
        //metodo para obtener una persona ingresando un ID
        [OperationContract]
        tbl_Usuario obtenerPersonaConCI(int id);
        //metodo para calcular el arancel ingresando el quintil 
        [OperationContract]
        double obtenerAranceles(int personaQuintil);
        //metodo para calcular el valor de matricula ingresando el quintil 
        [OperationContract]
        double obtenerMatricula(int personaQuintil);
        //metodo para calcular el factor ingresando el quintil 
        [OperationContract]
        double obtenerFactor(int personaQuintil);
        //metodo para crear un apgo y agregarlo a la base de datos
        [OperationContract]
        bool crearPago(int creditos1ra, int creditos2da, int creditos3ra,
            double factor, double valorMatricula, double valorArancel, double recargoRep2da,
            double recargaRep3ra, double fepon, int id);
    }    
    // Se agrega los tipos compuestos a las operaciones de servicio
    // Se define la clase pago que se usara para guardar en la base de datos segun los datos ingresados por el cliente 
    [DataContract]
    [Table(Name = "tbl_Pago")]
    public class tbl_Pago
    {
        [DataMember]
        [Column(IsPrimaryKey = true, AutoSync = AutoSync.OnInsert, IsDbGenerated = true)]
        public int idPago;
        [DataMember]
        [Column]
        public int creditos1ra;
        [DataMember]
        [Column]
        public int creditos2da;
        [DataMember]
        [Column]
        public int creditos3ra;
        [DataMember]
        [Column]
        public double factor;
        [DataMember]
        [Column]
        public double valorMatricula;
        [DataMember]
        [Column]
        public double valorArancel;
        [DataMember]
        [Column]
        public double recargoRep2da;
        [DataMember]
        [Column]
        public double recargoRep3ra;
        [DataMember]
        [Column]
        public double fepon;
        [DataMember]
        [Column]
        public double adicionales;
        [DataMember]
        [Column]
        public double bancario;
        [DataMember]
        [Column]
        public double valorApagar;
        [DataMember]
        [Column]
        public int idUsuario;
        //Constructor de la clase
        public tbl_Pago(int creditos1ra, int creditos2da, int creditos3ra, double factor, double valorMatricula, double valorArancel, double recargoRep2da, double recargoRep3ra, double fepon, double adicionales, double bancario, double pago, int idUsuario)
        {
            this.creditos1ra = creditos1ra;
            this.Creditos2da = creditos2da;
            this.creditos3ra = creditos3ra;
            this.factor = factor;
            this.valorMatricula = valorMatricula;
            this.valorArancel = valorArancel;
            this.recargoRep2da = recargoRep2da;
            this.recargoRep3ra = recargoRep3ra;
            this.fepon = fepon;
            this.adicionales = adicionales;
            this.bancario = bancario;
            this.valorApagar = pago;
            this.idUsuario = idUsuario;
        }
        // geters y seters de los atributos de clases
        public int IdPago { get => idPago; set => idPago = value; }
        public int Creditos1ra { get => creditos1ra; set => creditos1ra = value; }
        public int Creditos2da { get => creditos2da; set => creditos2da = value; }
        public int Creditos3ra { get => creditos3ra; set => creditos3ra = value; }
        public double Factor { get => factor; set => factor = value; }
        public double ValorMatricula { get => valorMatricula; set => valorMatricula = value; }
        public double ValorArancel { get => valorArancel; set => valorArancel = value; }
        public double RecargoRep2da { get => recargoRep2da; set => recargoRep2da = value; }
        public double RecargoRep3ra { get => recargoRep3ra; set => recargoRep3ra = value; }
        public double Fepon { get => fepon; set => fepon = value; }
        public double Adicionales { get => adicionales; set => adicionales = value; }
        public double Bancario { get => bancario; set => bancario = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public tbl_Pago()
        {
        }
        
    }
    // Se define la clase usuario que se usara para cargar de la base de datos el quintil de los usuarios creados en el proyecto anterior 
    [DataContract]
    [Table(Name = "tbl_Usuario")]
    public class tbl_Usuario
    {
        [DataMember]
        [Column(IsPrimaryKey = true, AutoSync = AutoSync.OnInsert, IsDbGenerated = true)]
        public int idUsuario;
        [DataMember]
        [Column]
        public string numeroCedula { get; set; }
        [DataMember]
        [Column]
        public string nombre1Usuario;
        [DataMember]
        [Column]
        public string nombre2Usuario;
        [DataMember]
        [Column]
        public string apellido1Usuario;
        [DataMember]
        [Column]
        public string apellido2Usuario;
        [DataMember]
        [Column]
        public string contrasena;
        [DataMember]
        [Column]
        public int quintil;

        public tbl_Usuario()
        {

        }

        // Se crea el constructor para la tabla usuario  
        public tbl_Usuario(string numeroCedula, string nombre1Usuario, string nombre2Usuario,
            string apellido1Usuario, string apellido2Usuario, string contrasena, int quintil)
        {
            this.apellido1Usuario = apellido1Usuario;
            this.apellido2Usuario = apellido2Usuario;
            this.nombre1Usuario = nombre1Usuario;
            this.nombre2Usuario = nombre2Usuario;
            this.numeroCedula = numeroCedula;
            this.quintil = quintil;
        }
        // geters y seters de los atributos de clases
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string NumeroCedula { get => numeroCedula; set => numeroCedula = value; }
        public string Nombre1Usuario { get => nombre1Usuario; set => nombre1Usuario = value; }
        public string Nombre2Usuario { get => nombre2Usuario; set => nombre2Usuario = value; }
        public string Apellido1Usuario { get => apellido1Usuario; set => apellido1Usuario = value; }
        public string Apellido2Usuario { get => apellido2Usuario; set => apellido2Usuario = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public int Quintil { get => quintil; set => quintil = value; }

        // Se implementa el toString para la clase 
        public override string ToString()
        {
            return "Cedula: " + numeroCedula + " Nombre: " + Nombre1Usuario + " " + Apellido1Usuario;
        }
    }
}
