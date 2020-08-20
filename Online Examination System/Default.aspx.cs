using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OES_BAL;

namespace Online_Examination_System
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OES_BAL.User u = new User();
            u.ID = 1;
            u.UserName = "hello";
            u.FirstName = "a";
            u.LastName = "b";
            u.Contact = "dasd";
            u.Address = "dsfdsafasd";
            u.Email = "sdasdsa";
            u.Gender = "m";
            u.CreatedBy = "fdasd";
            u.EditeBy = "asda";
            u.CreateWhen = DateTime.Now;
            u.EditedWhen = DateTime.Now;
            u.ADD();


        }
    }
}