using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bang_Revolution_WebApp
{
    public partial class Shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            Response.Redirect("ItemShop.aspx?username=" + Request["username"]);
        }

        protected void Characters_Click(object sender, EventArgs e)
        {
            Response.Redirect("CharacterShop.aspx?username=" + Request["username"]);
        }
    }
}