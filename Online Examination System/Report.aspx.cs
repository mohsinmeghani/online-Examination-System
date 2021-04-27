using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace Online_Examination_System
{
    public partial class Report : System.Web.UI.Page
    {

        public DataTable dt { get; set; }
        public String ReportName { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                SetReport();
                LoadReport();
            }
        }

        
        private void SetReport()
        {
            var rptname = Request.QueryString["rpt"];
            var rpt = new OES_BAL.Report();

            switch (rptname)
            {
                case "AnswerSheet":
                    ReportName = "AnswerSheet";
                    dt = rpt.GetAnswerSheet(1);
                    break;
                case "StudentCard":
                    ReportName = "StudentCard";
                    dt = rpt.GetStudentCard(5);
                    //dt.TableName = "StudentCard";
                    break;
            }
        }


        private void LoadReport()
        {
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/"+ReportName+".rdlc");
            ReportDataSource ds = new ReportDataSource("RptDataSet", dt);
            ReportViewer1.LocalReport.DataSources.Add(ds);
           
        }
    }
}