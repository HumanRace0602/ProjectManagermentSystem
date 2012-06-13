using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemWebUI.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    DataModels.Object.User newUser = new DataModels.Object.User();
                    newUser.username = Request.Form["userName"];
                    string password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Request.Form["password"].ToString(),"MD5");
                    int l = password.Length;
                    newUser.password = password;
                    newUser.email = Request.Form["email"];
                    BusinessLogicLib.Account.Account.AddNewUser(newUser);
                    Label1.Text = "恭喜您注册成功！";

                    Session["userName"] = Request.Form["userName"];
                    HyperLink1.NavigateUrl = "~/UserPage/MyPage.aspx";
                    Label2.Text = "5秒后自动进入个人中心，你也可以：";
                    HyperLink1.Text = "<br/><br/>[点击这里]";
                    Label3.Text = "进入个人中心";
                    Response.Write(" <meta   http-equiv='refresh'  content='5  url=../UserPage/Index.aspx'>");

                }
                catch
                {
                    Label1.Text = "抱歉，数据库错误！";
                }
            }
        }
    }
}