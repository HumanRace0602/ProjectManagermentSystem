using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemWebUI.Account
{
    public partial class RegisterValidation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = Request.QueryString["userName"];
            Response.Clear();
            if (BusinessLogicLib.Account.Account.IsUserRegistered(userName))
            {
                Response.Write("0");
            }
            else
            {
                Response.Write("1");
            }
        }
    }
}