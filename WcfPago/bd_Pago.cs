using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;



namespace WcfPago
{
    public class bd_Pago : DataContext
    {
        public bd_Pago() : base(@"Data Source=LAPTOP-T8C52P8P\SQLEXPRESS;Initial Catalog=BD_Proyecto2;Integrated Security=True") { }
        public Table<tbl_Usuario> usuario;
        public Table<tbl_Pago> pago;
    }
}