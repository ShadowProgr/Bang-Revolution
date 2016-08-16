using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using UserData;

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
        public bool checkRegis(string name)
        {
            bool check = false;
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("Select * from Users WHERE Name = @name", con);
                com.Parameters.AddWithValue("@name", name);
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
        public void addUser(string name, string pass, string email)
        {
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("Insert Into Users (Name, Pass, Email) Values (@Name, @Pass, @Email)", con);
                com.Parameters.AddWithValue("@Name", name);
                com.Parameters.AddWithValue("@Pass", pass);
                com.Parameters.AddWithValue("@Email", email);
                com.ExecuteNonQuery();
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
        }
        public int getUserID(string name)
        {
            int id = 0;
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("Select * from Users WHERE Name = @name", con);
                com.Parameters.AddWithValue("@name", name);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    id = (int)reader["ID"];
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
            return id;
        }
        public void addUserData(int id)
        {
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("Insert Into UserData ([User ID], Exp, Win, Lose, Rate, Money) Values (@UserID, @Exp, @Win, @Lose, @Rate, @Money)", con);
                com.Parameters.AddWithValue("@UserID", id);
                com.Parameters.AddWithValue("@Exp", 0);
                com.Parameters.AddWithValue("@Win", 0);
                com.Parameters.AddWithValue("@Lose", 0);
                com.Parameters.AddWithValue("@Rate", 0);
                com.Parameters.AddWithValue("@Money", 0);
                com.ExecuteNonQuery();
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
        }
        public UData getUserData(int id)
        {
            UData ud = new UData();
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("Select * from UserData WHERE [User ID] = @ID", con);
                com.Parameters.AddWithValue("@ID", id);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    ud = new UData()
                    {
                        id = (int)reader["User ID"],
                        exp = long.Parse(reader["Exp"].ToString()),
                        win = long.Parse(reader["Win"].ToString()),
                        lose = long.Parse(reader["Lose"].ToString()),
                        rate = float.Parse(reader["Rate"].ToString()),
                        money = long.Parse(reader["Money"].ToString())
                    };
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
            return ud;
        }
    }
}
