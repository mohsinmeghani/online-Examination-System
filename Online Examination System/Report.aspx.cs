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
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadReport();
            }
        }


        private void LoadReport()
        {
            var exam = new OES_BAL.Exam(1);
            var list =exam.GetQuestions();
            var dt = new DataTable();

            dt.Columns.Add("QuestionText");
            dt.Columns.Add("Answer");
            dt.Columns.Add("Course");

          //  dt.TableName = "AnswerSheet";

            foreach (var q in list)
            {
                var dr = dt.NewRow();
                dr["QuestionText"] = q.QuestionText;
                dr["Answer"] = q.Answer;
                dr["Course"] = q.Course.Name;

                dt.Rows.Add(dr);
            }

            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Report1.rdlc");
            ReportDataSource ds = new ReportDataSource("RptDataSet", dt);
            ReportViewer1.LocalReport.DataSources.Add(ds);
           


        }
    }
}