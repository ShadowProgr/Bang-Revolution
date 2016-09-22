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
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConnectToDB conn = new ConnectToDB();
            int id = conn.getUserID(Request["username"]);
            List<Character> character = conn.getCharbyUserID(id);
            List<Item> item = conn.getItembyUserID(id);
            itemGrid.DataSource = item;
            itemGrid.DataBind();
            characterGrid.DataSource = character;
            characterGrid.DataBind();
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

        protected void itemGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Set"))
            {
                int index = int.Parse(e.CommandArgument.ToString());
                GridViewRow row = itemGrid.Rows[index];
                Label label = row.FindControl("lblID_hidden") as Label;
                Label label1 = row.FindControl("lblisBg_hidden") as Label;
                ConnectToDB ctd = new ConnectToDB();
                int uid = ctd.getUserID(Request["username"]);
                int id = int.Parse(label.Text);
                if (bool.Parse(label1.Text) == true)
                {
                    ctd.updateCurrentBg(id, uid);
                } else
                {
                    ctd.updateCurrentBC(id, uid);
                }
            }
        }
    }
}