using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Examination_System
{
    public partial class ExamResult : System.Web.UI.Page
    {
        public OES_BAL.User User { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsError { get; set; }
        public String ErrorMessage { get; set; }
        public String SuccessMessage { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                PageLoad();
               
               // LoadGrid();
            }
        }


        private void LoadDDL()
        {
            OES_BAL.CourseCategory cc= new OES_BAL.CourseCategory();
            var list= cc.GetAll();


            ddl_CourseCategory.DataTextField = "Name";
            ddl_CourseCategory.DataValueField = "ID";
            ddl_CourseCategory.DataSource = list;
            ddl_CourseCategory.DataBind();


            ddl_CourseCategory.Items.Insert(0, new ListItem("[Select Value]", "0"));
        }

        private void PageLoad()
        {
            if (Session["user"] != null)
            {
                ViewState["IsEditMode"] = false;
                var u = (OES_BAL.User)Session["user"];
                User = u;

                LoadStudent();
                var id = Request.QueryString["id"];
                var reg_date = DateTime.Now;
                var exp_date = reg_date.AddDays(10);

               


                if (!string.IsNullOrEmpty(id))
                {
                    var user_id = 0;
                    var is_num = int.TryParse(id, out  user_id);
                    if (is_num)
                    {
                        var user = new OES_BAL.Student(user_id);
                        if (user.isExist(user_id))
                        {
                            ViewState["IsEditMode"] = true;
                          
                        }
                        else
                        {
                            SetError("Invalid User ID");
                            //LockControls();
                        }


                    }
                }

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

        private void SetSuccess(string message)
        {
            IsSuccess = true;
            SuccessMessage = message;
        }

        protected void ddl_CourseCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            dd_exam.Items.Clear();
            LoadExams();
        }


        private void LoadExams()
        {
            var std_id = Convert.ToInt32(dd_students.SelectedValue);
            if (std_id!=0)
            {
                var std = new OES_BAL.Student(std_id);
                var exams = std.GetCompletedExams();

                foreach (var exam in exams)
                {
                    ListItem li = new ListItem(exam.Course.Name, exam.ID.ToString());
                    dd_exam.Items.Add(li);
                }

            }
              
        }


        private void LoadStudent()
        {
            OES_BAL.Student obj_user = new OES_BAL.Student();
            var users =obj_user.GetAll();
            dd_students.DataValueField = "ID";
            dd_students.DataTextField = "FirstName";
            dd_students.DataSource = users;
            dd_students.DataBind();

            dd_students.Items.Insert(0, new ListItem("[Select Value]", "0"));
        }

       


        public string RenderControlToHtml(Control ControlToRender)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter stWriter = new System.IO.StringWriter(sb);
            System.Web.UI.HtmlTextWriter htmlWriter = new System.Web.UI.HtmlTextWriter(stWriter);
            ControlToRender.RenderControl(htmlWriter);
            return sb.ToString();
        }

        protected void dd_students_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCategories();
            //LoadPrograms();
        }

        


        private void LoadCategories()
        {
            var s_id =  Convert.ToInt32( dd_students.SelectedValue);
            if (s_id!=0)
            {
                var cc = new OES_BAL.CourseCategory();
                var categories = cc.GetAll();
                ddl_CourseCategory.DataValueField = "ID";
                ddl_CourseCategory.DataTextField = "Name";
                ddl_CourseCategory.DataSource = categories;
                ddl_CourseCategory.DataBind();

                ddl_CourseCategory.Items.Insert(0, new ListItem("[select Category]", "0"));
            }
            else
            {
                SetError("Please select any Cateogry");
            }
        }


        
        protected void dd_program_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCategories();
        }

        
        

        private void LockControls()
        {
            btn_generate.Enabled = false;
            dd_students.Enabled = false;
            dd_exam.Enabled = false;
            ddl_CourseCategory.Enabled = false;
           
           
        }

        protected void btn_generate_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void GenerateReport()
        {
            Response.Redirect("Report.aspx");
            
        }
            
    }
}