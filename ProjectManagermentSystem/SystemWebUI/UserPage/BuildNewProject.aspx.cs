using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLib;
using DataModels.Object;

namespace SystemWebUI.UserPage
{
    public partial class BuildNewProject : SystemWebUI.PageClass.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                ButtonAddExecute.OnClientClick = "__doPostBack('" + this.ButtonAddExecute.UniqueID + "','')";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
            ListBox2.Items.Add(ListBox1.SelectedValue);
            ListBox1.Items.Remove(ListBox1.SelectedValue);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
            ListBox1.Items.Add(ListBox2.SelectedValue);
            ListBox2.Items.Remove(ListBox2.SelectedValue);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
            List<string> users = new List<string>();
            users = ProjectUser.FindSimilarUsers(TextBox3.Text);

            ListBox1.DataSource = users;
            ListBox1.DataBind();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (Session["buttonClick"].ToString() == "request")
            {               
                LabelRequest.Text = ListBox2.Items[0].Value;
                Session["requestUser"] = ListBox2.Items[0].Value;
            }
            if (Session["buttonClick"].ToString() == "execute")
            {
                List<string> users = new List<string>();
                if (!Object.Equals(Session["executeUsers"], null))
                {
                    users = Session["executeUsers"] as List<string>;
                }
                foreach (ListItem i in ListBox2.Items)
                {
                    users.Add(i.Value);
                }
                users = (from u in users
                            select u).Distinct().ToList();
                LabelExecute.Text = "";
                Session["executeUsers"] = users;
                foreach (string user in users)
                {
                    LabelExecute.Text += " " + user;
                }
            }
        }

        protected void ButtonAddRequest_Click(object sender, EventArgs e)
        {
            ButtonAddExecute_Click(sender, e);
            Session["buttonClick"] = "request";
        }

        protected void ButtonAddExecute_Click(object sender, EventArgs e)
        {
            Session["buttonClick"] = "execute";
            ClearModalPopupExtender();
            this.ModalPopupExtender1.Show();   

        }

        private void ClearModalPopupExtender()
        {
            for (int i = 0; i < ListBox1.Items.Count;)
            {
                ListBox1.Items.RemoveAt(i);
            }
            for (int i = 0; i < ListBox2.Items.Count;)
            {
                ListBox2.Items.RemoveAt(0);
            }
                TextBox3.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                List<ProjectRole> roles = new List<ProjectRole>();
                
                ProjectRole roleAdmin = new ProjectRole{ role="Admin",
                                                         userName=Session["userName"].ToString()};
                roles.Add(roleAdmin);
                if(!Object.Equals(Session["requestUser"],null))
                {
                    ProjectRole roleRequest = new ProjectRole{ role="Request", userName=Session["requestUser"].ToString(), 
                                                               state="Unknown"};
                    roles.Add(roleRequest);
                }
                if(!Object.Equals(Session["executeUsers"],null))
                {
                    List<string> users = new List<string>();
                    users = Session["executeUsers"] as List<string>;
                    foreach(string u in users)
                    {
                        ProjectRole roleExecute = new ProjectRole{ role = "Execute", state="Unknown", userName=u};
                        roles.Add(roleExecute);
                    }
                }
                UserProject newProject = new UserProject{ 
                                                           projectContext= TextBox2.Text, 
                                                           projectName=TextBox1.Text,
                                                           projectPublishTime = DateTime.Now,
                                                           projectState= false,
                                                           roles = roles  
                                                            };
                UserProject.AddNewProject(newProject);
                Response.Redirect("MyProject.aspx");
            }
            else
            {
                Label7.ForeColor =System.Drawing.Color.Red;
                Label7.Text = "项目名不能为空";
            }
        }
    }
}