﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BusinessLogicLib;

namespace SystemWebUI.UserPage.ProjectDocuments
{
    public partial class Final : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"].ToString() != "traveller")
            {
                if (UserProject.IsAllowReadProject(Int32.Parse(Request.QueryString["id"]), Session["userName"].ToString()))
                {
                    title.InnerText = "项目:" + Request.QueryString["projectName"] + " 结案文档";
                    string path = Server.MapPath("~/App_Data/Projects") + "\\" + Request.QueryString["id"] + "\\Final.txt";
                    bool isPublise = false;
                    if (File.Exists(path))
                    {
                        divContext.InnerHtml = File.ReadAllText(path, System.Text.Encoding.UTF8);
                        isPublise = true;
                    }
                    else
                    {
                        divContext.InnerText = "该项目还没有发布结案文档。";                        
                    }

                    if (UserProject.IsProjectSetupByUser(Int32.Parse(Request.QueryString["id"]), Session["userName"].ToString()))
                    {
                        if (BusinessLogicLib.UserProject.IsProjectFinished(Int32.Parse(Request.QueryString["id"])))
                        {
                            Button1.Visible = false;
                        }
                        else
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
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["Button1"].ToString() == "Edit")
            {
                this.Response.Redirect("FreeTextBox.aspx?id="+Request.QueryString["id"]+"&projectName="+Request.QueryString["projectName"]+"&documentType=final");
            }
            if (Session["Button1"].ToString() == "Append")
            {
                this.Response.Redirect("FreeTextBox.aspx?id=" + Request.QueryString["id"] + "&projectName=" + Request.QueryString["projectName"] + "&documentType=final");
            }
        }
    }
}