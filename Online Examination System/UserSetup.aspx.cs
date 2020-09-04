using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Examination_System
{
    public partial class UserSetup : System.Web.UI.Page
    {

        public OES_BAL.User User { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsError { get; set; }
        public String ErrorMessage { get; set; }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PageLoad();
                LoadGrid();  
            }
            
        }

       
        protected void Register(object sender, EventArgs e)
        {
            try
            {
                if ((bool)ViewState["IsEditMode"])
                {
                   // Update();
                }
                else
                {
                    Add();
                }
            }
            catch (Exception ex)
            {
                SetError(ex.Message);
            }
           
        }


        private void Update()
        {
            try
            {
               
                    var id =  Convert.ToInt16( txt_ID.Text);
                    var firstName = txt_firstname.Text;
                    var lastName = txt_lastname.Text;
                    var gender = ddl_gender.SelectedValue;
                  
                    var email = txt_email.Text.Trim();
                    var contact = txt_contact.Text;
                    var address = txt_address.Text;
                    var password = txt_confirmpassword.Text;

                    OES_BAL.User u = new OES_BAL.User(id);
                    
                    u.FirstName = firstName;
                    u.LastName = lastName;
                    u.Email = email;
                    u.Gender = gender;
                    u.Contact = contact;
                    u.Address = address;
                    
                    u.Password = password;
                    u.EditedBy = User.FirstName + " " + User.LastName;

                    u.Update();
                
            }
            catch (Exception ex)
            {

                SetError(ex.Message);
            }
        }

        private void Add()
        {
            try
            {

                if (Page.IsValid)
                {

                    var firstName = txt_firstname.Text;
                    var lastName = txt_lastname.Text;
                    var gender = ddl_gender.SelectedValue;
                    var username = txt_username.Text;
                    var email = txt_email.Text.Trim();
                    var contact = txt_contact.Text;
                    var address = txt_address.Text;
                    var password = txt_confirmpassword.Text;

                    OES_BAL.User u = new OES_BAL.User();
                    
                    u.FirstName = firstName;
                    u.LastName = lastName;
                    u.Email = email;
                    u.Gender = gender;
                    u.Contact = contact;
                    u.Address = address;
                    u.UserName = username;
                    u.Password = password;
                    u.CreatedBy = User.FirstName + " " + User.LastName;

                    u.ADD();

                    txt_ID.Text = u.ID.ToString();

                    PostCreate();
                }
            }
            catch(Exception ex)
            {
                 SetError( ex.Message);
            }

           
        }

        protected void validator_username_ServerValidate(object source, ServerValidateEventArgs args)
        {
           var isValidate= ValidateUserName();
           args.IsValid = isValidate; 
                        
        }


        private bool ValidateUserName()
        {
            OES_BAL.Util u = new OES_BAL.Util();

            var username = txt_username.Text;
            if (u.IsUserNameExist(username))
            {
                validator_username.ErrorMessage = "UserName Already Exist";
               
               return false;
            }
            else
            {
                return true;
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


             TextBox[] textboxes = { txt_confirmpassword,txt_contact,txt_email,txt_firstname,txt_lastname,txt_password,txt_username,txt_address};
             Button[] buttons = {btn_save,btn_delete };
             DropDownList[] dds = { ddl_gender};
            //disable Textboxes
             foreach (var textbox in textboxes)
             {
                 textbox.Enabled = false;
             }

            //diable dropdown

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

        private void PageLoad()
        {
            if (Session["user"]!=null)
            {
                var u = (OES_BAL.User)Session["user"];
                User = u;

                var id = Request.QueryString["id"];
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

                            txt_ID.Text = user.ID.ToString();
                            txt_username.Text = user.UserName;
                            txt_firstname.Text = user.FirstName;
                            txt_lastname.Text = user.LastName;
                            txt_email.Text = user.Email;
                            txt_address.Text = user.Address;
                            txt_contact.Text = user.Contact;
                            ddl_gender.SelectedValue = user.Gender;

                            txt_username.Enabled = false;

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

        [WebMethod]
        public static string GetUserName(string u)
        {
            OES_BAL.Util util = new OES_BAL.Util();
            var isexist=util.IsUserNameExist(u);
            if (isexist)
            { 
                return "UserName Already Exist";
            }

            return "";
        }

        protected void txt_username_TextChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "CheckUserName", "checkUsername();", true);
        }


        private void SetError(string message)
        {
            IsError = true;
            ErrorMessage = message;
        }


        private void LoadGrid()
        {
            OES_BAL.User u = new OES_BAL.User();
            var list = u.GetAll();
            gv_users.DataSource = list.Select(x=>new {x.ID,x.UserName,x.FirstName,x.LastName}).ToList();
            gv_users.DataBind();
        }

        private void LoadGrid(string SortExpression)
        {
            OES_BAL.User u = new OES_BAL.User();
            var list = u.GetAll();
            if (SortExpression=="ID")
            {
                list = list.OrderBy(x => x.ID).ToList();
            }
            else if (SortExpression=="UserName")
            {
                list = list.OrderBy(x => x.UserName).ToList();
            }
            else if (SortExpression == "FirstName")
            {
                list = list.OrderBy(x => x.FirstName).ToList();
            }

            gv_users.DataSource = list.Select(x => new { x.ID, x.UserName, x.FirstName, x.LastName }).ToList();
            gv_users.DataBind();
        }
        protected void gv_users_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gv_users_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_users.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void gv_users_Sorting(object sender, GridViewSortEventArgs e)
        {
            LoadGrid(e.SortExpression);

        }

        protected void gv_users_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gv_users_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gv_users_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void gv_users_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void delete(object sender, EventArgs e)
        {

        }

    }
}