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
                if (BusinessLogicLib.Account.Account.IsUserValidated(Request.Form["userName"], Request.Form["password"]))
                {
                    LabelResult.Text = "登陆成功";
                }
                else
                {
                    LabelResult.Text = "*用户名或者密码错误";
                }

            }
            else
            {
                Random random = new Random();
                LabelResult.Text = "*验证码有误";
                ImageCaptcha.ImageUrl = "~/Account/Captcha.aspx?"+random.Next(9999);
            }
        }
    }
}