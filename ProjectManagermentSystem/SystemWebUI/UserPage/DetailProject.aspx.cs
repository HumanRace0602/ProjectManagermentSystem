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
    public partial class DetailProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"].ToString() != "traverller")
            {
                if (UserProject.IsAllowReadProject(Int32.Parse(Request.QueryString["id"]), Session["userName"].ToString()))
                {
                    UserProject myProject = new UserProject();
                    List<ProjectRole> pRoles = new List<ProjectRole>();
                    pRoles = UserProject.GetUserSetupProjectRolesById(Int32.Parse(Request.QueryString["id"]), Session["userName"].ToString());
                    foreach (ProjectRole pRole in pRoles)
                    {
                        if (pRole.role == "Request")
                        {
                            TableCell2.Text = pRole.userName;
                        }
                        if (pRole.role == "Execute")
                        {
                            TableCell3.Text = pRole.userName;
                        }
                    }
                    TableCell1.Text = Session["userName"].ToString();
                    TableCell4.Text = Session["userName"].ToString();
                    TableCell5.Text = "<a href=\"ProjectDocuments/Request.aspx?id=" + Request.QueryString["id"] + "&projectName=" + Request.QueryString["projectName"] + "\">文档</a>";
                    TableCell6.Text = "<a href=\"ProjectDocuments/Plan.aspx?id=" + Request.QueryString["id"] + "&projectName=" + Request.QueryString["projectName"] + "\">文档</a>";
                    TableCell7.Text = "<a href=\"ProjectDocuments/Execute.aspx?id=" + Request.QueryString["id"] + "&projectName=" + Request.QueryString["projectName"] + "\">文档</a>";
                    TableCell8.Text = "<a href=\"ProjectDocuments/Final.aspx?id=" + Request.QueryString["id"] + "&projectName=" + Request.QueryString["projectName"] + "\">文档</a>";
                }
            }
        }
    }
}