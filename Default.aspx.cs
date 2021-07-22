using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Domain;

namespace ARIS
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text.Trim()=="" || txtPassword.Text.Trim()=="")
            {
                this.lblError.Text = "Please enter username and password";
            }
            else
            {
                this.lblError.Text = "";

                var username = txtUsername.Text.Trim();
                var password = txtPassword.Text.Trim();

                var obj = new Users
                {
                    Username = username,
                    Password = password
                };

                var user = UsersDAL.CheckLogin(obj);

                if(user != null)
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    lblError.Text = "Invalid Username or Password";
                }
            }
        }
    }
}