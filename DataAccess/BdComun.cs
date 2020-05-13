using System.Data.SqlClient;

namespace Taller.DataAccess
{
    public class BdComun
    {

       public static SqlConnection ObtenerConexion()
       {
           SqlConnection conectar = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Taller;Integrated Security=true;");

           conectar.Open();
           return conectar;
       }

    }
}
