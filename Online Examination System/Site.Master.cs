using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Examination_System
{
    public partial class SiteMaster : MasterPage
    {
        
        public String loginTitle { get; set; }
        public String Name { get; set; }
        public bool IsLogin { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                var u = (OES_BAL.User)Session["user"];
                Name = u.FirstName+" "+u.LastName;
                loginTitle = "Log Out";
                IsLogin = true;
            }
            else
            {
                loginTitle = "Log In";
                IsLogin = false;
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("login.aspx");
        }
    }

}