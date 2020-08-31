using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Examination_System
{
    public partial class registration : System.Web.UI.Page
    {

        public OES_BAL.User User { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsError { get; set; }
        public String ErrorMessage { get; set; }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoad();
        }

       
        protected void Register(object sender, EventArgs e)
        {
            Add();
        }


        private void Update()
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
                    var address = "Abc Road";
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
                    u.EditedBy = User.FirstName + " " + User.LastName;

                    u.Update();
                }
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
                    var address = "Abc Road";
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
        }

        private void LockControls()
        {


             TextBox[] textboxes = { txt_confirmpassword,txt_contact,txt_email,txt_firstname,txt_lastname,txt_password,txt_username};
             Button[] buttons = {btn_register };
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

    }
}