using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class ConnectToDB 
    {
        SqlConnection con = null;
        public ConnectToDB()
        {
            string str = ConfigurationSettings.AppSettings["connectionString"];
            con = new SqlConnection(str);
        }
        public bool checkLogin(string name, string pass)
        {
            bool check = false;
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("Select * from Users WHERE Name = @name AND Pass = @pass", con);
                com.Parameters.AddWithValue("@name", name);
                com.Parameters.AddWithValue("@pass", pass);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    check = true;
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                if (con.State != System.Data.ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            return check;
        }
    }
}
