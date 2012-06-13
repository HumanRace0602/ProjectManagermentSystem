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
    public partial class Execute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"].ToString() != "traveller")
            {
                if (UserProject.IsAllowReadProject(Int32.Parse(Request.QueryString["id"]), Session["userName"].ToString()))
                {
                    title.InnerText = "项目:" + Request.QueryString["projectName"] + " 执行文档";
                    string path = Server.MapPath("~/App_Data/Projects") + "\\" + Request.QueryString["id"] + "\\Execute.txt";
                    bool isPublise = false;
                    if (File.Exists(path))
                    {
                        divContext.InnerHtml = File.ReadAllText(path, System.Text.Encoding.UTF8);
                        isPublise = true;
                    }
                    else
                    {
                        divContext.InnerText = "该项目还没有发布执行文档。";
                    }

                    if (UserProject.IsProjectExecuteByUser(Int32.Parse(Request.QueryString["id"]), Session["userName"].ToString()))
                    {
                        Button1.Visible = true;
                        if (isPublise)
                        {
                            Button1.Text = "编辑";
                            Session["Button1"] = "Edit";
                        }
                        else
                        {
                            Button1.Text = "添加";
                            Session["Button1"] = "Append";
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["Button1"].ToString() == "Edit")
            {
                this.Response.Redirect("FreeTextBox.aspx?id=" + Request.QueryString["id"] + "&projectName=" + Request.QueryString["projectName"] + "&documentType=execute");
            }
            if (Session["Button1"].ToString() == "Append")
            {
                this.Response.Redirect("FreeTextBox.aspx?id=" + Request.QueryString["id"] + "&projectName=" + Request.QueryString["projectName"] + "&documentType=execute");
            }
        }
    }
}