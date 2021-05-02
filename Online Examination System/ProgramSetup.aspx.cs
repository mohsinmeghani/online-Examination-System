﻿using System;
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
        public String SuccessMessage { get; set; }
        

        public OES_BAL.Program Program { get; set; }
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
            var programID = Convert.ToInt16(txt_id.Text);
            var programCode = txt_program_code.Text;
            var programName = txt_program_name.Text;
            var programDetails = txt_program_details.Text;

            Program = new OES_BAL.Program(programID);
            Program.Code = programCode;
            Program.Name = programName;
            Program.Details = programDetails;
            Program.Update();

        }

        private void PostSave()
        {
            SetSuccess("Program Created / Updated");
            LockControls();
            LoadGrid();
        }

        private void LockControls()
        {


            TextBox[] textboxes = { txt_program_code,txt_program_details,txt_program_name };
            Button[] buttons = { btn_save ,btn_delete };
            
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
                ViewState["IsEditMode"] = false;
                var u = (OES_BAL.User)Session["user"];
                User = u;

                var id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    var program_id = 0;
                    var is_num = int.TryParse(id, out  program_id);
                    if (is_num)
                    {
                        ViewState["IsEditMode"] = true;
                        Program = new OES_BAL.Program(program_id);

                        if (Program.ID!=0)
                        {
                            txt_id.Text = Program.ID.ToString();
                            txt_program_code.Text = Program.Code;
                            txt_program_name.Text = Program.Name;
                            txt_program_details.Text = Program.Details;
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

        protected void gv_program_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        private void delete()
        {
            if ((bool)ViewState["IsEditMode"])
            {
                var id = Convert.ToInt16(txt_id.Text);
                var p = new OES_BAL.Program(id);
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
            SetSuccess("Program Deleted");
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

        protected void btn_refresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProgramSetup.aspx");
        }
    }
}