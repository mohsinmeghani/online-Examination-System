using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Examination_System
{
    public partial class registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register(object sender, EventArgs e)
        {
            RegisterUser();
        }


        private void RegisterUser()
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

                    u.ADD();
                }
            }
            catch(Exception ex)
            {
             // erroB
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
                validator_username.ErrorMessage = "UserName Exist";
               return false;
            }
            else
            {
                return true;
            }
           
        }
    }
}