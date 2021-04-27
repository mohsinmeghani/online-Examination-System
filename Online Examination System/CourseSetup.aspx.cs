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
        public String SuccessMessage { get; set; }
        public String ErrorMessage { get; set; }
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDDL();
                PageLoad();
                LoadGrid();
               
            }
           
        }

        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if ((bool)ViewState["IsEditMode"])
                    {
                        Update();
                    }
                    else
                    {
                        Add();
                    }
                   
                }
            }
            catch (Exception ex)
            {

                SetError(ex.Message);
            }

        }

        private void PostCreate()
        {
            SetSuccess("Course Created / Updated");
            LockControls();
            LoadGrid();
            LoadDDL();
        }

        private void LockControls()
        {


            TextBox[] textboxes = { txt_course_code, txt_course_details, txt_course_name, txt_chTheory,txt_chPractical };
            Button[] buttons = { btn_save , btn_delete };
            DropDownList[] dds = {ddl_program,ddl_course_category,ddl_parent_course };
            


            //disable Textboxes
            foreach (var textbox in textboxes)
            {
                textbox.Enabled = false;
            }

            foreach (var dd in dds)
            {
                dd.Enabled = false;
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
            gv_course.DataSource = list.Select(x=>new { x.ID,x.Name}).ToList();
            gv_course.DataBind();
        }

        private void LoadDDL()
        {
            OES_BAL.Program p = new OES_BAL.Program();
            var list = p.GetAll();
            ddl_program.DataTextField = "Name";
            ddl_program.DataValueField = "ID";
            ddl_program.DataSource = list;
            ddl_program.DataBind();

            OES_BAL.CourseCategory cc = new OES_BAL.CourseCategory();
            var cc_list = cc.GetAll();
            ddl_course_category.DataTextField = "Name";
            ddl_course_category.DataValueField = "ID";
            ddl_course_category.DataSource = cc_list;
            ddl_course_category.DataBind();

        }


        private void Add()
        {
            
            if (!int.TryParse(txt_chTheory.Text,out _))
            {
                SetError("Credit Hours Theory must be Number");
                return;
            }

            if(!int.TryParse(txt_chPractical.Text, out _))
            {
                SetError("Credit Hours Practical must be Number");
                return;
            }    
            OES_BAL.Course c = new OES_BAL.Course();
            var courseCode = txt_course_code.Text;
            var courseName = txt_course_name.Text;
            var courseDetails = txt_course_details.Text;
            var ch_theory = Convert.ToInt32(txt_chTheory.Text);
            var ch_practical = Convert.ToInt32(txt_chPractical.Text);

            var p_id = Convert.ToInt16( ddl_program.SelectedValue);
            var cc_id = ddl_course_category.SelectedValue != "" ? Convert.ToInt16(ddl_course_category.SelectedValue) : 0;


            c.Code = courseCode;
            c.Name = courseName;
            c.Details = courseDetails;
            c.CH_Theory = ch_theory;
            c.CH_Practical = ch_practical;
            c.Program = new OES_BAL.Program((int)p_id);
            if (cc_id!=0)
            {
                c.CourseCategory = new OES_BAL.CourseCategory(cc_id);
            }

          
           

            c.Add();

            txt_id.Text = c.ID.ToString();
            PostCreate();
        }


        private void Update()
        {
            if (!int.TryParse(txt_chTheory.Text, out _))
            {
                SetError("Credit Hours Theory must be Number");
                return;
            }

            if (!int.TryParse(txt_chPractical.Text, out _))
            {
                SetError("Credit Hours Practical must be Number");
                return;
            }

            var id = Convert.ToInt16(txt_id.Text);
            var code = txt_course_code.Text;
            var name = txt_course_name.Text;
            var details = txt_course_details.Text;
            var ch_theory = Convert.ToInt32(txt_chTheory.Text);
            var ch_practical = Convert.ToInt32(txt_chPractical.Text);
            var p_id = Convert.ToInt16(ddl_program.SelectedValue);

            var c = new OES_BAL.Course(id);
            c.Code = code;
            c.Name = name;
            c.Details = details;
            c.CH_Theory = ch_theory;
            c.CH_Practical = ch_practical;
            c.Program = new OES_BAL.Program(p_id);
            c.Update();
            PostCreate();



        }
        private void PageLoad()
        {
            if (Session["user"] != null)
            {

                ViewState["IsEditMode"] = false;
                var u = (OES_BAL.User)Session["user"];
                User = u;
                ddl_program.Items.Insert(0,new ListItem("[Select Program]", ""));
                ddl_course_category.Items.Insert(0, new ListItem("[Select Category]", ""));
                ddl_parent_course.Items.Insert(0, new ListItem("[Select Parent Course]", ""));

                var id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    var course_id = 0;
                    var is_num = int.TryParse(id, out  course_id);
                    if (is_num)
                    {
                        ViewState["IsEditMode"] = true;
                        var course = new OES_BAL.Course(course_id);
                        if (course.ID!=0)
                        {
                            txt_id.Text = course.ID.ToString();
                            txt_course_code.Text = course.Code;
                            txt_course_name.Text = course.Name;
                            txt_course_details.Text = course.Details;
                            txt_chTheory.Text = course.CH_Theory.ToString();
                            txt_chPractical.Text = course.CH_Practical.ToString();
                            ddl_program.SelectedValue = course.Program.ID.ToString();
                            ddl_course_category.SelectedValue = course.CourseCategory!=null?course.CourseCategory.ID.ToString():"";
                            ddl_parent_course.SelectedValue = course.ParentCourse!=null? course.ParentCourse.ID.ToString():"";
                        }
                        else
                        {
                            SetError("Invalid Course ID");
                            LockControls();
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
        protected void gv_course_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_course.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void gv_course_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        private void delete()
        {
            if ((bool)ViewState["IsEditMode"])
            {
                var id = Convert.ToInt16(txt_id.Text);
                var c = new  OES_BAL.Course(id);
                c.Delete();

                PostDelete();
            }
            else
            {
                SetError("Select Any Course to Delete");
            }
        }


        private void PostDelete()
        {
            SetSuccess("Course Deleted");
            LockControls();
            LoadGrid();
        }
        protected void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                delete();
            }
            catch (Exception ex)
            {

                SetError(ex.Message);
            }
           
            
        }
    }
}