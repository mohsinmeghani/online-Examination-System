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

                var id = Request.QueryString["id"];

                lbl_UserID.Text = User.ID.ToString();
                lbl_Name.Text = User.FirstName + " " + User.LastName;
                OES_BAL.RegisterProgram p = new OES_BAL.RegisterProgram(User.ID);
                if (p.Programs.Count == 0)
                {
                    SetError("Program not Registered for this User");
                }
                else
                {
                    lbl_program.Text = p.Programs.First().Name;
                    LoadDDL();
                }

                if (!string.IsNullOrEmpty(id))
                {
                    var user_id = 0;
                    var is_num = int.TryParse(id, out  user_id);
                    if (is_num)
                    {
                        var user = new OES_BAL.User(user_id);
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
            LoadCourses();
        }


        private void LoadCourses()
        {



            CheckBox r = new CheckBox();
            r.Text = "Theory of Automata";
            r.ID = "r_1";


            div_courses.InnerHtml = RenderControlToHtml(r);
        }


        public string RenderControlToHtml(Control ControlToRender)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter stWriter = new System.IO.StringWriter(sb);
            System.Web.UI.HtmlTextWriter htmlWriter = new System.Web.UI.HtmlTextWriter(stWriter);
            ControlToRender.RenderControl(htmlWriter);
            return sb.ToString();
        }
    }
}