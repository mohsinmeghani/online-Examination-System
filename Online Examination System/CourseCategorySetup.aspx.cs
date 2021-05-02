using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Examination_System
{
    public partial class CourseCategorySetup : System.Web.UI.Page
    {
        public OES_BAL.User User { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsError { get; set; }
        public String ErrorMessage { get; set; }
        public String SuccessMessage { get; set; }
        

        public OES_BAL.CourseCategory CourseCategory { get; set; }
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
            var CategoryID = Convert.ToInt16(txt_id.Text);
            var CategoryName = txt_category_name.Text;

            CourseCategory = new OES_BAL.CourseCategory(CategoryID);
            CourseCategory.Name = CategoryName;

            CourseCategory.Update();

        }

        private void PostSave()
        {
            SetSuccess("Category Created / Updated");
            LockControls();
            LoadGrid();
        }

        private void LockControls()
        {


            TextBox[] textboxes = { txt_category_name };
            Button[] buttons = { btn_save  };
            
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
            OES_BAL.CourseCategory cc = new OES_BAL.CourseCategory();
            var list = cc.GetAll();
            gv_program.DataSource = list;
            gv_program.DataBind();
        }


        private void Add()
        {
            
            OES_BAL.CourseCategory cc = new OES_BAL.CourseCategory();
            var CategoryName= txt_category_name.Text;

            cc.Name = CategoryName;

            cc.Add();

            txt_id.Text = cc.ID.ToString();
        } 

        private void PageLoad()
        {
            if (Session["user"] != null)
            {
                ViewState["IsEditMode"] = false;
                var u = (OES_BAL.User)Session["user"];
                User = u;

                var id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    var cc_id = 0;
                    var is_num = int.TryParse(id, out  cc_id);
                    if (is_num)
                    {
                        ViewState["IsEditMode"] = true;
                        CourseCategory = new OES_BAL.CourseCategory(cc_id);

                        if (CourseCategory.ID!=0)
                        {
                            txt_id.Text = CourseCategory.ID.ToString();
                            txt_category_name.Text = CourseCategory.Name;
                        
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


        protected void gv_program_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_program.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void btn_refresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("CourseCategorySetup.aspx");
        }
    }
}