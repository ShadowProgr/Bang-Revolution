using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Entity;

namespace Bang_Revolution_WebApp
{
    public partial class Shop : System.Web.UI.Page
    {
        List<Character> character = new List<Character>();
        List<Item> item = new List<Item>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConnectToDB conn = new ConnectToDB();
                int id = conn.getUserID(Request["username"]);
                character = conn.getAllChar();
                List<Character> notShow = conn.getCharbyUserID(id);
                foreach (Character c in notShow)
                {
                    for (int i = 0; i < character.Count; i++)
                    {
                        if (character[i].id == c.id)
                        {
                            character.RemoveAt(i);
                            i = 0;
                            break;
                        }
                    }
                }
                characterGrid.DataSource = character;
                characterGrid.DataBind();
                item = conn.getAllItem();
                List<Item> notShow2 = conn.getItembyUserID(id);
                foreach (Item i in notShow2)
                {
                    for (int j = 0; j < item.Count; j++)
                    {
                        if (item[j].id == i.id)
                        {
                            item.RemoveAt(j);
                            j = 0;
                            break;
                        }
                    }
                }
                itemGrid.DataSource = item;
                itemGrid.DataBind();
            }
        }

        protected void update()
        {
            ConnectToDB conn = new ConnectToDB();
            int id = conn.getUserID(Request["username"]);
            character = conn.getAllChar();
            List<Character> notShow = conn.getCharbyUserID(id);
            foreach (Character c in notShow)
            {
                for (int i = 0; i < character.Count; i++)
                {
                    if (character[i].id == c.id)
                    {
                        character.RemoveAt(i);
                        i = 0;
                        break;
                    }
                }
            }
            characterGrid.DataSource = character;
            characterGrid.DataBind();
            item = conn.getAllItem();
            List<Item> notShow2 = conn.getItembyUserID(id);
            foreach (Item i in notShow2)
            {
                for (int j = 0; j < item.Count; j++)
                {
                    if (item[j].id == i.id)
                    {
                        item.RemoveAt(j);
                        j = 0;
                        break;
                    }
                }
            }
            itemGrid.DataSource = item;
            itemGrid.DataBind();
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx?username=" + Request["username"]);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shop.aspx?username=" + Request["username"]);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Items_Click(object sender, EventArgs e)
        {
            BangShop.ActiveViewIndex = 0;
        }

        protected void Characters_Click(object sender, EventArgs e)
        {
            BangShop.ActiveViewIndex = 1;
        }

        protected void itemGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Buy1"))
            {
                int index = int.Parse(e.CommandArgument.ToString());
                GridViewRow row = itemGrid.Rows[index];
                Label label = row.FindControl("lblID_hidden") as Label;
                ConnectToDB ctd = new ConnectToDB();
                int iid = int.Parse(label.Text);
                int uid = ctd.getUserID(Request["username"]);
                UData ud = ctd.getUserData(uid);
                double price = ctd.getItem(iid).price;
                if (ud.money > price) 
                {
                    ctd.addItemtoIC(uid, iid);
                    ctd.updateMoney(uid, ud.money - price);
                }
                for (int j = 0; j < item.Count; j++)
                {
                    if (item[j].id == iid)
                    {
                        item.RemoveAt(j);
                        j = 0;
                        break;
                    }
                }
                itemGrid.DataSource = item;
                itemGrid.DataBind();
                update();
            }
        }

        protected void characterGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Buy2"))
            {
                int index = int.Parse(e.CommandArgument.ToString());
                GridViewRow row = characterGrid.Rows[index];
                Label label = row.FindControl("lblID_hidden") as Label;
                ConnectToDB ctd = new ConnectToDB();
                int cid = int.Parse(label.Text);
                int uid = ctd.getUserID(Request["username"]);
                UData ud = ctd.getUserData(uid);
                double price = ctd.getChar(cid).price;
                if (ud.money > price) {
                    ctd.addChartoPC(uid, cid);
                    ctd.updateMoney(uid, ud.money - price);
                }
                update();
            }
        }

    }
}