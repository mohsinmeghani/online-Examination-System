using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Examination_System
{
    public partial class Program_Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Add a method to populate Program Drop Down list on form load. 
        }

        protected void Register(object sender, EventArgs e)
        {

        }
        private void LoadGrid()
        {
            OES_BAL.User u = new OES_BAL.User();
            var users = u.GetAll();
            gv_items.DataSource = users.Select(x => new { x.ID, x.FirstName, x.LastName, x.UserName }).ToList();
            gv_items.DataBind();
        }
    }
}