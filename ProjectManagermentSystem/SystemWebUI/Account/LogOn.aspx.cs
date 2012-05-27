using System;

namespace SystemWebUI.Account
{
    public partial class LogOn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (Session["Captcha"].ToString() == Request.Form["inputCaptcha"].ToUpper())
            {
                //userName.Value = Request.Form["userName"];
                //password.Value = Request.Form["password"];
                if (BusinessLogicLib.Account.Account.IsUserValidated(Request.Form["userName"], Request.Form["password"]))
                {
                    Session["userName"] = Request.Form["userName"];
                    Response.Redirect("~/UserPage/Index.aspx");
                }
                else
                {
                    LabelResult.Text = "*用户名或者密码错误";
                }

            }
            else
            {
                userName.Value = Request.Form["userName"];
                password.Value = Request.Form["password"];
                Random random = new Random();
                LabelResult.Text = "*验证码有误";
                ImageCaptcha.ImageUrl = "~/Account/Captcha.aspx?"+random.Next(9999);
            }
        }
    }
}