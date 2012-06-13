using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemWebUI.UserPage
{
    public partial class MyJoinProjectMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjectDataSource1.DataBind();
        }

        protected void Accept_Command(object sender, CommandEventArgs e)
        {
            if (BusinessLogicLib.UserProject.AcceptProject(Int32.Parse(e.CommandArgument.ToString())))
            {
                Response.Write("<script>alert('接受成功!');</script>");
                Response.Redirect("~/UserPage/MyJoinProjectMessage.aspx");
            }
            else
            {
                Response.Write("<script>alert('接受失败!');</script>");
            }

            ObjectDataSource1.DataBind();
        }

        protected void deny_Command(object sender, CommandEventArgs e)
        {
            if (BusinessLogicLib.UserProject.AcceptProject(Int32.Parse(e.CommandArgument.ToString())))
            {
                Response.Write("<script>alert('拒绝成功!');</script>");
                Response.Redirect("~/UserPage/MyJoinProjectMessage.aspx");
            }
            else
            {
                Response.Write("<script>alert('拒绝失败!');</script>");
            }
            ObjectDataSource1.DataBind();
        }
    }
}