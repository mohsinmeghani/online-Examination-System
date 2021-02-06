using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Examination_System
{
    public partial class DashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"]!=null)
            {
               // var user = new  OES_BAL.User();
                var user= (OES_BAL.User) Session["user"];
                lbl_user.Text = user.FirstName+" "+user.LastName;

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}