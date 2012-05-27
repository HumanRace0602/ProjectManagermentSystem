using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemWebUI.Common
{
    public partial class SiteCommon : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"].ToString() != "traveller")
            {
                Label1.Text = "欢迎您，" + Session["userName"].ToString();
                Button1.Text = "[注销]";
            }
            else
            {
                Label1.Text = "请登陆";
                Button1.Text = "[登陆]";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Account/LogOn.aspx");
        }
    }
}