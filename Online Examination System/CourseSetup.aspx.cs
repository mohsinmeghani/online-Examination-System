using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Examination_System
{
    public partial class CourseRegistration : System.Web.UI.Page
    {
        public OES_BAL.User User { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsError { get; set; }
        public String ErrorMessage { get; set; }
     
        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoad();
            LoadGrid();
            LoadDDL();
        }

        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    Add();
                    PostCreate();
                }
            }
            catch (Exception ex)
            {

                SetError(ex.Message);
            }

        }

        private void PostCreate()
        {
            IsSuccess = true;
            LockControls();
            LoadGrid();
            LoadDDL();
        }

        private void LockControls()
        {


            TextBox[] textboxes = { txt_course_code, txt_course_details, txt_course_name };
            Button[] buttons = { btn_save };

            //disable Textboxes
            foreach (var textbox in textboxes)
            {
                textbox.Enabled = false;
            }

            //disable buttons
            foreach (var btn in buttons)
            {
                btn.Enabled = false;
            }
        }
        private void LoadGrid()
        {
            OES_BAL.Course c = new OES_BAL.Course();
            var list = c.GetAll();
            gv_course.DataSource = list;
            gv_course.DataBind();
        }

        private void LoadDDL()
        {
            OES_BAL.Program p = new OES_BAL.Program();
            var list = p.GetAll();
            ddl_program_name.DataSource = list;
            ddl_program_name.DataBind();
        }


        private void Add()
        {

            OES_BAL.Course p = new OES_BAL.Course();
            var courseCode = txt_course_code.Text;
            var courseName = txt_course_name.Text;
            var courseDetails = txt_course_details.Text;
            var courseProgram = ddl_program_name.DataValueField;

            p.Code = courseCode;
            p.Name = courseName;
            p.Details = courseDetails;
          //  p.Program = courseProgram;

            p.Add();

            txt_id.Text = p.ID.ToString();
        }

        private void PageLoad()
        {
            if (Session["user"] != null)
            {
                var u = (OES_BAL.User)Session["user"];
                User = u;
            }
            else
            {
                User = new OES_BAL.User();
                Response.Redirect("login.aspx");
            }
        }

        private void SetError(string message)
        {
            IsError = true;
            ErrorMessage = message;
        }

        protected void gv_course_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_course.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void gv_course_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void delete(object sender, EventArgs e)
        {

        }
    }
}