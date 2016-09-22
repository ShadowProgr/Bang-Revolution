using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
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

        public void updateCurrentBg(int bid, int uid)
        {
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("Update UserData SET CurrentBackCard = @BC WHERE [User ID] = @uid", con);
                com.Parameters.AddWithValue("@uid", uid);
                com.Parameters.AddWithValue("@BC", bid);
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
        public void updateCurrentBC(int bid, int uid)
        {
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("Update UserData SET CurrentBg = @bg WHERE [User ID] = @uid", con);
                com.Parameters.AddWithValue("@uid", uid);
                com.Parameters.AddWithValue("@bg", bid);
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

        public Character getChar(int id)
        {
            Character c = new Character();
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("Select * from Characters WHERE ID = @ID", con);
                com.Parameters.AddWithValue("@ID", id);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    c = new Character()
                    {
                        id = (int)reader["ID"],
                        desc = reader["Desc"].ToString(),
                        img = reader["Img"].ToString(),
                        name = reader["Name"].ToString(),
                        hp = (int)reader["HP"],
                        price = (double)reader["Price"],
                        skillID = (int)reader["SkillID"]

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
            return c;
        }

        public Item getItem(int id)
        {
            Item i = new Item();
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("Select * from Items WHERE ID = @ID", con);
                com.Parameters.AddWithValue("@ID", id);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    i = new Item()
                    {
                        id = (int)reader["ID"],
                        img = reader["Img"].ToString(),
                        name = reader["Name"].ToString(),
                        price = (double)reader["Price"],
                        isBackground = (bool)reader["isBg"]
                    };
                    i.img = @"~/img/" + i.name + ".jpg";
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
            return i;
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
                        desc = reader["Desc"].ToString(),
                        name = reader["Name"].ToString().Trim(),
                        hp = (int)reader["HP"],
                        price = (double)reader["Price"],
                        skillID = (int)reader["SkillID"]
                    };
                    c.img = @"~/img/" + c.name + ".png";
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

        public List<Character> getAllChar()
        {
            List<Character> character = new List<Character>();
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM Characters", con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Character c = new Character()
                    {
                        id = (int)reader["ID"],
                        desc = reader["Desc"].ToString(),
                        img = reader["Img"].ToString(),
                        name = reader["Name"].ToString().Trim(),
                        hp = (int)reader["HP"],
                        price = (double)reader["Price"],
                        skillID = (int)reader["SkillID"]
                    };
                    c.img = @"~/img/" + c.name + ".png";
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
                SqlCommand com = new SqlCommand("SELECT * FROM ItemPurchase IP join Items I on IP.[Item ID] = I.ID WHERE IP.[User ID] = @id", con);
                com.Parameters.AddWithValue("@id", userID);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Item i = new Item()
                    {
                        id = (int)reader["ID"],
                        img = reader["Img"].ToString(),
                        name = reader["Name"].ToString(),
                        price = (double)reader["Price"],
                        isBackground = (bool)reader["isBg"]
                    };
                    i.img = @"~/img/" + i.name + ".jpg";
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

        public List<Item> getAllItem()
        {
            List<Item> items = new List<Item>();
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM Items", con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Item i = new Item()
                    {
                        id = (int)reader["ID"],
                        img = reader["Img"].ToString(),
                        name = reader["Name"].ToString(),
                        price = (double)reader["Price"],
                        isBackground = (bool)reader["isBg"]
                    };
                    i.img = @"~/img/" + i.name + ".jpg";
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

        public void addChartoPC(int uid, int cid)
        {
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("Insert Into CharacterPuchase ([User ID], [Char ID]) Values (@UserID, @CharID)", con);
                com.Parameters.AddWithValue("@UserID", uid);
                com.Parameters.AddWithValue("@CharID", cid);
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

        public void updateMoney(int uid, double money)
        {
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("Update UserData SET Money = @money WHERE [User ID] = @uid", con);
                com.Parameters.AddWithValue("@uid", uid);
                com.Parameters.AddWithValue("@money", money);
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

        public void addItemtoIC(int uid, int iid)
        {
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("Insert Into ItemPurchase ([User ID], [Item ID]) Values (@UserID, @ItemID)", con);
                com.Parameters.AddWithValue("@UserID", uid);
                com.Parameters.AddWithValue("@ItemID", iid);
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
