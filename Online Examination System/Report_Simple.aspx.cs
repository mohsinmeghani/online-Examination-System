using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Online_Examination_System
{
    public partial class Report_Simple : System.Web.UI.Page
    {
        public String Title { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadReport();
            }
        }



        private void LoadReport()
        {
            var rpt = Request.QueryString["rpt"];
            var obj = new OES_BAL.Report();
            var dt = new DataTable();
            switch(rpt)
            {
                case "IndivisualScore":
                    var cid = Request.QueryString["cid"];
                    dt = obj.GetIndivisualScore(Convert.ToInt32(cid));
                    Title = "Indivisual Score - Question Wise";
                    break;
                case "StudentCard":
                    var stdid = Request.QueryString["stdid"];
                    dt = obj.GetStudentCard(Convert.ToInt32(stdid));
                    Title = "Student Card Report";
                    break;
                case "DiffAndDisc":
                    var course_id = Request.QueryString["cid"];
                    dt = obj.GetDiffandDisc(Convert.ToInt32( course_id));
                    Title = "Difficulty and Discrimination";
                    break;

            }

            LoadMasterTable(obj.MasterTable);
            LoadDetailTable(dt);
           
        }


        private void LoadMasterTable(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                HtmlTableRow tr = new HtmlTableRow();
                for (int b = 0; b < dt.Columns.Count; b++)
                {
                    var tag = b == 0 ? "th" : "td";
                    HtmlTableCell td = new HtmlTableCell(tag);
                    td.InnerText = dt.Rows[i][b].ToString();
                    tr.Cells.Add(td);
                }

                table_master.Rows.Add(tr);
                
            }
            
        }


        private void LoadDetailTable(DataTable dt)
        {
            //Load Columns 
            HtmlTableRow tr = new HtmlTableRow();
            for (int i = 0; i < dt.Columns.Count; i++)
            {

                HtmlTableCell td = new HtmlTableCell("th");
                td.InnerText = dt.Columns[i].ColumnName;
                tr.Cells.Add(td);
                 //= "font-weight: bold";
            }
            table_detail.Rows.Add(tr);

            //Load Rows

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HtmlTableRow tr1 = new HtmlTableRow();
                for (int b = 0; b < dt.Columns.Count; b++)
                {
                    var tag = dt.Rows[i][0].ToString() == "Sum" ?"th" : "td";
                    HtmlTableCell td = new HtmlTableCell(tag);
                    if (tag == "th" && b == 0)
                    {
                        td.Style.Add("text-align","right");
                        td.BgColor = "yellow";
                        td.ColSpan = 3;
                        b = b + 2;
                    }
                    
                        td.InnerText = dt.Rows[i][b].ToString();
                        tr1.Cells.Add(td);
                    
                }

                table_detail.Rows.Add(tr1);
            }

        }
    }
}