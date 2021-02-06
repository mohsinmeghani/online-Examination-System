using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Examination_System
{
    public partial class QuestionSetup : System.Web.UI.Page
    {
        public OES_BAL.User User { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsError { get; set; }
        public String ErrorMessage { get; set; }
        public String SuccessMessage { get; set; }
        

        public OES_BAL.Question Question { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PageLoad();
                LoadGrid();
            }

            
               
        }
                
           
           
            // Add a method to populate Program Drop Down list on form load. 
        

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
                    PostSave();
                }
            }
            catch (Exception ex)
            {

                SetError(ex.Message);
            }

        }

        private void Update()
        {
            var QuestionID = Convert.ToInt16(txt_id.Text);
            var q_text = txt_questionText.Text;
           
            var answer = dd_answer.SelectedValue;
            var a = txt_A.Text;
            var b = txt_B.Text;
            var c = txt_C.Text;
            var d = txt_D.Text;


            var c_id = Convert.ToInt16(dd_course.SelectedValue);
            var course = new OES_BAL.Course(c_id);
           

            Question = new OES_BAL.Question(QuestionID);
            Question.QuestionText = q_text;
            Question.Option = new OES_BAL.Option();
            Question.Option.A = a;
            Question.Option.B= b;
            Question.Option.C = c;
            Question.Option.D = d;
            Question.Answer = answer;
            Question.Course = course;

            Question.Update();


        }

        private void PostSave()
        {
            SetSuccess("Question Created / Updated");
            LockControls();
            LoadGrid();
        }

        private void LockControls()
        {


            TextBox[] textboxes = { txt_questionText, txt_A,txt_B,txt_C,txt_D };
            Button[] buttons = { btn_save ,btn_delete };
            DropDownList[] dds = { dd_course,dd_answer };

            foreach (var dd in dds)
            {
                dd.Enabled = false;
                    
            }
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
            OES_BAL.Question q = new OES_BAL.Question();
            var list = q.GetAll();
            gv_questions.DataSource = list;
            gv_questions.DataBind();
        }


        private void Add()
        {
            
            OES_BAL.Question q = new OES_BAL.Question();
            var q_text = txt_questionText.Text;
           
            var answer = dd_answer.SelectedValue;
            var a = txt_A.Text;
            var b = txt_B.Text;
            var c = txt_C.Text;
            var d = txt_D.Text;
            var c_id = Convert.ToInt32(dd_course.SelectedValue);
            
            var course = new OES_BAL.Course(  c_id );

            q.QuestionText = q_text;
            q.Option = new OES_BAL.Option();
            q.Option.A = a;
            q.Option.B = b;
            q.Option.C = c;
            q.Option.D = d;
            q.Answer = answer;
            q.Course = course;
            q.Add();

            txt_id.Text = q.ID.ToString();
        } 

        private void PageLoad()
        {
            if (Session["user"] != null)
            {
                ViewState["IsEditMode"] = false;
                var u = (OES_BAL.User)Session["user"];
                User = u;

                LoadCourses();
                var id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    var question_id = 0;
                    var is_num = int.TryParse(id, out question_id);
                    if (is_num)
                    {
                        ViewState["IsEditMode"] = true;
                        Question = new OES_BAL.Question(question_id);

                        if (Question.ID!=0)
                        {
                            txt_id.Text = Question.ID.ToString();
                            txt_questionText.Text = Question.QuestionText;
                            txt_A.Text = Question.Option.A;
                            txt_B.Text = Question.Option.B;
                            txt_C.Text = Question.Option.C;
                            txt_D.Text = Question.Option.D;

                            // txt_options.Text = Question.Option.GetOptionJSON();
                            dd_answer.SelectedValue = Question.Answer;
                            dd_course.SelectedValue = Question.Course.ID.ToString();

                         }
                        else
                        {
                            SetError("Invalid Program ID");
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


        protected void gv_questions_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_questions.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void gv_questions_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        private void delete()
        {
            if ((bool)ViewState["IsEditMode"])
            {
                var id = Convert.ToInt16(txt_id.Text);
                var p = new OES_BAL.Question(id);
                p.Delete();
                PostDelete();
            }
            else
            {
                SetError("Select Any Program to Delete");
            }
        }


        private void PostDelete()
        {
            SetSuccess("Question Deleted");
            LoadGrid();
            LockControls();
        }
        protected void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                delete();
            }
            catch (Exception ex )
            {
                SetError(ex.Message);
                
            }
        }


        private void LoadCourses()
        {
            var obj_course = new OES_BAL.Course();
            var c = obj_course.GetAll();
            dd_course.DataSource = c;
            dd_course.DataTextField = "Name";
            dd_course.DataValueField = "ID";
            dd_course.DataBind();

        }

       
    }
}