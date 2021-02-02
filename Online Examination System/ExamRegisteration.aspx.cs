using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Examination_System
{
    public partial class CourseRegisteration : System.Web.UI.Page
    {
        public OES_BAL.Student User { get; set; }
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
                var u = (OES_BAL.Student)Session["user"];
                User = u;

                LoadUsers();
                var id = Request.QueryString["id"];
                var reg_date = DateTime.Now;
                var exp_date = reg_date.AddDays(10);

                lbl_reg_date.Text = reg_date.ToString("dddd, dd MMMM yyyy");
                lbl_exp_date.Text = exp_date.ToString("dddd, dd MMMM yyyy");


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
                User = new OES_BAL.Student();
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
            LoadCourses();
        }



        private void LoadUsers()
        {
            OES_BAL.Student obj_user = new OES_BAL.Student();
            var users =obj_user.GetAll();
            dd_users.DataValueField = "ID";
            dd_users.DataTextField = "FirstName";
            dd_users.DataSource = users;
            dd_users.DataBind();

            dd_users.Items.Insert(0, new ListItem("[Select Value]", "0"));
        }

       


        public string RenderControlToHtml(Control ControlToRender)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter stWriter = new System.IO.StringWriter(sb);
            System.Web.UI.HtmlTextWriter htmlWriter = new System.Web.UI.HtmlTextWriter(stWriter);
            ControlToRender.RenderControl(htmlWriter);
            return sb.ToString();
        }

        protected void dd_users_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPrograms();
        }

        private void LoadPrograms()
        {
            var userid = Convert.ToInt32(dd_users.SelectedValue);
            if (userid != 0)
            {
                var p = new OES_BAL.RegisterProgram(userid);
                var programs = p.Programs;
                dd_program.DataTextField = "Name";
                dd_program.DataValueField = "ID";

                dd_program.DataSource = programs;
                dd_program.DataBind();

                dd_program.Items.Insert(0, new ListItem("[select program]", "0"));
            }
            else
            {
                SetError("Please select any Student");
            
            }
        }


        private void LoadCategories()
        {
            var p_id =  Convert.ToInt32( dd_program.SelectedValue);
            if (p_id!=0)
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


        private void LoadCourses()
        {
           var p_id= Convert.ToInt32(dd_program.SelectedValue);
           var cc_id = Convert.ToInt32(ddl_CourseCategory.SelectedValue);
            if (p_id!=0 && cc_id!=0)
            {
                var cc = new OES_BAL.CourseCategory(cc_id);
                var courses = cc.GetCourses(p_id);
                dd_course.DataSource = courses;
                dd_course.DataTextField = "Name";
                dd_course.DataValueField = "ID";
                dd_course.DataBind();

            }
            else
            {
                SetError("Program and Category not Selected");
            }


        }
        protected void dd_program_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCategories();
        }

        
        protected void btn_save_Click(object sender, EventArgs e)
        {
            Save();
        }



        private void Save()
        {
            //getting values

            try
            {
                var u_id = Convert.ToInt32(dd_users.SelectedValue);
                var p_id = Convert.ToInt32(dd_program.SelectedValue);
                var cc_id = Convert.ToInt32(ddl_CourseCategory.SelectedValue);
                var c_id = Convert.ToInt32(dd_course.SelectedValue);


                if (u_id!=0 && p_id!=0 && cc_id!=0 && c_id!=0)
                {
                    var exam = new OES_BAL.Exam();
                    exam.User = new OES_BAL.Student(u_id);
                    exam.Course = new OES_BAL.Course(u_id);
                    exam.Registeration_Date = Convert.ToDateTime(lbl_reg_date.Text);
                    exam.Expiration_Date = Convert.ToDateTime(lbl_exp_date.Text);
                    exam.Description = "ABC";
                    exam.Add();

                    SetSuccess("Exam Registered");
                }
                else
                {
                    SetError("Select Option");
                }

               

            }
            catch (Exception ex)
            {

                SetError(ex.Message);
            }

           

        }
    }
}