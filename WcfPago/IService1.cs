using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace WcfPago
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
       
        [OperationContract]
        tbl_Pago obtenerPago(string cedula);
        [OperationContract]
        tbl_Usuario obtenerPersona(string cedula);
        [OperationContract]
        tbl_Usuario obtenerPersonaConCI(int id);
        [OperationContract]
        quintilx obtenerArancel(int quintil);
        [OperationContract]
        double obtenerAranceles(int personaQuintil);
        [OperationContract]
        double obtenerMatricula(int personaQuintil);
        [OperationContract]
        double obtenerFactor(int personaQuintil);
        [OperationContract]
        bool crearPago(int creditos1ra, int creditos2da, int creditos3ra,
            double factor, double valorMatricula, double valorArancel, double recargoRep2da,
            double recargaRep3ra, double fepon, int id);
       
      /*  double obtenerPago(int creditos1ra, int creditos2da, int creditos3ra,
            double factor,double valorMatricula, double valorArancel, double recargoRep2da,
            double recargaRep3ra, double fepon);
        */
        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class quintilx
    {
        [DataMember]
        public double factor { get; set; }
        [DataMember]
        public double arancelesTotal { get; set; }
        [DataMember]
        public double matricula { get; set; }
    }

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
        public int idUsuario;

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

        public tbl_Pago(int creditos1ra, int creditos2da, int creditos3ra, double factor, double valorMatricula, double valorArancel, double  recargoRep2da, double recargoRep3ra, double fepon, double adicionales, double bancario, int idUsuario)
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
            this.idUsuario = idUsuario;
        }
    }

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
