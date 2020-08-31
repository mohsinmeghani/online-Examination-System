using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Examination_System
{
    public partial class ProgramSetup : System.Web.UI.Page
    {
        public OES_BAL.User User { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsError { get; set; }
        public String ErrorMessage { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            PageLoad();
            LoadGrid();
            // Add a method to populate Program Drop Down list on form load. 
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
        }

        private void LockControls()
        {


            TextBox[] textboxes = { txt_program_code,txt_program_details,txt_program_name };
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
            OES_BAL.Program p = new OES_BAL.Program();
            var list = p.GetAll();
            gv_program.DataSource = list;
            gv_program.DataBind();
        }


        private void Add()
        {
            
            OES_BAL.Program p = new OES_BAL.Program();
            var programCode = txt_program_code.Text;
            var programName = txt_program_name.Text;
            var programDetails = txt_program_details.Text;

            p.Code = programCode;
            p.Name = programName;
            p.Details = programDetails;

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


        protected void gv_program_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_program.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void gv_program_Sorting(object sender, GridViewSortEventArgs e)
        {

        }
    }
}