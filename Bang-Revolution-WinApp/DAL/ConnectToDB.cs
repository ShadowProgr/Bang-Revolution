using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
using Entity;

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

        public List<Role> getRoles()
        {
            List<Role> roles = new List<Role>();
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("Select * from Roles", con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Role r = new Role()
                    {
                        id = (int)reader["ID"],
                        desc = reader["[Desc]"].ToString(),
                        img = reader["Img"].ToString(),
                        name = reader["Name"].ToString()
                    };
                    roles.Add(r);
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
            return roles;
        }

        public List<Character> getCharbyUserID(int userID)
        {
            List<Character> character = new List<Character>();
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM CharacterPuchase CP join Characters C on CP.[Char ID] = C.ID WHERE CP.[User ID] = @id", con);
                com.Parameters.AddWithValue("@id", userID);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Character c = new Character()
                    {
                        id = (int)reader["ID"],
                        desc = reader["[Desc]"].ToString(),
                        img = reader["Img"].ToString(),
                        name = reader["Name"].ToString(),
                        hp = (int) reader["HP"],
                        price = (float) reader["Price"],
                        skillID = (int) reader["SkillID"]
                    };
                    character.Add(c);
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
            return character;
        }

        public List<Item> getItembyUserID(int userID)
        {
            List<Item> items = new List<Item>();
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM ItemPuchase IP join Items I on IP.[Item ID] = I.ID WHERE IP.[User ID] = @id", con);
                com.Parameters.AddWithValue("@id", userID);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Item i = new Item()
                    {
                        id = (int)reader["ID"],
                        img = reader["Img"].ToString(),
                        name = reader["Name"].ToString(),
                        price = (float)reader["Price"],
                        isBackground = (bool) reader["isBg"]
                    };
                    items.Add(i);
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
            return items;
        }

        public List<Card> getCard()
        {
            List<Card> card = new List<Card>();
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("Select * from Roles", con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Card c = new Card()
                    {
                        id = (int)reader["ID"],
                        img = reader["Img"].ToString(),
                        name = reader["Name"].ToString(),
                        effectID = (int) reader["EffectID"],
                        rank = (int)reader["Rank"],
                        suit = (int) reader["Suit"]
                    };
                    card.Add(c);
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
            return card;
        }

        public void addUser(string name, string pass, string email)
        {
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("INSERT INTO Users (Name, Pass, Email) VALUES (@name, @pass, @email) ", con);
                com.Parameters.AddWithValue("@name", name);
                com.Parameters.AddWithValue("@pass", pass);
                com.Parameters.AddWithValue("@email", email);
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
    }
}
