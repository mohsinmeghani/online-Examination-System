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

        }

        protected void LogIn(object sender, EventArgs e)
        {

            if (is_login())
            {
                Response.Redirect("DashBoard.aspx");
                //redirect
            }
            else
            {
                //error
            }
            
        }



        private bool is_login()
        {
            OES_BAL.User u = new User();
            var username = txt_username.Text.Trim();
            var password = txt_password.Text;

            if (string.IsNullOrEmpty(username)||string.IsNullOrEmpty(password))
            {
             //errror   
            }
            else
            {
                var is_login =u.Login(username, password);
                return is_login;
            }

            return false;

        }
    }


}