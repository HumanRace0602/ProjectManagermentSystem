using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLib;

namespace SystemWebUI.UserPage
{
    public partial class DetailProjectDocument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"].ToString() != "traveller")
            {
                if (Request.QueryString["role"] == "Admin")
                {
                    UserProject userProject = new UserProject();
                    try
                    {
                        userProject = UserProject.GetUserSetupProjectById(Int32.Parse(Request.QueryString["id"]), Session["userName"].ToString());
                    }
                    catch
                    {
                        Response.Write("Error!");
                    }
                    string path = Server.MapPath("~/App_Data/Projects") + "\\" + Request.QueryString["id"];
                }
            }
        }
    }
}