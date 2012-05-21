using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLib.Account;

namespace SystemWebUI.Account
{
    public partial class Captcha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BusinessLogicLib.Account.Captcha captcha = new BusinessLogicLib.Account.Captcha();
            System.IO.MemoryStream ms = captcha.CreateCaptcha(4);
            Response.ClearContent();
            Response.ContentType = "image/Gif";
            Response.BinaryWrite(ms.ToArray());
            Session["Captcha"] = captcha.GetRandomNum();
        }
    }
}