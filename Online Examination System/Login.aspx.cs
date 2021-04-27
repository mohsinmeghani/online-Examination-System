using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Online_Examination_System.Models;
using System.Configuration;
using OES_BAL;


namespace Online_Examination_System.Account
{
    public partial class Login : Page
    {
        private String LicenseKey { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            pageLoad();
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (CheckLicense())
            {
                login();
            }
            else
            {
               
                lable_incorrect.Text = @"License is Invalid / Expired" ;
            }
           
        }

        private bool CheckLicense()
        {
            try
            {
                OES_BAL.License lic = new License(LicenseKey);
                var is_valid = lic.CheckLicense();
                return is_valid;
            }
            catch (Exception ex)
            {

                lable_incorrect.Text = ex.Message;

                return false;
            }
           
        }

        


        private void login()
        {
           
            OES_BAL.User u = new OES_BAL.User();
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

        private void ReadLicense()
        {
            var license = ConfigurationManager.AppSettings["License"];
            LicenseKey = license;
        }

        private void pageLoad()
        {
            ReadLicense();

          
           
            if (Session["user"]!=null)
            {
                Response.Redirect("dashboard.aspx");
            }
        }
    }


}