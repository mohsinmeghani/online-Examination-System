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
    public partial class StudentLogin : Page
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
            OES_BAL.Student s = new OES_BAL.Student();
            var username = txt_username.Text.Trim();
            var password = txt_password.Text;

            try
            {
                var std = s.Login(username, password);
                if (std != null)
                {
                    Session["std"] = std;
                    Response.Redirect("ExamCenter.aspx");
                }
            }
            catch (Exception ex)
            {

                lable_incorrect.Text = ex.Message;
            }
           
        }

        private void pageLoad()
        {

            if (Session["std"]!=null)
            {
                Response.Redirect("ExamCenter.aspx");
            }
        }
    }


}