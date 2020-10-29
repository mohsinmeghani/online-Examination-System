using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Examination_System
{
    public partial class ProgramRegisteration : System.Web.UI.Page
    {
        public OES_BAL.User User { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsError { get; set; }
        public String ErrorMessage { get; set; }
        public String SuccessMessage { get; set; }

      

        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoad();
            if (!Page.IsPostBack)
            {
                
                LoadDDL();
                LoadGrid();
               
            }
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


        private void LoadDDL()
        {
            OES_BAL.Program p = new OES_BAL.Program();
            var list = p.GetAll();


            ddl_program.DataTextField = "Name";
            ddl_program.DataValueField = "ID";
            ddl_program.DataSource = list;
            ddl_program.DataBind();


            ddl_program.Items.Insert(0, new ListItem("[Select Value]", "0"));
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

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    Add();
                   
                }
            }
            catch (Exception ex)
            {

                SetError(ex.Message);
            }
           
        }


        private void LoadGrid()
        {
            var user_id = User.ID;
            var rp = new OES_BAL.RegisterProgram(user_id);
            var p = rp.Programs;

            gv_regProgram.DataSource = p;
            gv_regProgram.DataBind();
            
        }


        private void Add()
        {

            OES_BAL.RegisterProgram rp = new OES_BAL.RegisterProgram();
            rp.Date = DateTime.Now;
            rp.User = this.User;

            var user_id = User.ID;

            var is_registered = rp.Get(user_id);

            if (is_registered.Programs.Count>0)
            {
                SetError("Program Already Registered");
                return;
            }
            

            var prog_id = Convert.ToInt16( ddl_program.SelectedValue);
            if (prog_id!=0)
            {
                rp.Programs = new List<OES_BAL.Program>(); 
                rp.Programs.Add(new OES_BAL.Program(prog_id));
            }
            else
            {
                SetError("Program Not Selected");
                return;
            }
           
            rp.Add();
            SetSuccess("Program Registered!");
            
        }
    }
}