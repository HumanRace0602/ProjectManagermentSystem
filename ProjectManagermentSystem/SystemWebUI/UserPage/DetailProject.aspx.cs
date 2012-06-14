using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataModels.Object;
using BusinessLogicLib;

namespace SystemWebUI.UserPage
{
    public partial class DetailProject : SystemWebUI.PageClass.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserProject.IsAllowReadProject(Int32.Parse(Request.QueryString["id"]), Session["userName"].ToString()))
            {
                UserProject myProject = new UserProject();
                List<ProjectRole> pRoles = new List<ProjectRole>();
                pRoles = UserProject.GetProjectRolesByProjectId(Int32.Parse(Request.QueryString["id"]));
                string executeUsers = String.Empty;
                foreach (ProjectRole pRole in pRoles)
                {
                    if (pRole.state == "Yes")
                    {
                        if (pRole.role == "Request")
                        {
                            TableCell2.Text = pRole.userName;
                        }
                        if (pRole.role == "Execute")
                        {
                            executeUsers += pRole.userName + " ";
                        }
                    }
                    if (pRole.role == "Admin")
                    {
                        TableCell1.Text = pRole.userName;
                        TableCell4.Text = pRole.userName;
                    }
                    
                }
                TableCell3.Text = executeUsers;

                TableCell6.Text = "<a href=\"ProjectDocuments/Request.aspx?id=" + Request.QueryString["id"] + "&projectName=" + Request.QueryString["projectName"] + "\">文档</a>";
                TableCell5.Text = "<a href=\"ProjectDocuments/Plan.aspx?id=" + Request.QueryString["id"] + "&projectName=" + Request.QueryString["projectName"] + "\">文档</a>";
                TableCell7.Text = "<a href=\"ProjectDocuments/Execute.aspx?id=" + Request.QueryString["id"] + "&projectName=" + Request.QueryString["projectName"] + "\">文档</a>";
                TableCell8.Text = "<a href=\"ProjectDocuments/Final.aspx?id=" + Request.QueryString["id"] + "&projectName=" + Request.QueryString["projectName"] + "\">文档</a>";
            }
            else
            {
                Response.Redirect("Error.aspx");
            }

            if (BusinessLogicLib.UserProject.IsProjectFinished(Int32.Parse(Request.QueryString["id"])))
            {
                LinkButton1.Visible = false;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (!BusinessLogicLib.UserProject.IsProjectFinished(Int32.Parse(Request.QueryString["id"])))
            {
                BusinessLogicLib.UserProject.FinishProject(Int32.Parse(Request.QueryString["id"]));
                Response.Write("<script>alert('成功结束')</script>");
                Response.Redirect("~/UserPage/MyProject.aspx");
            }
        }
    }
}