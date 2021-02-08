using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Examination_System
{
    public partial class ExamCenter : System.Web.UI.Page
    {
        public OES_BAL.Student Student { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            PageLoad();
        
        }


        private void PageLoad()
        {
            if (Session["std"] != null)
            {
                // var user = new  OES_BAL.User();
                var std = (OES_BAL.Student)Session["std"];
                Student = std;
                lbl_user.Text = std.FirstName + " " + std.LastName;
                lbl_email.Text = std.Email;
                lbl_username.Text = std.UserName;
                GetExamList();

            }
            else
            {
                Response.Redirect("StudentLogin.aspx");
            }
        }



        private void GetExamList()
        {
            var examlist = Student.GetExamList();
            foreach (var exam in examlist)
            {
                ListItem li = new ListItem();
                li.Text = exam.Course.Name;
                li.Value = exam.ID.ToString();
                dd_exam.Items.Add(li);
            }
        }



    }
}