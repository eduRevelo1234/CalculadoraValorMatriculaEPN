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
using System.Data.Linq;

namespace wcfPago1
{
        //Clase de la base de datos que se usara para hacer las consultas mediante LINQ
        public class bd_Pago : DataContext
        {
            public bd_Pago() : base(@"Data Source=DESKTOP-V65BFOG\SQLEXPRESS;Initial Catalog=BD_EncuestaSocioEconomica;Integrated Security=True") { }
            public Table<tbl_Usuario> usuario;
            public Table<tbl_Pago> pago;
        }
}