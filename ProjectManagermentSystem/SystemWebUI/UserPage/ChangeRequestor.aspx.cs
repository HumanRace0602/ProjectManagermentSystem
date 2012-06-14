using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLib;

namespace SystemWebUI.UserPage
{
    public partial class ChangeRequestor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            List<string> users = new List<string>();
            users = ProjectUser.FindSimilarUsers(TextBox3.Text);

            ListBox1.DataSource = users;
            ListBox1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ListBox2.Items.Add(ListBox1.SelectedValue);
            ListBox1.Items.Remove(ListBox1.SelectedValue);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Add(ListBox2.SelectedValue);
            ListBox2.Items.Remove(ListBox2.SelectedValue);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {

        }
    }
}