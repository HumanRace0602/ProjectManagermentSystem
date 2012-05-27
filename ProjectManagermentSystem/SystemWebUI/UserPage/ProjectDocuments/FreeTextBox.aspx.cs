using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLib;
using System.IO;

namespace SystemWebUI.UserPage.ProjectDocuments
{
    public partial class FreeTextBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserProject.IsProjectSetupByUser(Int32.Parse(Request.QueryString["id"]), Session["userName"].ToString()))
            {
                if (!IsPostBack)
                {
                    string path = Server.MapPath("~/App_Data/Projects") + "\\" + Request.QueryString["id"] + "\\Final.txt";
                    if (File.Exists(path))
                    {
                        FreeTextBox2.Text = File.ReadAllText(path, System.Text.Encoding.UTF8);
                    }
                    Button1.Visible = true;
                    Button2.Visible = true;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string pathDir = Server.MapPath("~/App_Data/Projects") + "\\" + Request.QueryString["id"];
            string path = pathDir + "\\Final.txt";
            string text = FreeTextBox2.Text;
            if (!Directory.Exists(pathDir))
            {
                Directory.CreateDirectory(pathDir);
            }
            File.WriteAllText(path, FreeTextBox2.Text, System.Text.Encoding.UTF8);
            Response.Redirect("Final.aspx?id="+Request.QueryString["id"]+"&projectName="+Request.QueryString["projectName"]);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Final.aspx?id=" + Request.QueryString["id"] + "&projectName=" + Request.QueryString["projectName"]);
        }
    }
}