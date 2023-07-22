using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        public static string GetConection()
        {
            //return "Data Source=leyed\\SQLEXPRESS;Initial Catalog=InventarioComputoFH;Persist Security Info=True;User ID=sa;Password=123456789; TrustServerCertificate=True";


            string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["InventarioComputoFH"].ConnectionString;

            return cadenaConexion;


        }

    }
}
//Data Source=leyed\SQLEXPRESS;Initial Catalog=InventarioComputoFH;Persist Security Info=True;User ID=sa