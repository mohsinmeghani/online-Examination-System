using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Online_Examination_System.Models;
using OES_BAL;

namespace Online_Examination_System.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pageLoad();
        }

        protected void LogIn(object sender, EventArgs e)
        {

            login();
        }



        private void login()
        {
            OES_BAL.User u = new User();
            var username = txt_username.Text.Trim();
            var password = txt_password.Text;

            try
            {
                var user = u.Login(username, password);
                if (user!=null)
                {
                    Session["user"] = user;
                    Response.Redirect("Dashboard.aspx");
                }
            }
            catch (Exception ex)
            {

                lable_incorrect.Text = ex.Message;
            }
           
        }

        private void pageLoad()
        {

            if (Session["user"]!=null)
            {
                Response.Redirect("dashboard.aspx");
            }
        }
    }


}