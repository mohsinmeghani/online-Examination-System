using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Online_Examination_System.Models;
using OES_BAL;
using System.Configuration;

namespace Online_Examination_System.Account
{
    public partial class StudentLogin : Page
    {
        public String LicenseKey { get; set; }
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
                lable_incorrect.Text = "License is Invalid / Expired";
            }
            
        }

        private void ReadLicense()
        {
            var license = ConfigurationManager.AppSettings["License"];
            LicenseKey = license;
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
             ReadLicense();

            if (Session["std"]!=null)
            {
                Response.Redirect("ExamCenter.aspx");
            }
        }
    }


}