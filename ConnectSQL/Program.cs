 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConnectSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=DESKTOP-JE4BQAC;Database=Sample_Database;Trusted_connection=True";
            
            using(SqlConnection con=new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd=new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "insert into dbo.Sample_Table values(9,'jane','smith','ny','ny','janesmith@gmail.com')";

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        string personId = dr["PersonID"].ToString();
                        string lastname = dr["LastName"].ToString();
                        string firstname = dr["FirstName"].ToString();
                        string address = dr["Address"].ToString();
                        string city = dr["City"].ToString();
                        string email = dr["Email"].ToString();

                        Console.WriteLine(personId + " " + lastname + " " + firstname + " " + address + " " + city + " " + email);
                    }
                    dr.Close();
                }
            }
            Console.ReadKey();
        }
    }
}
